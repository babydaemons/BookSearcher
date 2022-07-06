using System;
using System.Data;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;
using System.Windows.Forms;

namespace BookSearcherTest
{
    public class DummyCSVSaver : CSVSaver
    {
        public DummyCSVSaver(DataGridView view, string path) : base(view, path)
        {
        }

        public override string[] Titles => new string[] { "AAA,BBB", "CCC,DDD" };

        public override int ColumnIndexPrice => -1;

        public override int ColumnIndexISBN => -1;
    }

    [TestClass]
    public class TestCSVSaver : Form1
    {
        [TestMethod]
        public void TestCalcSalingPrice00000()
        {
            Assert.AreEqual(0, CSVSaver.CalcSellingPrice(0));
        }

        [TestMethod]
        public void TestCalcSalingPrice00001()
        {
            Assert.AreEqual(1532, CSVSaver.CalcSellingPrice(1));
        }

        [TestMethod]
        public void TestCalcSalingPrice03000()
        {
            Assert.AreEqual(6430, CSVSaver.CalcSellingPrice(3000));
        }

        [TestMethod]
        public void TestCalcSalingPrice03001()
        {
            Assert.AreEqual(6477, CSVSaver.CalcSellingPrice(3001));
        }

        [TestMethod]
        public void TestCalcSalingPrice05000()
        {
            Assert.AreEqual(9764, CSVSaver.CalcSellingPrice(5000));
        }

        [TestMethod]
        public void TestCalcSalingPrice05001()
        {
            Assert.AreEqual(9971, CSVSaver.CalcSellingPrice(5001));
        }

        [TestMethod]
        public void TestCalcSalingPrice10000()
        {
            Assert.AreEqual(18364, CSVSaver.CalcSellingPrice(10000));
        }

        [TestMethod]
        public void TestCalcSalingPrice10001()
        {
            Assert.AreEqual(18743, CSVSaver.CalcSellingPrice(10001));
        }

        [TestMethod]
        public void TestCalcSalingPrice20000()
        {
            Assert.AreEqual(35876, CSVSaver.CalcSellingPrice(20000));
        }

        [TestMethod]
        public void TestCalcSalingPrice20001()
        {
            Assert.AreEqual(36600, CSVSaver.CalcSellingPrice(20001));
        }

        [TestMethod]
        public void TestWrite()
        {
            var view = DataGridViewCommonOutput2;
            view.Rows[0].Cells[2].Value = "NH";
            view.Rows[1].Cells[2].Value = "X";

            var table = new DataTable();
            table.Columns.Add("AAA,BBB", typeof(string));
            table.Columns.Add("CCC,DDD", typeof(string));

            var row1 = table.NewRow();
            row1[0] = "111,222";
            row1[1] = "333,444";
            table.Rows.Add(row1);

            var row2 = table.NewRow();
            row2[0] = "aaa\nbbb";
            table.Rows.Add(row2);

            var path = DateTime.Now.ToString("yyyyMMddhhmmssfffff") + ".csv";
            using (var writer = new DummyCSVSaver(view, path))
            {
                writer.Write(table);
            }

            using (var reader = new CSVReader(path))
            {
                var titles = reader.ReadValueFields(2);
                Assert.AreEqual(table.Columns[0].ColumnName, titles[0]);
                Assert.AreEqual(table.Columns[1].ColumnName, titles[1]);

                var values0 = reader.ReadValueFields(2);
                Assert.AreEqual((string)table.Rows[0][0], values0[0]);
                Assert.AreEqual((string)table.Rows[0][1], values0[1]);

                var values1 = reader.ReadValueFields(2);
                Assert.AreEqual((string)table.Rows[1][0], values1[0]);
                Assert.AreEqual("", values1[1]);
            }

            File.Delete(path);
        }
    }
}
