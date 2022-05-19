using System.Collections.Generic;

namespace BookSearcher
{
    internal class BookSearcher14 : BookSearcher
    {
        public BookSearcher14(CSVFile bookCSV, CSVFile scrapingCSV) : base(bookCSV, scrapingCSV)
        {
        }

        public override void Search(Dictionary<ColumnType, ColumnInfo> columnInfo)
        {
            Search(columnInfo[ColumnType.ISBN]);
        }
    }
}
