using System.Data;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;
using ExcelDataReader;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace BookSearcherApp
{
    public class ExcelFile : CSVFile
    {
        private IExcelDataReader excelReader;
        private DataSet dataSet;
        private int rowCount;
        private const int READ_END = 75;

        public ExcelFile(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            return true;
        }

        public override void ReadAll(BackgroundWorker backgoundworker, DataIOProgressBar progressBar)
        {
            StartIO(backgoundworker, progressBar);

            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            {
                var task = new Task(() =>
                {
                    excelReader = ExcelReaderFactory.CreateReader(memoryMappedViewStream);
                    dataSet = excelReader.AsDataSet();
                });

                task.Start();
                while (!task.IsCompleted)
                {
                    Thread.Sleep(100);
                    var progress = (int)(READ_END * DIV_VALUE * memoryMappedViewStream.Position / memoryMappedViewStream.Length);
                    ReportProgress(progress);
                }
                task.Wait();
            }
            rowCount = dataSet.Tables[0].Rows.Count;

            ReadHeader();
            AllocateTable();

            DoReadAll();

            StopIO();
            Debug.WriteLine($"{Path} - {CurrentProgress}");
        }

        private void ReadHeader()
        {
            // フィールド名を取得
            var columnCount = dataSet.Tables[0].Rows[0].ItemArray.Length;
            var titles = new List<string>();
            foreach (var j in Enumerable.Range(0, columnCount))
            {
                var title = dataSet.Tables[0].Rows[0].ItemArray[j].ToString();
                if (string.IsNullOrEmpty(title)) { break; }
                titles.Add(title);
            }
            Titles = titles.ToArray();
            ColumnCount = Titles.Length;

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

        protected override void DoReadAll()
        {
            int rowIndex = 0;

            // データを行単位で取得
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (rowIndex++ == 0) { continue; }
                var fields = new string[ColumnCount];
                foreach (var j in Enumerable.Range(0, ColumnCount))
                {
                    fields[j] = row.ItemArray[j].ToString();
                }
                AddTableRow(rowIndex, rowCount, fields, READ_END * DIV_VALUE, MAX_VALUE);
            }
        }
    }
}
