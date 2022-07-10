using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;

namespace BookSearcherApp
{
    public class BookSearcher16 : AbstractSearcherPartial3
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.Year);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.Publisher);

        public BookSearcher16() : base()
        {
        }

        protected override void ExecuteSearch()
        {
            Search(bookTitle, year, publisher);
        }

        protected void Search(ColumnInfo columnPartial1, ColumnInfo columnPartial2, ColumnInfo columnPartial3)
        {
            resultRows = new ConcurrentBag<RowIndexPair>();
            var bookValues = CreateColumnList(BookCSV.Table, columnPartial1, columnPartial2, columnPartial3, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.Table, columnPartial1, columnPartial2, columnPartial3, false);

            var bookKeys = bookValues.Keys;
            var scrapingKeys = scrapingValues.Keys;

            bookKeys.AsParallel().ForAll(i =>
            {
                var bookValue1 = bookValues[i].Value1;
                var bookValue2 = bookValues[i].Value2;
                var bookValue3 = bookValues[i].Value3;
                scrapingKeys.AsParallel().ForAll(j =>
                {
                    var scrapingValue1 = scrapingValues[j].Value1;
                    var scrapingValue2 = scrapingValues[j].Value2;
                    var scrapingValue3 = scrapingValues[j].Value3;
                    if (IsPartialMatch33(bookValue1, bookValue2, bookValue3, scrapingValue1, scrapingValue2, scrapingValue3))
                    {
                        resultRows.Add(new RowIndexPair { BookRowIndex = i, ScrapingRowIndex = j });
                    }
                });
            });
            SaveTable(resultRows.ToList());
        }

        private static bool IsPartialMatch33(string value1a, string value1b, string value1c, string value2a, string value2b, string value2c)
        {
            var char1 = value1a[0];
            var index1 = value2a.IndexOf(char1);
            if (index1 == -1)
            {
                return false;
            }

            var length1 = value1a.Length;
            var left1 = value2a.Length - index1;
            if (left1 < length1)
            {
                return false;
            }

            var char2 = value1b[0];
            var index2 = value2b.IndexOf(char2);
            if (index2 == -1)
            {
                return false;
            }

            var length2 = value1b.Length;
            var left2 = value2b.Length - index2;
            if (left2 < length2)
            {
                return false;
            }

            var char3 = value1c[0];
            var index3 = value2c.IndexOf(char3);
            if (index3 == -1)
            {
                return false;
            }

            var length3 = value1c.Length;
            var left3 = value2c.Length - index3;
            if (left3 < length3)
            {
                return false;
            }

            if (!value2a.Contains(value1a))
            {
                return false;
            }

            if (!value2b.Contains(value1b))
            {
                return false;
            }

            if (!value2c.Contains(value1c))
            {
                return false;
            }

            return true;
        }
    }
}
