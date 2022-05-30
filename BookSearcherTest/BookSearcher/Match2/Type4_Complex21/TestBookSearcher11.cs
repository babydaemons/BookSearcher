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

        const int PrefixLength = 10;

        public TestBookSearcher11()
        {
            ApplyColumnInfo(BookTitle);
            ApplyColumnInfo(Publisher);
            ApplyColumnInfo(Complex);

            bookAscA = CreateDataAsc(ROW_COUNT);
            bookDescA = CreateDataDesc(ROW_COUNT);
            scrapingAscB = CreateDataAsc(ROW_COUNT);
            scrapingDescB = CreateDataDesc(ROW_COUNT);
            bookDiff1A = CreateDataAsc(ROW_COUNT + 1);
            bookDiff2A = CreateDataDesc(ROW_COUNT + 1);
            scrapingDiff1B = CreateDataAsc(ROW_COUNT + 1);
            scrapingDiff2B = CreateDataDesc(ROW_COUNT + 1);
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
            var scrapings = CreateDataAsc(ROW_COUNT);
            AddRow(scrapings, AppendType.Right, null, -1);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn12()
        {
            var books = bookDiff1A;
            var scrapings = CreateDataAsc(ROW_COUNT);
            AddRow(scrapings, AppendType.Left, null, -1);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn22()
        {
            var books = CreateDataAsc(ROW_COUNT);
            AddRow(books, AppendType.Right, AppendType.None, null, -1);
            var scrapings = scrapingDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher11();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }
    }
}
