using System.Collections.Generic;

namespace BookSearcher
{
    internal class BookSearcher04 : BookSearcher
    {
        public BookSearcher04(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(Dictionary<ColumnType, ColumnInfo> columnInfo)
        {
            Search(columnInfo[ColumnType.BookTitle], columnInfo[ColumnType.Publisher]);
        }
    }
}
