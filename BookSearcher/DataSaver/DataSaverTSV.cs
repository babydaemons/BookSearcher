using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookSearcherApp
{
    public abstract partial class DataSaver : DataIO
    {
        #region WriteTSV

        public void WriteTSV(DataTable table, int totalRows, bool includeAmazonHeader)
        {
            try
            {
                if (includeAmazonHeader)
                {
                    var titles_JP = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        var name_EN = column.ColumnName;
                        var name_JP = headers_JP[name_EN];
                        titles_JP.Add(ExtractValue(name_JP));
                    }

                    var amazonHeader = GetAmazonHeader(titles_JP.Count);
                    var titles_AZ = new List<string>();
                    foreach (var header in amazonHeader)
                    {
                        titles_AZ.Add(ExtractValue(header));
                    }
                    writer.WriteLine(string.Join("\t", titles_AZ.ToArray()));
                    writer.WriteLine(string.Join("\t", titles_JP.ToArray()));
                }

                var titles_EN = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    titles_EN.Add(ExtractValue(column.ColumnName));
                }
                writer.WriteLine(string.Join("\t", titles_EN.ToArray()));

                var rowCount = table.Rows.Count;
                var columnCount = table.Columns.Count;
                ReportProgress(0);
                foreach (var i in Enumerable.Range(0, rowCount))
                {
                    var values = new List<string>();
                    foreach (var j in Enumerable.Range(0, columnCount))
                    {
                        values.Add(ExtractValue(table.Rows[i][j]));
                    }
                    writer.WriteLine(string.Join("\t", values.ToArray()));
                    ReportProgress(MAX_VALUE * ++currentRow / totalRows);
                }
            }
            catch (Exception ex)
            {
                throw new MyException("CSVファイル保存エラー", path, ex);
            }
            finally
            {
                Close();
            }
        }

        public static string ExtractValue(Object value)
        {
            string v = (value.GetType() == typeof(DBNull)) ? "" : (string)value;
            return v;
        }

        #endregion
    }
}
