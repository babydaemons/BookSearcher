using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public abstract class CSVFile : CSVData
    {
        private readonly FileStream fileStream;
        protected readonly long fileSize;
        private MemoryMappedFile memoryMappedFile;
        protected readonly ConcurrentBag<long> lineOffsets = new ConcurrentBag<long>();
        public string Path { get; }
        public Encoding FileEncoding { get; protected set; }
        public bool Loaded => !IsRunning;

        protected CSVFile(string path)
        {
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

        public abstract bool ParseTitle();

        public static CSVFile ParseTitle(string path)
        {
            var extension = System.IO.Path.GetExtension(path).ToLower();
            if (extension == ".xlsx")
            {
                ExcelFile excelFile = new ExcelFile(path);
                if (excelFile.ParseTitle())
                {
                    return excelFile;
                }
            }

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

            MessageBox.Show("不正な形式のCSVファイルです。\n" + path, "入力ファイルエラー");
            return null;
        }

        public override void ReadAll(BackgroundWorker backgroundWorker, FileIOProgressBar progressBar)
        {
            StartIO(backgroundWorker, progressBar);

            AllocateTable();
            DoReadAll();

            memoryMappedFile.Dispose();
            memoryMappedFile = null;

            StopIO();
            Debug.WriteLine($"{Path} - {CurrentProgress}");
        }

        protected abstract void DoReadAll();

        protected void AddTableRow(Stream stream, string[] fields, int start = 0, int end = FileIOProgressBar.MAX_VALUE)
        {
            AddRow(fields);
            ReportProgress((int)(start + (end - start) * stream.Position / stream.Length));
        }

        protected void AddTableRow(long position, long length, string[] fields, int start = 0, int end = FileIOProgressBar.MAX_VALUE)
        {
            AddRow(fields);
            ReportProgress((int)(start + (end - start) * position / length));
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
