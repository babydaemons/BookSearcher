using System;

namespace BookSearcherApp
{
    public class BookSearcher13 : BookSearcher
    {
        private readonly ColumnInfo URL = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.All, ColumnType.URL);

        public BookSearcher13() : base()
        {
        }

        public override TimeSpan Search()
        {
            return Search(URL);
        }
    }
}
