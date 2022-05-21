using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BookSearcher
{
    public class MemoryTable : Dictionary<int, MemoryRow>
    {
        public string[] ColumnNames { get; }
        public int ColumnCount { get; }
        public DataTable DataTable => WriteDataTable();
        private readonly DataTable table = new DataTable();

        public MemoryTable(string[] columnNames, int capacity) : base(capacity)
        {
            ColumnNames = columnNames;
            ColumnCount = columnNames.Length;

            table.Columns.Add("RowIndex", typeof(int));

            foreach (var columName in ColumnNames)
            {
                try
                {
                    table.Columns.Add(columName, typeof(string));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Environment.Exit(1);
                }
            }
        }

        public void AddRow(int rowIndex, string[] values)
        {
            if (values.Length > ColumnCount)
            {
                return; // throw new Exception($"{rowIndex}行目の列数が不正です：${string.Join("/", values)}");
            }

            var row = new MemoryRow
            {
                RowIndex = rowIndex
            };
            for (int i = 0; i < ColumnCount; i++)
            {
                row[ColumnNames[i]] = i < values.Length ? values[i] : "";
            }

            Add(rowIndex, row);
        }

        private DataTable WriteDataTable()
        {
            foreach (var key in Keys)
            {
                var row = table.NewRow();
                table.Rows.Add(this[key].WriteDataRow(key, row));
            }
            return table;
        }
    }
}
