using System;

namespace BookSearcherApp
{
    public class BookSearcher05 : AbstractSearcher_Type1_CompleteBeginng
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.BeginningMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Publisher);

        public BookSearcher05() : base()
        {
        }

        protected override void ExecuteSearch() => SearchBeginning(publisher, bookTitle);
    }
}
