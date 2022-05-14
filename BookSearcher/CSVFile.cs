using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace BookSearcher
{
    enum RecordType { Unknown, MercariLine, SingleLine, MultiLine };

    internal class CSVFile
    {
        // https://www.ipentec.com/document/csharp-read-csv-file-by-regex
        private static readonly Regex regex_delimiter = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
        private static readonly Regex regex_suffix = new Regex("(?<suffix>,+\\s*)$");

        private static readonly string[] mercari_delimiter = new string[] { "=\"", "\" " };

        public string Path { get; }
        public RecordType RecordType { get; private set; } = RecordType.Unknown;
        public int Columns { get; private set; }
        public string[] Titles { get; private set; }
        public string[] Fields { get; private set; }
        public List<string[]> Records { get; private set; }
        private string eraseSuffix = "";

        public CSVFile(string path, RecordType recordType)
        {
            Path = path;

            try
            {
                if (ParseTitleMercariLine())
                {
                    return;
                }
                else if (ParseTitleSingleLine())
                {
                    return;
                }
                else if (ParseTitleMultiLine())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("不正な形式のCSVファイルです。\n" + Path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ParseTitleSingleLine()
        {
            bool result = false;
            using (var stream = new StreamReader(Path, Encoding.UTF8))
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
                    RecordType = RecordType.SingleLine;
                    result = true;
                }
            }
            return result;
        }

        private bool ParseTitleMultiLine()
        {
            bool result = false;
            using (var reader = new TextFieldParser(Path, Encoding.UTF8))
            {
                reader.SetDelimiters(",");
                Titles = reader.ReadFields();
                Columns = Titles.Length;
                Fields = reader.ReadFields();
                if (Fields.Length == Titles.Length)
                {
                    RecordType = RecordType.MultiLine;
                    result = true;
                }
            }
            return result;
        }

        private bool ParseTitleMercariLine()
        {
            bool result = false;
            using (var reader = new TextFieldParser(Path, Encoding.UTF8))
            {
                reader.SetDelimiters(",");
                _ = reader.ReadFields();
                var fields = reader.ReadFields();
                foreach (var field in fields)
                {
                    if (field.StartsWith("<mer-item-thumbnail "))
                    {
                        RecordType = RecordType.MercariLine;
                        result = true;
                        break;
                    }
                }
                Titles = ReadMercariFields(fields[0], 0);
                Fields = ReadMercariFields(fields[0], 1);
                Columns = Titles.Length;
            }
            return result;
        }


        public void ReadAll()
        {
            try
            {
                Records = new List<string[]>();

                if (RecordType == RecordType.SingleLine)
                {
                    ReadAllSingleLine();
                }
                else
                {
                    ReadAllMultiLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadAllSingleLine()
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
                            using (var reader = new StreamReader(buffer, Encoding.UTF8))
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

        private void ReadAllMultiLine()
        {
            using (var reader = new TextFieldParser(Path, Encoding.UTF8))
            {
                reader.SetDelimiters(",");
                _ = reader.ReadFields();
                while (!reader.EndOfData)
                {
                    Records.Add(reader.ReadFields());
                }
            }
        }

        private void ReadAllMercariLine()
        {
            using (var reader = new TextFieldParser(Path, Encoding.UTF8))
            {
                reader.SetDelimiters(",");
                _ = reader.ReadFields();
                var fields = reader.ReadFields();
                Records.Add(ReadMercariFields(fields[0], 1));
                Columns = Titles.Length;
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

        private string[] ReadMercariFields(string line, int offset)
        {
            line = line.Replace("<mer-item-thumbnail ", "");
            line = line.Replace("radius=\"\" mer-defined=\"\"></mer-item-thumbnail>", "");
            string[] pairs = line.Split(mercari_delimiter, StringSplitOptions.RemoveEmptyEntries);
            string[] fields = new string[pairs.Length / 2];
            for (int i = 0; i < pairs.Length; i += 2)
            {
                fields[i / 2] = pairs[i + offset];
            }
            return fields;
        }
    }
}
