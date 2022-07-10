using System;

namespace BookSearcherApp
{
    public class BookSearcher14 : AbstractSearcherComplete1
    {
        private readonly ColumnInfo ISBN = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.ISBN);

        public BookSearcher14() : base()
        {
        }

        protected override void ExecuteSearch() => Search(ISBN);
    }
}
