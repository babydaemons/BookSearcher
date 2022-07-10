using System;

namespace BookSearcherApp
{
    public class BookSearcher15 : AbstractSearcherComplete1
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch, ColumnType.BookTitle);

        public BookSearcher15() : base()
        {
        }

        protected override void ExecuteSearch() => Search(bookTitle);
    }
}
