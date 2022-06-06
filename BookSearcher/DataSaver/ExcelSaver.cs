using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using ClosedXML.Excel;

namespace BookSearcherApp
{
    public class ExcelSaver
    {
        public const string FONT_NAME = "游ゴシック";
        public const int MAX_EXCEL_ROWS = 1000000; /* 1048576 */

        private readonly string path;
        private readonly BackgroundWorker worker;

        private static int N = 0;
        private static string sheetNameBase;

        public ExcelSaver(string path, BackgroundWorker worker = null)
        {
            this.path = path;
            this.worker = worker;
        }

        public static void Write(string path, List<DataTable> tables, BackgroundWorker backgroundWorker = null)
        {
            N = tables.Count;

            var n = 0;
            var exists = File.Exists(path);

            if (backgroundWorker != null) { backgroundWorker.ReportProgress((n + 1) * 5 / N); }

            using (var book = exists ? new XLWorkbook(path, XLEventTracking.Disabled) : new XLWorkbook(XLEventTracking.Disabled))
            {
                var sheets = new List<IXLWorksheet>();

                sheetNameBase = "照合結果_" + DateTime.Now.ToString("yyyyMMdd-HHmm");
                foreach (var table in tables)
                {
                    sheets.Add(Write(table, n, book, backgroundWorker));
                    ++n;
                }

                if (exists)
                {
                    book.Save();
                }
                else
                {
                    book.SaveAs(path);
                }
                if (backgroundWorker != null) { backgroundWorker.ReportProgress(100); }
            }
        }

        public static IXLWorksheet Write(DataTable table, int n, XLWorkbook book, BackgroundWorker backgroundWorker = null)
        {
            var suffix = N == 1 ? "" : $" ({n + 1})";
            var sheet = book.AddWorksheet(table, sheetNameBase + suffix);
            if (backgroundWorker != null) { backgroundWorker.ReportProgress((n + 1) * 35 / N); }

            sheet.Style.Font.FontName = FONT_NAME;
            if (backgroundWorker != null) { backgroundWorker.ReportProgress((n + 1) * 40 / N); }

            var ROWS1 = table.Rows.Count > 100 ? 100 : table.Rows.Count;
            sheet.Rows(1, ROWS1).AdjustToContents();
            if (backgroundWorker != null) { backgroundWorker.ReportProgress((n + 1) * 70 / N); }

            return sheet;
        }

        public void Save() => Write(path, BookSearcher.ResultTables, worker);
    }
}
