namespace BookSearcher
{
    internal class BookSearcher15 : BookSearcher
    {
        public BookSearcher15(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var bookTitle = new ColumnInfo(MatchType.CompleteMatch, spaceMatch, ColumnType.BookTitle);
            Search(bookTitle, prefixLength);
        }
    }
}
