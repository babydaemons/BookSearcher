using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace BookSearcherApp
{
    public class CSVWriter : FileIO
    {
        private StreamWriter writer;
        protected string path;

        public CSVWriter(string path)
        {
            try
            {
                this.path = path;
                writer = new StreamWriter(path);
            }
            catch (Exception ex)
            {
                Close();
                throw new MyException("CSVファイル保存エラー", path, ex);
            }
        }

        ~CSVWriter()
        {
            Close();
        }

        protected override void Close()
        {
            if (writer != null)
            {
                writer.Close();
                writer.Dispose();
                writer = null;
            }
        }

        public void Write(DataTable table)
        {
            try
            {
                var titles = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    titles.Add(QuoteValue(column.ColumnName));
                }
                writer.WriteLine(string.Join(",", titles.ToArray()));

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
            string v = (value.GetType() == typeof(DBNull)) ? "" : (string)value;
            return "\"" + v.Replace("\"", "\"\"") + "\"";
        }
    }
}
