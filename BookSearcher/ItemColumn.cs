using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BookSearcher
{
    internal class ItemColumn
    {
        public static Dictionary<char, string> ParseTitle(string path)
        {
            var titles = new Dictionary<char, string>();
            try
            {
                using (var reader = new StreamReader(path, Encoding.GetEncoding(932)))
                {
                    string line = reader.ReadLine();
                    string[] fields = line.Split('\u002C'); // ','
                    char columnNumber = 'A';
                    foreach (string field in fields)
                    {
                        titles.Add(columnNumber, field);
                        columnNumber++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return titles;
        }

    }
}
