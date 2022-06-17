using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;

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

            using (var book = exists ? MyExcelBook.Open(path) : MyExcelBook.CreateBook(path))
            {
                sheetNameBase = "照合結果_" + DateTime.Now.ToString("yyyyMMdd-HHmm");
                foreach (var table in tables)
                {
                    Write(table, n, book, backgroundWorker);
                    ++n;
                }
                book.Save();

                if (backgroundWorker != null) { backgroundWorker.ReportProgress(100); }
            }
        }

        public static void Write(DataTable table, int n, MyExcelBook book, BackgroundWorker backgroundWorker = null)
        {
            var suffix = N == 1 ? "" : $" ({n + 1})";

            book.CreateSheet(sheetNameBase + suffix);
            var progress = 0;
            var currentProgress = (n + 1) * 10 / N;
            if (backgroundWorker != null && currentProgress > progress)
            {
                progress = currentProgress;
                backgroundWorker.ReportProgress(progress); 
            }

            uint rowIndex = 1;
            for (uint columnIndex  = 1; columnIndex <= table.Columns.Count; columnIndex++)
            {
                book.SetValue(rowIndex, columnIndex, table.Columns[(int)columnIndex - 1].ColumnName);
            }
            ++rowIndex;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (uint columnIndex = 1; columnIndex <= table.Columns.Count; columnIndex++)
                {
                    book.SetValue(rowIndex, columnIndex, table.Rows[i][(int)columnIndex - 1].ToString());
                }
                ++rowIndex;

                var currentProgress2 = ((n + 1) * 10 + 90 * i / table.Rows.Count) / N;
                if (backgroundWorker != null && currentProgress2 > progress)
                {
                    progress = currentProgress2;
                    backgroundWorker.ReportProgress(progress);
                }
            }
        }

        public void Save() => Write(path, BookSearcher.ResultTables, worker);
    }
}
