using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace BookSearcherApp
{
    internal class CSVKoshoFile : CSVFileSplitInfoMultiLine
    {
        private readonly CultureInfo culture;
        protected override Regex[] Url => new Regex[] { new Regex(@"https://www.kosho.or.jp/products/") };
        protected override Regex RegexInfoDelimiter => new Regex(@"\s+、");
        private static readonly Regex RegexYear = new Regex(@"^(?<year>([1１][9９]|[2２][0０])[0-9０-９][0-9０-９])");
        private static readonly Regex RegexJYear = new Regex(@"^(?<year>(明治|大正|昭和|平成|令和)[1-9１-９][0-9０-９]?)");
        private static readonly Regex RegexJYear2 = new Regex(@"^(?<era>[明大昭平令])(?<year>[1-9１-９][0-9０-９]?)");
        private static readonly string search_published_year_min = "search_published_year_min=";
        private static readonly string search_published_year_max = "&search_published_year_max";
        private int urlIndex = -1;

        public CSVKoshoFile(string path) : base(path)
        {
            culture = new CultureInfo("ja-JP", true);
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
        }

        protected override void InsertTitleColums(List<string> titles)
        {
            var titleBase = titles[infoIndex];
            titles.Insert(infoIndex + 1, $"{titleBase}/出版年");
            titles.Insert(infoIndex + 1, $"{titleBase}/出版社");
            titles.Insert(infoIndex + 1, $"{titleBase}/著者");

            urlIndex = Enumerable.Range(0, titles.Count).Where(i => titles[i] == "ページURL").First();
            var urlBase = titles[urlIndex];
            titles.Insert(urlIndex + 1, $"{urlBase}/出版年");
        }

        protected override void InsertInfoColumn(List<string> fields, string[] infos)
        {
            fields.Insert(infoIndex + 1, ParseYear(infos));
            fields.Insert(infoIndex + 1, infos[0].StartsWith("、") ? infos[0].Substring(1) : (infos.Length > 1 ? infos[1] : ""));
            fields.Insert(infoIndex + 1, infos[0].StartsWith("、") ? "" : infos[0]);

            var url = fields[urlIndex];
            var yearStart = url.IndexOf(search_published_year_min) + search_published_year_min.Length;
            var year = url.Substring(yearStart, url.IndexOf(search_published_year_max) - yearStart);
            fields.Insert(urlIndex + 1, year);
        }

        private string ParseYear(string[] infos)
        {
            foreach (var info in infos)
            {
                var match_year = RegexYear.Match(info);
                if (match_year.Success)
                {
                    var year = match_year.Groups["year"].Value;
                    ConertWideDigits(ref year);
                    return year;
                }
                var match_jyear = RegexJYear.Match(info);
                if (match_jyear.Success)
                {
                    var year = match_jyear.Groups["year"].Value + "年";
                    ConertWideDigits(ref year);
                    if (DateTime.TryParseExact(year, "ggyy年", culture, DateTimeStyles.AssumeLocal, out DateTime date))
                    {
                        year = date.Year.ToString();
                    }
                    return year;
                }
                var match_jyear2 = RegexJYear2.Match(info);
                if (match_jyear2.Success)
                {
                    var era = match_jyear2.Groups["era"].Value;
                    era = era.Replace("明", "明治");
                    era = era.Replace("大", "大正");
                    era = era.Replace("昭", "昭和");
                    era = era.Replace("平", "平成");
                    era = era.Replace("令", "令和");
                    var year = era + match_jyear2.Groups["year"].Value + "年";
                    ConertWideDigits(ref year);
                    if (DateTime.TryParseExact(year, "ggyy年", culture, DateTimeStyles.AssumeLocal, out DateTime date))
                    {
                        year = date.Year.ToString();
                    }
                    return year;
                }
            }
            return "";
        }
    }
}
