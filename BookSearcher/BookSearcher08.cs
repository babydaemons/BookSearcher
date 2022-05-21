namespace BookSearcher
{
    internal class BookSearcher08 : BookSearcher
    {
        public BookSearcher08(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var bookTitle = new ColumnInfo(MatchType.BeginningMatch, spaceMatch, ColumnType.BookTitle);
            var author = new ColumnInfo(MatchType.PartialMatch, SpaceMatch.Ignore, ColumnType.Author);
            SearchPartial1(author, bookTitle);
        }
    }
}
