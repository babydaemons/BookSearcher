namespace BookSearcherApp
{
    internal class BookSearcher08 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.BeginningMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo author = new ColumnInfo(MatchType.PartialMatch, SpaceMatch.Ignore, ColumnType.Author);

        public BookSearcher08() : base()
        {
        }

        public override void Search()
        {
            SearchPartial1(author, bookTitle);
        }
    }
}
