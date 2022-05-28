using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher01 : TestBookSearcher
    {
        private readonly CSVData dataAsc;
        private readonly CSVData dataDesc;
        private readonly CSVData dataDiff1;
        private readonly CSVData dataDiff2;

        const string BookTitle = "書籍タイトル";
        const string valuePrefix1 = "書籍タイトル通巻";
        const string Year = "発売年";
        const string valuePrefix2 = "20";

        public TestBookSearcher01()
        {
            BookColumnSetting.Rows.Add(BookTitle, valuePrefix1, "書籍名");
            ScrapingColumnSetting.Rows.Add(BookTitle, valuePrefix1, "書籍名");

            BookColumnSetting.Rows.Add(Year, valuePrefix2, "出版年");
            ScrapingColumnSetting.Rows.Add(Year, valuePrefix2, "出版年");

            dataAsc = CreateDataAsc(ROW_COUNT, BookTitle, Year, valuePrefix1, valuePrefix2, 8, 2);
            dataDesc = CreateDataDesc(ROW_COUNT, BookTitle, Year, valuePrefix1, valuePrefix2, 8, 2);
            dataDiff1 = CreateDataAsc(ROW_COUNT + 1, BookTitle, Year, valuePrefix1, valuePrefix2, 8, 2);
            dataDiff2 = CreateDataDesc(ROW_COUNT + 1, BookTitle, Year, valuePrefix1, valuePrefix2, 8, 2);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAsc;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher01();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAsc;
            var scrapings = dataDesc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher01();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataAsc;
            var scrapings = dataDiff1;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher01();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2;
            var scrapings = dataAsc;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher01();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn11()
        {
            var books = dataAsc;
            var scrapings = CreateDataAsc(ROW_COUNT, BookTitle, Year, valuePrefix1, valuePrefix2, 8, 2);
            var i = scrapings.MemoryTable.Count;
            var row = new MemoryRow(scrapings.MemoryTable, i, new string[] { valuePrefix1 + i.ToString("D8!"), valuePrefix2 + i.ToString("D2") });
            scrapings.MemoryTable.TryAdd(i, row);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher01();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn12()
        {
            var books = dataAsc;
            var scrapings = CreateDataAsc(ROW_COUNT, BookTitle, Year, valuePrefix1, valuePrefix2, 8, 2);
            var i = scrapings.MemoryTable.Count;
            var row = new MemoryRow(scrapings.MemoryTable, i, new string[] { valuePrefix1 + i.ToString("D8"), valuePrefix2 + i.ToString("D2!") });
            scrapings.MemoryTable.TryAdd(i, row);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher01();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn21()
        {
            var books = CreateDataAsc(ROW_COUNT, BookTitle, Year, valuePrefix1, valuePrefix2, 8, 2);
            var i = books.MemoryTable.Count;
            var row = new MemoryRow(books.MemoryTable, i, new string[] { valuePrefix1 + i.ToString("D8!"), valuePrefix2 + i.ToString("D2") });
            books.MemoryTable.TryAdd(i, row);
            var scrapings = dataDiff1;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher01();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn22()
        {
            var books = CreateDataAsc(ROW_COUNT, BookTitle, Year, valuePrefix1, valuePrefix2, 8, 2);
            var i = books.MemoryTable.Count;
            var row = new MemoryRow(books.MemoryTable, i, new string[] { valuePrefix1 + i.ToString("D8"), valuePrefix2 + i.ToString("D2!") });
            books.MemoryTable.TryAdd(i, row);
            var scrapings = dataDiff1;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, -1);
            searcher = new BookSearcher01();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }
    }
}
