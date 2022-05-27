namespace BookSearcherApp
{
    internal class BookSearcher07 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo author = new ColumnInfo(MatchType.PartialMatch, SpaceMatch.Ignore, ColumnType.Author);

        public BookSearcher07() : base()
        {
        }

        public override void Search()
        {
            SearchPartial1(author, bookTitle);
        }
    }
}
