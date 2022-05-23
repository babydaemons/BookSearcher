namespace BookSearcher
{
    internal class BookSearcher13 : BookSearcher
    {
        private readonly ColumnInfo URL = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.URL);

        public BookSearcher13() : base()
        {
        }

        public override void Search()
        {
            Search(URL);
        }
    }
}
