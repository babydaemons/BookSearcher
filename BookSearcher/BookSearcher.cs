using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public enum ColumnIndex { Name, Value, Type };
    public enum ColumnType { None, BookTitle, Author, Publisher, Year, ISBN, URL, Price, Complex };
    public enum MatchType { CompleteMatch, BeginningMatch, PartialMatch };
    public enum SpaceMatch { All, Ignore };

    public struct ColumnInfo
    {
        public MatchType MatchType { get; }
        public SpaceMatch SpaceMatch { get; }
        public int BookColumnIndex { get; }
        public int ScrapingColumnIndex { get; }

        public ColumnInfo(MatchType matchType, SpaceMatch spaceMatch, ColumnType columnType, bool isComplexMatching = false)
        {
            MatchType = matchType;
            SpaceMatch = spaceMatch;
            BookColumnIndex = isComplexMatching ? -1 : BookSearcher.SelectBookColumnIndex(columnType);
            ScrapingColumnIndex = isComplexMatching ? -1 : BookSearcher.SelectScrapingColumnIndex(columnType);
        }
    }

    struct ValuePairPartial1
    {
        public string Value1;
        public string Value2;
        public static bool operator ==(ValuePairPartial1 a, ValuePairPartial1 b) => a.Value1 == b.Value1 && a.Value2.Contains(b.Value2);
        public static bool operator !=(ValuePairPartial1 a, ValuePairPartial1 b) => a.Value1 != b.Value1 || !b.Value2.Contains(a.Value2);
        public override bool Equals(object obj)
        {
            ValuePairPartial1 a = this;
            ValuePairPartial1 b = (ValuePairPartial1)obj;
            return a == b;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    struct ValuePairPartial32
    {
        public string Value1;
        public string Value2;
        public string Value3;
        public static bool operator ==(ValuePairPartial32 a, ValuePairPartial32 b) => a.Value1 == b.Value1 && a.Value2.Contains(b.Value2) && a.Value3.Contains(b.Value3);
        public static bool operator !=(ValuePairPartial32 a, ValuePairPartial32 b) => a.Value1 != b.Value1 || !b.Value2.Contains(a.Value2) || !b.Value3.Contains(a.Value3);
        public override bool Equals(object obj)
        {
            ValuePairPartial32 a = this;
            ValuePairPartial32 b = (ValuePairPartial32)obj;
            return a == b;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    struct ValuePairPartial33
    {
        public string Value1;
        public string Value2;
        public string Value3;
        public static bool operator ==(ValuePairPartial33 a, ValuePairPartial33 b) => a.Value1.Contains(b.Value1) && a.Value2.Contains(b.Value2) && a.Value3.Contains(b.Value3);
        public static bool operator !=(ValuePairPartial33 a, ValuePairPartial33 b) => !a.Value1.Contains(b.Value1) || !b.Value2.Contains(a.Value2) || !b.Value3.Contains(a.Value3);
        public override bool Equals(object obj)
        {
            ValuePairPartial33 a = this;
            ValuePairPartial33 b = (ValuePairPartial33)obj;
            return a == b;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    struct RowIndexPair
    {
        public int BookRowIndex;
        public int ScrapingRowIndex;
    }

    struct Column1
    {
        public string Value;
    }

    struct Column2
    {
        public string Value1;
        public string Value2;
    }

    struct Column3
    {
        public string Value1;
        public string Value2;
        public string Value3;
    }

    public abstract class BookSearcher
    {
        protected static CSVData BookCSV;
        protected static CSVData ScrapingCSV;
        protected static SpaceMatch SpaceMatch;
        protected static int PrefixLength;
        private static readonly string[] columnTypeNames = new string[] { "", "書籍名", "著者名", "出版社名", "出版年", "ISBN", "URL", "価格", "2種類の複合データ" };
        private static DataTable resultTable = new DataTable();
        public static DataTable ResultTable => resultTable;
        private delegate string ConvertValue(string value);
        private static DataGridView BookColumnSetting;
        private static DataGridView ScrapingColumnSetting;

        public static void InitColumnSettings(DataGridView bookColumnSetting, DataGridView scrapingColumnSetting)
        {
            BookColumnSetting = bookColumnSetting;
            ScrapingColumnSetting = scrapingColumnSetting;
        }

        public static int SelectBookColumnIndex(ColumnType columnType)
        {
            return SelectColumnIndex(BookColumnSetting, columnType);
        }

        public static int SelectScrapingColumnIndex(ColumnType columnType)
        {
            return SelectColumnIndex(ScrapingColumnSetting, columnType);
        }

        public static void InitSearchSettings(CSVData bookCSV, CSVData scrapingCSV, SpaceMatch spaceMatch, int prefixLength)
        {
            BookCSV = bookCSV;
            ScrapingCSV = scrapingCSV;
            SpaceMatch = spaceMatch;
            PrefixLength = prefixLength;
        }

        private static int SelectColumnIndex(DataGridView columnSetting, ColumnType columnType)
        {
            var columnTypeName = columnTypeNames[(int)columnType];
            for (int columnIndex = 0; columnIndex < columnSetting.RowCount; ++columnIndex)
            {
                var value = (string)columnSetting.Rows[columnIndex].Cells[(int)ColumnIndex.Type].Value;
                if (value == columnTypeName)
                {
                    return columnIndex;
                }
            }

            var tableName = (string)columnSetting.Tag;
            throw new Exception($"「{tableName}」の「{columnTypeName}」が選択されていません。");
        }

        protected BookSearcher()
        {
        }

        public abstract TimeSpan Search();

        protected TimeSpan Search(ColumnInfo columnInfo)
        {
            var stopwatch = Stopwatch.StartNew();
            var bookValues = CreateColumnList(BookCSV.MemoryTable, columnInfo, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.MemoryTable, columnInfo, false);
            var results = from bookRow in bookValues
                          join scrapingRow in scrapingValues.AsParallel()
                          on bookRow.Value.Value equals scrapingRow.Value.Value
                          select new RowIndexPair { BookRowIndex = bookRow.Key, ScrapingRowIndex = scrapingRow.Key };
            SaveTable(new List<RowIndexPair>(results));
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        protected TimeSpan Search(ColumnInfo columnInfo1, ColumnInfo columnInfo2)
        {
            var stopwatch = Stopwatch.StartNew();
            var bookValues = CreateColumnList(BookCSV.MemoryTable, columnInfo1, columnInfo2, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.MemoryTable, columnInfo1, columnInfo2, false);
            var results = from bookRow in bookValues
                          join scrapingRow in scrapingValues.AsParallel()
                          on new { bookRow.Value.Value1, bookRow.Value.Value2 } equals new { scrapingRow.Value.Value1, scrapingRow.Value.Value2 }
                          select new RowIndexPair { BookRowIndex = bookRow.Key, ScrapingRowIndex = scrapingRow.Key };
            SaveTable(new List<RowIndexPair>(results));
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        protected TimeSpan SearchPartial1(ColumnInfo columnPartial, ColumnInfo columnComplete)
        {
            var stopwatch = Stopwatch.StartNew();
            var bookValues = CreateColumnList(BookCSV.MemoryTable, columnPartial, columnComplete, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.MemoryTable, columnPartial, columnComplete, false);
            var results = from bookRow in bookValues
                          join scrapingRow in scrapingValues.AsParallel()
                          on new ValuePairPartial1 { Value1 = bookRow.Value.Value2, Value2 = bookRow.Value.Value1 }
                          equals new ValuePairPartial1 { Value1 = scrapingRow.Value.Value2, Value2 = scrapingRow.Value.Value1 }
                          select new RowIndexPair { BookRowIndex = bookRow.Key, ScrapingRowIndex = scrapingRow.Key };
            SaveTable(new List<RowIndexPair>(results));
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        protected TimeSpan SearchPartial2(ColumnInfo columnPartial1, ColumnInfo columnPartial2)
        {
            var stopwatch = Stopwatch.StartNew();
            var bookValues = CreateColumnList(BookCSV.MemoryTable, columnPartial1, columnPartial2, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.MemoryTable, columnPartial1, columnPartial2, false);
            var resultRows = new ConcurrentBag<RowIndexPair>();

            var bookKeys = bookValues.Keys;
            var scrapingKeys = scrapingValues.Keys;

            bookKeys.AsParallel().ForAll(i =>
            {
                var bookValue1 = bookValues[i].Value1;
                var bookValue2 = bookValues[i].Value2;
                scrapingKeys.AsParallel().ForAll(j =>
                {
                    var scrapingValue1 = scrapingValues[j].Value1;
                    var scrapingValue2 = scrapingValues[j].Value2;
                    if (IsPartialMatch2(bookValue1, bookValue2, scrapingValue1, scrapingValue2))
                    {
                        resultRows.Add(new RowIndexPair { BookRowIndex = i, ScrapingRowIndex = j });
                    }
                });
            });
            SaveTable(resultRows.ToList());
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        private static bool IsPartialMatch2(string value1a, string value1b, string value2a, string value2b)
        {
            var char1 = value1a[0];
            var index1 = value2a.IndexOf(char1);
            if (index1 == -1)
            {
                return false;
            }

            var length1 = value1a.Length;
            var left1 = value2a.Length - index1;
            if (left1 < length1)
            {
                return false;
            }

            var char2 = value1b[0];
            var index2 = value2b.IndexOf(char2);
            if (index2 == -1)
            {
                return false;
            }

            var length2 = value1b.Length;
            var left2 = value2b.Length - index2;
            if (left2 < length2)
            {
                return false;
            }

            if (!value2a.Contains(value1a))
            {
                return false;
            }

            if (!value2b.Contains(value1b))
            {
                return false;
            }

            return true;
        }


        protected TimeSpan SearchComplex2(ColumnInfo columnPartial1, ColumnInfo columnPartial2, ColumnInfo columnComplex3)
        {
            var stopwatch = Stopwatch.StartNew();
            var bookValues = CreateBookColumnList(columnPartial1, columnPartial2);
            var scrapingValues = CreateScrapingColumnList(columnComplex3);
            var resultRows = new ConcurrentBag<RowIndexPair>();

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
            stopwatch.Stop();
            return stopwatch.Elapsed;
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

        protected TimeSpan SearchPartial32(ColumnInfo columnPartial1, ColumnInfo columnPartial2, ColumnInfo columnPartial3)
        {
            var stopwatch = Stopwatch.StartNew();
            var bookValues = CreateColumnList(BookCSV.MemoryTable, columnPartial1, columnPartial2, columnPartial3, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.MemoryTable, columnPartial1, columnPartial2, columnPartial3, false);
            var results = from bookRow in bookValues
                          join scrapingRow in scrapingValues.AsParallel()
                          on new ValuePairPartial32 { Value1 = bookRow.Value.Value1, Value2 = bookRow.Value.Value2, Value3 = bookRow.Value.Value3 }
                          equals new ValuePairPartial32 { Value1 = scrapingRow.Value.Value1, Value2 = scrapingRow.Value.Value2, Value3 = scrapingRow.Value.Value3 }
                          select new RowIndexPair { BookRowIndex = bookRow.Key, ScrapingRowIndex = scrapingRow.Key };
            SaveTable(new List<RowIndexPair>(results));
            return stopwatch.Elapsed;
        }

        protected TimeSpan SearchPartial33(ColumnInfo columnPartial1, ColumnInfo columnPartial2, ColumnInfo columnPartial3)
        {
            var stopwatch = Stopwatch.StartNew();
            var bookValues = CreateColumnList(BookCSV.MemoryTable, columnPartial1, columnPartial2, columnPartial3, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.MemoryTable, columnPartial1, columnPartial2, columnPartial3, false);
            var results = from bookRow in bookValues
                          join scrapingRow in scrapingValues.AsParallel()
                          on new ValuePairPartial33 { Value1 = bookRow.Value.Value1, Value2 = bookRow.Value.Value2, Value3 = bookRow.Value.Value3 }
                          equals new ValuePairPartial33 { Value1 = scrapingRow.Value.Value1, Value2 = scrapingRow.Value.Value2, Value3 = scrapingRow.Value.Value3 }
                          select new RowIndexPair { BookRowIndex = bookRow.Key, ScrapingRowIndex = scrapingRow.Key };
            SaveTable(new List<RowIndexPair>(results));
            return stopwatch.Elapsed;
        }

        private ConcurrentDictionary<int, Column1> CreateColumnList(MemoryTable table, ColumnInfo columnInfo, bool isBookDB)
        {
            var columnName = table.ColumnNames[isBookDB ? columnInfo.BookColumnIndex : columnInfo.ScrapingColumnIndex];
            var columnIndex = table.ColumnIndexes[columnName];
            var spaceMatch = columnInfo.SpaceMatch;

            var rows = table.Where(row => row.Value[columnIndex].Length > 0);
            var values = new ConcurrentDictionary<int, Column1>(Environment.ProcessorCount, table.Count);
            ConvertValue convertValue = spaceMatch == SpaceMatch.All ? ConvertNone : (ConvertValue)ConvertRemoveSpace;
            foreach (var row in rows)
            {
                _ = values.TryAdd(row.Key, new Column1 { Value = convertValue(row.Value[columnIndex]) });
            }
            return values;
        }

        private ConcurrentDictionary<int, Column2> CreateColumnList(MemoryTable table, ColumnInfo columnInfo1, ColumnInfo columnInfo2, bool isBookDB)
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

        private ConcurrentDictionary<int, Column3> CreateColumnList(MemoryTable table, ColumnInfo columnInfo1, ColumnInfo columnInfo2, ColumnInfo columnInfo3, bool isBookDB)
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
            var values = new ConcurrentDictionary<int, Column2> ();
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

        private ConvertValue GetConvertValue(ColumnInfo columnInfo)
        {
            if (columnInfo.MatchType == MatchType.CompleteMatch && columnInfo.SpaceMatch == SpaceMatch.All)
            {
                return ConvertNone;
            }
            else if (columnInfo.MatchType == MatchType.CompleteMatch && columnInfo.SpaceMatch == SpaceMatch.Ignore)
            {
                return ConvertRemoveSpace;
            }
            else if (columnInfo.MatchType == MatchType.BeginningMatch && columnInfo.SpaceMatch == SpaceMatch.All)
            {
                return ConvertExtractPrefix;
            }
            else if (columnInfo.MatchType == MatchType.BeginningMatch && columnInfo.SpaceMatch == SpaceMatch.Ignore)
            {
                return ConvertRemoveSpaceExtractPrefix;
            }
            else if (columnInfo.MatchType == MatchType.PartialMatch)
            {
                return ConvertRemoveSpace;
            }
            else
            {
                throw new Exception("セル値の変換指定が不正です。");
            }
        }

        private void SaveTable(List<RowIndexPair> resultRows)
        {
            resultTable = new DataTable();
            foreach (var column in BookCSV.Titles)
            {
                resultTable.Columns.Add("データベースファイル\n" + column);
            }
            foreach (var column in ScrapingCSV.Titles)
            {
                resultTable.Columns.Add("スクレイピングデータファイル\n" + column);
            }

            foreach (var resultRow in resultRows)
            {
                var row = resultTable.NewRow();
                int i = 0;
                foreach (var columnIndex in Enumerable.Range(0, BookCSV.MemoryTable.ColumnCount))
                {
                    row[i++] = BookCSV.MemoryTable[resultRow.BookRowIndex][columnIndex];
                }
                foreach (var columnIndex in Enumerable.Range(0, ScrapingCSV.MemoryTable.ColumnCount))
                {
                    row[i++] = ScrapingCSV.MemoryTable[resultRow.ScrapingRowIndex][columnIndex];
                }
                resultTable.Rows.Add(row);
            }
        }

        private string ConvertNone(string value)
        {
            return value;
        }

        private string ConvertRemoveSpace(string value)
        {
            return value.Replace(" ", "").Replace("　", "");
        }

        private string ConvertExtractPrefix(string value)
        {
            return value.Length > PrefixLength ? value.Substring(0, PrefixLength) : value;
        }

        private string ConvertRemoveSpaceExtractPrefix(string value)
        {
            value = value.Replace(" ", "").Replace("　", "");
            return value.Length > PrefixLength ? value.Substring(0, PrefixLength) : value;
        }
    }
}
