using Microsoft.VisualBasic.FileIO;

namespace BookSearcher
{
    internal class CSVMultiLineFile : CSVFile
    {
        public CSVMultiLineFile(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            bool result = false;
            using (var reader = new TextFieldParser(Path, FileEncoding))
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

        protected override void DoReadAll()
        {
            using (var reader = new TextFieldParser(Path, FileEncoding))
            {
                reader.SetDelimiters(",");
                _ = reader.ReadFields();
                while (!reader.EndOfData)
                {
                    Records.Add(reader.ReadFields());
                }
            }
        }
    }
}
