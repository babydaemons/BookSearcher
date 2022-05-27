using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookSearcherApp
{
    public class MemoryRow
    {
        private readonly MemoryTable table;
        private string[] values;
        public int RowIndex { get; }

        public MemoryRow(MemoryTable table, int rowIndex, string[] values)
        {
            this.table = table;
            RowIndex = rowIndex;
            this.values = new string[table.ColumnCount];
            foreach (var i in Enumerable.Range(0, table.ColumnCount))
            {
                this.values[i] = i < values.Length ? values[i] : "";
            }
        }

        public string this[int columnIndex]
        {
            get { return values[columnIndex]; }
            set { values[columnIndex] = value; }
        }

        public DataRow WriteDataRow(DataRow row)
        {
            foreach (var i in Enumerable.Range(0, values.Length))
            {
                row[i] = values[i];
            }
            return row;
        }
    }
}
