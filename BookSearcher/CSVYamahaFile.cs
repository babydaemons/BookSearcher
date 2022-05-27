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
            Columns = 0;
            while (titles[Columns].Length > 0)
            {
                ++Columns;
            }
            DeleteTailFields(titles);
        }

        protected override void InsertInfoColumn(List<string> fields, string[] infos)
        {
        }
    }
}
