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
        protected abstract Regex RegexInfoDelimiter { get; }
        protected int infoIndex = -1;
        protected int infoCount = -1;

        public CSVFileSplitInfo(string path) : base(path)
        {
        }

        abstract protected void InsertTitleColums(List<string> titles);

        protected bool IsMatchUrl()
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

        protected void DetectInfoColumn(List<string> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (fields[i].StartsWith("https://"))
                {
                    continue;
                }
                var infos = RegexInfoDelimiter.Split(fields[i]);
                if (infos.Length > infoCount)
                {
                    infoIndex = i;
                    infoCount = infos.Length;
                }
            }
        }

        protected void InsertInfoColumn(List<string> fields)
        {
            var infos = RegexInfoDelimiter.Split(fields[infoIndex]);
            InsertInfoColumn(fields, infos);
        }

        protected abstract void InsertInfoColumn(List<string> fields, string[] infos);
    }
}
