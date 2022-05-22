using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace BookSearcher
{
    internal abstract class CSVFileSplitInfo : CSVFile
    {
        const int CHECK_LINES = 20;
        protected abstract Regex[] Url { get; }
        protected abstract Regex RegexInfoDelimiter { get; }
        protected abstract bool DoDeleteTailFields { get; }
        protected int infoIndex = -1;
        protected int infoCount = -1;

        public CSVFileSplitInfo(string path) : base(path)
        {
        }

        abstract protected void InsertTitleColums(List<string> titles);

        protected bool IsMatchUrl()
        {
            var matched = new bool[Url.Length];

            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new StreamReader(memoryMappedViewStream, FileEncoding))
            {
                var line = reader.ReadLine();
                for (int k = 0; k < CHECK_LINES; k++)
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    foreach (var i in Enumerable.Range(0, Url.Length))
                    {
                        if (matched[i])
                        { 
                            continue; 
                        }
                        var match = Url[i].Match(line);
                        if (match.Success)
                        {
                            matched[i] = true;
                        }
                    }
                }
            }
            return matched.All(match => match);
        }

        protected void DetectInfoColumn(List<string> fields)
        {
            if (RegexInfoDelimiter == null)
            {
                return;
            }

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
            if (DoDeleteTailFields)
            {
                DeleteTailFields(fields);
            }
            if (RegexInfoDelimiter == null)
            {
                return;
            }

            var infos = RegexInfoDelimiter.Split(fields[infoIndex]);
            InsertInfoColumn(fields, infos);
        }

        protected abstract void InsertInfoColumn(List<string> fields, string[] infos);

        protected void DeleteTailFields(List<string> fields)
        {
            fields.RemoveRange(Columns, fields.Count - Columns);
        }
    }
}
