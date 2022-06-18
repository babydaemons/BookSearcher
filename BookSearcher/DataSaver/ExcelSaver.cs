using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace BookSearcherApp
{
    public class ExcelSaver : FileIO
    {
        public const int MAX_EXCEL_ROWS = 1000000; /* 1048576 */
        
        public const string FONT_NAME = "游ゴシック";
        public const float FONT_SIZE= 11F;

        private int STYLE_ID = int.MinValue;

        private readonly string path;

        private static int N = 0;
        private static string sheetNameBase;

        private static int M = 0;
        private static int m = 0;

        private static int P0 = 0;
        private static int P1 = 0;

        public ExcelSaver(string path)
        {
            this.path = path;
        }

        public void Write(string path, List<DataTable> tables, BackgroundWorker backgroundWorker, FileIOProgressBar progressBar)
        {
            StartIO(backgroundWorker, progressBar);

            ReportProgress(2 * DIV_VALUE);
            
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

            P0 = (exists ? 5 : 10) * DIV_VALUE;
            P1 = (exists ? 65 : 85) * DIV_VALUE;

            var oldFile = exists ? new FileInfo(oldPath) : null;
            var newFile = new FileInfo(newPath);

            using (var package = exists ? new ExcelPackage(newFile, oldFile) : new ExcelPackage(newFile))
            {
                ReportProgress(P0);

                sheetNameBase = "照合結果_" + DateTime.Now.ToString("yyyyMMdd-HHmm");
                foreach (var table in tables)
                {
                    Write(table, n, package);
                    ++n;
                }

                package.Save();
                if (exists)
                {
                    File.Delete(oldPath);
                }

                ReportProgress(MAX_VALUE);
            }

            StopIO();
        }

        public void Write(DataTable table, int n, ExcelPackage package)
        {
            var suffix = N == 1 ? "" : $" ({n + 1})";
            var sheet = package.Workbook.Worksheets.Add(sheetNameBase + suffix);

            if (STYLE_ID == int.MinValue)
            {
                sheet.Cells[1, 1].Style.Font.Name = FONT_NAME;
                sheet.Cells[1, 1].Style.Font.Size = FONT_SIZE;
                STYLE_ID = sheet.Cells[1, 1].StyleID;
            }

            foreach (var j in Enumerable.Range(0, table.Columns.Count))
            {
                sheet.Cells[1, j + 1].Value = table.Columns[j].ColumnName;
                sheet.Cells[1, j + 1].StyleID = STYLE_ID;
            }

            foreach (var i in Enumerable.Range(0, table.Rows.Count))
            {
                foreach (var j in Enumerable.Range(0, table.Columns.Count))
                {
                    sheet.Cells[i + 2, j + 1].Value = table.Rows[i][j].ToString();
                    sheet.Cells[i + 2, j + 1].StyleID = STYLE_ID;
                }

                ++m;
                ReportProgress(P0 + (P1 - P0) * m / M);
            }
        }

        public void Save(BackgroundWorker backgroundWorker, FileIOProgressBar progressBar) => Write(path, BookSearcher.ResultTables, backgroundWorker, progressBar);
    }
}
