using System;

namespace BookSearcherApp
{
    public class BookSearcher14 : BookSearcher
    {
        private readonly ColumnInfo ISBN = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.ISBN);

        public BookSearcher14() : base()
        {
        }

        public override TimeSpan Search()
        {
            return Search(ISBN);
        }
    }
}
