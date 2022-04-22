namespace BookSearcher
{
    internal class BookItem
    {
        public BookItem(string line)
        {
            string[] fields = line.Split('\u002C'); // ','
            Id = fields[0];
            Title = fields[1];
            ISBN = fields[2];
            int.TryParse(fields[3], out int year);
            Year = year;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
    }
}
