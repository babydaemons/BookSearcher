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
            var bookValues = CreateColumnList(BookCSV.MemoryTable, columnInfo, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.MemoryTable, columnInfo, false);
            var results = from bookRow in bookValues
                          join scrapingRow in scrapingValues.AsParallel()
                          on bookRow.Value.Value equals scrapingRow.Value.Value
                          select new RowIndexPair { BookRowIndex = bookRow.Key, ScrapingRowIndex = scrapingRow.Key };
            SaveTable(new List<RowIndexPair>(results));
        }

        private ConcurrentDictionary<int, Column1> CreateColumnList(MemoryTable table, ColumnInfo columnInfo, bool isBookDB)
        {
            var columnName = table.ColumnNames[isBookDB ? columnInfo.BookColumnIndex : columnInfo.ScrapingColumnIndex];
            var columnIndex = table.ColumnIndexes[columnName];
            var spaceMatch = columnInfo.SpaceMatch;

            var rows = table.Where(row => row.Value[columnIndex].Length > 0);
            var values = new ConcurrentDictionary<int, Column1>(Environment.ProcessorCount, table.Count);
            ConvertValue convertValue = spaceMatch == SpaceMatch.All ? ConvertNone : (ConvertValue)ConvertRemoveSpace;
            foreach (var row in rows)
            {
                _ = values.TryAdd(row.Key, new Column1 { Value = convertValue(row.Value[columnIndex]) });
            }
            return values;
        }

        struct Column1
        {
            public string Value;
        }
    }
}
