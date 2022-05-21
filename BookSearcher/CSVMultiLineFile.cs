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
            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new TextFieldParser(memoryMappedViewStream, FileEncoding))
            {
                reader.SetDelimiters(",");
                Titles = reader.ReadFields();
                Columns = Titles.Length;
                Fields = reader.ReadFields();
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
            using (var reader = new TextFieldParser(Path, FileEncoding))
            {
                reader.SetDelimiters(",");
                _ = reader.ReadFields();
                while (!reader.EndOfData)
                {
                    AddTableRow(reader.ReadFields());
                }
            }
        }
    }
}
