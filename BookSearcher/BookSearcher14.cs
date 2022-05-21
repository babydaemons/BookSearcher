namespace BookSearcher
{
    internal class BookSearcher14 : BookSearcher
    {
        public BookSearcher14(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var ISBN = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.ISBN);
            Search(ISBN, prefixLength);
        }
    }
}
