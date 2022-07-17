using System.Collections.Generic;
using System.Linq;

namespace BookSearcherApp
{
    internal abstract class CSVFileSplitInfoQuotedLine : CSVFileSplitInfo
    {
        public CSVFileSplitInfoQuotedLine(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            if (!IsMatchUrl())
            {
                return false;
            }

            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new CSVReader(memoryMappedViewStream, FileEncoding))
            {
                var titles = new List<string>(reader.ReadTitleFields());
                TitleRowCount = titles.Count;
                var fields = new List<string>(reader.ReadValueFields(TitleRowCount));
                DetectInfoColumn(fields);
                InsertTitleColums(titles);
                InsertInfoColumn(fields);
                Titles = titles.ToArray();
                Fields = fields.ToArray();
                if (Fields.Length == Titles.Length)
                {
                    ColumnCount = Titles.Length;
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
                while (!reader.EndOfData)
                {
                    var fields = new List<string>(reader.ReadValueFields(TitleRowCount));
                    bool matched = fields.Any(field => { var match = Url[0].Match(field); return match.Success; });
                    if (matched)
                    {
                        InsertInfoColumn(fields);
                        AddTableRow(memoryMappedViewStream, fields.ToArray());
                    }
                }
            }
        }
    }
}
