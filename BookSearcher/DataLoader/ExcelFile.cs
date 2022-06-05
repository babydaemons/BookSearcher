using System.IO.MemoryMappedFiles;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;
using ClosedXML.Excel;

namespace BookSearcherApp
{
    internal class ExcelFile : CSVFile
    {
        MemoryMappedViewStream memoryMappedViewStream;
        XLWorkbook book;
        IXLWorksheet sheet;
        IXLTable table;

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
            backgoundworker.ReportProgress(0);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            ReadHeader();
            CountLines();
            DoReadAll();

            stopWatch.Stop();
            Debug.WriteLine($"{Path} - {stopWatch.Elapsed}");

            Loaded = true;

            table = null;
            sheet = null;
            book.Dispose();
            book = null;
            backgoundworker?.ReportProgress(95);
            memoryMappedViewStream.Dispose();
            memoryMappedViewStream = null;
            backgoundworker?.ReportProgress(100);
        }

        private void ReadHeader()
        {
            backgoundworker.ReportProgress(5);

            // http://nineworks2.blog.fc2.com/blog-entry-64.html
            memoryMappedViewStream = GetMemoryMappedViewStream();
            book = new XLWorkbook(memoryMappedViewStream, XLEventTracking.Disabled);
            backgoundworker.ReportProgress(60);

            sheet = book.Worksheet(1);
            // テーブル作成
            table = sheet.RangeUsed().AsTable();

            // フィールド名を取得
            ColumnCount = table.Fields.Count();
            Titles = new string[ColumnCount];
            foreach (var field in table.Fields)
            {
                Titles[field.Index] = field.Name;
            }
            Fields = new string[ColumnCount];
            var cells = table.DataRange.Rows(1, 1).Cells().ToArray();

            // データを行単位で取得
            foreach (var row in table.DataRange.Rows())
            {
                var fields = new string[ColumnCount];
                foreach (var j in Enumerable.Range(0, ColumnCount))
                {
                    fields[j] = row.Cell(j + 1).Value.ToString();
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
            rowCount = table.RowCount();
            AllocateTable(rowCount);
        }

        protected override void DoReadAll()
        {
            rowIndex = 0;

            // データを行単位で取得
            foreach (var row in table.DataRange.Rows())
            {
                var fields = new string[ColumnCount];
                foreach (var j in Enumerable.Range(0, ColumnCount))
                {
                    fields[j] = row.Cell(j + 1).Value.ToString();
                }
                AddTableRow(rowIndex++, fields, 60, 90);
            }
        }
    }
}
