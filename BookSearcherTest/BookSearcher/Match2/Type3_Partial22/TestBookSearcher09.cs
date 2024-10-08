﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher09 : TestBookSearcher
    {
        private readonly ColumnInfo[] columnInfosLR;

        private readonly CSVData dataAscA;
        private readonly CSVData dataDescA;
        private readonly CSVData dataAscB;
        private readonly CSVData dataDescB;
        private readonly CSVData dataDiff1A;
        private readonly CSVData dataDiff2A;
        private readonly CSVData dataDiff1B;
        private readonly CSVData dataDiff2B;

        const int PrefixLength = 10;

        public TestBookSearcher09()
        {
            ApplyColumnInfo(BookTitle);
            ApplyColumnInfo(Author);

            columnInfosLR = new ColumnInfo[] { BookTitleLR, AuthorLR };

            dataAscA = CreateDataAsc(ROW_COUNT);
            dataDescA = CreateDataDesc(ROW_COUNT);
            dataAscB = CreateDataAsc(ROW_COUNT, columnInfosLR);
            dataDescB = CreateDataDesc(ROW_COUNT, columnInfosLR);
            dataDiff1A = CreateDataAsc(ROW_COUNT + 1);
            dataDiff2A = CreateDataDesc(ROW_COUNT + 1);
            dataDiff1B = CreateDataAsc(ROW_COUNT + 1, columnInfosLR);
            dataDiff2B = CreateDataDesc(ROW_COUNT + 1, columnInfosLR);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAscA;
            var scrapings = dataAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher09();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAscA;
            var scrapings = dataDescB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher09();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataDescA;
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher09();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2A;
            var scrapings = dataAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher09();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows3()
        {
            var books = dataDescA;
            var scrapings = dataDiff2B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher09();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn11()
        {
            var books = dataAscA;
            var scrapings = CreateDataAsc(ROW_COUNT, columnInfosLR);
            AddFormattedRow(scrapings, AppendType.Right, AppendType.None);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher09();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn12()
        {
            var books = dataDiff1A;
            var scrapings = CreateDataAsc(ROW_COUNT, columnInfosLR);
            AddFormattedRow(scrapings, AppendType.None, AppendType.Right);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher09();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn13()
        {
            var books = dataDiff1A;
            var scrapings = CreateDataAsc(ROW_COUNT, columnInfosLR);
            AddFormattedRow(scrapings, AppendType.None, AppendType.Right);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher09();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn21()
        {
            var books = CreateDataAsc(ROW_COUNT);
            AddFormattedRow(books, AppendType.Right, AppendType.None);
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher09();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn22()
        {
            var books = CreateDataAsc(ROW_COUNT);
            AddFormattedRow(books, AppendType.None, AppendType.Right);
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher09();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTables[0].Rows.Count);
        }
    }
}
