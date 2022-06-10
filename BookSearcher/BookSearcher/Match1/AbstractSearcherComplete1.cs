using System;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;

namespace BookSearcherApp
{
    public abstract class AbstractSearcherComplete1 : BookSearcher
    {
        protected AbstractSearcherComplete1() : base()
        {
        }

        protected void Search(ColumnInfo columnInfo)
        {
            resultRows = new ConcurrentBag<RowIndexPair>();
            var bookValues = CreateColumnList(BookCSV.Table, columnInfo, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.Table, columnInfo, false);

            var result =
                from bookValue in bookValues
                join scrapingValue in scrapingValues.AsParallel()
                on bookValue.Key equals scrapingValue.Key
                select new RowIndexPair { BookRowIndex = bookValue.Value, ScrapingRowIndex = scrapingValue.Value };

            result.AsParallel().ForAll(row => resultRows.Add(row));

            SaveTable(result.ToList());
        }

        private ConcurrentDictionary<string, int> CreateColumnList(DataTable table, ColumnInfo columnInfo, bool isBookDB)
        {
            var columnIndex = isBookDB ? columnInfo.BookColumnIndex : columnInfo.ScrapingColumnIndex;
            var spaceMatch = columnInfo.SpaceMatch;

            var N = table.Rows.Count;
            var values = new ConcurrentDictionary<string, int>(Environment.ProcessorCount, N);
            ConvertValue convertValue = spaceMatch == SpaceMatch.All ? ConvertNone : (ConvertValue)ConvertRemoveSpace;
            foreach (var i in Enumerable.Range(0, N))
            {
                var value = (string)table.Rows[i][columnIndex];
                if (string.IsNullOrEmpty(value)) { continue; }
                _ = values.TryAdd(convertValue(value), i);
            }
            return values;
        }
    }
}
