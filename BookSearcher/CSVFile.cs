using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BookSearcher
{
    internal abstract class CSVFile
    {
        public string Path { get; }
        public Encoding FileEncoding { get; protected set; }
        public int Columns { get; protected set; }
        public string[] Titles { get; protected set; }
        public string[] Fields { get; protected set; }
        public List<string[]> Records { get; protected set; }

        protected CSVFile(string path)
        {
            Path = path;
            var bytes = new List<byte>();
            using (var file = File.OpenRead(path))
            {
                while (file.Position < file.Length)
                {
                    int c = file.ReadByte();
                    if (c == -1)
                    {
                        break;
                    }
                    if (c == '\n')
                    {
                        break;
                    }
                    bytes.Add((byte)c);
                }
            }
            FileEncoding = DetectEncoding(bytes.ToArray());
        }

        private Encoding DetectEncoding(byte[] bytes)
        {
            var sjis = Encoding.GetEncoding(932);
            if (bytes.Length < 2)
            {
                return sjis;
            }
            if ((bytes[0] == 0xfe) && (bytes[1] == 0xff))
            {
                // UTF-16 BE
                return new UnicodeEncoding(true, true);
            }
            if ((bytes[0] == 0xff) && (bytes[1] == 0xfe))
            {
                if ((4 <= bytes.Length) &&
                    (bytes[2] == 0x00) && (bytes[3] == 0x00))
                {
                    // UTF-32 LE
                    return new UTF32Encoding(false, true);
                }
                // UTF-16 LE
                return new UnicodeEncoding(false, true);
            }
            if (bytes.Length < 3)
            {
                return sjis;
            }
            if ((bytes[0] == 0xef) && (bytes[1] == 0xbb) && (bytes[2] == 0xbf))
            {
                // UTF-8
                return new UTF8Encoding(true, true);
            }
            if (bytes.Length < 4)
            {
                return sjis;
            }
            if ((bytes[0] == 0x00) && (bytes[1] == 0x00) &&
                (bytes[2] == 0xfe) && (bytes[3] == 0xff))
            {
                // UTF-32 BE
                return new UTF32Encoding(true, true);
            }

            return sjis;
        }

        public abstract bool ParseTitle();

        public static CSVFile ParseTitle(string path)
        {
            try
            {
                CSVMercariFile mercariFile = new CSVMercariFile(path);
                if (mercariFile.ParseTitle())
                {
                    return mercariFile;
                }

                CSVKoshoFile koshoFile = new CSVKoshoFile(path);
                if (koshoFile.ParseTitle())
                {
                    return koshoFile;
                }

                CSVRakutenIchibaFile rakutenIchibaFile = new CSVRakutenIchibaFile(path);
                if (rakutenIchibaFile.ParseTitle())
                {
                    return rakutenIchibaFile;
                }

                CSVRakutenBooksFile rakutenBooksFile = new CSVRakutenBooksFile(path);
                if (rakutenBooksFile.ParseTitle())
                {
                    return rakutenBooksFile;
                }

                CSVSingleLineFile singleLineFile = new CSVSingleLineFile(path);
                if (singleLineFile.ParseTitle())
                {
                    return singleLineFile;
                }

                CSVMultiLineFile multiLineFile = new CSVMultiLineFile(path);
                if (multiLineFile.ParseTitle())
                {
                    return multiLineFile;
                }

                MessageBox.Show("不正な形式のCSVファイルです。\n" + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        protected abstract void DoReadAll();

        public void ReadAll()
        {
            Records = new List<string[]>();
            try
            {
                DoReadAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
