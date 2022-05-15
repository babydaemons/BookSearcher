using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BookSearcher
{
    internal class CSVKoshoFile : CSVFileSplitInfoSingleLine
    {
        private readonly CultureInfo culture;
        protected override Regex Url => new Regex(@"https://www.kosho.or.jp/products/");
        protected override Regex RegexInfoDelimiter => new Regex(@"\s+、");
        private static readonly Regex RegexYear = new Regex(@"^(?<year>([1１][9９]|[2２][0０])[0-9０-９][0-9０-９])");
        private static readonly Regex RegexJYear = new Regex(@"^(?<year>(明治|大正|昭和|平成|令和)[1-9１-９][0-9０-９]?)");
        private static readonly Regex RegexJYear2 = new Regex(@"^(?<era>[明大昭平令])(?<year>[1-9１-９][0-9０-９]?)");

        public CSVKoshoFile(string path) : base(path)
        {
            culture = new CultureInfo("ja-JP", true);
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
        }

        protected override void InsertTitleColums(List<string> titles)
        {
            var titleBase = titles[infoIndex];
            titles[infoIndex] += "/出版年";
            titles.Insert(infoIndex, $"{titleBase}/出版社");
            titles.Insert(infoIndex, $"{titleBase}/著者");
        }

        protected override void InsertInfoColumn(List<string> fields, string[] infos)
        {
            fields[infoIndex] = ParseYear(infos);
            fields.Insert(infoIndex, infos.Length > 1 ? infos[1] : "");
            fields.Insert(infoIndex, infos[0]);
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

        private static void ConertWideDigits(ref string digits)
        {
            digits = digits.Replace("０", "0");
            digits = digits.Replace("１", "1");
            digits = digits.Replace("２", "2");
            digits = digits.Replace("３", "3");
            digits = digits.Replace("４", "4");
            digits = digits.Replace("５", "5");
            digits = digits.Replace("６", "6");
            digits = digits.Replace("７", "7");
            digits = digits.Replace("８", "8");
            digits = digits.Replace("９", "9");
        }
    }
}
