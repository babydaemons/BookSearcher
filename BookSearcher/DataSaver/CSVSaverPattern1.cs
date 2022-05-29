using System.Windows.Forms;

namespace BookSearcherApp
{
    public class CSVSaverPattern1 : CSVSaver1
    {
        public override int ColumnIndexPrice => 5;

        public override int ColumnIndexISBN => 1;

        public CSVSaverPattern1(DataGridView view) : base(view) { }
    }
}
