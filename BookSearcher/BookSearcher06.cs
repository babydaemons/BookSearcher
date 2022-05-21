using System.Collections.Generic;

namespace BookSearcher
{
    internal class BookSearcher06 : BookSearcher
    {
        public BookSearcher06(CSVFile bookCSV, CSVFile scrapingCSV, int prefixLength) : base(bookCSV, scrapingCSV, prefixLength)
        {
        }

        public override void Search(Dictionary<ColumnType, ColumnInfo> columnInfo)
        {
            SearchPartial1(columnInfo[ColumnType.BookTitle], columnInfo[ColumnType.Publisher]);
        }
    }
}
