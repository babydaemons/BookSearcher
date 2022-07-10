using System;

namespace BookSearcherApp
{
    public class BookSearcher01 : AbstractSearcher_Type1_CompleteBeginng
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);

        public BookSearcher01() : base()
        {
        }

        protected override void ExecuteSearch() => Search(year, bookTitle);
    }
}
