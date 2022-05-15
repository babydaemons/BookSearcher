using System;
using Microsoft.VisualBasic.FileIO;

namespace BookSearcher
{
    internal class CSVMercariFile : CSVFile
    {
        private static readonly string[] mercari_delimiter = new string[] { "=\"", "\" " };

        public CSVMercariFile(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            using (var reader = new TextFieldParser(Path, FileEncoding))
            {
                reader.SetDelimiters(",");
                _ = reader.ReadFields();
                var fields = reader.ReadFields();
                foreach (var field in fields)
                {
                    if (field.StartsWith("<mer-item-thumbnail "))
                    {
                        Titles = ReadFields(fields[0], 0);
                        Fields = ReadFields(fields[0], 1);
                        Columns = Titles.Length;
                        return true;
                    }
                }
            }
            return false;
        }

        protected override void DoReadAll()
        {
            using (var reader = new TextFieldParser(Path, FileEncoding))
            {
                reader.SetDelimiters(",");
                _ = reader.ReadFields();
                var fields = reader.ReadFields();
                Records.Add(ReadFields(fields[0], 1));
                Columns = Titles.Length;
            }
        }

        private string[] ReadFields(string line, int offset)
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
