﻿using Microsoft.VisualBasic.FileIO;

namespace BookSearcher
{
    internal class CSVMultiLineFile : CSVFile
    {
        public CSVMultiLineFile(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            using (var reader = new TextFieldParser(Path, FileEncoding))
            {
                reader.SetDelimiters(",");
                Titles = reader.ReadFields();
                Columns = Titles.Length;
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
