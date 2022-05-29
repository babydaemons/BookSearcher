using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BookSearcherApp
{
    public abstract class AbstractSearcher_Type1_CompleteBeginng : AbstractSearcher2
    {
        protected AbstractSearcher_Type1_CompleteBeginng() : base()
        {
        }

        protected TimeSpan Search(ColumnInfo columnInfo1, ColumnInfo columnInfo2)
        {
            StopWatch = Stopwatch.StartNew();
            var bookValues = CreateColumnList(BookCSV.MemoryTable, columnInfo1, columnInfo2, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.MemoryTable, columnInfo1, columnInfo2, false);
            var results = from bookRow in bookValues
                          join scrapingRow in scrapingValues.AsParallel()
                          on new { bookRow.Value.Value1, bookRow.Value.Value2 } equals new { scrapingRow.Value.Value1, scrapingRow.Value.Value2 }
                          select new RowIndexPair { BookRowIndex = bookRow.Key, ScrapingRowIndex = scrapingRow.Key };
            SaveTable(new List<RowIndexPair>(results));
            StopWatch.Stop();
            return StopWatch.Elapsed;
        }
    }
}
