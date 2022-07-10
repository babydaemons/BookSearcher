using System;
using System.Collections.Concurrent;
using System.Linq;

namespace BookSearcherApp
{
    public class BookSearcher02 : AbstractSearcher_Type1_CompleteBeginng
    {
        private readonly ColumnInfo bookTitle = new ColumnInfo(MatchType.BeginningMatch, SpaceMatch, ColumnType.BookTitle);
        private readonly ColumnInfo year = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, ColumnType.Year);

        public BookSearcher02() : base()
        {
        }

        protected override void ExecuteSearch() => SearchBeginning(year, bookTitle);
    }
}
