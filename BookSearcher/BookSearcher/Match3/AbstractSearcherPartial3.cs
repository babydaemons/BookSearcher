using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearcherApp
{
    public abstract class AbstractSearcherPartial3 : BookSearcher
    {
        protected ConcurrentDictionary<int, Column3> CreateColumnList(MemoryTable table, ColumnInfo columnInfo1, ColumnInfo columnInfo2, ColumnInfo columnInfo3, bool isBookDB)
        {
            var columnName1 = table.ColumnNames[isBookDB ? columnInfo1.BookColumnIndex : columnInfo1.ScrapingColumnIndex];
            var columnName2 = table.ColumnNames[isBookDB ? columnInfo2.BookColumnIndex : columnInfo2.ScrapingColumnIndex];
            var columnName3 = table.ColumnNames[isBookDB ? columnInfo3.BookColumnIndex : columnInfo3.ScrapingColumnIndex];
            var columnIndex1 = table.ColumnIndexes[columnName1];
            var columnIndex2 = table.ColumnIndexes[columnName2];
            var columnIndex3 = table.ColumnIndexes[columnName3];

            var rows = table.AsEnumerable().Where(row => row.Value[columnIndex1].Length > 0 && row.Value[columnIndex2].Length > 0 && row.Value[columnIndex3].Length > 0);
            var values = new ConcurrentDictionary<int, Column3>(Environment.ProcessorCount, table.Count);
            ConvertValue convertValue1 = GetConvertValue(columnInfo1);
            ConvertValue convertValue2 = GetConvertValue(columnInfo2);
            ConvertValue convertValue3 = GetConvertValue(columnInfo3);
            foreach (var row in rows)
            {
                _ = values.TryAdd(
                    row.Key,
                    new Column3
                    {
                        Value1 = convertValue1(row.Value[columnIndex1]),
                        Value2 = convertValue2(row.Value[columnIndex2]),
                        Value3 = convertValue3(row.Value[columnIndex3])
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
