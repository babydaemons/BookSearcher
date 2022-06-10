using System;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;

namespace BookSearcherApp
{
    public abstract class AbstractSearcher_Type1_CompleteBeginng : AbstractSearcher2
    {
        protected AbstractSearcher_Type1_CompleteBeginng() : base()
        {
        }

        protected void Search(ColumnInfo columnInfo1, ColumnInfo columnInfo2)
        {
            resultRows = new ConcurrentBag<RowIndexPair>();
            var bookValues = CreateCopleteColumnList(BookCSV.Table, columnInfo1, columnInfo2, true);
            var scrapingValues = CreateCopleteColumnList(ScrapingCSV.Table, columnInfo1, columnInfo2, false);

            var result =
                from bookValue in bookValues
                join scrapingValue in scrapingValues.AsParallel()
                on bookValue.Key equals scrapingValue.Key
                select new RowIndexPair { BookRowIndex = bookValue.Value, ScrapingRowIndex = scrapingValue.Value };

            result.AsParallel().ForAll(row => resultRows.Add(row));

            SaveTable(result.ToList());
        }

        private ConcurrentDictionary<string, int> CreateCopleteColumnList(DataTable table, ColumnInfo columnInfo1, ColumnInfo columnInfo2, bool isBookDB)
        {
            var columnIndex1 = isBookDB ? columnInfo1.BookColumnIndex : columnInfo1.ScrapingColumnIndex;
            var columnIndex2 = table.Columns[isBookDB ? columnInfo2.BookColumnIndex : columnInfo2.ScrapingColumnIndex];

            var N = table.Rows.Count;
            var values = new ConcurrentDictionary<string, int>(Environment.ProcessorCount, N);
            ConvertValue convertValue1 = GetConvertValue(columnInfo1);
            ConvertValue convertValue2 = GetConvertValue(columnInfo2);
            foreach (var i in Enumerable.Range(0, N))
            {
                var value1 = (string)table.Rows[i][columnIndex1];
                if (string.IsNullOrEmpty(value1)) { continue; }
                var value2 = (string)table.Rows[i][columnIndex2];
                if (string.IsNullOrEmpty(value2)) { continue; }
                _ = values.TryAdd(convertValue1(value1) + "\a" + convertValue2(value2), i);
            }
            return values;
        }

        protected void SearchBeginning(ColumnInfo columnInfo1, ColumnInfo columnInfo2)
        {
            resultRows = new ConcurrentBag<RowIndexPair>();
            var bookValues = CreateBeginningColumnList(BookCSV.Table, columnInfo1, columnInfo2, true);
            var scrapingValues = CreateBeginningColumnList(ScrapingCSV.Table, columnInfo1, columnInfo2, false);

            var result =
                from bookValue in bookValues
                join scrapingValue in scrapingValues.AsParallel()
                on bookValue.Key equals scrapingValue.Key
                select new RowIndexPairList { BookRowIndexList = bookValue.Value, ScrapingRowIndexList = scrapingValue.Value };

            result.AsParallel().ForAll(row => {
                foreach (var bookRowIndex in row.BookRowIndexList)
                {
                    foreach (var scrapingRowIndex in row.ScrapingRowIndexList)
                    {
                        resultRows.Add(new RowIndexPair { BookRowIndex = bookRowIndex, ScrapingRowIndex = scrapingRowIndex });
                    }
                }
            });

            SaveTable(resultRows.ToList());
        }

        protected ConcurrentDictionary<string, ConcurrentBag<int>> CreateBeginningColumnList(DataTable table, ColumnInfo columnInfo1, ColumnInfo columnInfo2, bool isBookDB)
        {
            var columnIndex1 = isBookDB ? columnInfo1.BookColumnIndex : columnInfo1.ScrapingColumnIndex;
            var columnIndex2 = isBookDB ? columnInfo2.BookColumnIndex : columnInfo2.ScrapingColumnIndex;

            var N = table.Rows.Count;
            var values = new ConcurrentDictionary<string, ConcurrentBag<int>>(Environment.ProcessorCount, N);
            ConvertValue convertValue1 = GetConvertValue(columnInfo1);
            ConvertValue convertValue2 = GetConvertValue(columnInfo2);
            foreach (var i in Enumerable.Range(0, N))
            {
                DataRow row = table.Rows[i];
                var value1 = (string)row[columnIndex1];
                if (string.IsNullOrEmpty(value1)) { continue; }
                var value2 = (string)row[columnIndex2];
                if (string.IsNullOrEmpty(value2)) { continue; }

                var strKey = convertValue1(value1) + "\a" + convertValue2(value2);
                if (values.ContainsKey(strKey))
                {
                    values[strKey].Add(i);
                }
                else
                {
                    _ = values.TryAdd(strKey, new ConcurrentBag<int>(new int[] { i }));
                }
            }
            return values;
        }

        protected struct RowIndexPairList
        {
            public ConcurrentBag<int> BookRowIndexList;
            public ConcurrentBag<int> ScrapingRowIndexList;
        }
    }
}
