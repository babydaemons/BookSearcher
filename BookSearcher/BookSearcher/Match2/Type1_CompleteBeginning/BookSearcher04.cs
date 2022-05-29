using System;

namespace BookSearcherApp
{
    public class BookSearcher04 : AbstractSearcher_Type1_CompleteBeginng
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.Publisher);

        public BookSearcher04() : base()
        {
        }

        public override TimeSpan Search()
        {
            return Search(bookTitle, publisher);
        }
    }
}
