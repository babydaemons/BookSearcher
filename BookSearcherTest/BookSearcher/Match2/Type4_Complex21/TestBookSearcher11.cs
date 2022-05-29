using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher11 : TestBookSearcher
    {
        private readonly CSVData bookAscA;
        private readonly CSVData bookDescA;
        private readonly CSVData scrapingAscB;
        private readonly CSVData scrapingDescB;
        private readonly CSVData bookDiff1A;
        private readonly CSVData bookDiff2A;
        private readonly CSVData scrapingDiff1B;
        private readonly CSVData scrapingDiff2B;

        const string BookTitle = "書籍タイトル";
        const string valueFormat1a = "書籍 通巻{0:D6}";
        const string Publisher = "出版社";
        const string valueFormat2a = "株式会社{0:D8}出版";
        const string Complex = "書籍タイトル＆著者";
        const string valueFormat1b = "タイトル「大好評！書籍通巻 {0:D6}第二版」／出版社「株式会社 {0:D8}出版」";

        const int PrefixLength = 10;

        public TestBookSearcher11()
        {
            BookColumnSetting.Rows.Add(BookTitle, valueFormat1a, "書籍名");
            BookColumnSetting.Rows.Add(Publisher, valueFormat2a, "出版社名");
            
            ScrapingColumnSetting.Rows.Add(BookTitle, valueFormat1a, "複合データ");

            bookAscA = CreateDataAsc(ROW_COUNT, BookTitle, Publisher, valueFormat1a, valueFormat2a);
            bookDescA = CreateDataDesc(ROW_COUNT, BookTitle, Publisher, valueFormat1a, valueFormat2a);
            scrapingAscB = CreateDataAsc(ROW_COUNT, Complex, valueFormat1b);
            scrapingDescB = CreateDataDesc(ROW_COUNT, Complex, valueFormat1b);
            bookDiff1A = CreateDataAsc(ROW_COUNT + 1, BookTitle, Publisher, valueFormat1a, valueFormat2a);
            bookDiff2A = CreateDataDesc(ROW_COUNT + 1, BookTitle, Publisher, valueFormat1a, valueFormat2a);
            scrapingDiff1B = CreateDataAsc(ROW_COUNT + 1, Complex, valueFormat1b);
            scrapingDiff2B = CreateDataDesc(ROW_COUNT + 1, Complex, valueFormat1b);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = bookAscA;
            var scrapings = scrapingAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = bookAscA;
            var scrapings = scrapingDescB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = bookDescA;
            var scrapings = scrapingDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = bookDiff2A;
            var scrapings = scrapingAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows3()
        {
            var books = bookDescA;
            var scrapings = scrapingDiff2B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn11()
        {
            var books = bookAscA;
            var scrapings = CreateDataAsc(ROW_COUNT, Complex, valueFormat1b);
            scrapings.AddRow(new string[] { string.Format(valueFormat1b + "!", scrapings.RowCount - 1) });
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn12()
        {
            var books = bookDiff1A;
            var scrapings = CreateDataAsc(ROW_COUNT, Complex, valueFormat1b);
            scrapings.AddRow(new string[] { string.Format("!" + valueFormat1b, scrapings.RowCount - 1) });
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn22()
        {
            var books = CreateDataAsc(ROW_COUNT, BookTitle, Publisher, valueFormat1a, valueFormat2a);
            books.AddRow(new string[] { string.Format(valueFormat1a, books.RowCount), string.Format(valueFormat2a + "!", books.RowCount) });
            var scrapings = scrapingDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }
    }
}
