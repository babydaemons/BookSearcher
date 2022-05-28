using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher06 : TestBookSearcher
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
        const string valueFormat1b = "●●●書籍通巻{0:D6}●●●";
        const string Publisher = "出版社";
        const string valueFormat2 = "株式会社{0:D8}出版";

        const int PrefixLength = 10;

        public TestBookSearcher06()
        {
            BookColumnSetting.Rows.Add(BookTitle, valueFormat1a, "書籍名");
            ScrapingColumnSetting.Rows.Add(BookTitle, valueFormat1b, "書籍名");

            BookColumnSetting.Rows.Add(Publisher, valueFormat2, "出版社名");
            ScrapingColumnSetting.Rows.Add(Publisher, valueFormat2, "出版社名");

            dataAscA = CreateDataAsc(ROW_COUNT, BookTitle, Publisher, valueFormat1a, valueFormat2);
            dataDescA = CreateDataDesc(ROW_COUNT, BookTitle, Publisher, valueFormat1a, valueFormat2);
            dataAscB = CreateDataAsc(ROW_COUNT, BookTitle, Publisher, valueFormat1b, valueFormat2);
            dataDescB = CreateDataDesc(ROW_COUNT, BookTitle, Publisher, valueFormat1b, valueFormat2);
            dataDiff1A = CreateDataAsc(ROW_COUNT + 1, BookTitle, Publisher, valueFormat1a, valueFormat2);
            dataDiff2A = CreateDataDesc(ROW_COUNT + 1, BookTitle, Publisher, valueFormat1a, valueFormat2);
            dataDiff1B = CreateDataAsc(ROW_COUNT + 1, BookTitle, Publisher, valueFormat1b, valueFormat2);
            dataDiff2B = CreateDataDesc(ROW_COUNT + 1, BookTitle, Publisher, valueFormat1b, valueFormat2);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAscA;
            var scrapings = dataAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher06();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAscA;
            var scrapings = dataDescB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher06();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataDescA;
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher06();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2A;
            var scrapings = dataAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher06();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows3()
        {
            var books = dataDescA;
            var scrapings = dataDiff2B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher06();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn11()
        {
            var books = dataAscA;
            var scrapings = CreateDataAsc(ROW_COUNT, BookTitle, Publisher, valueFormat1b, valueFormat2);
            scrapings.AddRow(new string[] { string.Format(valueFormat1b + "!", scrapings.RowCount), string.Format(valueFormat2, scrapings.RowCount) });
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher06();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn12()
        {
            var books = dataAscB;
            var scrapings = CreateDataAsc(ROW_COUNT, BookTitle, Publisher, valueFormat1b, valueFormat2);
            scrapings.AddRow(new string[] { string.Format(valueFormat1b, scrapings.RowCount), string.Format(valueFormat2, scrapings.RowCount) });
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher06();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn13()
        {
            var books = dataDiff1A;
            var scrapings = CreateDataAsc(ROW_COUNT, BookTitle, Publisher, valueFormat1b, valueFormat2);
            scrapings.AddRow(new string[] { string.Format(valueFormat1b, scrapings.RowCount), string.Format(valueFormat2, scrapings.RowCount) });
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher06();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn22()
        {
            var books = CreateDataAsc(ROW_COUNT, BookTitle, Publisher, valueFormat1b, valueFormat2);
            books.AddRow(new string[] { string.Format(valueFormat1b, books.RowCount), string.Format(valueFormat2 + "!", books.RowCount) });
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher06();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }
    }
}
