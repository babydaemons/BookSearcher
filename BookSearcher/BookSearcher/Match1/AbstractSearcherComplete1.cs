using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
            var bookValues = CreateColumnList(BookCSV.MemoryTable, columnInfo, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.MemoryTable, columnInfo, false);

            var result =
                from bookValue in bookValues
                join scrapingValue in scrapingValues.AsParallel()
                on bookValue.Key equals scrapingValue.Key
                select new RowIndexPair { BookRowIndex = bookValue.Value, ScrapingRowIndex = scrapingValue.Value };

            result.AsParallel().ForAll(row => resultRows.Add(row));

            SaveTable(result.ToList());
        }

        private ConcurrentDictionary<string, int> CreateColumnList(MemoryTable table, ColumnInfo columnInfo, bool isBookDB)
        {
            var columnName = table.ColumnNames[isBookDB ? columnInfo.BookColumnIndex : columnInfo.ScrapingColumnIndex];
            var columnIndex = table.ColumnIndexes[columnName];
            var spaceMatch = columnInfo.SpaceMatch;

            var rows = table.Where(row => row.Value[columnIndex].Length > 0);
            var values = new ConcurrentDictionary<string, int>(Environment.ProcessorCount, table.Count);
            ConvertValue convertValue = spaceMatch == SpaceMatch.All ? ConvertNone : (ConvertValue)ConvertRemoveSpace;
            rows.AsParallel().ForAll(row =>
            {
                _ = values.TryAdd(convertValue(row.Value[columnIndex]), row.Key);
            });
            return values;
        }
    }
}
