using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace BookSearcherApp
{
    public abstract class AbstractSearcher_Type2_Partial21 : AbstractSearcher2
    {
        protected AbstractSearcher_Type2_Partial21() : base()
        {
        }

        protected void Search(ColumnInfo columnInfo1, ColumnInfo columnInfo2)
        {
            resultRows = new ConcurrentBag<RowIndexPair>();
            var bookValues = CreateColumnList(BookCSV.Table, columnInfo1, columnInfo2, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.Table, columnInfo1, columnInfo2, false);

            var bookKeys = bookValues.Keys;
            var scrapingKeys = scrapingValues.Keys;

            bookKeys.AsParallel().ForAll(i =>
            {
                var bookValue1 = bookValues[i].Value1;
                var bookValue2 = bookValues[i].Value2;
                scrapingKeys.AsParallel().ForAll(j =>
                {
                    var scrapingValue1 = scrapingValues[j].Value1;
                    var scrapingValue2 = scrapingValues[j].Value2;
                    if (bookValue1 == scrapingValue1 && scrapingValue2.Contains(bookValue2))
                    {
                        resultRows.Add(new RowIndexPair { BookRowIndex = i, ScrapingRowIndex = j });
                    }
                });
            });
            SaveTable(resultRows.ToList());
        }
    }
}
