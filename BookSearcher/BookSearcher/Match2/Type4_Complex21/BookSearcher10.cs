using System;

namespace BookSearcherApp
{
    public class BookSearcher10 : AbstractSearcher_Type4_Complex21
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.Year);
        private readonly ColumnInfo complex = new ColumnInfo(MatchType.ComplexMatch, SpaceMatch.Ignore, ColumnType.Complex);

        public BookSearcher10() : base()
        {
        }

        protected override void ExecuteSearch() => Search(bookTitle, year, complex);
    }
}
