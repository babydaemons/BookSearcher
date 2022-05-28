using System.Linq;
using BookSearcherApp;

namespace BookSearcherTest
{
    public class TestBookSearcher : Form1
    {
        protected const int ROW_COUNT = 100;

        protected CSVData CreateDataAsc(string columnName, string valuePrefix, int count)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { $"{valuePrefix}{i:D8}" });
                rows.MemoryTable.TryAdd(i, row);
            });
            return rows;
        }

        protected CSVData CreateDataDesc(string columnName, string valuePrefix, int count)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { $"{valuePrefix}{i:D8}" });
                rows.MemoryTable.TryAdd(count - i - 1, row);
            });
            return rows;
        }
    }
}
