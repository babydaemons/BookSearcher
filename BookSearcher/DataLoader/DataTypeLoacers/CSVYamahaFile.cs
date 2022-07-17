using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookSearcherApp
{
    internal class CSVYamahaFile : CSVFileSplitInfoQuotedLine
    {
        protected override Regex[] Url => new Regex[] { new Regex("https://webshop.yamahamusic.jp/domestic/products/") };
        protected override Regex RegexInfoDelimiter => new Regex(@"\s+");
        private readonly Regex RegexISBN = new Regex("ISBN(?<ISBN>978[0-9]{10})");
        private readonly Regex RegexJAN = new Regex("JAN(?<JAN>4[0-9]{12})");

        public CSVYamahaFile(string path) : base(path)
        {
        }

        protected override void InsertTitleColums(List<string> titles)
        {
            titles.Insert(2, $"{titles[1]}/在庫状態");
            titles.Insert(2, $"{titles[1]}/税込価格");
            titles.Insert(2, $"{titles[1]}/本体価格");
            titles.Add($"{titles[titles.Count - 1]}/JAN・ISBN");
        }

        protected override void InsertInfoColumn(List<string> fields, string[] infos)
        {
            var matchISBN = RegexISBN.Match(fields[3]);
            var ISBN = matchISBN.Success ? matchISBN.Groups["ISBN"].Value : "";
            var matchJAN = RegexJAN.Match(fields[3]);
            var JAN = matchJAN.Success ? matchJAN.Groups["JAN"].Value : "";
            fields.Insert(2, infos.Length > 6 ? infos[6] : "");
            fields.Insert(2, infos.Length > 3 ? infos[3].Replace(",", "") : "");
            fields.Insert(2, infos[0].Replace(",", ""));
            fields.Add(ISBN.Length > 0 ? ISBN : JAN);
        }
    }
}
