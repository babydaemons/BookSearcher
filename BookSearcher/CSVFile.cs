using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace BookSearcher
{
    enum RecordType { SingleLine, MultiLine };

    internal class CSVFile
    {
        private static readonly string[] FieldSeparatorWithQuote = new string[] { "\",\"" };

        public string Path { get; }
        public RecordType RecordType { get; }
        public string[] Titles { get; private set; }
        public string[] Fields { get; }
        public List<string[]> Records { get; private set; }

        public CSVFile(string path, RecordType recordType)
        {
            Path = path;
            RecordType = recordType;

            try
            {
                if (recordType == RecordType.SingleLine)
                {
                    using (var stream = new StreamReader(path, Encoding.GetEncoding(932)))
                    {
                        var line = stream.ReadLine();
                        Titles = ReadFields(line);
                        line = stream.ReadLine();
                        Fields = ReadFields(line);
                    }
                }
                else
                {
                    using (var reader = new TextFieldParser(path, Encoding.GetEncoding(932)))
                    {
                        reader.SetDelimiters(",");
                        Titles = reader.ReadFields();
                        Fields = reader.ReadFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ReadAll()
        {
            try
            {
                Records = new List<string[]>();
                if (RecordType == RecordType.SingleLine)
                {
                    using (var stream = new StreamReader(Path, Encoding.GetEncoding(932)))
                    {
                        var line = stream.ReadLine();
                        Titles = ReadFields(line);
                        while ((line = stream.ReadLine()) != null)
                        {
                            Records.Add(ReadFields(line));
                        }
                    }
                }
                else
                {
                    using (var reader = new TextFieldParser(Path, Encoding.GetEncoding(932)))
                    {
                        reader.SetDelimiters(",");
                        Titles = reader.ReadFields();
                        while (!reader.EndOfData)
                        {
                            string[] fields = reader.ReadFields();
                            Records.Add(fields);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string[] ReadFields(string line)
        {
            string[] fields;
            if (line.StartsWith("\"") && line.EndsWith("\""))
            {
                line = line.Substring(1, line.Length - 2);
                fields = line.Split(FieldSeparatorWithQuote, StringSplitOptions.None);
                for (int i = 0; i < fields.Length; i++)
                {
                    fields[i] = fields[i].Trim();
                    fields[i] = fields[i].Replace("\"\"", "");
                }
            }
            else
            {
                fields = line.Split(',');
            }
            return fields;
        }
    }
}
