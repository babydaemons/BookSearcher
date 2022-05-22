using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BookSearcher
{
    public abstract class CSVFile
    {
        private readonly FileStream fileStream;
        protected readonly long fileSize;
        private MemoryMappedFile memoryMappedFile;
        protected readonly ConcurrentBag<long> lineOffsets = new ConcurrentBag<long>();
        protected long[] LineOffsets { get; private set; }

        public MemoryTable MemoryTable { get; private set; }
        public string Path { get; }
        public Encoding FileEncoding { get; protected set; }
        public int Columns { get; protected set; }
        public string[] Titles { get; protected set; }
        public string[] Fields { get; protected set; }
        public bool Loaded { get; private set; } = false;
        public DataTable Table => MemoryTable.DataTable;
        private BackgroundWorker backgoundworker;
        private int rowIndex = 0;
        private int rowCount = 0;
        private int progressPercent = 0;

        protected CSVFile(string path)
        {
            Loaded = false;
            Path = path;
            var fileInfo = new FileInfo(Path);
            fileSize = fileInfo.Length;
            fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read);
            memoryMappedFile = MemoryMappedFile.CreateFromFile(fileStream, null, fileSize, MemoryMappedFileAccess.Read, null, HandleInheritability.Inheritable, true);
            const int size = 4 * 1024;
            var bytes = new byte[size];
            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            {
                int count = memoryMappedViewStream.Read(bytes, 0, bytes.Length);
                FileEncoding = DetectEncoding(bytes, count);
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

        protected MemoryMappedViewStream GetMemoryMappedViewStream()
        {
            return memoryMappedFile.CreateViewStream(0, fileSize, MemoryMappedFileAccess.Read);
        }

        protected MemoryMappedViewStream GetMemoryMappedViewStream(long start, long size)
        {
            return memoryMappedFile.CreateViewStream(start, size, MemoryMappedFileAccess.Read);
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

                CSVHontoWebFile hontoWebFile = new CSVHontoWebFile(path);
                if (hontoWebFile.ParseTitle())
                {
                    return hontoWebFile;
                }

                CSVYamahaFile yamahaFile = new CSVYamahaFile(path);
                if (yamahaFile.ParseTitle())
                {
                    return yamahaFile;
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

        public void ReadAll(BackgroundWorker backgoundworker)
        {
            Loaded = false;
            this.backgoundworker = backgoundworker;
            backgoundworker.ReportProgress(0);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            CountLines();

            try
            {
                DoReadAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            stopWatch.Stop();
            Debug.WriteLine($"{Path} - {stopWatch.Elapsed}");

            Loaded = true;
            memoryMappedFile.Dispose();
            memoryMappedFile = null;
        }

        private void CountLines()
        {
            const int size = 10 * 1024 * 1024;
            var bytes = new byte[size];
            var startOffset = 0L;
            using (var memoryMappedViewStream = GetMemoryMappedViewStream())
            {
                while (memoryMappedViewStream.Position < memoryMappedViewStream.Length)
                {
                    int count = memoryMappedViewStream.Read(bytes, 0, size);
                    foreach (var i in Enumerable.Range(0, count).AsParallel())
                    {
                        if (bytes[i] == (byte)'\n')
                        {
                            lineOffsets.Add(startOffset + i + 1);
                        }
                    }
                    startOffset += count;
                }
            }

            rowCount = lineOffsets.Count;
            LineOffsets = lineOffsets.ToArray();
            Array.Sort(LineOffsets);
            MemoryTable = new MemoryTable(Titles, rowCount);
        }

        protected abstract void DoReadAll();

        protected void AddTableRow(int k, string[] fields)
        {
            MemoryTable.AddRow(k, fields);

            int percent = 100 * MemoryTable.Count / rowCount;
            if (progressPercent != percent)
            {
                backgoundworker.ReportProgress(percent);
                progressPercent = percent;
            }
        }

        protected void AddTableRow(string[] fields)
        {
            AddTableRow(rowIndex++, fields);
        }

        protected static void ConertWideDigits(ref string digits)
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

        protected static string MatchedValue(Regex regex, string[] infos)
        {
            foreach (var info in infos)
            {
                if (regex.Match(info).Success)
                {
                    return regex.Replace(info, "");
                }
            }
            return "";
        }
    }
}
