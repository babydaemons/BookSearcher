namespace BookSearcher
{
    internal class BookSearcher17 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.BeginningMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.Year);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.Publisher);

        public BookSearcher17() : base()
        {
        }

        public override void Search()
        {
            SearchPartial32(bookTitle, year, publisher);
        }
    }
}
