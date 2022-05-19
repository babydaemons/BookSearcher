using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BookSearcher
{
    enum ColumnIndex { Number, Name, Value, Type };
    enum ColumnType { None, BookTitle, Author, Publisher, Year, ISBN, URL };
    enum MatchType { CompleteMatch, BeginningMatch, PartialMatch };
    enum SpaceMatch { All, Ignore };

    struct ColumnInfo
    {
        public MatchType MatchType { get; }
        public SpaceMatch SpaceMatch { get; }
        public int BookColumnIndex { get; }
        public int ScrapingColumnIndex { get; }

        public ColumnInfo(MatchType matchType, SpaceMatch spaceMatch, int bookColumnIndex, int scrapingColumnIndex)
        {
            MatchType = matchType;
            SpaceMatch = spaceMatch;
            BookColumnIndex = bookColumnIndex;
            ScrapingColumnIndex = scrapingColumnIndex;
        }
    }

    struct RowIndexPair
    {
        public int BookRowIndex;
        public int ScrapingRowIndex;
    }

    struct Column1
    {
        public int Index;
        public string Value;
    }

    struct Column2
    {
        public int Index;
        public string Value1;
        public string Value2;
    }

    internal abstract class BookSearcher
    {
        private readonly CSVFile bookCSV;
        private readonly CSVFile scrapingCSV;
        private readonly int prefixLength;
        private static readonly string[] columnTypeNames = new string[] { "", "書籍名", "著者名", "出版社名", "出版年", "ISBN", "URL" };
        private static DataTable resultTable = new DataTable();
        public static DataTable ResultTable => resultTable;
        private delegate string ConvertValue(string value);

        protected BookSearcher(CSVFile bookCSV, CSVFile scrapingCSV, int prefixLength = 0)
        {
            this.bookCSV = bookCSV;
            this.scrapingCSV = scrapingCSV;
            this.prefixLength = prefixLength;
        }

        public abstract void Search(Dictionary<ColumnType, ColumnInfo> columnInfo);

        public static int SelectColumnIndex(DataGridView columnSetting, ColumnType columnType)
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

        protected void Search(ColumnInfo columnInfo)
        {
            var bookValues = CreateColumnList(bookCSV.Table, columnInfo, true);
            var scrapingValues = CreateColumnList(scrapingCSV.Table, columnInfo, false);
            var results = from bookRow in bookValues
                          join scrapingRow in scrapingValues
                          on bookRow.Value equals scrapingRow.Value
                          select new { BookRowIndex = bookRow.Index, ScrapingRowIndex = scrapingRow.Index };

            var resultRows = new List<RowIndexPair>();
            foreach (var result in results)
            {
                resultRows.Add(new RowIndexPair { BookRowIndex = result.BookRowIndex, ScrapingRowIndex = result.ScrapingRowIndex });
            }
            SaveTable(resultRows);
        }

        protected void Search(ColumnInfo columnInfo1, ColumnInfo columnInfo2)
        {
            var bookValues = CreateColumnList(bookCSV.Table, columnInfo1, columnInfo2, true);
            var scrapingValues = CreateColumnList(scrapingCSV.Table, columnInfo1, columnInfo2, false);
            var results = from bookRow in bookValues
                          join scrapingRow in scrapingValues
                          on new { bookRow.Value1, bookRow.Value2 } equals new { scrapingRow.Value1, scrapingRow.Value2 }
                          select new { BookRowIndex = bookRow.Index, ScrapingRowIndex = scrapingRow.Index };

            var resultRows = new List<RowIndexPair>();
            foreach (var result in results)
            {
                resultRows.Add(new RowIndexPair { BookRowIndex = result.BookRowIndex, ScrapingRowIndex = result.ScrapingRowIndex });
            }
            SaveTable(resultRows);
        }

        private List<Column1> CreateColumnList(DataTable table, ColumnInfo columnInfo, bool isBookDB)
        {
            var columnName = table.Columns[(isBookDB ? columnInfo.BookColumnIndex : columnInfo.ScrapingColumnIndex) + 1].Caption;
            var spaceMatch = columnInfo.SpaceMatch;

            var rows = table.AsEnumerable().Where(row => ((string)row[columnName]).Length > 0);
            var values = new List<Column1>();
            ConvertValue convertValue = spaceMatch == SpaceMatch.All ? ConvertNone : (ConvertValue)ConvertRemoveSpace;
            foreach (var row in rows)
            {
                values.Add(new Column1
                {
                    Index = row.Field<int>("RowIndex"),
                    Value = convertValue(row.Field<string>(columnName))
                });
            }
            return values;
        }

        private List<Column2> CreateColumnList(DataTable table, ColumnInfo columnInfo1, ColumnInfo columnInfo2, bool isBookDB)
        {
            var columnName1 = table.Columns[(isBookDB ? columnInfo1.BookColumnIndex : columnInfo1.ScrapingColumnIndex) + 1].Caption;
            var columnName2 = table.Columns[(isBookDB ? columnInfo2.BookColumnIndex : columnInfo2.ScrapingColumnIndex) + 1].Caption;

            var rows = table.AsEnumerable().Where(row => ((string)row[columnName1]).Length > 0 && ((string)row[columnName2]).Length > 0);
            var values = new List<Column2>();
            ConvertValue convertValue1 = GetConvertValue(columnInfo1);
            ConvertValue convertValue2 = GetConvertValue(columnInfo2);
            foreach (var row in rows)
            {
                values.Add(new Column2
                {
                    Index = row.Field<int>("RowIndex"),
                    Value1 = convertValue1(row.Field<string>(columnName1)),
                    Value2 = convertValue2(row.Field<string>(columnName2))
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
            else
            {
                return ConvertRemoveSpaceExtractPrefix;
            }
        }

        private void SaveTable(List<RowIndexPair> resultRows)
        {
            resultTable = new DataTable();
            foreach (var column in bookCSV.Titles)
            {
                resultTable.Columns.Add("データベースファイル\n" + column);
            }
            foreach (var column in scrapingCSV.Titles)
            {
                resultTable.Columns.Add("スクレイピングデータファイル\n" + column);
            }

            foreach (var resultRow in resultRows)
            {
                var row = resultTable.NewRow();
                int i = 0;
                for (var j = 1; j < bookCSV.Table.Columns.Count; j++)
                {
                    row[i++] = bookCSV.Table.Rows[resultRow.BookRowIndex][j];
                }
                for (var j = 1; j < scrapingCSV.Table.Columns.Count; j++)
                {
                    row[i++] = scrapingCSV.Table.Rows[resultRow.ScrapingRowIndex][j];
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
            return value.Length > prefixLength ? value.Substring(0, prefixLength) : value;
        }

        private string ConvertRemoveSpaceExtractPrefix(string value)
        {
            value = value.Replace(" ", "").Replace("　", "");
            return value.Length > prefixLength ? value.Substring(0, prefixLength) : value;
        }
    }
}
