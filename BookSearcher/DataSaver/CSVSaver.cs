using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public abstract class CSVSaver : CSVWriter
    {
        public abstract string[] Titles { get; }
        public int ColumnIndexSKU => 0;
        public abstract int ColumnIndexPrice { get; }
        public abstract int ColumnIndexISBN { get; }

        protected DataTable dataTable = new DataTable();
        public DataTable DataTable => dataTable;
        private readonly Dictionary<string, string> settings = new Dictionary<string, string>();
        private readonly string path;

        protected CSVSaver(DataGridView view, string path)
        {
            CheckParameterEntered(view);

            var settingName = (string)view.Tag;
            ParseSKUSuffix(settingName, settings["sku"]);

            foreach (var title in Titles)
            {
                dataTable.Columns.Add(title, typeof(string));
            }

            this.path = path;
        }

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

        private void ParseSKUSuffix(string settingName, string sku_input)
        {
            if (sku_input.Length == 0)
            {
                throw new MyException($"「{settingName}」入力エラー", $"「商品管理番号(真ん中2文字)／sku」が入力されていません。");
            }
            if (sku_input.Length != 2)
            {
                throw new MyException($"「{settingName}」入力エラー", $"「商品管理番号(真ん中2文字)／sku」の文字数が不正です：「{sku_input}」");
            }

            var sku_middle = sku_input.ToUpper();
            foreach (var i in Enumerable.Range(0, sku_middle.Length))
            {
                if (sku_middle[i] < 'A' || 'Z' < sku_middle[i])
                {
                    throw new MyException($"「{settingName}」入力エラー", $"商品管理番号(真ん中2文字)／sku」の{i + 1}文字目がアルファベットではありません：「{sku_input}」");
                }
            }
            settings["sku"] = sku_middle + DateTime.Now.ToString("yyMM");
        }

        public void Save(bool ISBNFromBook, bool CostFromBook, BackgroundWorker backgroundWorker, FileIOProgressBar progressBar)
        {
            ConvertTable();
            StartIO(backgroundWorker, progressBar);
            Write(ISBNFromBook, CostFromBook, path, dataTable);
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
                        var costString = ((string)resultTable.Rows[i][columnIndexCost]).Replace(",", "");
                        if (!int.TryParse(costString, out int cost))
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
    }
}
