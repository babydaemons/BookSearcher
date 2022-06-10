using System;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;

namespace BookSearcherApp
{
    public abstract class AbstractSearcherPartial3 : BookSearcher
    {
        protected ConcurrentDictionary<int, Column3> CreateColumnList(DataTable table, ColumnInfo columnInfo1, ColumnInfo columnInfo2, ColumnInfo columnInfo3, bool isBookDB)
        {
            var columnIndex1 = isBookDB ? columnInfo1.BookColumnIndex : columnInfo1.ScrapingColumnIndex;
            var columnIndex2 = isBookDB ? columnInfo2.BookColumnIndex : columnInfo2.ScrapingColumnIndex;
            var columnIndex3 = isBookDB ? columnInfo3.BookColumnIndex : columnInfo3.ScrapingColumnIndex;

            var N = table.Rows.Count;
            var values = new ConcurrentDictionary<int, Column3>(Environment.ProcessorCount, N);
            ConvertValue convertValue1 = GetConvertValue(columnInfo1);
            ConvertValue convertValue2 = GetConvertValue(columnInfo2);
            ConvertValue convertValue3 = GetConvertValue(columnInfo3);
            foreach (var i in Enumerable.Range(0, N))
            {
                var value1 = (string)table.Rows[i][columnIndex1];
                if (string.IsNullOrEmpty(value1)) { continue; }
                var value2 = (string)table.Rows[i][columnIndex2];
                if (string.IsNullOrEmpty(value2)) { continue; }
                var value3 = (string)table.Rows[i][columnIndex3];
                if (string.IsNullOrEmpty(value3)) { continue; }
                _ = values.TryAdd(
                    i,
                    new Column3
                    {
                        Value1 = convertValue1(value1),
                        Value2 = convertValue2(value2),
                        Value3 = convertValue3(value3)
                    });
            }
            return values;
        }

        protected struct Column3
        {
            public string Value1;
            public string Value2;
            public string Value3;
        }
    }
}
