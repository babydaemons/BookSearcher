using System;
using System.ComponentModel;
using BookSearcherApp;

namespace BookSearcherTest
{
    internal class TestCSVData : CSVData
    {
        public override void ReadAll(BackgroundWorker backgoundworker, FileIOProgressBar progressBar)
        {
            throw new NotImplementedException();
        }

        protected override void Close()
        {
        }
    }
}
