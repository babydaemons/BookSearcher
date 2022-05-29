using System;

namespace BookSearcherApp
{
    public class BookSearcher01 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);

        public BookSearcher01() : base()
        {
        }

        public override TimeSpan Search()
        {
            return Search(bookTitle, year);
        }
    }
}
