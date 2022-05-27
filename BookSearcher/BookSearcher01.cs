namespace BookSearcherApp
{
    internal class BookSearcher01 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);

        public BookSearcher01() : base()
        {
        }

        public override void Search()
        {
            Search(bookTitle, year);
        }
    }
}
