using System;

namespace BookSearcherApp
{
    public class BookSearcher07 : AbstractSearcher_Type2_Partial21
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo author = new ColumnInfo(MatchType.PartialMatch, SpaceMatch.Ignore, ColumnType.Author);

        public BookSearcher07() : base()
        {
        }

        public override void Search() => Search(author, bookTitle);
    }
}
