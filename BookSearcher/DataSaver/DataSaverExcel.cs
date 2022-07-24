using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using OfficeOpenXml;

namespace BookSearcherApp
{
    public abstract partial class DataSaver : DataIO
    {
        #region WriteExcel

        public const string FONT_NAME = "游ゴシック";
        public const float FONT_SIZE = 11F;

        private ExcelPackage package = null;

        public void WriteExcel(DataTable table, int totalRows, bool includeAmazonHeader)
        {
            try
            {
                var sheetName = "提出データ_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                var sheet = package.Workbook.Worksheets.Add(sheetName);
                sheet.Cells[1, 1].Style.Font.Name = FONT_NAME;
                sheet.Cells[1, 1].Style.Font.Size = FONT_SIZE;
                var styleId = sheet.Cells[1, 1].StyleID;

                Write(table, totalRows, sheet, styleId, includeAmazonHeader);

                package.Save();
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

        public void Write(DataTable table, int totalRows, ExcelWorksheet sheet, int styleId, bool includeAmazonHeader)
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

                ReportProgress(MAX_VALUE * ++currentRow / totalRows);
            }
        }

        #endregion
    }
}
