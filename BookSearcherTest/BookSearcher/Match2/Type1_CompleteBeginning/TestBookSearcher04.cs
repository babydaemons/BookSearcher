using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher04 : TestBookSearcher
    {
        private readonly CSVData dataAsc;
        private readonly CSVData dataDesc;
        private readonly CSVData dataDiff1;
        private readonly CSVData dataDiff2;

        public TestBookSearcher04()
        {
            ApplyColumnInfo(BookTitle);
            ApplyColumnInfo(Publisher);

            dataAsc = CreateDataAsc(ROW_COUNT);
            dataDesc = CreateDataDesc(ROW_COUNT);
            dataDiff1 = CreateDataAsc(ROW_COUNT + 1);
            dataDiff2 = CreateDataDesc(ROW_COUNT + 1);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAsc;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher04();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAsc;
            var scrapings = dataDesc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher04();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataAsc;
            var scrapings = dataDiff1;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher04();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher04();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn11()
        {
            var books = dataAsc;
            var scrapings = CreateDataAsc(ROW_COUNT);
            AddRow(scrapings, AppendType.Left, AppendType.None);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher04();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn12()
        {
            var books = dataAsc;
            var scrapings = CreateDataAsc(ROW_COUNT);
            AddRow(scrapings, AppendType.None, AppendType.Right);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher04();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn21()
        {
            var books = CreateDataAsc(ROW_COUNT);
            AddRow(books, AppendType.Left, AppendType.None);
            var scrapings = dataDiff1;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher04();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn22()
        {
            var books = CreateDataAsc(ROW_COUNT);
            AddRow(books, AppendType.None, AppendType.Right);
            var scrapings = dataDiff1;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher04();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }
    }
}
