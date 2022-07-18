using System;
using System.Data;
using System.Linq;
using OfficeOpenXml;

namespace BookSearcherApp
{
    public abstract partial class DataSaver : DataIO
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

        public void WriteExcel(DataTable table, bool includeAmazonHeader)
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

                Write(table, sheet, styleId, includeAmazonHeader);

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

        public void Write(DataTable table, ExcelWorksheet sheet, int styleId, bool includeAmazonHeader)
        {
            var i = 1;

            if (includeAmazonHeader)
            {
                var headersAZ = GetAmazonHeader(table.Columns.Count);
                foreach (var j in Enumerable.Range(0, table.Columns.Count))
                {
                    sheet.Cells[i, j + 1].Value = headersAZ[j];
                    sheet.Cells[i, j + 1].StyleID = styleId;
                }
                ++i;

                foreach (var j in Enumerable.Range(0, table.Columns.Count))
                {
                    sheet.Cells[i, j + 1].Value = headers_JP[table.Columns[j].ColumnName];
                    sheet.Cells[i, j + 1].StyleID = styleId;
                }
                ++i;
            }

            foreach (var j in Enumerable.Range(0, table.Columns.Count))
            {
                sheet.Cells[i, j + 1].Value = table.Columns[j].ColumnName;
                sheet.Cells[i, j + 1].StyleID = styleId;
            }
            ++i;

            foreach (var n in Enumerable.Range(0, table.Rows.Count))
            {
                foreach (var j in Enumerable.Range(0, table.Columns.Count))
                {
                    sheet.Cells[n + i, j + 1].Value = table.Rows[n][j].ToString();
                    sheet.Cells[n + i, j + 1].StyleID = styleId;
                }

                ++m;
                int progress = (int)(P0 + (P1 - P0) * m / M);
                ReportProgress(progress);
            }
        }

        #endregion
    }
}
