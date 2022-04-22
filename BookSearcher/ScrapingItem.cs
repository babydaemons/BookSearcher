using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearcher
{
    internal class ScrapingItem
    {
        public ScrapingItem(string line)
        {
            string[] fields = line.Split('\u002C'); // ','
            Url = fields[0];
            Title = fields[1];
            ProductUrl = fields[2];
            int.TryParse(fields[3], out int price);
            Price = price;
            Description = fields[5];
        }

        public string Url { get; set; }
        public string Title { get; set; }
        public string ProductUrl { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
