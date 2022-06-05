using System.ComponentModel;
using System.Data;

namespace BookSearcherApp
{
    public abstract class CSVData
    {
        public MemoryTable MemoryTable { get; private set; }
        public DataTable Table => MemoryTable.DataTable;
        public int RowCount => MemoryTable.Count;
        public int ColumnCount { get; protected set; }
        public string[] Titles { get; protected set; }
        public string[] Fields { get; protected set; }

        public void AllocateTable(int rows)
        {
            MemoryTable = new MemoryTable(Titles, rows);
        }

        public void SetTitles(string[] titles)
        {
            Titles = titles;
            ColumnCount = titles.Length;
        }
 
        public void AddRow(string[] fields) => MemoryTable.AddRow(fields);

        public abstract void ReadAll(BackgroundWorker backgoundworker);

        protected abstract void CountLines();
    }
}
