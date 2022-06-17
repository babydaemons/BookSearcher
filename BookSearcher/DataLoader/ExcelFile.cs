using System.Data;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;
using ExcelDataReader;

namespace BookSearcherApp
{
    internal class ExcelFile : CSVFile
    {
        MemoryMappedViewStream memoryMappedViewStream;
        IExcelDataReader excelReader;
        DataSet dataSet;

        public ExcelFile(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            return true;
        }

        public override void ReadAll(BackgroundWorker backgoundworker)
        {
            Loaded = false;
            this.backgoundworker = backgoundworker;
            backgoundworker.ReportProgress(0);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            memoryMappedViewStream = GetMemoryMappedViewStream();
            backgoundworker?.ReportProgress(5);
            excelReader = ExcelReaderFactory.CreateReader(memoryMappedViewStream);
            dataSet = excelReader.AsDataSet();
            memoryMappedViewStream.Dispose();
            memoryMappedViewStream = null;
            backgoundworker?.ReportProgress(40);

            ReadHeader();
            CountLines();
            DoReadAll();

            stopWatch.Stop();
            Debug.WriteLine($"{Path} - {stopWatch.Elapsed}");

            Loaded = true;

            backgoundworker?.ReportProgress(100);
        }

        private void ReadHeader()
        {
            // フィールド名を取得
            ColumnCount = dataSet.Tables[0].Rows[0].ItemArray.Length;
            Titles = new string[ColumnCount];
            foreach (var j in Enumerable.Range(0, ColumnCount))
            {
                Titles[j] = dataSet.Tables[0].Rows[0].ItemArray[j].ToString();
            }

            // データを行単位で取得
            var rowIndex = 0;
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (rowIndex++ == 0)
                {
                    continue;
                }

                var fields = new string[ColumnCount];
                foreach (var j in Enumerable.Range(0, ColumnCount))
                {
                    fields[j] = row.ItemArray[j].ToString();
                }
                bool isAllValid = fields.All(field => field.Length > 0);
                if (isAllValid)
                {
                    Fields = fields;
                    break;
                }
            }
        }

        protected override void CountLines()
        {
            rowCount = dataSet.Tables[0].Rows.Count;
            AllocateTable(rowCount);
        }

        protected override void DoReadAll()
        {
            rowIndex = 0;

            // データを行単位で取得
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var fields = new string[ColumnCount];
                foreach (var j in Enumerable.Range(0, ColumnCount))
                {
                    fields[j] = row.ItemArray[j].ToString();
                }
                AddTableRow(rowIndex++, fields, 40, 100);
            }
        }
    }
}
