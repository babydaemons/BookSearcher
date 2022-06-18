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

        private readonly string path;

        private static int N = 0;

        private static long M = 0;
        private static long m = 0;

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

            var exists = File.Exists(path);
            var oldPath = exists ? path.Replace(".xlsx", "-Copy.xlsx") : null;
            var newPath = path;
            if (exists)
            {
                File.Move(newPath, oldPath);
            }

            P0 = (exists ?  1 :  2) * DIV_VALUE;
            P1 = (exists ? 70 : 60) * DIV_VALUE;

            var oldFile = exists ? new FileInfo(oldPath) : null;
            var newFile = new FileInfo(newPath);

            using (var package = exists ? new ExcelPackage(newFile, oldFile) : new ExcelPackage(newFile))
            {
                ReportProgress(P0);

                var sheetNameBase = "照合結果_" + DateTime.Now.ToString("yyyyMMdd-HHmm");
                var sheetNames = new List<string>();
                foreach (var n in Enumerable.Range(0, N))
                {
                    var suffix = N == 1 ? "" : $" ({n + 1})";
                    sheetNames.Add(sheetNameBase + suffix);
                }

                var sheets = new List<ExcelWorksheet>();
                var styleIds = new List<int>();
                foreach (var n in Enumerable.Range(0, N))
                {
                    var sheet = package.Workbook.Worksheets.Add(sheetNames[n]);
                    sheet.Cells[1, 1].Style.Font.Name = FONT_NAME;
                    sheet.Cells[1, 1].Style.Font.Size = FONT_SIZE;
                    styleIds.Add(sheet.Cells[1, 1].StyleID);
                    sheets.Add(sheet);
                }

                foreach (var n in Enumerable.Range(0, N))
                {
                    var table = tables[n];
                    var sheet = sheets[n];
                    var styleId = styleIds[n];
                    Write(table, sheet, styleId);
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

        public void Write(DataTable table, ExcelWorksheet sheet, int styleId)
        {
            foreach (var j in Enumerable.Range(0, table.Columns.Count))
            {
                sheet.Cells[1, j + 1].Value = table.Columns[j].ColumnName;
                sheet.Cells[1, j + 1].StyleID = styleId;
            }

            foreach (var i in Enumerable.Range(0, table.Rows.Count))
            {
                foreach (var j in Enumerable.Range(0, table.Columns.Count))
                {
                    sheet.Cells[i + 2, j + 1].Value = table.Rows[i][j].ToString();
                    sheet.Cells[i + 2, j + 1].StyleID = styleId;
                }

                ++m;
                int progress = (int)(P0 + (P1 - P0) * m / M);
                ReportProgress(progress);
            }
        }

        public void Save(BackgroundWorker backgroundWorker, FileIOProgressBar progressBar) => Write(path, BookSearcher.ResultTables, backgroundWorker, progressBar);
    }
}
