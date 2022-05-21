namespace BookSearcher
{
    internal class BookSearcher05 : BookSearcher
    {
        public BookSearcher05(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var bookTitle = new ColumnInfo(MatchType.BeginningMatch, spaceMatch, ColumnType.BookTitle);
            var publisher = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Publisher);
            Search(bookTitle, publisher, prefixLength);
        }
    }
}
