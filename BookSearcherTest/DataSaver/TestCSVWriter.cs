﻿using System;
using System.IO;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearcherApp;

namespace BookSearcherTest
{
    [TestClass]
    public class TestCSVWriter
    {
        [TestMethod]
        public void TestWrite()
        {
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
            CSVWriter.Write(path, table);

            using (var reader = new TextFieldParser(path))
            {
                reader.SetDelimiters(",");
                var titles = reader.ReadFields();
                Assert.AreEqual(table.Columns[0].ColumnName, titles[0]);
                Assert.AreEqual(table.Columns[1].ColumnName, titles[1]);

                var values0 = reader.ReadFields();
                Assert.AreEqual((string)table.Rows[0][0], values0[0]);
                Assert.AreEqual((string)table.Rows[0][1], values0[1]);

                var values1 = reader.ReadFields();
                Assert.AreEqual((string)table.Rows[1][0], values1[0]);
                Assert.AreEqual("", values1[1]);
            }

            File.Delete(path);
        }
    }
}
