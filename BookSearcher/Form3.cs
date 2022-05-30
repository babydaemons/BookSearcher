using System;
using System.Data;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public partial class Form3 : Form
    {
        public Form3(string searchType, DataTable tableExcel, DataTable tablePattern1, DataTable tablePattern2, DataTable tableCommon1, DataTable tableCommon2)
        {
            InitializeComponent();

            // 画面タイトルの設定
            Text = $"BookSearcher - {searchType} - {tableExcel.Rows.Count}件";

            DataGridViewOutputPattern1.DataSource = tablePattern1;
            DataGridViewOutputPattern2.DataSource = tablePattern2;
            DataGridViewCommonOutput1.DataSource = tableCommon1;
            DataGridViewCommonOutput2.DataSource = tableCommon2;
            DataGridViewOutputExcel.DataSource = tableExcel;
        }
    }
}
