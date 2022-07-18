using System.Windows.Forms;

namespace BookSearcherApp
{
    public class DataSaverPattern2 : DataSaverPattern
    {
        public override int ColumnIndexPrice => 5;

        public override int ColumnIndexISBN => 1;

        public override int ColumnIndexAutoPriceStopperLower => -1;

        public override int ColumnIndexAutoPriceStopperUpper => -1;

        protected override bool IncludeAmazonHeader => true;

        public DataSaverPattern2(DataGridView view, string path) : base(view, path) { }
    }
}
