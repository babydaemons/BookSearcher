﻿using System;

namespace BookSearcherApp
{
    public class BookSearcher13 : AbstractSearcherComplete1
    {
        private readonly ColumnInfo URL = new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.All, ColumnType.URL);

        public BookSearcher13() : base()
        {
        }

        protected override void ExecuteSearch() => Search(URL);
    }
}
