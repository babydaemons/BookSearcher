using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BookSearcherApp
{
    public class ExcelFile : CSVFile
    {
        private List<CellInfo[]> table;

        public ExcelFile(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            return true;
        }

        public override void ReadAll(BackgroundWorker backgoundworker)
        {
            Loaded = false;
            this.backgoundworker = backgoundworker;
            backgoundworker?.ReportProgress(0);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            ReadHeader();
            CountLines();
            DoReadAll();

            stopWatch.Stop();
            Debug.WriteLine($"{Path} - {stopWatch.Elapsed}");

            Loaded = true;

            backgoundworker?.ReportProgress(100);
        }

        private void ReadHeader()
        {
            backgoundworker?.ReportProgress(5);

            var book = MyExcelBook.Open(Path);
            backgoundworker?.ReportProgress(10);

            book.SelectSheet(1);

            // テーブル作成
            table = book.GetAllCellValues();

            // フィールド名を取得
            ColumnCount = table[0].Length;
            Titles = new string[ColumnCount];
            foreach (var cell in table[0])
            {
                Titles[cell.Col - 1] = cell.Value;
            }
            Fields = new string[ColumnCount];

            // データを行単位で取得
            foreach (var row in table)
            {
                if (row[0].Row == 1)
                {
                    continue;
                }

                var fields = new string[ColumnCount];
                foreach (var j in Enumerable.Range(0, ColumnCount))
                {
                    fields[j] = row[j].Value;
                }
                bool isAllValid = fields.All(field => field.Length > 0);
                if (isAllValid)
                {
                    Fields = fields;
                    break;
                }
            }
        }

        protected override void CountLines()
        {
            rowCount = table.Count;
            AllocateTable(rowCount);
        }

        protected override void DoReadAll()
        {
            rowIndex = 0;

            // データを行単位で取得
            foreach (var row in table)
            {
                if (row[0].Row == 1)
                {
                    continue;
                }
                var fields = new string[ColumnCount];
                foreach (var j in Enumerable.Range(0, ColumnCount))
                {
                    fields[j] = row[j].Value;
                }
                AddTableRow(rowIndex++, fields, 60, 90);
            }
        }
    }
}
