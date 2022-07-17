using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookSearcherApp
{
    internal abstract class CSVFileSplitInfoMultiLine : CSVFileSplitInfo
    {
        public CSVFileSplitInfoMultiLine(string path) : base(path)
        {
        }

        public override bool ParseTitle()
        {
            if (!IsMatchUrl())
            {
                return false;
            }

            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            using (var reader = new CSVReader(memoryMappedViewStream, FileEncoding))
            {
                var titles = new List<string>(reader.ReadTitleFields());
                TitleRowCount = titles.Count;
                var fields = new List<string>(reader.ReadValueFields(TitleRowCount));
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
            try
            {
                using (var memoryMappedViewStream = GetMemoryMappedViewStream())
                using (var reader = new CSVReader(memoryMappedViewStream, FileEncoding))
                {
                    _ = reader.ReadTitleFields();
                    while (!reader.EndOfData)
                    {
                        var fields = new List<string>(reader.ReadValueFields(TitleRowCount));
                        InsertInfoColumn(fields);
                        AddTableRow(memoryMappedViewStream, fields.ToArray());
                    }
                }
            }
            catch (MalformedLineException ex)
            {
                MessageBox.Show($"入力ファイルの読み込みを中断しました。\n{ex.Message}\n\n入力ファイル：\n{Path}", "入力ファイルエラー");
            }
        }
    }
}
