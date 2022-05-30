using System;

namespace BookSearcherApp
{
    public class BookSearcher02 : AbstractSearcher_Type1_CompleteBeginng
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.BeginningMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);

        public BookSearcher02() : base()
        {
        }

        public override void Search() => Search(bookTitle, year);
    }
}
