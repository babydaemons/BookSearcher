using System.Linq;
using BookSearcherApp;

namespace BookSearcherTest
{
    public class TestBookSearcher : Form1
    {
        protected const int ROW_COUNT = 100;

        protected CSVData CreateDataAsc(int count, string columnName, string valuePrefix, int paddingLength = 8)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName });
            rows.AllocateTable(count);
            var format = $"D{paddingLength}";
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { valuePrefix + i.ToString(format) });
                rows.MemoryTable.TryAdd(i, row);
            });
            return rows;
        }

        protected CSVData CreateDataDesc(int count, string columnName, string valuePrefix, int paddingLength = 8)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName });
            rows.AllocateTable(count);
            var format = $"D{paddingLength}";
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { valuePrefix + i.ToString(format) });
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
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { i.ToString(valueFormat1), i.ToString(valueFormat2) });
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
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { i.ToString(valueFormat1), i.ToString(valueFormat2) });
                rows.MemoryTable.TryAdd(count - i - 1, row);
            });
            return rows;
        }
    }
}
