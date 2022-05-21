namespace BookSearcher
{
    internal class BookSearcher07 : BookSearcher
    {
        public BookSearcher07(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var bookTitle = new ColumnInfo(MatchType.CompleteMatch, spaceMatch, ColumnType.BookTitle);
            var author = new ColumnInfo(MatchType.PartialMatch, SpaceMatch.Ignore, ColumnType.Author);
            SearchPartial1(author, bookTitle);
        }
    }
}
