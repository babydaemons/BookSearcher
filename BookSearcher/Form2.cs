using System;
using System.Data;
using System.Windows.Forms;

namespace BookSearcher
{
    public partial class Form2 : Form
    {
        private readonly DataTable table;
        private readonly bool hideFirstColumn;

        public Form2(CSVFile csvFile)
        {
            table = csvFile.Table;
            hideFirstColumn = true;

            InitializeComponent();

            // 画面タイトルの設定
            Text = $"BookSearcher - {csvFile.Path}";
        }

        public Form2(DataTable result, string searchType)
        {
            table = result;
            hideFirstColumn = false;

            InitializeComponent();

            // 画面タイトルの設定
            Text = $"BookSearcher - {searchType}";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataGridPreView.DataSource = table;

            if (hideFirstColumn)
            {
                // DataGridPreViewのはじめの列を非表示にする
                DataGridPreView.Columns[0].Visible = false;
            }
        }
    }
}
