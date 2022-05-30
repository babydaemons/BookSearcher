using System;

namespace BookSearcherApp
{
    public class BookSearcher08 : AbstractSearcher_Type2_Partial21
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.BeginningMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo author = new ColumnInfo(MatchType.PartialMatch, SpaceMatch.Ignore, ColumnType.Author);

        public BookSearcher08() : base()
        {
        }

        public override void Search() => Search(bookTitle, author);
    }
}
