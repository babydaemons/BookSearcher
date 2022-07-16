using System.ComponentModel;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public abstract class DataSaver2 : DataSaver
    {
        public override int ColumnIndexISBN => 1;

        public override string[] Titles => new string[]
        {
            "sku",
            "item_name",
            "condition_note",
            "quantity",
            "leadtime",
            "price",
            "shipping_group",
            "point",
            "autoprice_template_mode",
            "autoprice_template_id",
            "calculation_column1",
            "autoprice_stopper",
            "calculation_column2",
            "autoprice_stopper_upper",
            "purchase_cost",
            "memo",
            "is_delete"
        };

        protected DataSaver2(DataGridView view, string path) : base(view, path) { }
    }
}
