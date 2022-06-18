using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using OfficeOpenXml;

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

        private static int M = 0;
        private static int m = 0;

        private static int P0 = 0;
        private static int P1 = 0;
        private static int P = 0;

        private static Font font = new Font(FONT_NAME, 11, FontStyle.Regular);

        public ExcelSaver(string path, BackgroundWorker worker = null)
        {
            this.path = path;
            this.worker = worker;
        }

        public static void Write(string path, List<DataTable> tables, BackgroundWorker backgroundWorker = null)
        {
            backgroundWorker?.ReportProgress(2);
            
            N = tables.Count;
            M = 0;
            foreach (var table in tables)
            {
                M += table.Rows.Count;
            }

            var n = 0;
            var exists = File.Exists(path);
            var oldPath = exists ? path.Replace(".xlsx", "-Copy.xlsx") : null;
            var newPath = path;
            if (exists)
            {
                File.Move(newPath, oldPath);
            }

            P0 = exists ? 5 : 10;
            P1 = exists ? 65 : 85;

            var oldFile = exists ? new FileInfo(oldPath) : null;
            var newFile = new FileInfo(newPath);

            using (var package = exists ? new ExcelPackage(newFile, oldFile) : new ExcelPackage(newFile))
            {
                backgroundWorker?.ReportProgress(P0);
                P =  P0;

                sheetNameBase = "照合結果_" + DateTime.Now.ToString("yyyyMMdd-HHmm");
                foreach (var table in tables)
                {
                    Write(table, n, package, backgroundWorker);
                    ++n;
                }

                package.Save();
                if (exists)
                {
                    File.Delete(oldPath);
                }

                backgroundWorker?.ReportProgress(100);
            }
        }

        public static void Write(DataTable table, int n, ExcelPackage package, BackgroundWorker backgroundWorker = null)
        {
            var suffix = N == 1 ? "" : $" ({n + 1})";
            var sheet = package.Workbook.Worksheets.Add(sheetNameBase + suffix);

            foreach (var j in Enumerable.Range(0, table.Columns.Count))
            {
                sheet.Cells[1, j + 1].Value = table.Columns[j].ColumnName;
            }

            foreach (var i in Enumerable.Range(0, table.Rows.Count))
            {
                foreach (var j in Enumerable.Range(0, table.Columns.Count))
                {
                    sheet.Cells[i + 2, j + 1].Value = table.Rows[i][j].ToString();
                }

                ++m;
                var progress = P0 + (P1 - P0) * m / M;
                if (progress > P)
                {
                    backgroundWorker?.ReportProgress(progress);
                    P = progress;
                }
            }

            using (var range = sheet.Cells[1, 1, table.Rows.Count + 1, table.Columns.Count])
            {
                range.Style.Font.SetFromFont(font);
            }
        }

        public void Save() => Write(path, BookSearcher.ResultTables, worker);
    }
}
