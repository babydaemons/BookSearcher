using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher15 : TestBookSearcher
    {
        private readonly CSVData dataAsc;
        private readonly CSVData dataDesc;
        private readonly CSVData dataDiff1;
        private readonly CSVData dataDiff2;

        public TestBookSearcher15()
        {
            const string BookTitle = "書籍タイトル";
            const string valuePrefix = "書籍タイトル通巻";
            BookColumnSetting.Rows.Add(BookTitle, valuePrefix, "書籍名");
            ScrapingColumnSetting.Rows.Add(BookTitle, valuePrefix, "書籍名");

            dataAsc = CreateDataAsc(ROW_COUNT, BookTitle, valuePrefix);
            dataDesc = CreateDataDesc(ROW_COUNT, BookTitle, valuePrefix);
            dataDiff1 = CreateDataAsc(ROW_COUNT  + 1, BookTitle, valuePrefix);
            dataDiff2 = CreateDataDesc(ROW_COUNT + 1, BookTitle, valuePrefix);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAsc;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher15();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAsc;
            var scrapings = dataDesc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher15();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataAsc;
            var scrapings = dataDiff1;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher15();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher15();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }
    }
}
