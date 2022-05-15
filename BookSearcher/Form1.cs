using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BookSearcher
{
    public partial class Form1 : Form
    {
        private CSVFile BookCSV;
        private CSVFile ScrapingCSV;
        private DateTime start;
        private DateTime finish;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "書籍データベースファイル",
                Filter = "CSVファイル|*.csv"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TextBox1.Text = dialog.FileName;
                BookCSV = CSVFile.ParseTitle(TextBox1.Text);
                BookColumnSetting.Rows.Clear();
                for (int i = 0; i < BookCSV.Titles.Length; ++i)
                {
                    BookColumnSetting.Rows.Add(new object[] { i + 1, BookCSV.Titles[i], BookCSV.Fields[i], "" });
                }
                if (BookCSV.Titles.Length > 0)
                {
                    Label1.Enabled = TextBox1.Enabled = Button1.Enabled = false;
                    BackgroundWorker1.RunWorkerAsync();
                }
            }
        }


        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BookCSV.ReadAll();
        }


        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Label1.Enabled = TextBox1.Enabled = Button1.Enabled = true;
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "スクレイピングデータファイル",
                Filter = "CSVファイル|*.csv"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TextBox2.Text = dialog.FileName;
                ScrapingCSV = CSVFile.ParseTitle(TextBox2.Text);
                ScrapingColumnSetting.Rows.Clear();
                for (int i = 0; i < ScrapingCSV.Titles.Length; ++i)
                {
                    ScrapingColumnSetting.Rows.Add(new object[] { i + 1, ScrapingCSV.Titles[i], ScrapingCSV.Fields[i], "" });
                }
                if (ScrapingCSV.Titles.Length > 0)
                {
                    Label2.Enabled = TextBox2.Enabled = Button2.Enabled = false;
                    BackgroundWorker2.RunWorkerAsync();
                }
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            ScrapingCSV.ReadAll();
        }

        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Label2.Enabled = TextBox2.Enabled = Button2.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = Label3.Text,
                Filter = RadioButtonFileTypeExcel.Checked ? "Excelファイル|*.xlsx;*.xlsm" : "CSVファイル|*.csv"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TextBox3.Text = dialog.FileName;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
            SetContolsEnabled(false);
            ToolStripStatusLabel1.Text = "00:00:00";
            ToolStripStatusLabel2.Text = "検索処理を実行中です．．．";
            Timer1.Enabled = true;
            BackgroundWorker4.RunWorkerAsync();
        }

        private void BackgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void BackgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            finish = DateTime.Now;
            var time = finish - start;
            MessageBox.Show(time.ToString());
            SetContolsEnabled(true);
            Timer1.Enabled = false;
            ToolStripStatusLabel1.Text = time.ToString(@"hh\:mm\:ss");
            ToolStripStatusLabel2.Text = "検索処理が完了しました．";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            finish = DateTime.Now;
            var time = finish - start;
            ToolStripStatusLabel1.Text = time.ToString(@"hh\:mm\:ss");
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var fileType = RadioButtonFileTypeExcel.Checked ? "Excel" : "CSV";
            Label3.Text = $"出力{fileType}ファイル";
        }

        private void SetContolsEnabled(bool enabled)
        {
            GroupBox1.Enabled = GroupBox2.Enabled = GroupBox3.Enabled = GroupBox4.Enabled = GroupBox5.Enabled = GroupBox6.Enabled = GroupBox7.Enabled = enabled;
            BookColumnSetting.Enabled = ScrapingColumnSetting.Enabled = enabled;
        }
    }
}
