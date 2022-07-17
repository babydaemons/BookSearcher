using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookSearcherApp
{
    public abstract partial class DataSaver : DataIO
    {
        #region WriteTSV

        public void WriteTSV(DataTable table)
        {
            try
            {
                var titles = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    titles.Add(ExtractValue(column.ColumnName));
                }
                writer.WriteLine(string.Join("\t", titles.ToArray()));

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

        public static string ExtractValue(Object value)
        {
            string v = (value.GetType() == typeof(DBNull)) ? "" : (string)value;
            return v;
        }

        #endregion
    }
}
