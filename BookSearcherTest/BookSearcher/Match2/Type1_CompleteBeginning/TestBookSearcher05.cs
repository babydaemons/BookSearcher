using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher05 : TestBookSearcher
    {
        private readonly ColumnInfo[] columnInfosR1;
        private readonly ColumnInfo[] columnInfosR2;

        private readonly CSVData dataAscA;
        private readonly CSVData dataDescA;
        private readonly CSVData dataAscB;
        private readonly CSVData dataDescB;
        private readonly CSVData dataDiff1A;
        private readonly CSVData dataDiff2A;
        private readonly CSVData dataDiff1B;
        private readonly CSVData dataDiff2B;

        const int PrefixLength = 10;

        public TestBookSearcher05()
        {
            ApplyColumnInfo(BookTitle);
            ApplyColumnInfo(Publisher);

            columnInfosR1 = new ColumnInfo[] { BookTitleR1, Publisher };
            columnInfosR2 = new ColumnInfo[] { BookTitleR2, Publisher };

            dataAscA = CreateDataAsc(ROW_COUNT, columnInfosR1);
            dataDescA = CreateDataDesc(ROW_COUNT, columnInfosR1);
            dataAscB = CreateDataAsc(ROW_COUNT, columnInfosR2);
            dataDescB = CreateDataDesc(ROW_COUNT, columnInfosR2);
            dataDiff1A = CreateDataAsc(ROW_COUNT + 1, columnInfosR1);
            dataDiff2A = CreateDataDesc(ROW_COUNT + 1, columnInfosR1);
            dataDiff1B = CreateDataAsc(ROW_COUNT + 1, columnInfosR2);
            dataDiff2B = CreateDataDesc(ROW_COUNT + 1, columnInfosR2);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAscA;
            var scrapings = dataAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher05();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAscA;
            var scrapings = dataDescB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher05();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataDescB;
            var scrapings = dataDiff1A;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher05();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2A;
            var scrapings = dataAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher05();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows3()
        {
            var books = dataDescA;
            var scrapings = dataDiff2B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher05();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn11()
        {
            var books = dataAscA;
            var scrapings = CreateDataAsc(ROW_COUNT, columnInfosR2);
            AddFormattedRow(scrapings, AppendType.Left, AppendType.None);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher05();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn12()
        {
            var books = dataDiff1A;
            var scrapings = CreateDataAsc(ROW_COUNT, columnInfosR2);
            AddFormattedRow(scrapings, AppendType.Right, AppendType.None);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher05();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn21()
        {
            var books = CreateDataAsc(ROW_COUNT, columnInfosR2);
            AddFormattedRow(books, AppendType.Right, AppendType.None);
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher05();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn22()
        {
            var books = CreateDataAsc(ROW_COUNT, columnInfosR2);
            AddFormattedRow(books, AppendType.None, AppendType.Right);
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher05();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }
    }
}
