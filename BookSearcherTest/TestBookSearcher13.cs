using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher13 : TestBookSearcher
    {
        private readonly CSVData dataAsc;
        private readonly CSVData dataDesc;
        private readonly CSVData dataDiff1;
        private readonly CSVData dataDiff2;

        public TestBookSearcher13()
        {
            const string URL = "ページURL";
            const string valuePrefix = "https://www.example.com/";
            BookColumnSetting.Rows.Add(URL, valuePrefix, "URL");
            ScrapingColumnSetting.Rows.Add(URL, valuePrefix, "URL");

            dataAsc = CreateDataAsc(ROW_COUNT, URL, valuePrefix);
            dataDesc = CreateDataDesc(ROW_COUNT, URL, valuePrefix);
            dataDiff1 = CreateDataAsc(ROW_COUNT + 1, URL, valuePrefix);
            dataDiff2 = CreateDataDesc(ROW_COUNT + 1, URL, valuePrefix);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAsc;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher13();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAsc;
            var scrapings = dataDesc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher13();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataAsc;
            var scrapings = dataDiff1;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher13();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher13();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }
    }
}
