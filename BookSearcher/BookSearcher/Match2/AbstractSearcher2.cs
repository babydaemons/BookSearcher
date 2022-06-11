using System;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;

namespace BookSearcherApp
{
    public abstract class AbstractSearcher2 : BookSearcher
    {
        protected AbstractSearcher2() : base()
        {
        }

        protected ConcurrentDictionary<int, Column2> CreateColumnList(DataTable table, ColumnInfo columnInfo1, ColumnInfo columnInfo2, bool isBookDB)
        {
            var columnIndex1 = isBookDB ? columnInfo1.BookColumnIndex : columnInfo1.ScrapingColumnIndex;
            var columnIndex2 = isBookDB ? columnInfo2.BookColumnIndex : columnInfo2.ScrapingColumnIndex;

            var N = table.Rows.Count;
            var values = new ConcurrentDictionary<int, Column2>(Form1.ProcessorCount, N);
            ConvertValue convertValue1 = GetConvertValue(columnInfo1);
            ConvertValue convertValue2 = GetConvertValue(columnInfo2);
            foreach (var i in Enumerable.Range(0, N))
            {
                var value1 = (string)table.Rows[i][columnIndex1];
                if (string.IsNullOrEmpty(value1)) { continue; }
                var value2 = (string)table.Rows[i][columnIndex2];
                if (string.IsNullOrEmpty(value2)) { continue; }
                _ = values.TryAdd(
                    i,
                    new Column2
                    {
                        Value1 = convertValue1(value1),
                        Value2 = convertValue2(value2)
                    });
            }
            return values;
        }

        protected struct Column2
        {
            public string Value1;
            public string Value2;
        }
    }
}
