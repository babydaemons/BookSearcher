namespace BookSearcher
{
    internal class BookSearcher13 : BookSearcher
    {
        public BookSearcher13(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var URL = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.URL);
            Search(URL, prefixLength);
        }
    }
}
