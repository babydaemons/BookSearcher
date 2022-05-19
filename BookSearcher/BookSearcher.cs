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

    struct ColumnInfo
    {
        public MatchType MatchType { get; }
        public int BookColumnIndex { get; }
        public int ScrapingColumnIndex { get; }

        public ColumnInfo(MatchType matchType, int bookColumnIndex, int scrapingColumnIndex)
        {
            MatchType = matchType;
            BookColumnIndex = bookColumnIndex;
            ScrapingColumnIndex = scrapingColumnIndex;
        }
    }

    struct RowIndexPair
    {
        public int BookRowIndex;
        public int ScrapingRowIndex;
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

        protected void Search(Dictionary<ColumnType, ColumnInfo> columnInfo, ColumnType columnType)
        {
            var bookColumnName = bookCSV.Titles[columnInfo[columnType].BookColumnIndex];
            var scrapingColumnName = scrapingCSV.Titles[columnInfo[columnType].ScrapingColumnIndex];

            var bookTable = bookCSV.Table;
            var scrapingTable = scrapingCSV.Table;

            var results = from bookRow in bookTable.AsEnumerable()
                          join scrapingRow in scrapingTable.AsEnumerable()
                          on bookRow.Field<string>(bookColumnName) equals scrapingRow.Field<string>(scrapingColumnName)
                          select new { BookRowIndex = bookRow.Field<int>("RowIndex"), ScrapingRowIndex = scrapingRow.Field<int>("RowIndex") };

            var resultRows = new List<RowIndexPair>();
            foreach (var result in results)
            {
                resultRows.Add(new RowIndexPair { BookRowIndex = result.BookRowIndex, ScrapingRowIndex = result.ScrapingRowIndex });
            }

            SaveTable(resultRows);
        }

        protected void SaveTable(List<RowIndexPair> resultRows)
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
    }
}
