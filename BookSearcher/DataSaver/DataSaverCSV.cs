using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookSearcherApp
{
    public abstract partial class DataSaver : DataIO
    {
        #region WriteCSV

        public void WriteCSV(DataTable table, bool includeAmazonHeader)
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
                        titles_JP.Add(QuoteValue(name_JP));
                    }

                    var amazonHeader = GetAmazonHeader(titles_JP.Count);
                    var titles_AZ = new List<string>();
                    foreach (var header in amazonHeader)
                    {
                        titles_AZ.Add(QuoteValue(header));
                    }
                    writer.WriteLine(string.Join(",", titles_AZ.ToArray()));
                    writer.WriteLine(string.Join(",", titles_JP.ToArray()));
                }

                var titles_EN = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    titles_EN.Add(QuoteValue(column.ColumnName));
                }
                writer.WriteLine(string.Join(",", titles_EN.ToArray()));

                var rowCount = table.Rows.Count;
                var columnCount = table.Columns.Count;
                ReportProgress(0);
                foreach (var i in Enumerable.Range(0, rowCount))
                {
                    var values = new List<string>();
                    foreach (var j in Enumerable.Range(0, columnCount))
                    {
                        values.Add(QuoteValue(table.Rows[i][j]));
                    }
                    writer.WriteLine(string.Join(",", values.ToArray()));
                    ReportProgress(MAX_VALUE * i / rowCount);
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

        public static string QuoteValue(Object value)
        {
            if (value != null && value.GetType() == typeof(DBNull))
            {
                return "";
            }
            if (string.IsNullOrEmpty((string)value))
            {
                return ""; 
            }
            var v = (string)value;
            return "\"" + v.Replace("\"", "\"\"") + "\"";
        }

        #endregion
    }
}
