using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher17 : TestBookSearcher
    {
        private readonly CSVData dataAscA;
        private readonly CSVData dataDescA;
        private readonly CSVData dataAscB;
        private readonly CSVData dataDescB;
        private readonly CSVData dataDiff1A;
        private readonly CSVData dataDiff2A;
        private readonly CSVData dataDiff1B;
        private readonly CSVData dataDiff2B;

        const string BookTitle = "書籍タイトル";
        const string valueFormat1a = "書籍通巻{0:D6}";
        const string valueFormat1b = "書籍通巻{0:D6}第二版";
        const string Year = "出版年";
        const string valueFormat2a = "20{0:D2}";
        const string valueFormat2b = "西暦20{0:D2}年";
        const string Publisher = "出版社";
        const string valueFormat3a = "{0:D8}出版";
        const string valueFormat3b = "株式会社{0:D8}出版";

        const int PrefixLength = 10;

        public TestBookSearcher17()
        {
            BookColumnSetting.Rows.Add(BookTitle, valueFormat1a, "書籍名");
            ScrapingColumnSetting.Rows.Add(BookTitle, valueFormat1b, "書籍名");

            BookColumnSetting.Rows.Add(Year, valueFormat2a, "出版年");
            ScrapingColumnSetting.Rows.Add(Year, valueFormat2b, "出版年");

            BookColumnSetting.Rows.Add(Publisher, valueFormat3a, "出版社名");
            ScrapingColumnSetting.Rows.Add(Publisher, valueFormat3b, "出版社名");

            dataAscA = CreateDataAsc(ROW_COUNT, BookTitle, Year, Publisher, valueFormat1a, valueFormat2a, valueFormat3a);
            dataDescA = CreateDataDesc(ROW_COUNT, BookTitle, Year, Publisher, valueFormat1a, valueFormat2a, valueFormat3a);
            dataAscB = CreateDataAsc(ROW_COUNT, BookTitle, Year, Publisher, valueFormat1b, valueFormat2b, valueFormat3b);
            dataDescB = CreateDataDesc(ROW_COUNT, BookTitle, Year, Publisher, valueFormat1b, valueFormat2b, valueFormat3b);
            dataDiff1A = CreateDataAsc(ROW_COUNT + 1, BookTitle, Year, Publisher, valueFormat1a, valueFormat2a, valueFormat3a);
            dataDiff2A = CreateDataDesc(ROW_COUNT + 1, BookTitle, Year, Publisher, valueFormat1a, valueFormat2a, valueFormat3a);
            dataDiff1B = CreateDataAsc(ROW_COUNT + 1, BookTitle, Year, Publisher, valueFormat1b, valueFormat2b, valueFormat3b);
            dataDiff2B = CreateDataDesc(ROW_COUNT + 1, BookTitle, Year, Publisher, valueFormat1b, valueFormat2b, valueFormat3b);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAscA;
            var scrapings = dataAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher17();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAscA;
            var scrapings = dataDescB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher17();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataDescA;
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher17();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2A;
            var scrapings = dataAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher17();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows3()
        {
            var books = dataDescA;
            var scrapings = dataDiff2B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher17();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn11()
        {
            var books = dataAscA;
            var scrapings = CreateDataAsc(ROW_COUNT, BookTitle, Year, Publisher, valueFormat1b, valueFormat2b, valueFormat3b);
            scrapings.AddRow(new string[] { string.Format(valueFormat1a + "!", scrapings.RowCount), string.Format(valueFormat2b, scrapings.RowCount), string.Format(valueFormat3b, scrapings.RowCount) });
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher17();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn12()
        {
            var books = dataDiff1A;
            var scrapings = CreateDataAsc(ROW_COUNT, BookTitle, Year, Publisher, valueFormat1b, valueFormat2b, valueFormat3b);
            scrapings.AddRow(new string[] { string.Format(valueFormat1a + "!", scrapings.RowCount), string.Format(valueFormat2b, scrapings.RowCount), string.Format(valueFormat3b, scrapings.RowCount) });
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher17();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn13()
        {
            var books = dataDiff1A;
            var scrapings = CreateDataAsc(ROW_COUNT, BookTitle, Year, Publisher, valueFormat1b, valueFormat2b, valueFormat3b);
            scrapings.AddRow(new string[] { string.Format(valueFormat1a + "!", scrapings.RowCount), string.Format("!" + valueFormat2b, scrapings.RowCount), string.Format("!" + valueFormat3b + "!", scrapings.RowCount) });
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher17();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn22()
        {
            var books = CreateDataAsc(ROW_COUNT, BookTitle, Year, Publisher, valueFormat1a, valueFormat2a, valueFormat3a);
            books.AddRow(new string[] { string.Format("!" + valueFormat1a, books.RowCount), string.Format(valueFormat2a + "!", books.RowCount), string.Format(valueFormat3a, books.RowCount) });
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher17();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }
    }
}
