namespace BookSearcher
{
    internal class BookSearcher03 : BookSearcher
    {
        public BookSearcher03(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(SpaceMatch spaceMatch, int prefixLength)
        {
            var bookTitle = new ColumnInfo(MatchType.PartialMatch, spaceMatch, ColumnType.BookTitle);
            var year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);
            SearchPartial1(bookTitle, year);
        }
    }
}
