using System.Data;

namespace BookSearcherApp
{
    public abstract class CSVSaver
    {
        public abstract string[] Titles { get; }

        public DataTable DataTable => new DataTable();

        protected CSVSaver()
        {
            foreach (var title in Titles)
            {
                DataTable.Columns.Add(title);
            }
        }

        public static int CalcSellingPrice(int F4)
        {
            double selling_price = (F4 + 88 + 110 + 330 + 550 + (F4 * 0.15)) * IF(F4 > 20000, 1.52, IF(F4 > 10000, 1.49, IF(F4 > 5000, 1.46, IF(F4 > 3000, 1.43, IF(F4 >= 1, 1.42, 0.00)))));
            return (int)(selling_price + 0.5);
        }

        private static double IF(bool condition, double then_value, double else_value)
        {
            return condition ? then_value : else_value;
        }
    }
}
