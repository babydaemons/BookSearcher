using System.Collections.Generic;

namespace BookSearcher
{
    internal class BookSearcher01 : BookSearcher
    {
        public BookSearcher01(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(Dictionary<ColumnType, ColumnInfo> columnInfo)
        {
            Search(columnInfo[ColumnType.BookTitle], columnInfo[ColumnType.Year]);
        }
    }
}
