using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public enum DataType { CSV, TSV, Excel };

    public abstract partial class DataSaver : DataIO
    {
        #region DataSaver

        private FileStream file;
        private StreamWriter writer;
        protected string path;
        private readonly DataType dataType;

        public DataSaver(DataGridView view, string path)
        {
            this.path = path;

            CheckParameterEntered(view);
            foreach (var title in Titles)
            {
                dataTable.Columns.Add(title, typeof(string));
            }

            var extension = Path.GetExtension(path).ToLower();
            if (extension == ".csv")
            {
                dataType = DataType.CSV;
            }
            else if (extension == ".txt")
            {
                dataType = DataType.TSV;
            }
            else if (extension == ".xlsx")
            {
                dataType = DataType.Excel;
            }
            else
            {
                throw new MyException("出力ファイル種別エラー", $"不正なデータ種別です：{extension}");
            }
            Open();
        }

        protected bool IsOpened()
        {
            if (dataType == DataType.Excel)
            {
                return package != null && file != null && file.CanWrite;
            }
            if (file != null)
            {
                return writer != null && file != null && file.CanWrite;
            }
            else
            {
                return writer != null && writer.BaseStream != null && writer.BaseStream.CanWrite;
            }
        }

        protected void Open()
        {
            if (IsOpened())
            {
                return;
            }

            try
            {
                file = new FileStream(path, FileMode.Create, FileAccess.Write);
                writer = dataType != DataType.Excel ?　new StreamWriter(file, Encoding.GetEncoding(932), 8 * 4096) : null;
                package = dataType == DataType.Excel ? new ExcelPackage(file) : null;
            }
            catch (Exception ex)
            {
                Close();
                throw new MyException("出力ファイル保存エラー", path, ex);
            }
        }

        protected override void Close()
        {
            if (IsOpened())
            {
                if (dataType == DataType.Excel)
                {
                    if (package != null)
                    {
                        package.Dispose();
                        package = null;
                    }
                }
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
                if (file != null)
                {
                    file.Close();
                    file.Dispose();
                }
            }
            writer = null;
            file = null;

            try
            {
                var file = new FileInfo(path);
                if (file.Exists && file.Length == 0)
                {
                    file.Delete();
                }
            }
            catch (IOException)
            {
            }
        }

        public void Write(DataTable table)
        {
            if (dataType == DataType.CSV)
            {
                WriteCSV(table);
            }
            else if (dataType == DataType.TSV)
            {
                WriteTSV(table);
            }
            else if (dataType == DataType.Excel)
            {
                WriteExcel(table);
            }
        }

        #endregion

        #region CalcCost

        public abstract string[] Titles { get; }
        public int ColumnIndexSKU => 0;
        public abstract int ColumnIndexPrice { get; }
        public abstract int ColumnIndexISBN { get; }

        protected DataTable dataTable = new DataTable();
        public DataTable DataTable => dataTable;
        private readonly Dictionary<string, string> settings = new Dictionary<string, string>();

        private static readonly SortedDictionary<int, double> costTable = new SortedDictionary<int, double>();

        private void CheckParameterEntered(DataGridView view)
        {
            var settingName = (string)view.Tag;
            foreach (DataGridViewRow row in view.Rows)
            {
                DataGridViewCellCollection cells = row.Cells;

                var keyJP = (string)cells[0].Value;
                var keyEN = (string)cells[1].Value;
                var value = (string)cells[2].Value;
                if (string.IsNullOrEmpty(value))
                {
                    throw new MyException($"「{settingName}」入力エラー", $"「{keyJP}／{keyEN}」が入力されていません。");
                }

                settings.Add(keyEN, value);
            }
        }

        public void Save(BackgroundWorker backgroundWorker, DataIOProgressBar progressBar)
        {
            ConvertTable();
            StartIO(backgroundWorker, progressBar);
            Write(dataTable);
            StopIO();
        }

        public void ConvertTable() => ConvertTable(BookSearcher.ResultTables, BookSearcher.ColumnIndexISBN, BookSearcher.ColumnIndexCost);

        public void ConvertTable(List<DataTable> resultTables, int columnIndexISBN, int columnIndexCost)
        {
            foreach (var resultTable in resultTables)
            {
                foreach (var i in Enumerable.Range(0, resultTable.Rows.Count))
                {
                    var row = dataTable.NewRow();
                    foreach (var key in settings.Keys)
                    {
                        row[key] = settings[key];
                    }

                    if (ColumnIndexSKU >= 0)
                    {
                        row[ColumnIndexSKU] = (string)resultTable.Rows[i][columnIndexISBN] + settings["sku"];
                    }
                    if (ColumnIndexISBN >= 0)
                    {
                        row[ColumnIndexISBN] = (string)resultTable.Rows[i][columnIndexISBN];
                    }
                    if (ColumnIndexPrice >= 0)
                    {
                        var costString = (string)resultTable.Rows[i][columnIndexCost];
                        if (!int.TryParse(costString.Replace(",", "").Replace("円", ""), out int cost))
                        {
                            cost = 1; // throw new Exception($"原価のデータの書式が不正です：{i + 1}行{columnIndexCost + 1}列：「{costString}」");
                        }
                        var price = CalcSellingPrice(cost);
                        row[ColumnIndexPrice] = price.ToString();
                    }
                    dataTable.Rows.Add(row);
                }
            }
        }

        public static void InitCostTable(DataTable table)
        {
            costTable.Clear();
            foreach (DataRow row in table.Rows)
            {
                var costLower = int.Parse(row[0].ToString());
                var costRatio = double.Parse(row[1].ToString());
                costTable.Add(costLower, costRatio);
            }
        }

        public static int CalcSellingPrice(int cost)
        {
            var costRatio = 0.0;
            foreach (var costLimit in costTable.Reverse())
            {
                if (cost > costLimit.Key)
                {
                    costRatio = costLimit.Value;
                    break;
                }
            }

            // ＜出力CSVパターン２＞
            // ・販売価格の計算式の中で550円の部分を計算式から削除いただきたく。
            double sellingPrice = (cost + 88 + 110 + 330 + (cost * 0.15)) * costRatio;
            return (int)(sellingPrice + 0.5);
        }

        #endregion
    }
}
