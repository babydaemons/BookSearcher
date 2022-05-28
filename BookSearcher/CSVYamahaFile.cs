using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BookSearcherApp
{
    internal class CSVYamahaFile : CSVFileSplitInfoQuotedLine
    {
        protected override Regex[] Url => new Regex[] { new Regex("https://webshop.yamahamusic.jp/domestic/products/") };
        protected override Regex RegexInfoDelimiter => null;
        protected override bool DoDeleteTailFields => true;

        public CSVYamahaFile(string path) : base(path)
        {
        }

        protected override void InsertTitleColums(List<string> titles)
        {
            ColumnCount = 0;
            while (titles[ColumnCount].Length > 0)
            {
                ++ColumnCount;
            }
            DeleteTailFields(titles);
        }

        protected override void InsertInfoColumn(List<string> fields, string[] infos)
        {
        }
    }
}
