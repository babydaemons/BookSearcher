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

            using (var wb = exists ? new XLWorkbook(path, XLEventTracking.Disabled) : new XLWorkbook(XLEventTracking.Disabled))
            {
                var ws = wb.AddWorksheet(table, "照合結果_" + DateTime.Now.ToString("yyyyMMdd-HHmm"));
                if (backgroundWorker != null)
                {
                    backgroundWorker.ReportProgress(25);
                }

                ws.Style.Font.FontName = FontName;
                if (backgroundWorker != null)
                {
                    backgroundWorker.ReportProgress(50);
                }

                ws.Columns().AdjustToContents();
                if (backgroundWorker != null)
                {
                    backgroundWorker.ReportProgress(75);
                }

                if (exists)
                {
                    wb.Save();
                }
                else
                {
                    wb.SaveAs(path);
                }
                if (backgroundWorker != null)
                {
                    backgroundWorker.ReportProgress(100);
                }
            }
        }

        public void Save() => Write(path, BookSearcher.ResultTable, worker);
    }
}
