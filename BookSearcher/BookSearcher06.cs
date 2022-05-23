namespace BookSearcher
{
    internal class BookSearcher06 : BookSearcher
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.PartialMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo publisher = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Publisher);

        public BookSearcher06() : base()
        {
        }

        public override void Search()
        {
            SearchPartial1(bookTitle, publisher);
        }
    }
}
