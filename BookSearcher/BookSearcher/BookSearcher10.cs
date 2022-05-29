using System;

namespace BookSearcherApp
{
    public class BookSearcher10 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.Year);
        private readonly ColumnInfo complex = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.Complex);

        public BookSearcher10() : base()
        {
        }

        public override TimeSpan Search()
        {
            return SearchComplex2(bookTitle, year, complex);
        }
    }
}
