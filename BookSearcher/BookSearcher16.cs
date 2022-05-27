namespace BookSearcherApp
{
    internal class BookSearcher16 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.Year);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.Publisher);

        public BookSearcher16() : base()
        {
        }

        public override void Search()
        {
            SearchPartial33(bookTitle, year, publisher);
        }
    }
}
