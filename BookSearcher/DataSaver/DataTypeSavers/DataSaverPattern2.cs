using System.Windows.Forms;

namespace BookSearcherApp
{
    public class DataSaverPattern2 : DataSaverPattern
    {
        public override int ColumnIndexPrice => 5;

        public override int ColumnIndexISBN => 1;

        public DataSaverPattern2(DataGridView view, string path) : base(view, path) { }
    }
}
