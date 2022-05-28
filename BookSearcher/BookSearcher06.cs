using System;

namespace BookSearcherApp
{
    internal class BookSearcher06 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Publisher);

        public BookSearcher06() : base()
        {
        }

        public override TimeSpan Search()
        {
            return SearchPartial1(bookTitle, publisher);
        }
    }
}
