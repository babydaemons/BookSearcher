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

        protected CSVData CreateDataAsc(int count, string columnName1, string columnName2, string valuePrefix1, string valuePrefix2, int paddingLength1 = 8, int paddingLength2 = 8)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName1, columnName2 });
            rows.AllocateTable(count);
            var format1 = $"D{paddingLength1}";
            var format2 = $"D{paddingLength2}";
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { valuePrefix1 + i.ToString(format1), valuePrefix2 + i.ToString(format2) });
                rows.MemoryTable.TryAdd(i, row);
            });
            return rows;
        }

        protected CSVData CreateDataDesc(int count, string columnName1, string columnName2, string valuePrefix1, string valuePrefix2, int paddingLength1 = 8, int paddingLength2 = 8)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName1, columnName2 });
            rows.AllocateTable(count);
            var format1 = $"D{paddingLength1}";
            var format2 = $"D{paddingLength2}";
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { valuePrefix1 + i.ToString(format1), valuePrefix2 + i.ToString(format2) });
                rows.MemoryTable.TryAdd(count - i - 1, row);
            });
            return rows;
        }
    }
}
