using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearcherApp
{
    public abstract class AbstractSearcher_Type2_Partial21 : AbstractSearcher2
    {
        protected AbstractSearcher_Type2_Partial21() : base()
        {
        }

        protected TimeSpan SearchPartial1(ColumnInfo columnPartial, ColumnInfo columnComplete)
        {
            StopWatch = Stopwatch.StartNew();
            var bookValues = CreateColumnList(BookCSV.MemoryTable, columnPartial, columnComplete, true);
            var scrapingValues = CreateColumnList(ScrapingCSV.MemoryTable, columnPartial, columnComplete, false);
            var results = from bookRow in bookValues
                          join scrapingRow in scrapingValues.AsParallel()
                          on new ValuePairPartial1 { Value1 = bookRow.Value.Value2, Value2 = bookRow.Value.Value1 }
                          equals new ValuePairPartial1 { Value1 = scrapingRow.Value.Value2, Value2 = scrapingRow.Value.Value1 }
                          select new RowIndexPair { BookRowIndex = bookRow.Key, ScrapingRowIndex = scrapingRow.Key };
            SaveTable(new List<RowIndexPair>(results));
            StopWatch.Stop();
            return StopWatch.Elapsed;
        }

        struct ValuePairPartial1
        {
            public string Value1;
            public string Value2;
            public static bool operator ==(ValuePairPartial1 a, ValuePairPartial1 b) => a.Value1 == b.Value1 && a.Value2.Contains(b.Value2);
            public static bool operator !=(ValuePairPartial1 a, ValuePairPartial1 b) => a.Value1 != b.Value1 || !b.Value2.Contains(a.Value2);
            public override bool Equals(object obj)
            {
                ValuePairPartial1 a = this;
                ValuePairPartial1 b = (ValuePairPartial1)obj;
                return a == b;
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}
