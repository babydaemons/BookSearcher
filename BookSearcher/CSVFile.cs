using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace BookSearcher
{
    enum RecordType { SingleLine, MultiLine };

    internal class CSVFile
    {
        // https://www.ipentec.com/document/csharp-read-csv-file-by-regex
        private static readonly Regex regex_delimiter = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

        public string Path { get; }
        public RecordType RecordType { get; }
        public int Columns { get; private set; }
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
                        Titles = EraseEmptyTitle(ReadFields(line));
                        Columns = Titles.Length;
                        line = stream.ReadLine();
                        Fields = ExtractLimittedField(ReadFields(line), Columns);
                    }
                }
                else
                {
                    using (var reader = new TextFieldParser(path, Encoding.GetEncoding(932)))
                    {
                        reader.SetDelimiters(",");
                        Titles = EraseEmptyTitle(reader.ReadFields());
                        Columns = Titles.Length;
                        Fields = ExtractLimittedField(reader.ReadFields(), Columns);
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
                    using (var reader = new StreamReader(Path, Encoding.GetEncoding(932)))
                    {
                        var line = reader.ReadLine();
                        _ = ReadFields(line);
                        while ((line = reader.ReadLine()) != null)
                        {
                            Records.Add(ExtractLimittedField(ReadFields(line), Columns));
                        }
                    }
                }
                else
                {
                    using (var reader = new TextFieldParser(Path, Encoding.GetEncoding(932)))
                    {
                        reader.SetDelimiters(",");
                        _ = reader.ReadFields();
                        while (!reader.EndOfData)
                        {
                            Records.Add(ExtractLimittedField(reader.ReadFields(), Columns));
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
            string[] fields = regex_delimiter.Split(line);
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

        public static string[] EraseEmptyTitle(string[] origTitles)
        {
            int columns = 0;
            foreach (string title in origTitles)
            {
                if (title.Length == 0)
                {
                    break;
                }
                ++columns;
            }
            var titles = new string[columns];
            for (int i = 0; i < columns; i++)
            {
                titles[i] = origTitles[i].Trim();
            }
            return titles;
        }

        public static string[] ExtractLimittedField(string[] origFiealds, int columns)
        {
            string[] fields = new string[columns];
            for (int i = 0; i < columns; i++)
            {
                fields[i] = origFiealds[i].Trim();
            }
            return fields;
        }
    }
}
