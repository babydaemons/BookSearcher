using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace BookSearcher
{
    internal class BookSearcher
    {
        private List<BookItem> bookList = new List<BookItem>();
        private List<ScrapingItem> scrapingList = new List<ScrapingItem>();

        public BookSearcher()
        {
        }

        public void Load(string bookListPath, string scrapingListPath)
        {
            try
            {
                using (var reader = new StreamReader(bookListPath, Encoding.GetEncoding(932)))
                {
                    string line = reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        var bookItem = new BookItem(line);
                        bookList.Add(bookItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }

            try
            {
                using (var reader = new StreamReader(scrapingListPath, Encoding.GetEncoding(932)))
                {
                    string line = reader.ReadLine();
                    while ((line = reader.ReadLine()) != null)
                    {
                        var scrapingItem = new ScrapingItem(line);
                        scrapingList.Add(scrapingItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SearchType09(string resultPath, int length)
        {
            // 書籍名の部分一致ですが、空白無視の前5-7文字一致と言うことは、空白を削除したカラムで先頭一致で5-7文字が一致すれば良い
            var bookMap = new Dictionary<string, BookItem>();
            foreach (var bookItem in bookList)
            {
                var title = bookItem.Title.Replace(" ", "").Replace("　", "");
                if (title.Length > length)
                {
                    title = title.Substring(0, length);
                }
                if (bookMap.ContainsKey(title))
                {
                    continue;
                }
                bookMap.Add(title, bookItem);
            }

            var scrapingMap = new Dictionary<string, ScrapingItem>();
            foreach (var scrapingItem in scrapingList)
            {
                var title = scrapingItem.Title.Replace(" ", "").Replace("　", "");
                if (title.Length > length)
                {
                    title = title.Substring(0, length);
                }
                if (scrapingMap.ContainsKey(title))
                {
                    continue;
                }
                scrapingMap.Add(title, scrapingItem);
            }

            var resultList =
                from bookItem in bookMap
                join scrapingItem in scrapingMap on bookItem.Key equals scrapingItem.Key
                orderby bookItem.Key
                select new { scrapingItem.Value.Url, bookItem.Value.Title, scrapingItem.Value.ProductUrl, scrapingItem.Value.Price };

            try
            {
                using (var writer = new StreamWriter(resultPath, false, Encoding.GetEncoding(932)))
                {
                    foreach (var result in resultList)
                    {
                        var line = $"{result.Url},{result.Title},{result.ProductUrl},{result.Price}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // 著者名の部分一致で名前と苗字の間のスペースを削除できれば、完全一致で良い
        }

        public void SearchType15(string resultPath)
        {
            var bookMap = new Dictionary<string, BookItem>();
            foreach (var bookItem in bookList)
            {
                var title = bookItem.Title;
                if (bookMap.ContainsKey(title))
                {
                    continue;
                }
                bookMap.Add(title, bookItem);
            }

            var scrapingMap = new Dictionary<string, ScrapingItem>();
            foreach (var scrapingItem in scrapingList)
            {
                var title = scrapingItem.Title;
                if (scrapingMap.ContainsKey(title))
                {
                    continue;
                }
                scrapingMap.Add(title, scrapingItem);
            }

            var resultList =
                from bookItem in bookMap
                join scrapingItem in scrapingMap on bookItem.Key equals scrapingItem.Key
                orderby bookItem.Key
                select new { scrapingItem.Value.Url, bookItem.Value.Title, scrapingItem.Value.ProductUrl, scrapingItem.Value.Price };

            try
            {
                using (var writer = new StreamWriter(resultPath, false, Encoding.GetEncoding(932)))
                {
                    foreach (var result in resultList)
                    {
                        var line = $"{result.Url},{result.Title},{result.ProductUrl},{result.Price}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
