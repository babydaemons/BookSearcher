using System;
using System.Data;
using System.Linq;
using OfficeOpenXml;

namespace BookSearcherApp
{
    public abstract partial class DataSaver : FileIO
    {
        #region WriteExcel

        public const int MAX_EXCEL_ROWS = 1000000; /* 1048576 */

        public const string FONT_NAME = "游ゴシック";
        public const float FONT_SIZE = 11F;

        private ExcelPackage package = null;

        private static long M = 0;
        private static long m = 0;

        private static int P0 = 0;
        private static int P1 = 0;

        public void WriteExcel(DataTable table)
        {
            try
            {
                M = table.Rows.Count;

                P0 = 15 * DIV_VALUE;
                P1 = 75 * DIV_VALUE;

                ReportProgress(P0);

                var sheetName = "提出データ_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                var sheet = package.Workbook.Worksheets.Add(sheetName);
                sheet.Cells[1, 1].Style.Font.Name = FONT_NAME;
                sheet.Cells[1, 1].Style.Font.Size = FONT_SIZE;
                var styleId = sheet.Cells[1, 1].StyleID;

                Write(table, sheet, styleId);

                package.Save();
                ReportProgress(MAX_VALUE);
            }
            catch (Exception ex)
            {
                throw new MyException("Excelファイル保存エラー", path, ex);
            }
            finally
            {
                Close();
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

        #endregion
    }
}
