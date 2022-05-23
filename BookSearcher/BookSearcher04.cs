﻿namespace BookSearcher
{
    internal class BookSearcher04 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.Publisher);

        public BookSearcher04() : base()
        {
        }

        public override void Search()
        {
            Search(bookTitle, publisher);
        }
    }
}
