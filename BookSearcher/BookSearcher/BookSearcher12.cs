using System;

namespace BookSearcherApp
{
    public class BookSearcher12 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.BookTitle);
        private readonly ColumnInfo author = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.Author);
        private readonly ColumnInfo complex = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.Complex);

        public BookSearcher12() : base()
        {
        }

        public override TimeSpan Search()
        {
            return SearchComplex2(bookTitle, author, complex);
        }
    }
}
