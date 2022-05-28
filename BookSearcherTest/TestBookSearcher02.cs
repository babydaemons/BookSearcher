﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestBookSearcher02 : TestBookSearcher
    {
        private readonly CSVData dataAscA;
        private readonly CSVData dataDescA;
        private readonly CSVData dataAscB;
        private readonly CSVData dataDescB;
        private readonly CSVData dataDiff1A;
        private readonly CSVData dataDiff2A;
        private readonly CSVData dataDiff1B;
        private readonly CSVData dataDiff2B;

        const string BookTitle = "書籍タイトル";
        const string valueFormat1a = "書籍通巻{0:D6}A";
        const string valueFormat1b = "書籍通巻{0:D6}B";
        const string Year = "発売年";
        const string valueFormat2 = "20{0:D2}";

        const int PrefixLength = 10;

        public TestBookSearcher02()
        {
            BookColumnSetting.Rows.Add(BookTitle, valueFormat1a, "書籍名");
            ScrapingColumnSetting.Rows.Add(BookTitle, valueFormat1b, "書籍名");

            BookColumnSetting.Rows.Add(Year, valueFormat2, "出版年");
            ScrapingColumnSetting.Rows.Add(Year, valueFormat2, "出版年");

            dataAscA = CreateDataAsc(ROW_COUNT, BookTitle, Year, valueFormat1a, valueFormat2);
            dataDescA = CreateDataDesc(ROW_COUNT, BookTitle, Year, valueFormat1a, valueFormat2);
            dataAscB = CreateDataAsc(ROW_COUNT, BookTitle, Year, valueFormat1b, valueFormat2);
            dataDescB = CreateDataDesc(ROW_COUNT, BookTitle, Year, valueFormat1b, valueFormat2);
            dataDiff1A = CreateDataAsc(ROW_COUNT + 1, BookTitle, Year, valueFormat1a, valueFormat2);
            dataDiff2A = CreateDataDesc(ROW_COUNT + 1, BookTitle, Year, valueFormat1a, valueFormat2);
            dataDiff1B = CreateDataAsc(ROW_COUNT + 1, BookTitle, Year, valueFormat1b, valueFormat2);
            dataDiff2B = CreateDataDesc(ROW_COUNT + 1, BookTitle, Year, valueFormat1b, valueFormat2);
        }

        [TestMethod]
        public void TestMatchingAscVsAsc()
        {
            var books = dataAscA;
            var scrapings = dataAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher02();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingAscVsDesc()
        {
            var books = dataAscA;
            var scrapings = dataDescB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher02();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows1()
        {
            var books = dataDescB;
            var scrapings = dataDiff1A;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher02();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows2()
        {
            var books = dataDiff2A;
            var scrapings = dataAscB;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher02();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffRows3()
        {
            var books = dataDescA;
            var scrapings = dataDiff2B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher02();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn11()
        {
            var books = dataAscA;
            var scrapings = CreateDataAsc(ROW_COUNT, BookTitle, Year, valueFormat1b, valueFormat2);
            var i = scrapings.MemoryTable.Count;
            var row = new MemoryRow(scrapings.MemoryTable, i, new string[] { i.ToString(valueFormat1b + "!"), i.ToString(valueFormat2) });
            scrapings.MemoryTable.TryAdd(i, row);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher02();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn12()
        {
            var books = dataAscB;
            var scrapings = CreateDataAsc(ROW_COUNT, BookTitle, Year, valueFormat1b, valueFormat2);
            var i = scrapings.MemoryTable.Count;
            var row = new MemoryRow(scrapings.MemoryTable, i, new string[] { i.ToString(valueFormat1b), i.ToString(valueFormat2 + "!") });
            scrapings.MemoryTable.TryAdd(i, row);
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher02();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn21()
        {
            var books = CreateDataAsc(ROW_COUNT, BookTitle, Year, valueFormat1a, valueFormat2);
            var i = books.MemoryTable.Count;
            var row = new MemoryRow(books.MemoryTable, i, new string[] { i.ToString(valueFormat1a + "!"), i.ToString(valueFormat2) });
            books.MemoryTable.TryAdd(i, row);
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher02();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT + 1, BookSearcher.ResultTable.Rows.Count);
        }

        [TestMethod]
        public void TestMatchingDiffColumn22()
        {
            var books = CreateDataAsc(ROW_COUNT, BookTitle, Year, valueFormat1b, valueFormat2);
            var i = books.MemoryTable.Count;
            var row = new MemoryRow(books.MemoryTable, i, new string[] { i.ToString(valueFormat1b), i.ToString(valueFormat2 + "!") });
            books.MemoryTable.TryAdd(i, row);
            var scrapings = dataDiff1B;
            BookSearcher.InitSearchSettings(books, scrapings, SpaceMatch.All, PrefixLength);
            searcher = new BookSearcher02();
            searcher.Search();
            Assert.AreEqual(ROW_COUNT, BookSearcher.ResultTable.Rows.Count);
        }
    }
}
