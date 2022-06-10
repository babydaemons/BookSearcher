using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;

namespace BookSearcherApp
{
    public class BookSearcher09 : AbstractSearcher2
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo author = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.Author);

        public BookSearcher09() : base()
        {
        }

        public override void Search()
        {
            Search(bookTitle, author);
        }

        private void Search(ColumnInfo columnPartial1, ColumnInfo columnPartial2)
        {
            resultRows = new ConcurrentBag<RowIndexPair>();
            var bookValues = CreateColumnList(BookCSV.Table, columnPartial1, columnPartial2, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.Table, columnPartial1, columnPartial2, false);

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
                    if (IsPartialMatch2(bookValue1, bookValue2, scrapingValue1, scrapingValue2))
                    {
                        resultRows.Add(new RowIndexPair { BookRowIndex = i, ScrapingRowIndex = j });
                    }
                });
            });
            SaveTable(resultRows.ToList());
        }

        private static bool IsPartialMatch2(string value1a, string value1b, string value2a, string value2b)
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

            if (!value2a.Contains(value1a))
            {
                return false;
            }

            if (!value2b.Contains(value1b))
            {
                return false;
            }

            return true;
        }
    }
}
