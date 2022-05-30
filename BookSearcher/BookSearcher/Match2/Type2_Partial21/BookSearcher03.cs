using System;

namespace BookSearcherApp
{
    public class BookSearcher03 : AbstractSearcher_Type2_Partial21
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);

        public BookSearcher03() : base()
        {
        }

        public override void Search()
        {
            Search(bookTitle, year);
        }
    }
}
