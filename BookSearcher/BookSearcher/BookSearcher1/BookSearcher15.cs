using System;

namespace BookSearcherApp
{
    public class BookSearcher15 : BookSearcher1
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.BookTitle);

        public BookSearcher15() : base()
        {
        }

        public override TimeSpan Search()
        {
            return Search(bookTitle);
        }
    }
}
