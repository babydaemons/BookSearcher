namespace BookSearcherApp
{
    internal class CSVMultiLineFile : CSVFile
    {
        protected int TitlesRowCount = -1;

        public CSVMultiLineFile(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new CSVReader(memoryMappedViewStream, FileEncoding))
            {
                Titles = reader.ReadTitleFields();
                TitlesRowCount = Titles.Length;
                ColumnCount = Titles.Length;
                Fields = reader.ReadValueFields(TitlesRowCount);
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
            using (var reader = new CSVReader(memoryMappedViewStream, FileEncoding))
            {
                _ = reader.ReadTitleFields();
                while (!reader.EndOfData)
                {
                    AddTableRow(memoryMappedViewStream, reader.ReadValueFields(TitlesRowCount));
                }
            }
        }
    }
}
