using System.Windows.Forms;

namespace BookSearcherApp
{
    public class DataSaverCommon2 : DataSaverPattern
    {
        public override int ColumnIndexPrice => 5;

        public override int ColumnIndexISBN => 1;

        public DataSaverCommon2(DataGridView view, string path) : base(view, path) { }
    }
}
