using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSearcherApp
{
    internal class CSVSingleLineFile : CSVFile
    {
        // https://www.ipentec.com/document/csharp-read-csv-file-by-regex
        protected static readonly Regex RegexDelimiter = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
        protected static readonly Regex RegexSuffix = new Regex("(?<suffix>,+\\s*)$");

        public CSVSingleLineFile(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new StreamReader(memoryMappedViewStream, FileEncoding))
            {
                var line = RegexSuffix.Replace(reader.ReadLine(), "");
                Titles = ReadFields(line);
                ColumnCount = Titles.Length;
                line = RegexSuffix.Replace(reader.ReadLine(), "");
                Fields = ReadFields(line);
                if (Fields.Length == Titles.Length)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void DoReadAll()
        {
            DoReadPart(0);
        }

        private void DoReadPart(int n)
        {
            int N = 1;
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
                    var fields = ReadFields(line);
                    AddTableRow(rowIndex++, fields);
                }
            }
        }

        public static string[] ReadFields(string line)
        {
            bool quoted = line.IndexOf("\",") != -1 || line.IndexOf(",\"") != -1;
            string[] fields = quoted ? RegexDelimiter.Split(line) : line.Split(',');
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].StartsWith("\"") && fields[i].EndsWith("\""))
                {
                    fields[i] = fields[i].Substring(1, fields[i].Length - 2);
                    fields[i] = fields[i].Replace("\"\"", "");
                }
                fields[i] = fields[i].Trim();
            }
            return fields;
        }
    }
}
