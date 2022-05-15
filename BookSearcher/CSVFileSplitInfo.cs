using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace BookSearcher
{
    internal abstract class CSVFileSplitInfo : CSVFile
    {
        const int CHECK_LINES = 10;
        protected abstract Regex Url { get; }
        protected abstract Regex RegexDelimiter { get; }
        protected int infoIndex = -1;
        protected int infoCount = -1;

        public CSVFileSplitInfo(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            if (!IsMatchUrl())
            {
                return false;
            }

            using (var reader = new TextFieldParser(Path, FileEncoding))
            {
                reader.SetDelimiters(",");
                var titles = new List<string>(reader.ReadFields());
                var fields = new List<string>(reader.ReadFields());
                DetectInfoColumn(fields);
                InsertTitleColums(titles);
                InsertInfoColumn(fields);
                Titles = titles.ToArray();
                Fields = fields.ToArray();
                if (Fields.Length == Titles.Length)
                {
                    Columns = Titles.Length;
                    return true;
                }
            }
            return false;
        }

        abstract protected void InsertTitleColums(List<string> titles);

        private bool IsMatchUrl()
        {
            using (var reader = new StreamReader(Path, FileEncoding))
            {
                var line = reader.ReadLine();
                for (int i = 0; i < CHECK_LINES; i++)
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    var match = Url.Match(line);
                    if (match.Success)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void DetectInfoColumn(List<string> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].StartsWith("https://"))
                {
                    continue;
                }
                var infos = RegexDelimiter.Split(fields[i]);
                if (infos.Length > infoCount)
                {
                    infoIndex = i;
                    infoCount = infos.Length;
                }
            }
        }

        private void InsertInfoColumn(List<string> fields)
        {
            var infos = RegexDelimiter.Split(fields[infoIndex]);
            InsertInfoColumn(fields, infos);
        }

        protected abstract void InsertInfoColumn(List<string> fields, string[] infos);

        protected override void DoReadAll()
        {
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
