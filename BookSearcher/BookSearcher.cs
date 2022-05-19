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
        protected CSVFile bookCSV;
        protected CSVFile scrapingCSV;
        private static readonly string[] columnTypeNames = new string[] { "", "書籍名", "著者名", "出版社名", "出版年", "ISBN", "URL" };
        private static DataTable resultTable = new DataTable();
        public static DataTable ResultTable => resultTable;
        protected BookSearcher(CSVFile bookCSV, CSVFile scrapingCSV)
        {
            this.bookCSV = bookCSV;
            this.scrapingCSV = scrapingCSV;
        }
        private delegate string ConvertValue(string value);

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
            var bookColumnName = bookCSV.Titles[columnInfo.BookColumnIndex];
            var scrapingColumnName = scrapingCSV.Titles[columnInfo.ScrapingColumnIndex];

            var bookRows = bookCSV.Table.AsEnumerable().Where(row => ((string)row[bookColumnName]).Length > 0);
            var scrapingRows = scrapingCSV.Table.AsEnumerable().Where(row => ((string)row[scrapingColumnName]).Length > 0);

            var bookValues = CreateColumnList(bookRows, bookColumnName, columnInfo.SpaceMatch);
            var scrapingValues = CreateColumnList(scrapingRows, scrapingColumnName, columnInfo.SpaceMatch);
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
            var bookColumnName1 = bookCSV.Titles[columnInfo1.BookColumnIndex];
            var bookColumnName2 = bookCSV.Titles[columnInfo2.BookColumnIndex];
            var scrapingColumnName1 = scrapingCSV.Titles[columnInfo1.ScrapingColumnIndex];
            var scrapingColumnName2 = scrapingCSV.Titles[columnInfo2.ScrapingColumnIndex];

            var bookRows = bookCSV.Table.AsEnumerable().Where(row => ((string)row[bookColumnName1]).Length > 0 && ((string)row[bookColumnName2]).Length > 0);
            var scrapingRows = scrapingCSV.Table.AsEnumerable().Where(row => ((string)row[scrapingColumnName1]).Length > 0 && ((string)row[scrapingColumnName2]).Length > 0);

            var bookValues = CreateColumnList(bookRows, bookColumnName1, columnInfo1.SpaceMatch, bookColumnName2, columnInfo2.SpaceMatch);
            var scrapingValues = CreateColumnList(scrapingRows, scrapingColumnName1, columnInfo1.SpaceMatch, scrapingColumnName2, columnInfo2.SpaceMatch);
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

        private List<Column1> CreateColumnList(EnumerableRowCollection<DataRow> rows, string columnName, SpaceMatch spaceMatch)
        {
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

        private List<Column2> CreateColumnList(EnumerableRowCollection<DataRow> rows, string columnName1, SpaceMatch spaceMatch1, string columnName2, SpaceMatch spaceMatch2)
        {
            var values = new List<Column2>();
            ConvertValue convertValue1 = spaceMatch1 == SpaceMatch.All ? ConvertNone : (ConvertValue)ConvertRemoveSpace;
            ConvertValue convertValue2 = spaceMatch2 == SpaceMatch.All ? ConvertNone : (ConvertValue)ConvertRemoveSpace;
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
    }
}
