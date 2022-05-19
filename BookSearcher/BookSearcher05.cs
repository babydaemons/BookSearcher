using System.Collections.Generic;

namespace BookSearcher
{
    internal class BookSearcher05 : BookSearcher
    {
        public BookSearcher05(CSVFile bookCSV, CSVFile scrapingCSV, int prefixLength) : base(bookCSV, scrapingCSV, prefixLength)
        {
        }

        public override void Search(Dictionary<ColumnType, ColumnInfo> columnInfo)
        {
            Search(columnInfo[ColumnType.BookTitle], columnInfo[ColumnType.Publisher]);
        }
    }
}
