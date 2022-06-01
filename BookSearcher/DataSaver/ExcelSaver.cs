using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using ClosedXML.Excel;

namespace BookSearcherApp
{
    public class ExcelSaver
    {
        const string FontName = "游ゴシック";

        private readonly string path;
        private readonly BackgroundWorker worker;

        public ExcelSaver(string path, BackgroundWorker worker = null)
        {
            this.path = path;
            this.worker = worker;
        }

        public static void Write(string path, DataTable table, BackgroundWorker backgroundWorker = null)
        {
            var exists = File.Exists(path);

            var ROWS1 = table.Rows.Count > 100 ? 100 : table.Rows.Count;
            using (var book = exists ? new XLWorkbook(path, XLEventTracking.Disabled) : new XLWorkbook(XLEventTracking.Disabled))
            {
                if (backgroundWorker != null) { backgroundWorker.ReportProgress(5); }

                var sheet = book.AddWorksheet(table, "照合結果_" + DateTime.Now.ToString("yyyyMMdd-HHmm"));
                if (backgroundWorker != null) { backgroundWorker.ReportProgress(35); }

                sheet.Style.Font.FontName = FontName;
                if (backgroundWorker != null) { backgroundWorker.ReportProgress(40); }

                sheet.Rows(1,ROWS1).AdjustToContents();
                if (backgroundWorker != null) { backgroundWorker.ReportProgress(70); }

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

        public void Save() => Write(path, BookSearcher.ResultTable, worker);
    }
}
