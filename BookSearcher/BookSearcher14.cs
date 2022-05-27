namespace BookSearcherApp
{
    internal class BookSearcher14 : BookSearcher
    {
        private readonly ColumnInfo ISBN = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.ISBN);

        public BookSearcher14() : base()
        {
        }

        public override void Search()
        {
            Search(ISBN);
        }
    }
}
