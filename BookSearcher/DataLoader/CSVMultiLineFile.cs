using Microsoft.VisualBasic.FileIO;

namespace BookSearcherApp
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
                ColumnCount = Titles.Length;
                Fields = reader.ReadFields();
                if (Fields.Length == Titles.Length)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void DoReadAll()
        {
            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new TextFieldParser(memoryMappedViewStream, FileEncoding))
            {
                reader.SetDelimiters(",");
                _ = reader.ReadFields();
                while (!reader.EndOfData)
                {
                    AddTableRow(memoryMappedViewStream, reader.ReadFields());
                }
            }
        }
    }
}
