using System;

namespace BookSearcherApp
{
    internal class CSVMercariFile : CSVFile
    {
        private static readonly string[] mercari_delimiter = new string[] { "=\"", "\" " };

        public CSVMercariFile(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            try
            {
                using (var memoryMappedViewStream = GetMemoryMappedViewStream())
                using (var reader = new CSVReader(memoryMappedViewStream, FileEncoding))
                {
                    _ = reader.ReadFields();
                    var fields = reader.ReadFields();
                    foreach (var field in fields)
                    {
                        if (field.StartsWith("<mer-item-thumbnail "))
                        {
                            Titles = ReadFields("生データ", fields[0], 0);
                            Fields = ReadFields(fields[0], fields[0], 1);
                            ColumnCount = Titles.Length;
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Close();
                throw new MyException("CSVファイル読込エラー", Path, ex);
            }
        }

        protected override void DoReadAll()
        {
            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new CSVReader(memoryMappedViewStream, FileEncoding))
            {
                _ = reader.ReadFields();
                while (!reader.EndOfData)
                {
                    var fields = reader.ReadFields();
                    AddTableRow(memoryMappedViewStream, ReadFields(fields[0], fields[0], 1));
                }
            }
        }

        private string[] ReadFields(string raw_data, string parse_data, int offset)
        {
            parse_data = parse_data.Replace("<mer-item-thumbnail ", "");
            parse_data = parse_data.Replace("radius=\"\" mer-defined=\"\"></mer-item-thumbnail>", "");
            string[] pairs = parse_data.Split(mercari_delimiter, StringSplitOptions.RemoveEmptyEntries);
            string[] fields = new string[pairs.Length / 2 + 1];
            fields[0] = raw_data;
            for (int i = 0; i < pairs.Length; i += 2)
            {
                fields[i / 2 + 1] = pairs[i + offset];
            }
            return fields;
        }
    }
}
