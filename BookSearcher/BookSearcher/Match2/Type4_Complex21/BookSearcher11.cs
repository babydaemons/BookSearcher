using System;

namespace BookSearcherApp
{
    public class BookSearcher11 : AbstractSearcher_Type4_Complex21
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.BookTitle);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.Publisher);
        private readonly ColumnInfo complex = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.Complex);

        public BookSearcher11() : base()
        {
        }

        public override void Search() => Search(bookTitle, publisher, complex);
    }
}
