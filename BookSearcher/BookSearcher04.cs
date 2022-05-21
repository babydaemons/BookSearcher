namespace BookSearcher
{
    internal class BookSearcher04 : BookSearcher
    {
        public BookSearcher04(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var bookTitle = new ColumnInfo(MatchType.CompleteMatch, spaceMatch, ColumnType.BookTitle);
            var publisher = new ColumnInfo(MatchType.CompleteMatch, spaceMatch, ColumnType.Publisher);
            Search(bookTitle, publisher, prefixLength);
        }
    }
}
