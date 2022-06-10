﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace BookSearcherApp
{
    internal abstract class CSVFileSplitInfoQuotedLine : CSVFileSplitInfo
    {
        public CSVFileSplitInfoQuotedLine(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            if (!IsMatchUrl())
            {
                return false;
            }

            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new TextFieldParser(memoryMappedViewStream, FileEncoding))
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
                    ColumnCount = Titles.Length;
                    return true;
                }
            }
            return false;
        }

        protected override void DoReadAll()
        {
            DoReadPart(0);
        }

        private void DoReadPart(int n)
        {
            int N = 1;
            int partLines = LineOffsets.Length / N;
            long start = LineOffsets[n * partLines];
            long end = n < N - 1 ? LineOffsets[(n + 1) * partLines] : fileSize;
            long size = end - start;
            int rowIndex = n * partLines;
            using (var memoryMappedViewStream = GetMemoryMappedViewStream(start, size))
            using (var reader = new TextFieldParser(memoryMappedViewStream, FileEncoding))
            {
                reader.SetDelimiters(",");
                while (!reader.EndOfData)
                {
                    var fields = new List<string>(reader.ReadFields());
                    bool matched = fields.Any(field => { var match = Url[0].Match(field); return match.Success; });
                    if (matched)
                    {
                        DeleteTailFields(fields);
                        InsertInfoColumn(fields);
                        AddTableRow(rowIndex++, fields.ToArray());
                    }
                }
            }
        }
    }
}
