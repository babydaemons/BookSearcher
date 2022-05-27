using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookSearcherApp
{
    internal class CSVRakutenBooksFile : CSVFileSplitInfoSingleLine
    {
        protected override Regex[] Url => new Regex[] { new Regex("https://(product|books).rakuten.co.jp/") };
        protected override Regex RegexInfoDelimiter => new Regex(@" ／ ");
        protected override bool DoDeleteTailFields => false;
        private static readonly Regex RegexISBN = new Regex(@"^(ISBN：|インストアコード：|UPC/JAN：)");

        public CSVRakutenBooksFile(string path) : base(path)
        {
        }

        protected override void InsertTitleColums(List<string> titles)
        {
            var titleBase = titles[infoIndex];
            titles[infoIndex] += "/出版社";
            titles.Insert(infoIndex, $"{titleBase}/出版年");
        }

        protected override void InsertInfoColumn(List<string> fields, string[] infos)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                fields[i] = RegexISBN.Replace(fields[i], "");
            }
            fields[infoIndex] = infos.Length > 1 ? infos[1] : "";
            fields.Insert(infoIndex, infos[0].Substring(0, 4));
        }
    }
}
