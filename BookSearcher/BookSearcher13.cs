using System.Collections.Generic;

namespace BookSearcher
{
    internal class BookSearcher13 : BookSearcher
    {
        public BookSearcher13(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(Dictionary<ColumnType, ColumnInfo> columnInfo)
        {
            Search(columnInfo[ColumnType.URL]);
        }
    }
}
