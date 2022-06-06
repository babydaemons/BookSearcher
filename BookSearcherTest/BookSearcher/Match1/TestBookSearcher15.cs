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
            ApplyColumnInfo(BookTitle);

            dataAsc = CreateDataAsc(ROW_COUNT);
            dataDesc = CreateDataDesc(ROW_COUNT);
            dataDiff1 = CreateDataAsc(ROW_COUNT);
            dataDiff2 = CreateDataDesc(ROW_COUNT);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAsc;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher15();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAsc;
            var scrapings = dataDesc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher15();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataAsc;
            var scrapings = dataDiff1;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher15();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher15();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }
    }
}
