namespace BookSearcher
{
    internal class BookSearcher05 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.BeginningMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Publisher);

        public BookSearcher05() : base()
        {
        }

        public override void Search()
        {
            Search(bookTitle, publisher);
        }
    }
}
