using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher14 : TestBookSearcher
    {
        private readonly CSVData dataAsc;
        private readonly CSVData dataDesc;
        private readonly CSVData dataDiff1;
        private readonly CSVData dataDiff2;

        public TestBookSearcher14()
        {
            const string ISBN = "書籍ISBN13";
            const string valuePrefix = "97841";
            BookColumnSetting.Rows.Add(ISBN, valuePrefix, "ISBN");
            ScrapingColumnSetting.Rows.Add(ISBN, valuePrefix, "ISBN");

            dataAsc = CreateDataAsc(ROW_COUNT, ISBN, valuePrefix);
            dataDesc = CreateDataDesc(ROW_COUNT, ISBN, valuePrefix);
            dataDiff1 = CreateDataAsc(ROW_COUNT + 1, ISBN, valuePrefix);
            dataDiff2 = CreateDataDesc(ROW_COUNT + 1, ISBN, valuePrefix);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAsc;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher14();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAsc;
            var scrapings = dataDesc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher14();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataAsc;
            var scrapings = dataDiff1;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher14();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher14();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }
    }
}
