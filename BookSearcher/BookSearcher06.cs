namespace BookSearcher
{
    internal class BookSearcher06 : BookSearcher
    {
        public BookSearcher06(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var bookTitle = new ColumnInfo(MatchType.PartialMatch, spaceMatch, ColumnType.BookTitle);
            var publisher = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Publisher);
            SearchPartial1(bookTitle, publisher);
        }
    }
}
