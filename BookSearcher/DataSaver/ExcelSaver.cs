using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using ClosedXML.Excel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.Util;
using System.Linq;

namespace BookSearcherApp
{
    public class ExcelSaver
    {
        public const string FONT_NAME = "游ゴシック";
        public const int MAX_EXCEL_ROWS = 1000000; /* 1048576 */

        private readonly string path;
        private readonly BackgroundWorker worker;

        private static int N = 0;
        private static int P0 = 0;
        private static int P1 = 0;
        private static int P2 = 0;
        private static string sheetNameBase;
        private static IFont font;

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
            if (exists)
            {
                var fileInfo = new FileInfo(path);
                using (var file = fileInfo.OpenRead())
                {
                    exists = file.Length > 0;
                }
            }

            P0 = exists ? 20 : 6;
            P2 = exists ? 60 : 80;
            P1 = P2 - P0;

            backgroundWorker?.ReportProgress((n + 1) * 5 / N);

            var book = exists ? WorkbookFactory.Create(path) : new XSSFWorkbook();
            font = book.CreateFont();
            font.FontHeightInPoints = 11;
            font.FontName = FONT_NAME;

            backgroundWorker?.ReportProgress((n + 1) * P0 / N);

            sheetNameBase = "照合結果_" + DateTime.Now.ToString("yyyyMMdd-HHmm");
            foreach (var table in tables)
            {
                Write(table, n, book, backgroundWorker);
                ++n;
            }

            backgroundWorker?.ReportProgress((n + 1) * P2 / N);
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                book.Write(stream);
            }
            
            backgroundWorker?.ReportProgress(100);
        }

        public static void Write(DataTable table, int n, IWorkbook book, BackgroundWorker backgroundWorker = null)
        {
            var suffix = N == 1 ? "" : $" ({n + 1})";
            var sheet = book.CreateSheet(sheetNameBase + suffix);
            var currentProgress = 0;

            var titles = sheet.CreateRow(0);
            foreach (var j in Enumerable.Range(0, table.Columns.Count))
            {
                var cell = titles.CreateCell(j);
                cell.SetCellValue(table.Columns[j].ColumnName);
                cell.CellStyle.SetFont(font);
            }

            foreach (var i in Enumerable.Range(0, table.Rows.Count))
            {
                var values = sheet.CreateRow(i + 1);
                foreach (var j in Enumerable.Range(0, table.Columns.Count))
                {
                    var cell = values.CreateCell(j);
                    cell.SetCellValue(table.Rows[i][j].ToString());
                    cell.CellStyle.SetFont(font);
                }

                var progress = (n + 1) * (P0 + P1 * i / table.Rows.Count) / N;
                if (progress > currentProgress)
                {
                    backgroundWorker?.ReportProgress(progress);
                    currentProgress = progress;
                }
            }
        }

        public void Save() => Write(path, BookSearcher.ResultTables, worker);
    }
}
