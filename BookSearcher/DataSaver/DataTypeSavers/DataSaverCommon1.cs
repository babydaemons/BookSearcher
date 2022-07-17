using System.Windows.Forms;

namespace BookSearcherApp
{
    public class DataSaverCommon1 : DataSaverCommon
    {
        public override int ColumnIndexPrice => 5;

        public override int ColumnIndexISBN => 1;

        public DataSaverCommon1(DataGridView view, string path) : base(view, path) { }
    }
}
