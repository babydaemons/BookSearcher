using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace BookSearcherApp
{
    public abstract class AbstractSearcher_Type1_CompleteBeginng : AbstractSearcher2
    {
        protected AbstractSearcher_Type1_CompleteBeginng() : base()
        {
        }

        protected void Search(ColumnInfo columnInfo1, ColumnInfo columnInfo2)
        {
            resultRows = new ConcurrentBag<RowIndexPair>();
            var bookValues = CreateCopleteColumnList(BookCSV.MemoryTable, columnInfo1, columnInfo2, true);
            var scrapingValues = CreateCopleteColumnList(ScrapingCSV.MemoryTable, columnInfo1, columnInfo2, false);

            var result =
                from bookValue in bookValues
                join scrapingValue in scrapingValues.AsParallel()
                on bookValue.Key equals scrapingValue.Key
                select new RowIndexPair { BookRowIndex = bookValue.Value, ScrapingRowIndex = scrapingValue.Value };

            result.AsParallel().ForAll(row => resultRows.Add(row));

            SaveTable(result.ToList());
        }

        private ConcurrentDictionary<string, int> CreateCopleteColumnList(MemoryTable table, ColumnInfo columnInfo1, ColumnInfo columnInfo2, bool isBookDB)
        {
            var columnName1 = table.ColumnNames[isBookDB ? columnInfo1.BookColumnIndex : columnInfo1.ScrapingColumnIndex];
            var columnName2 = table.ColumnNames[isBookDB ? columnInfo2.BookColumnIndex : columnInfo2.ScrapingColumnIndex];
            var columnIndex1 = table.ColumnIndexes[columnName1];
            var columnIndex2 = table.ColumnIndexes[columnName2];

            var rows = table.AsEnumerable().Where(row => row.Value[columnIndex1].Length > 0 && row.Value[columnIndex2].Length > 0);
            var values = new ConcurrentDictionary<string, int>(Environment.ProcessorCount, table.Count);
            ConvertValue convertValue1 = GetConvertValue(columnInfo1);
            ConvertValue convertValue2 = GetConvertValue(columnInfo2);
            rows.AsParallel().ForAll(row =>
            {
                _ = values.TryAdd(convertValue1(row.Value[columnIndex1]) + "\a" + convertValue2(row.Value[columnIndex2]), row.Key);
            });
            return values;
        }
    }
}
