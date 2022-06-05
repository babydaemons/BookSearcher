using System;
using System.ComponentModel;
using BookSearcherApp;

namespace BookSearcherTest
{
    internal class TestCSVData : CSVData
    {
        public override void ReadAll(BackgroundWorker backgoundworker)
        {
            throw new NotImplementedException();
        }

        protected override void CountLines()
        {
            throw new NotImplementedException();
        }
    }
}
