using System.Linq;
using BookSearcherApp;

namespace BookSearcherTest
{
    public class TestBookSearcher : Form1
    {
        protected const int ROW_COUNT = 100;

        protected struct ColumnInfo
        {
            public string Name;
            public string Format;
            public string Key;
        }

        protected readonly ColumnInfo ISBN = new ColumnInfo { Name = "書籍ISBNコード", Format = "9781{0:D8}", Key = "ISBN" };
        protected readonly ColumnInfo Cost = new ColumnInfo { Name = "仕入原価", Format = "{0}", Key = "価格" };
        protected readonly ColumnInfo URL = new ColumnInfo { Name = "ページURL", Format = "https://www.example.com/{0:D8}", Key = "URL" };
        protected readonly ColumnInfo Year = new ColumnInfo { Name = "発売年", Format = "20{0:D2}", Key = "出版年" };
        protected readonly ColumnInfo YearLR = new ColumnInfo { Name = "発売年", Format = "西暦20{0:D2}年", Key = "出版年" };
        protected readonly ColumnInfo BookTitle = new ColumnInfo { Name = "書籍タイトル", Format = "書籍通巻{0:D5}号", Key = "書籍名" };
        protected readonly ColumnInfo BookTitleR1 = new ColumnInfo { Name = "書籍タイトル", Format = "書籍通巻{0:D5}号R1", Key = "書籍名" };
        protected readonly ColumnInfo BookTitleR2 = new ColumnInfo { Name = "書籍タイトル", Format = "書籍通巻{0:D5}号R2", Key = "書籍名" };
        protected readonly ColumnInfo BookTitleLR = new ColumnInfo { Name = "書籍タイトル", Format = "LR書籍通巻{0:D5}号LR", Key = "書籍名" };
        protected readonly ColumnInfo Publisher = new ColumnInfo { Name = "出版社", Format = "株式会社{0:D8}出版", Key = "出版社名" };
        protected readonly ColumnInfo PublisherLR = new ColumnInfo { Name = "出版社", Format = "LR株式会社{0:D8}出版LR", Key = "出版社名" };
        protected readonly ColumnInfo Author = new ColumnInfo { Name = "著者", Format = "山田{0:D2}太郎", Key = "著者名" };
        protected readonly ColumnInfo AuthorLR = new ColumnInfo { Name = "著者", Format = "ミスター山田{0:D2}太郎先生", Key = "著者名" };
        protected readonly ColumnInfo Complex = new ColumnInfo { Name = "書籍タイトル＆出版社＆出版年", Format = "タイトル「大好評！書籍通巻 {0:D5}号第二版」／著者「ミスター山田{0:D2}太郎先生」／出版社「株式会社 {0:D8}出版」／出版年「西暦20{0:D2}年」", Key = "複合データ" };

        protected enum AppendType { None, Left, Right, Both };

        protected void ApplyColumnInfo(ColumnInfo column)
        {
            BookColumnSetting.Rows.Add(column.Name, column.Format, column.Key);
            ScrapingColumnSetting.Rows.Add(column.Name, column.Format, column.Key);
        }

        protected TestBookSearcher() : base()
        {
            ApplyColumnInfo(ISBN);
            ApplyColumnInfo(Cost);
        }

