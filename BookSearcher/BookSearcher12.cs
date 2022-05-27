namespace BookSearcherApp
{
    internal class BookSearcher12 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.PartialMatch, SpaceMatch.Ignore, ColumnType.BookTitle, true);
        private readonly ColumnInfo author = new ColumnInfo(MatchType.PartialMatch, SpaceMatch.Ignore, ColumnType.Author, true);
        private readonly ColumnInfo complex = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Complex);

        public BookSearcher12() : base()
        {
        }

        public override void Search()
        {
            SearchComplex2(bookTitle, author, complex);
        }
    }
}
