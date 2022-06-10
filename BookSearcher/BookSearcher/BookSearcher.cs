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
    public enum MatchType { CompleteMatch, BeginningMatch, PartialMatch, ComplexMatch };
    public enum SpaceMatch { All, Ignore };

    public abstract class BookSearcher
    {
        protected static CSVData BookCSV;
        protected static CSVData ScrapingCSV;
        protected static SpaceMatch SpaceMatch;
        protected static int PrefixLength;
        private static readonly string[] columnTypeNames = new string[] { "", "書籍名", "著者名", "出版社名", "出版年", "ISBN", "URL", "価格", "複合データ" };
        private static readonly List<DataTable> resultTables = new List<DataTable>();
        public static List<DataTable> ResultTables => resultTables;
        protected delegate string ConvertValue(string value);
        private static DataGridView BookColumnSetting;
        private static DataGridView ScrapingColumnSetting;
        protected static ConcurrentBag<RowIndexPair> resultRows = new ConcurrentBag<RowIndexPair>();
        public static int ResultCount => resultRows.Count;
        public static int ColumnIndexISBN { get; private set; }
        public static int ColumnIndexCost { get; private set; }

        protected BookSearcher()
        {
            ColumnIndexISBN = SelectColumnIndex(BookColumnSetting, ColumnType.ISBN);
            ColumnIndexCost = SelectColumnIndex(BookColumnSetting, ColumnType.Price);
        }

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
            throw new MyException($"「{tableName}」入力エラー", $"「{columnTypeName}」が選択されていません。");
        }

        public abstract void Search();

        protected ConvertValue GetConvertValue(ColumnInfo columnInfo)
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
            else if (columnInfo.MatchType == MatchType.ComplexMatch)
            {
                return ConvertRemoveSpace;
            }
            else
            {
                throw new Exception("セル値の変換指定が不正です。");
            }
        }

        protected void SaveTable(List<RowIndexPair> resultRows)
        {
            resultTables.Clear();
            resultTables.Add(new DataTable());
            foreach (var column in BookCSV.Titles)
            {
                resultTables[0].Columns.Add("データベースファイル／" + column, typeof(string));
            }
            foreach (var column in ScrapingCSV.Titles)
            {
                resultTables[0].Columns.Add("スクレイピングデータファイル／" + column, typeof(string));
            }

            int k = 0;
            int n = 0;
            foreach (var resultRow in resultRows)
            {
                var row = resultTables[n].NewRow();
                int i = 0;
                foreach (var columnIndex in Enumerable.Range(0, BookCSV.ColumnCount))
                {
                    row[i++] = BookCSV.Table.Rows[resultRow.BookRowIndex][columnIndex];
                }
                foreach (var columnIndex in Enumerable.Range(0, ScrapingCSV.ColumnCount))
                {
                    row[i++] = ScrapingCSV.Table.Rows[resultRow.ScrapingRowIndex][columnIndex];
                }
                resultTables[n].Rows.Add(row);

                if (++k > (n + 1) * ExcelSaver.MAX_EXCEL_ROWS)
                {
                    resultTables.Add(resultTables[0].Clone());
                    ++n;
                }
            }
        }

        protected string ConvertNone(string value)
        {
            return value;
        }

        protected string ConvertRemoveSpace(string value)
        {
            return value.Replace(" ", "").Replace("　", "");
        }

        protected string ConvertExtractPrefix(string value)
        {
            return value.Length > PrefixLength ? value.Substring(0, PrefixLength) : value;
        }

        protected string ConvertRemoveSpaceExtractPrefix(string value)
        {
            value = value.Replace(" ", "").Replace("　", "");
            return value.Length > PrefixLength ? value.Substring(0, PrefixLength) : value;
        }

        protected struct ColumnInfo
        {
            public MatchType MatchType { get; }
            public SpaceMatch SpaceMatch { get; }
            public int BookColumnIndex { get; }
            public int ScrapingColumnIndex { get; }

            public ColumnInfo(MatchType matchType, SpaceMatch spaceMatch, ColumnType columnType)
            {
                MatchType = matchType;
                SpaceMatch = spaceMatch;
                BookColumnIndex = columnType == ColumnType.Complex ? -1 : BookSearcher.SelectBookColumnIndex(columnType);
                ScrapingColumnIndex = matchType == MatchType.ComplexMatch && columnType != ColumnType.Complex ? -1 : BookSearcher.SelectScrapingColumnIndex(columnType);
            }
        }

        protected struct RowIndexPair
        {
            public int BookRowIndex;
            public int ScrapingRowIndex;
        }
    }
}
