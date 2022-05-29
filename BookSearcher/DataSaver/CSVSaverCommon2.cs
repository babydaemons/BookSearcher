using System.Windows.Forms;

namespace BookSearcherApp
{
    public class CSVSaverCommon2 : CSVSaver1
    {
        public override int ColumnIndexPrice => 5;

        public override int ColumnIndexISBN => 1;

        public CSVSaverCommon2(DataGridView view) : base(view) { }
    }
}
