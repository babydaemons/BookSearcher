using System;
using System.Data;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public partial class Form2 : Form
    {
        private readonly DataTable table;

        public Form2(CSVFile csvFile)
        {
            table = csvFile.Table;

            InitializeComponent();

            // 画面タイトルの設定
            Text = $"{Properties.Resources.Version} - {csvFile.Path} - {table.Rows.Count}件";
        }

        public Form2(DataTable result, string searchType)
        {
            table = result;

            InitializeComponent();

            // 画面タイトルの設定
            Text = $"{Properties.Resources.Version} - {searchType} - {table.Rows.Count}件";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataGridPreView.DataSource = table;
        }
    }
}
