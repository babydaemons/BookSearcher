using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSearcher
{
    internal abstract class CSVFileSplitInfoSingleLine : CSVFileSplitInfo
    {
        // https://www.ipentec.com/document/csharp-read-csv-file-by-regex
        protected static readonly Regex RegexDelimiter = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
        protected static readonly Regex RegexSuffix = new Regex("(?<suffix>,+\\s*)$");

        public CSVFileSplitInfoSingleLine(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            if (!IsMatchUrl())
            {
                return false;
            }

            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new StreamReader(memoryMappedViewStream, FileEncoding))
            {
                var line = RegexSuffix.Replace(reader.ReadLine(), "");
                var titles = new List<string>(CSVSingleLineFile.ReadFields(line));
                line = RegexSuffix.Replace(reader.ReadLine(), "");
                var fields = new List<string>(CSVSingleLineFile.ReadFields(line));
                DetectInfoColumn(fields);
                InsertTitleColums(titles);
                InsertInfoColumn(fields);
                Titles = titles.ToArray();
                Fields = fields.ToArray();
                if (Fields.Length == Titles.Length)
                {
                    Columns = Titles.Length;
                    return true;
                }
            }
            return false;
        }

        protected override void DoReadAll()
        {
            var N = Environment.ProcessorCount;
            _ = Parallel.For(0, N, n => DoReadPart(n));
        }

        private void DoReadPart(int n)
        {
            int N = Environment.ProcessorCount;
            int partLines = LineOffsets.Length / N;
            long start = LineOffsets[n * partLines];
            long end = n < N - 1 ? LineOffsets[(n + 1) * partLines] : fileSize;
            long size = end - start;
            int rowIndex = n * partLines;
            using (var memoryMappedViewStream = GetMemoryMappedViewStream(start, size))
            using (var reader = new StreamReader(memoryMappedViewStream, FileEncoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = RegexSuffix.Replace(line, "");
                    var fields = new List<string>(CSVSingleLineFile.ReadFields(line));
                    InsertInfoColumn(fields);
                    AddTableRow(rowIndex++, fields.ToArray());
                }
            }
        }
    }
}
