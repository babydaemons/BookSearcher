using System;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public class MemoryTable : ConcurrentDictionary<int, MemoryRow>
    {
        public string[] ColumnNames { get; }
        public ConcurrentDictionary<string, int> ColumnIndexes { get; } = new ConcurrentDictionary<string, int>();
        public int ColumnCount { get; }
        public DataTable DataTable => WriteDataTable();
        private readonly DataTable table = new DataTable();

        public MemoryTable(string[] columnNames, int capacity) : base(Environment.ProcessorCount, capacity)
        {
            ColumnNames = columnNames;
            ColumnCount = columnNames.Length;

            foreach (var i in Enumerable.Range(0, ColumnNames.Length))
            {
                ColumnIndexes.TryAdd(columnNames[i], i);
            }

            foreach (var columName in ColumnNames)
            {
                table.Columns.Add(columName, typeof(string));
            }
        }

        public void AddRow(int rowIndex, string[] values)
        {
            if (values.Length > ColumnCount)
            {
                return; // throw new Exception($"{rowIndex}行目の列数が不正です：${string.Join("/", values)}");
            }

            var row = new MemoryRow(this, rowIndex, values);

            _ = TryAdd(rowIndex, row);
        }

        public void AddRow(string[] values)
        {
            AddRow(Count, values);
        }

        private DataTable WriteDataTable()
        {
            foreach (var key in Keys)
            {
                var row = table.NewRow();
                table.Rows.Add(this[key].WriteDataRow(row));
            }
            return table;
        }
    }
}
