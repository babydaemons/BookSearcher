using System.Windows.Forms;

namespace BookSearcherApp
{
    public class DataSaverCommon1 : DataSaverCommon
    {
        public override int ColumnIndexPrice => 5;

        public override int ColumnIndexISBN => 1;

        public override int ColumnIndexAutoPriceStopperLower => 11;

        public override int ColumnIndexAutoPriceStopperUpper => 13;

        protected override bool IncludeAmazonHeader => false;

        public DataSaverCommon1(DataGridView view, string path) : base(view, path) { }
    }
}
