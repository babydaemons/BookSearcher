using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;

namespace BookSearcherApp
{
    public class ExcelSaver : FileIO
    {
        public const int MAX_EXCEL_ROWS = 1000000; /* 1048576 */

        public const string FONT_NAME = "游ゴシック";
        public const float FONT_SIZE = 11F;

        private ExcelPackage package = null;
        private string newPath;
        private string oldPath;
        private FileStream newFile;
        private FileStream oldFile;
        private bool exists;

        private static int N = 0;

        private static long M = 0;
        private static long m = 0;

        private static int P0 = 0;
        private static int P1 = 0;

        public ExcelSaver(string path)
        {
            Open(path);
        }

        private void Open(string path)
        {
            exists = File.Exists(path);
            var oldSuffix = "-Copy$" + DateTime.Now.ToString("yyyyMMddHHmmssyyyyyy") + ".xlsx";
            oldPath = exists ? path.Replace(".xlsx", oldSuffix) : null;
            newPath = path;

            try
            {
                if (exists)
                {
                    File.Move(newPath, oldPath);
                }

                oldFile = exists ? new FileStream(oldPath, FileMode.Open, FileAccess.ReadWrite) : null;
                newFile = new FileStream(newPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                package = exists ? new ExcelPackage(newFile, oldFile) : new ExcelPackage(newFile);
            }
            catch (Exception ex)
            {
                Close();
                throw new MyException("Excelファイルオープンエラー", path, ex);
            }
        }

        ~ExcelSaver()
        {
            Close();
        }

        protected override void Close()
        {
            if (package != null)
            {
                package.Dispose();
                package = null;
            }
            if (newFile != null)
            {
                newFile.Close();
                newFile.Dispose();
                newFile = null;
            }
            if (oldFile != null)
            {
                oldFile.Close();
                oldFile.Dispose();
                oldFile = null;
            }
        }

        public void Write(List<DataTable> tables, BackgroundWorker backgroundWorker, FileIOProgressBar progressBar)
        {
            try
            {
                if (package == null)
                {
                    Open(newPath);
                }

                StartIO(backgroundWorker, progressBar);

                N = tables.Count;
                M = 0;
                foreach (var table in tables)
                {
                    M += table.Rows.Count;
                }

                P0 = (exists ? 10 : 15) * DIV_VALUE;
                P1 = (exists ? 60 : 75) * DIV_VALUE;

                ReportProgress(P0);

                var sheetNameBase = "照合結果_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
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
                    ExcelWorksheet sheet;
                    try
                    {
                        sheet = package.Workbook.Worksheets.Add(sheetNames[n]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"シート名が重複します。\n\n出力ファイル名：\n{newPath}\n\nシート名：{sheetNames[n]}", "出力Excelファイルエラー");
                        File.Move(oldPath, newPath);
                        return;
                    }
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
                ReportProgress(MAX_VALUE);
                StopIO();
            }
            catch (Exception ex)
            {
                throw new MyException("Excelファイルオープンエラー", newPath, ex);
            }
            finally
            {
                Close();
                if (exists)
                {
                    File.Delete(oldPath);
                }
            }
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

        public void Save(BackgroundWorker backgroundWorker, FileIOProgressBar progressBar) => Write(BookSearcher.ResultTables, backgroundWorker, progressBar);
    }
}
