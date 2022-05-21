namespace BookSearcher
{
    internal class BookSearcher01 : BookSearcher
    {
        public BookSearcher01(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var bookTitle = new ColumnInfo(MatchType.CompleteMatch, spaceMatch, ColumnType.BookTitle);
            var year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);
            Search(bookTitle, year, prefixLength);
        }
    }
}
