using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearcherApp
{
    public abstract class AbstractSearcher2 : BookSearcher
    {
        protected AbstractSearcher2() : base()
        {
        }

        protected ConcurrentDictionary<int, Column2> CreateColumnList(MemoryTable table, ColumnInfo columnInfo1, ColumnInfo columnInfo2, bool isBookDB)
        {
            var columnName1 = table.ColumnNames[isBookDB ? columnInfo1.BookColumnIndex : columnInfo1.ScrapingColumnIndex];
            var columnName2 = table.ColumnNames[isBookDB ? columnInfo2.BookColumnIndex : columnInfo2.ScrapingColumnIndex];
            var columnIndex1 = table.ColumnIndexes[columnName1];
            var columnIndex2 = table.ColumnIndexes[columnName2];

            var rows = table.AsEnumerable().Where(row => row.Value[columnIndex1].Length > 0 && row.Value[columnIndex2].Length > 0);
            var values = new ConcurrentDictionary<int, Column2>(Environment.ProcessorCount, table.Count);
            ConvertValue convertValue1 = GetConvertValue(columnInfo1);
            ConvertValue convertValue2 = GetConvertValue(columnInfo2);
            foreach (var row in rows)
            {
                _ = values.TryAdd(
                    row.Key,
                    new Column2
                    {
                        Value1 = convertValue1(row.Value[columnIndex1]),
                        Value2 = convertValue2(row.Value[columnIndex2])
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
