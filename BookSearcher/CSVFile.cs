using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BookSearcher
{
    public abstract class CSVFile
    {
        public string Path { get; }
        public Encoding FileEncoding { get; protected set; }
        public int Columns { get; protected set; }
        public string[] Titles { get; protected set; }
        public string[] Fields { get; protected set; }
        public bool Loaded { get; private set; } = false;
        protected DataTable table = new DataTable();
        public DataTable Table => table;
        private BackgroundWorker backgoundworker;
        private int rowIndex = 0;
        private int rowCount = 0;
        private int progressPercent = 0;

        protected CSVFile(string path)
        {
            Path = path;
            var bytes = new byte[1024 * 1024];
            using (var file = File.OpenRead(path))
            {
                while (file.Position < file.Length)
                {
                    int count = file.Read(bytes, 0, bytes.Length);
                    if (rowCount == 0)
                    {
                        FileEncoding = DetectEncoding(bytes, count);
                    }
                    for (int i = 0; i < count; ++i)
                    {
                        if (bytes[i] == (byte)'\n')
                        {
                            ++rowCount;
                        }
                    }
                }
            }
        }

        private Encoding DetectEncoding(byte[] bytes, int count)
        {
            var sjis = Encoding.GetEncoding(932);
            if (count < 2)
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
            if (count < 3)
            {
                return sjis;
            }
            if ((bytes[0] == 0xef) && (bytes[1] == 0xbb) && (bytes[2] == 0xbf))
            {
                // UTF-8
                return new UTF8Encoding(true, true);
            }
            if (count < 4)
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

        protected void CreateTable()
        {
            table.Columns.Add("RowIndex", typeof(int));

            foreach (var title in Titles)
            {
                try
                {
                    table.Columns.Add(title, typeof(string));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Environment.Exit(1);
                }
            }
        }

        public void ReadAll(BackgroundWorker backgoundworker)
        {
            this.backgoundworker = backgoundworker;
            Loaded = false;

            try
            {
                DoReadAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Loaded = true;
        }

        protected abstract void DoReadAll();

        protected void AddTableRow(string[] fields)
        {
            if (fields.Length > table.Columns.Count - 1)
            {
                return;
            }
            var row = table.NewRow();
            var i = 0;
            row[i++] = rowIndex++;
            foreach (var field in fields)
            {
                row[i++] = field;
            }
            table.Rows.Add(row);

            int percent = 100 * rowIndex / rowCount;
            if (progressPercent != percent)
            {
                backgoundworker.ReportProgress(percent);
                progressPercent = percent;
            }
        }
    }
}
