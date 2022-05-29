using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestCSVSaver
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
    }
}
