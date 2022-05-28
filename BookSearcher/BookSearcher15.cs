using System;

namespace BookSearcherApp
{
    internal class BookSearcher15 : BookSearcher
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
