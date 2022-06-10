using System.ComponentModel;
using System.Data;
using System.Linq;

namespace BookSearcherApp
{
    public abstract class CSVData
    {
        protected readonly DataTable dataTable = new DataTable();
        public DataTable Table => dataTable;
        public int RowCount => dataTable.Rows.Count;
        public int ColumnCount { get; protected set; }
        public string[] Titles { get; protected set; }
        public string[] Fields { get; protected set; }

        public void AllocateTable(int rows)
        {
            dataTable.Rows.Clear();
            foreach (var column in Titles)
            {
                dataTable.Columns.Add(column, typeof(string));
            }
        }

        public void SetTitles(string[] titles)
        {
            Titles = titles;
            ColumnCount = titles.Length;
        }
 
        public void AddRow(string[] fields)
        {
            var row = dataTable.NewRow();
            foreach (var i in Enumerable.Range(0, ColumnCount))
            {
                row[i] = i < fields.Length ? fields[i] : "";
            }
            dataTable.Rows.Add(row);
        }

        public abstract void ReadAll(BackgroundWorker backgoundworker);

        protected abstract void CountLines();
    }
}
