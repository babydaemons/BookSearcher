using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSearcher
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
                Columns = Titles.Length;
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
            var N = Environment.ProcessorCount;
            var M = 4096;
            var linesCount = N * M;
            var lines = new string[linesCount];
            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new StreamReader(memoryMappedViewStream, FileEncoding))
            {
                var line = reader.ReadLine();
                var iteration = 0;
                while (!reader.EndOfStream)
                {
                    var count = 0;
                    while ((lines[count] = reader.ReadLine()) != null && count < N)
                    {
                        count++;
                    }
                    _ = Parallel.For(0, N, n =>
                    {
                        for (int i = 0; i < M; ++i)
                        {
                            var k = n * M + i;
                            var rowIndex = iteration * linesCount + k;
                            if (k >= count)
                            {
                                break;
                            }
                            lines[k] = RegexSuffix.Replace(lines[k], "");
                            var fields = ReadFields(lines[k]);
                            AddTableRow(rowIndex, fields);
                        }
                    });
                    ++iteration;
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
            }
            return fields;
        }
    }
}
