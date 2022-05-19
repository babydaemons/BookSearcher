using System.Collections.Generic;

namespace BookSearcher
{
    internal class BookSearcher15 : BookSearcher
    {
        public BookSearcher15(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(Dictionary<ColumnType, ColumnInfo> columnInfo)
        {
            Search(columnInfo, ColumnType.BookTitle);
        }
    }
}
