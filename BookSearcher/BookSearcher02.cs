namespace BookSearcher
{
    internal class BookSearcher02 : BookSearcher
    {
        public BookSearcher02(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var bookTitle = new ColumnInfo(MatchType.BeginningMatch, spaceMatch, ColumnType.BookTitle);
            var year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);
            Search(bookTitle, year, prefixLength);
        }
    }
}
