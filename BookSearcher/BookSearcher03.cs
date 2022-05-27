namespace BookSearcherApp
{
    internal class BookSearcher03 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);

        public BookSearcher03() : base()
        {
        }

        public override void Search()
        {
            SearchPartial1(bookTitle, year);
        }
    }
}
