using System;

namespace BookSearcherApp
{
    public class BookSearcher06 : AbstractSearcher_Type2_Partial21
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Publisher);

        public BookSearcher06() : base()
        {
        }

        protected override void ExecuteSearch() => Search(publisher, bookTitle);
    }
}
