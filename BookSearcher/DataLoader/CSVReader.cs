using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace BookSearcherApp
{
    public class CSVReader : TextFieldParser
    {
        public CSVReader(Stream stream, Encoding encoding) : base(stream, encoding)
        {
            SetDelimiters(",");
        }

        public CSVReader(string path) : base(path)
        {
            SetDelimiters(",");
        }

        public string[] ReadTitleFields()
        {
            return ReadValueFields(0);
        }

        public string[] ReadValueFields(int columns)
        {
            var fields = new List<string>(ReadFields());
            for (var i = fields.Count - 1; i >= columns; i--)
            {
                if (string.IsNullOrEmpty(fields[i]))
                {
                    fields.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
            return fields.ToArray();
        }
    }
}
