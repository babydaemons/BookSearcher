using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace BookSearcher
{
    internal abstract class CSVFileSplitInfoMultiLine : CSVFileSplitInfo
    {
        public CSVFileSplitInfoMultiLine(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            if (!IsMatchUrl())
            {
                return false;
            }

            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new TextFieldParser(memoryMappedViewStream, FileEncoding))
            {
                reader.SetDelimiters(",");
                var titles = new List<string>(reader.ReadFields());
                var fields = new List<string>(reader.ReadFields());
                DetectInfoColumn(fields);
                InsertTitleColums(titles);
                InsertInfoColumn(fields);
                Titles = titles.ToArray();
                Fields = fields.ToArray();
                if (Fields.Length == Titles.Length)
                {
                    Columns = Titles.Length;
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
                    var fields = new List<string>(reader.ReadFields());
                    InsertInfoColumn(fields);
                    AddTableRow(fields.ToArray());
                }
            }
        }
    }
}
