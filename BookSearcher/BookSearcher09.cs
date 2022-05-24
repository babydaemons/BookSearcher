﻿namespace BookSearcher
{
    internal class BookSearcher09 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo author = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.Author);

        public BookSearcher09() : base()
        {
        }

        public override void Search()
        {
            SearchPartial2(author, bookTitle);
        }
    }
}
