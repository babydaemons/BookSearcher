using System.Windows.Forms;

namespace BookSearcherApp
{
    public class CSVSaverPattern2 : CSVSaver1
    {
        public override int ColumnIndexPrice => 5;

        public override int ColumnIndexISBN => 1;

        public CSVSaverPattern2(DataGridView view, string path) : base(view, path) { }
    }
}
