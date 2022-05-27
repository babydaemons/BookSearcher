using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookSearcherApp
{
    internal class CSVRakutenIchibaFile : CSVFileSplitInfoSingleLine
    {
        protected override Regex[] Url => new Regex[] { new Regex("https://item.rakuten.co.jp/") };
        protected override Regex RegexInfoDelimiter => new Regex(@"\s*/\s*");
        protected override bool DoDeleteTailFields => false;
        private static readonly Regex RegexUsed = new Regex(@"^【中古】\s*");
        private static readonly Regex RegexBookType = new Regex(@"\s*[\[\(](単行本|新書|ハードカバー|ソフトカバー)[^\]\)]*[\]\)].*");

        public CSVRakutenIchibaFile(string path) : base(path)
        {
        }

        protected override void InsertTitleColums(List<string> titles)
        {
            var titleBase = titles[infoIndex];
            titles[infoIndex] += "/出版社";
            titles.Insert(infoIndex, $"{titleBase}/著者");
            titles.Insert(infoIndex, $"{titleBase}/書籍名");
        }

        protected override void InsertInfoColumn(List<string> fields, string[] infos)
        {
            fields[infoIndex] = infos.Length > 2 ? RegexBookType.Replace(infos[2], "") : "";
            fields.Insert(infoIndex, infos.Length > 1 ? infos[1] : "");
            fields.Insert(infoIndex, RegexUsed.Replace(infos[0], ""));
        }
    }
}
