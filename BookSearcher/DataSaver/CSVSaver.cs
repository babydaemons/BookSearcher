﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public abstract class CSVSaver : FileIO
    {
        #region CSVWriter

        private StreamWriter writer;
        protected string path;

        public CSVSaver(DataGridView view, string path)
        {
            this.path = path;

            CheckParameterEntered(view);
            foreach (var title in Titles)
            {
                dataTable.Columns.Add(title, typeof(string));
            }

            Open();
        }

        protected bool IsOpened()
        {
            return writer != null && writer.BaseStream != null && writer.BaseStream.CanWrite;
        }

        protected void Open()
        {
            if (IsOpened())
            {
                return;
            }

            try
            {
                writer = new StreamWriter(path);
            }
            catch (Exception ex)
            {
                Close();
                throw new MyException("CSVファイル保存エラー", path, ex);
            }
        }

        protected override void Close()
        {
            if (IsOpened())
            {
                writer.Close();
                writer.Dispose();
            }
            writer = null;

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
            try
            {
                var titles = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    titles.Add(QuoteValue(column.ColumnName));
                }
                writer.WriteLine(string.Join(",", titles.ToArray()));

                var rowCount = table.Rows.Count;
                var columnCount = table.Columns.Count;
                ReportProgress(0);
                foreach (var i in Enumerable.Range(0, rowCount))
                {
                    var values = new List<string>();
                    foreach (var j in Enumerable.Range(0, columnCount))
                    {
                        values.Add(QuoteValue(table.Rows[i][j]));
                    }
                    writer.WriteLine(string.Join(",", values.ToArray()));
                    ReportProgress(MAX_VALUE * i / rowCount);
                }
            }
            catch (Exception ex)
            {
                throw new MyException("CSVファイル保存エラー", path, ex);
            }
            finally
            {
                Close();
            }
        }

        public static string QuoteValue(Object value)
        {
            string v = (value.GetType() == typeof(DBNull)) ? "" : (string)value;
            return "\"" + v.Replace("\"", "\"\"") + "\"";
        }

        #endregion

        #region CSVSaver

        public abstract string[] Titles { get; }
        public int ColumnIndexSKU => 0;
        public abstract int ColumnIndexPrice { get; }
        public abstract int ColumnIndexISBN { get; }

        protected DataTable dataTable = new DataTable();
        public DataTable DataTable => dataTable;
        private readonly Dictionary<string, string> settings = new Dictionary<string, string>();

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

        public void Save(BackgroundWorker backgroundWorker, FileIOProgressBar progressBar)
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
 
        public static int CalcSellingPrice(int cost)
        {
            double selling_price = (cost + 88 + 110 + 330 + 550 + (cost * 0.15)) * IF(cost > 20000, 1.52, IF(cost > 10000, 1.49, IF(cost > 5000, 1.46, IF(cost > 3000, 1.43, IF(cost >= 1, 1.42, 0.00)))));
            return (int)(selling_price + 0.5);
        }

        private static double IF(bool condition, double then_value, double else_value)
        {
            return condition ? then_value : else_value;
        }

        #endregion
    }
}
