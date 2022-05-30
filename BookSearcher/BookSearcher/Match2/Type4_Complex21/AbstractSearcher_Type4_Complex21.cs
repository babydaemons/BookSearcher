using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearcherApp
{
    public abstract class AbstractSearcher_Type4_Complex21 : AbstractSearcher2
    {
        protected void Search(ColumnInfo columnPartial1, ColumnInfo columnPartial2, ColumnInfo columnComplex3)
        {
            resultRows = new ConcurrentBag<RowIndexPair>();
            var bookValues = CreateBookColumnList(columnPartial1, columnPartial2);
            var scrapingValues = CreateScrapingColumnList(columnComplex3);

            var bookKeys = bookValues.Keys;
            var scrapingKeys = scrapingValues.Keys;

            bookKeys.AsParallel().ForAll(i =>
            {
                var bookRow = bookValues[i];
                var value1 = bookRow.Value1;
                var value2 = bookRow.Value2;

                scrapingKeys.AsParallel().ForAll(j =>
                {
                    var scrapingComplexValue = scrapingValues[j].Value1;
                    if (IsComplexMatch(value1, value2, scrapingComplexValue))
                    {
                        resultRows.Add(new RowIndexPair { BookRowIndex = i, ScrapingRowIndex = j });
                    }
                });
            });
            SaveTable(resultRows.ToList());
        }

        private static bool IsComplexMatch(string value1, string value2, string scrapingComplexValue)
        {
            var char1 = value1[0];
            var index1 = scrapingComplexValue.IndexOf(char1);
            if (index1 == -1)
            {
                return false;
            }

            var length1 = value1.Length;
            var left1 = scrapingComplexValue.Length - index1;
            if (left1 < length1)
            {
                return false;
            }

            var char2 = value2[0];
            var index2 = scrapingComplexValue.IndexOf(char2);
            if (index2 == -1)
            {
                return false;
            }

            var length2 = value2.Length;
            var left2 = scrapingComplexValue.Length - index2;
            if (left2 < length2)
            {
                return false;
            }

            if (!scrapingComplexValue.Contains(value1))
            {
                return false;
            }

            if (!scrapingComplexValue.Contains(value2))
            {
                return false;
            }

            return true;
        }

        private ConcurrentDictionary<int, Column2> CreateBookColumnList(ColumnInfo columnInfo1, ColumnInfo columnInfo2)
        {
            var table = BookCSV.MemoryTable;
            var columnName1 = table.ColumnNames[columnInfo1.BookColumnIndex];
            var columnName2 = table.ColumnNames[columnInfo2.BookColumnIndex];
            var columnIndex1 = table.ColumnIndexes[columnName1];
            var columnIndex2 = table.ColumnIndexes[columnName2];

            var rows = table.Where(row => row.Value[columnIndex1].Length > 0 && row.Value[columnIndex2].Length > 0);
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

        private ConcurrentDictionary<int, Column2> CreateScrapingColumnList(ColumnInfo columnInfo)
        {
            var table = ScrapingCSV.MemoryTable;
            var columnName = table.ColumnNames[columnInfo.ScrapingColumnIndex];
            var columnIndex = table.ColumnIndexes[columnName];

            var rows = table.Where(row => row.Value[columnIndex].Length > 0);
            var values = new ConcurrentDictionary<int, Column2>();
            ConvertValue convertValue = GetConvertValue(columnInfo);
            foreach (var row in rows)
            {
                _ = values.TryAdd(
                    row.Key,
                    new Column2
                    {
                        Value1 = convertValue(row.Value[columnIndex]),
                        Value2 = ""
                    });
            }
            return values;
        }

    }
}
