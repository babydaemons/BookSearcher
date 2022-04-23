using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BookSearcher
{
    public partial class Form1 : Form
    {
        private Dictionary<char, string> BookTitles = new Dictionary<char, string>();
        private Dictionary<char, string> ScrapingTitles = new Dictionary<char, string>();
        private DateTime start;
        private DateTime finish;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "書籍データベースファイル";
            dialog.Filter = "CSVファイル|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
                BookTitles = BookItem.ParseTitle(textBox1.Text);
                bookColumnSetting.Rows.Clear();
                foreach (var columnNumber in BookTitles.Keys)
                {
                    bookColumnSetting.Rows.Add(new object[] { columnNumber, BookTitles[columnNumber], "" });
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "スクレイピングデータファイル";
            dialog.Filter = "CSVファイル|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dialog.FileName;
                ScrapingTitles = ScrapingItem.ParseTitle(textBox2.Text);
                scrapingColumnSetting.Rows.Clear();
                foreach (var columnNumber in ScrapingTitles.Keys)
                {
                    scrapingColumnSetting.Rows.Add(new object[] { columnNumber, ScrapingTitles[columnNumber], "" });
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "出力Excelファイル";
            //dialog.Filter = "Excelファイル|*.xlsx;*.xlsm";
            dialog.Filter = "CSVファイル|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dialog.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
            label1.Enabled = label2.Enabled = label3.Enabled = false;
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = false;
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = false;
            groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = false;
            bookColumnSetting.Enabled = scrapingColumnSetting.Enabled = false;
            toolStripStatusLabel1.Text = "00:00:00";
            toolStripStatusLabel2.Text = "検索処理を実行中です．．．";
            timer1.Enabled = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var searcher = new BookSearcher();
            searcher.Load(textBox1.Text, textBox2.Text);
            if (radioButton09.Checked)
            {
                searcher.SearchType09(textBox3.Text, int.Parse(comboBox1.Text));
            }
            else if (radioButton15.Checked)
            {
                searcher.SearchType15(textBox3.Text);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            finish = DateTime.Now;
            var time = finish - start;
            MessageBox.Show(time.ToString());
            label1.Enabled = label2.Enabled = label3.Enabled = true;
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = true;
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = true;
            groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = true;
            bookColumnSetting.Enabled = scrapingColumnSetting.Enabled = true;
            timer1.Enabled = false;
            toolStripStatusLabel1.Text = time.ToString(@"hh\:mm\:ss");
            toolStripStatusLabel2.Text = "検索処理が完了しました．";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            finish = DateTime.Now;
            var time = finish - start;
            toolStripStatusLabel1.Text = time.ToString(@"hh\:mm\:ss");
        }
    }
}
