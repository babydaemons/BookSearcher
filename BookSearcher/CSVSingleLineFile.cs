using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSearcher
{
    internal class CSVSingleLineFile : CSVFile
    {
        // https://www.ipentec.com/document/csharp-read-csv-file-by-regex
        private static readonly Regex regex_delimiter = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
        private static readonly Regex regex_suffix = new Regex("(?<suffix>,+\\s*)$");

        private string eraseSuffix = "";

        public CSVSingleLineFile(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            using (var stream = new StreamReader(Path, FileEncoding))
            {
                var line = stream.ReadLine();
                var match = regex_suffix.Match(line);
                if (match.Success)
                {
                    eraseSuffix = match.Groups["suffix"].Value;
                    line = line.Replace(eraseSuffix, "");
                }
                Titles = ReadFields(line);
                Columns = Titles.Length;
                line = ReadLine(stream);
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
            int N = Program.Debugging ? 1 : Environment.ProcessorCount;
            var offsets = new List<long>();
            using (var file = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                long offset = 0;
                offsets.Add(offset);
                byte[] bytes = new byte[1024 * 1024];
                while (file.Position < file.Length)
                {
                    int readBytes = file.Read(bytes, 0, bytes.Length);
                    for (int i = 0; i < readBytes; i++)
                    {
                        if (bytes[i] == (byte)'\n')
                        {
                            offsets.Add(offset + i + 1);
                        }
                    }
                    offset = file.Position;
                }
            }

            int start = 1;
            int n = (offsets.Count - start) / N + 1;
            var partRecords = new List<List<string[]>>(N);
            for (int i = 0; i < N; i++)
            {
                partRecords.Add(new List<string[]>(n));
            }
            Records.Capacity = offsets.Count;

            Parallel.For(0, N, k =>
            {
                using (var file = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    var bytes = new byte[1024 * 1024];
                    for (int i = start + k; i < offsets.Count; i += N)
                    {
                        if (i + 1 == offsets.Count)
                        {
                            break;
                        }
                        file.Position = offsets[i];
                        int length = (int)(offsets[i + 1] - offsets[i]);
                        file.Read(bytes, 0, length);
                        using (var buffer = new MemoryStream(bytes, 0, length))
                        {
                            using (var reader = new StreamReader(buffer, FileEncoding))
                            {
                                partRecords[k].Add(ReadFields(regex_suffix.Replace(reader.ReadLine(), "")));
                            }
                        }
                    }
                }
            });

            for (int i = 0; i < N; i++)
            {
                Records.AddRange(partRecords[i]);
            }
        }

        private string ReadLine(StreamReader reader)
        {
            var line = reader.ReadLine();
            if (line != null && eraseSuffix.Length > 0)
            {
                line = line.Replace(eraseSuffix, "");
            }
            return line;
        }

        private string[] ReadFields(string line)
        {
            bool quoted = line.IndexOf("\",") != -1 || line.IndexOf(",\"") != -1;
            string[] fields = quoted ? regex_delimiter.Split(line) : line.Split(',');
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
