namespace BookSearcherApp
{
    internal class BookSearcher02 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.BeginningMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);

        public BookSearcher02() : base()
        {
        }

        public override void Search()
        {
            Search(bookTitle, year);
        }
    }
}
