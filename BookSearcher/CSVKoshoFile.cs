using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;
#if DEBUG
using System.IO;
#endif

namespace BookSearcher
{
    internal class CSVKoshoFile : CSVFile
    {
        private CultureInfo culture;
        private static readonly string url = "https://www.kosho.or.jp/products/";
        private static readonly Regex regex_delimiter = new Regex("\\s+、");
        private static readonly Regex regex_year = new Regex(@"^(?<year>([1１][9９]|[2２][0０])[0-9０-９][0-9０-９])");
        private static readonly Regex regex_jyear = new Regex(@"^(?<year>(明治|大正|昭和|平成|令和)[1-9１-９][0-9０-９]?)");
        private static readonly Regex regex_jyear2 = new Regex(@"^(?<era>[明大昭平令])(?<year>[1-9１-９][0-9０-９]?)");
        private int infoIndex = -1;
        private int infoCount = -1;
#if DEBUG
        private StreamWriter writer;
#endif

        public CSVKoshoFile(string path) : base(path)
        {
            culture = new CultureInfo("ja-JP", true);
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
        }

        public override bool ParseTitle()
        {
            bool result = false;
            using (var reader = new TextFieldParser(Path, FileEncoding))
            {
                reader.SetDelimiters(",");
                var titles = new List<string>(reader.ReadFields());
                var fields = new List<string>(reader.ReadFields());
                DetectInfoColumn(fields);
                var titleBase = titles[infoIndex];
                titles[infoIndex] += "/出版年";
                titles.Insert(infoIndex, $"{titleBase}/出版社");
                titles.Insert(infoIndex, $"{titleBase}/著者");
                InsertInfoColumn(fields);
                Titles = titles.ToArray();
                Fields = fields.ToArray();
                if (Fields.Length == Titles.Length)
                {
                    foreach (var field in Fields)
                    {
                        if (field.StartsWith(url))
                        {
                            RecordType = RecordType.KoshoLine;
                            Columns = Titles.Length;
                            result = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        private void DetectInfoColumn(List<string> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                var infos = regex_delimiter.Split(fields[i]);
                if (infos.Length > infoCount)
                {
                    infoIndex = i;
                    infoCount = infos.Length;
                }
            }
        }

        private void InsertInfoColumn(List<string> fields)
        {
            var infos = regex_delimiter.Split(fields[infoIndex]);
#if DEBUG
            if (writer != null)
            {
                writer.WriteLine(string.Join("\t", infos)); 
            }
#endif
            fields[infoIndex] = ParseYear(infos);
            fields.Insert(infoIndex, infos.Length > 1 ? infos[1] : "");
            fields.Insert(infoIndex, infos[0]);
        }

        private string ParseYear(string[] infos)
        {
            foreach (var info in infos)
            {
                var match_year = regex_year.Match(info);
                if (match_year.Success)
                {
                    var year = match_year.Groups["year"].Value;
                    ConertWideDigits(ref year);
                    return year;
                }
                var match_jyear = regex_jyear.Match(info);
                if (match_jyear.Success)
                {
                    var year = match_jyear.Groups["year"].Value + "年";
                    ConertWideDigits(ref year);
                    DateTime date;
                    if (DateTime.TryParseExact(year, "ggyy年", culture, DateTimeStyles.AssumeLocal, out date))
                    {
                        year = date.Year.ToString();
                    }
                    return year;
                }
                var match_jyear2 = regex_jyear.Match(info);
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
                    DateTime date;
                    if (DateTime.TryParseExact(year, "ggyy年", culture, DateTimeStyles.AssumeLocal, out date))
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

        protected override void DoReadAll()
        {
#if DEBUG
            using (writer = new StreamWriter(Path.Replace(".csv", ".tsv"), false, FileEncoding))
#endif
            using (var reader = new TextFieldParser(Path, FileEncoding))
            {
                reader.SetDelimiters(",");
                _ = reader.ReadFields();
                while (!reader.EndOfData)
                {
                    var fields = new List<string>(reader.ReadFields());
                    InsertInfoColumn(fields);
                    Records.Add(fields.ToArray());
                }
            }
        }
    }
}