        protected CSVData CreateDataAsc(int count, ColumnInfo[] columnInfos = null)
        {
            var rows = CreateData(count);
            var formats = GetFormats(columnInfos);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                _ = rows.MemoryTable.TryAdd(i, GetRow(rows, formats, i));
            });
            return rows;
        }

        protected CSVData CreateDataDesc(int count, ColumnInfo[] columnInfos = null)
        {
            var rows = CreateData(count);
            var formats = GetFormats(columnInfos);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                _ = rows.MemoryTable.TryAdd(count - i - 1, GetRow(rows, formats, i));
            });
            return rows;
        }

        private CSVData CreateData(int count)
        {
            var rows = new CSVData();
            var columnCount = BookColumnSetting.RowCount;
            var columnNames = new string[columnCount];
            foreach (var i in Enumerable.Range(0, columnCount))
            {
                columnNames[i] = (string)BookColumnSetting[0, i].Value;
            }
            rows.SetTitles(columnNames);
            rows.AllocateTable(count);
            return rows;
        }

        private string[] GetFormats(ColumnInfo[] columnInfos = null)
        {
            if (columnInfos != null)
            {
                columnInfos = (new ColumnInfo[] { ISBN, Cost }).Concat(columnInfos).ToArray();
            }

            var columnCount = BookColumnSetting.RowCount;
            var formats = new string[columnCount];
            foreach (var i in Enumerable.Range(0, columnCount))
            {
                formats[i] = columnInfos != null ? columnInfos[i].Format : (string)BookColumnSetting[1, i].Value;
            }
            return formats;
        }

        private MemoryRow GetRow(CSVData rows, string[] formats, int i)
        {
            var columnCount = formats.Length;
            var values = new string[columnCount];
            foreach (var j in Enumerable.Range(0, columnCount))
            {
                values[j] = string.Format(formats[j], i);
            }
            return new MemoryRow(rows.MemoryTable, i, values);
        }

        protected void AddRow(CSVData rows, AppendType type, ColumnInfo[] columnInfos = null, int offset = 0)
        {
            var formats = GetFormats(columnInfos);

            var i = formats.Length - 1;
            formats[i] = ModifyFormat(type, formats[i]);

            var n = rows.RowCount;
            _ = rows.MemoryTable.TryAdd(n, GetRow(rows, formats, n + offset));
        }

        protected void AddRow(CSVData rows, AppendType type1, AppendType type2, ColumnInfo[] columnInfos = null, int offset = 0)
        {
            var formats = GetFormats(columnInfos);

            var i = formats.Length - 2;
            formats[i] = ModifyFormat(type1, formats[i]);

            ++i;
            formats[i] = ModifyFormat(type2, formats[i]);

            var n = rows.RowCount;
            _ = rows.MemoryTable.TryAdd(n, GetRow(rows, formats, n + offset));
        }

        protected void AddRow(CSVData rows, AppendType type1, AppendType type2, AppendType type3, ColumnInfo[] columnInfos = null, int offset = 0)
        {
            var formats = GetFormats(columnInfos);

            var i = formats.Length - 3;
            formats[i] = ModifyFormat(type1, formats[i]);

            ++i;
            formats[i] = ModifyFormat(type2, formats[i]);

            ++i;
            formats[i] = ModifyFormat(type3, formats[i]);

            var n = rows.RowCount;
            _ = rows.MemoryTable.TryAdd(n, GetRow(rows, formats, n + offset));
        }

        private string ModifyFormat(AppendType type, string format)
        {
            if (type == AppendType.Left)
            {
                return "!" + format;
            }
            else if (type == AppendType.Right)
            {
                return format + "!";
            }
            else if (type == AppendType.Both)
            {
                return format + "!";
            }
            else
            {
                return format;
            }
        }

        protected CSVData CreateDataAsc(int count, string columnName1, string columnName2, string valueFormat1, string valueFormat2)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName1, columnName2 });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { string.Format(valueFormat1, i), string.Format(valueFormat2, i) });
                rows.MemoryTable.TryAdd(i, row);
            });
            return rows;
        }

        protected CSVData CreateDataDesc(int count, string columnName1, string columnName2, string valueFormat1, string valueFormat2)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName1, columnName2 });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { string.Format(valueFormat1, i), string.Format(valueFormat2, i) });
                rows.MemoryTable.TryAdd(count - i - 1, row);
            });
            return rows;
        }

        protected CSVData CreateDataAsc(int count, string columnName1, string columnName2, string columnName3, string valueFormat1, string valueFormat2, string valueFormat3)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName1, columnName2, columnName3 });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { string.Format(valueFormat1, i), string.Format(valueFormat2, i), string.Format(valueFormat3, i) });
                rows.MemoryTable.TryAdd(i, row);
            });
            return rows;
        }

        protected CSVData CreateDataDesc(int count, string columnName1, string columnName2, string columnName3, string valueFormat1, string valueFormat2, string valueFormat3)
        {
            var rows = new CSVData();
            rows.SetTitles(new string[] { columnName1, columnName2, columnName3 });
            rows.AllocateTable(count);
            Enumerable.Range(0, count).AsParallel().ForAll(i =>
            {
                var row = new MemoryRow(rows.MemoryTable, i, new string[] { string.Format(valueFormat1, i), string.Format(valueFormat2, i), string.Format(valueFormat3, i) });
                rows.MemoryTable.TryAdd(count - i - 1, row);
            });
            return rows;
        }
    }
}
