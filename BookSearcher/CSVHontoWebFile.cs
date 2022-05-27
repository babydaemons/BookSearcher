using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BookSearcherApp
{
    internal class CSVHontoWebFile : CSVFileSplitInfoMultiLine
    {
        protected override Regex[] Url => new Regex[] { new Regex("https://honto.jp/netstore/"), new Regex(@"\s+税込価格："), new Regex(@"\s+出版社："), new Regex(@"\s+(発行年月|発売日)："), new Regex(@"\s+発送可能日：") };
        protected override Regex RegexInfoDelimiter => new Regex(@"\n\s*");
        protected override bool DoDeleteTailFields => false;
        private readonly Regex RegexRemovePrefixSpace = new Regex(@"^\s+");
        private readonly Regex RegexRemovePrefixPrice = new Regex(@"^\s*税込価格：");
        private readonly Regex RegexRemovePrefixPublisher = new Regex(@"^\s*出版社：");
        private readonly Regex RegexRemovePrefixYear = new Regex(@"^\s*(発行年月|発売日)：");
        private readonly Regex RegexRemovePrefixDelivery = new Regex(@"^\s*発送可能日：");

        public CSVHontoWebFile(string path) : base(path)
        {
        }

        protected override void InsertTitleColums(List<string> titles)
        {
            var titleBase = titles[infoIndex];
            titles[infoIndex] = $"{titleBase}/発送可能日";
            titles.Insert(infoIndex, $"{titleBase}/発売年");
            titles.Insert(infoIndex, $"{titleBase}/出版社");
            titles.Insert(infoIndex, $"{titleBase}/税込価格");
            titles.Insert(infoIndex, $"{titleBase}/著者");
            titles.Insert(infoIndex, $"{titleBase}/書籍名");
        }

        protected override void InsertInfoColumn(List<string> fields, string[] infos)
        {
            infos = infos.Where(info => !info.StartsWith("（レビュー：")).ToArray();

            var bookTitle = RegexRemovePrefixSpace.Replace(infos[0], "");
            var author = infos.Length == infoCount ? RegexRemovePrefixSpace.Replace(infos[1], "") : "";
            var price = MatchedValue(RegexRemovePrefixPrice, infos);
            var publisher = MatchedValue(RegexRemovePrefixPublisher, infos);
            var year = MatchedValue(RegexRemovePrefixYear, infos);
            if (year.Length > 4)
            {
                year = year.Substring(0, 4);
                ConertWideDigits(ref year);
            }
            var delivery = MatchedValue(RegexRemovePrefixDelivery, infos);

            fields[infoIndex] = delivery;
            fields.Insert(infoIndex, year);
            fields.Insert(infoIndex, publisher);
            fields.Insert(infoIndex, price);
            fields.Insert(infoIndex, author);
            fields.Insert(infoIndex, bookTitle);
        }
    }
}
