using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
                    CreateTable();
                    return true;
                }
            }
            return false;
        }

        protected override void DoReadAll()
        {
            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new StreamReader(memoryMappedViewStream, FileEncoding))
            {
                var line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    line = RegexSuffix.Replace(line, "");
                    var fields = ReadFields(line);
                    AddTableRow(fields);
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
