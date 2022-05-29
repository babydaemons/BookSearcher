using System.Linq;
using BookSearcherApp;

namespace BookSearcherTest
{
    public class TestBookSearcher : Form1
    {
        protected const int ROW_COUNT = 100;

        protected CSVData CreateDataAsc(int count, string columnName, string valueFormat)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { string.Format(valueFormat, i) });
                rows.MemoryTable.TryAdd(i, row);
            });
            return rows;
        }

        protected CSVData CreateDataDesc(int count, string columnName, string valueFormat)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { string.Format(valueFormat, i) });
                rows.MemoryTable.TryAdd(count - i - 1, row);
            });
            return rows;
        }

        protected CSVData CreateDataAsc(int count, string columnName1, string columnName2, string valueFormat1, string valueFormat2)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName1, columnName2 });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { string.Format(valueFormat1, i), string.Format(valueFormat2, i) });
                rows.MemoryTable.TryAdd(i, row);
            });
            return rows;
        }

        protected CSVData CreateDataDesc(int count, string columnName1, string columnName2, string valueFormat1, string valueFormat2)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName1, columnName2 });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { string.Format(valueFormat1, i), string.Format(valueFormat2, i) });
                rows.MemoryTable.TryAdd(count - i - 1, row);
            });
            return rows;
        }

        protected CSVData CreateDataAsc(int count, string columnName1, string columnName2, string columnName3, string valueFormat1, string valueFormat2, string valueFormat3)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName1, columnName2, columnName3 });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { string.Format(valueFormat1, i), string.Format(valueFormat2, i), string.Format(valueFormat3, i) });
                rows.MemoryTable.TryAdd(i, row);
            });
            return rows;
        }

        protected CSVData CreateDataDesc(int count, string columnName1, string columnName2, string columnName3, string valueFormat1, string valueFormat2, string valueFormat3)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName1, columnName2, columnName3 });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { string.Format(valueFormat1, i), string.Format(valueFormat2, i), string.Format(valueFormat3, i) });
                rows.MemoryTable.TryAdd(count - i - 1, row);
            });
            return rows;
        }
    }
}
