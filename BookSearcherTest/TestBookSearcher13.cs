using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher13 : TestBookSearcher
    {
        private CSVData dataAsc;
        private CSVData dataDesc;
        private CSVData dataDiff1;
        private CSVData dataDiff2;

        public TestBookSearcher13()
        {
            const string URL = "ページURL";
            const string valuePrefix = "https://www.example.com/";
            BookColumnSetting.Rows.Add(URL, valuePrefix, "URL");
            ScrapingColumnSetting.Rows.Add(URL, valuePrefix, "URL");

            dataAsc = CreateDataAsc(URL, valuePrefix, ROW_COUNT);
            dataDesc = CreateDataDesc(URL, valuePrefix, ROW_COUNT);
            dataDiff1 = CreateDataAsc(URL, valuePrefix, ROW_COUNT + 1);
            dataDiff2 = CreateDataDesc(URL, valuePrefix, ROW_COUNT + 1);
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
