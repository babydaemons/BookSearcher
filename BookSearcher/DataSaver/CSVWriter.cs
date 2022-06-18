using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;

namespace BookSearcherApp
{
    public class CSVWriter : FileIO
    {
        public void Write(string path, DataTable table)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                Write(writer, table);
            }
        }

        public void Write(Stream stream, DataTable table)
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                Write(writer, table);
            }
        }

        public void Write(StreamWriter writer, DataTable table)
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

        public static string QuoteValue(Object value)
        {
            string v = (value.GetType() == typeof(DBNull)) ? "" : (string)value;
            return "\"" + v.Replace("\"", "\"\"") + "\"";
        }
    }
}
