using System;

namespace BookSearcherApp
{
    public class BookSearcher11 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.BookTitle);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.Publisher);
        private readonly ColumnInfo complex = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.Complex);

        public BookSearcher11() : base()
        {
        }

        public override TimeSpan Search()
        {
            return SearchComplex2(bookTitle, publisher, complex);
        }
    }
}
