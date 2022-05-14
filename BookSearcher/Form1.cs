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

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "書籍データベースファイル";
            dialog.Filter = "CSVファイル|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
                BookCSV = new CSVFile(textBox1.Text);
                bookColumnSetting.Rows.Clear();
                for (int i = 0; i < BookCSV.Titles.Length; ++i)
                {
                    bookColumnSetting.Rows.Add(new object[] { i + 1, BookCSV.Titles[i], BookCSV.Fields[i], "" });
                }
                if (BookCSV.Titles.Length > 0)
                {
                    label1.Enabled = checkBox1.Enabled = textBox1.Enabled = button1.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BookCSV.ReadAll();
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Enabled = checkBox1.Enabled = textBox1.Enabled = button1.Enabled = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "スクレイピングデータファイル";
            dialog.Filter = "CSVファイル|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dialog.FileName;
                ScrapingCSV = new CSVFile(textBox2.Text);
                scrapingColumnSetting.Rows.Clear();
                for (int i = 0; i < ScrapingCSV.Titles.Length; ++i)
                {
                    scrapingColumnSetting.Rows.Add(new object[] { i + 1, ScrapingCSV.Titles[i], ScrapingCSV.Fields[i], "" });
                }
                if (ScrapingCSV.Titles.Length > 0)
                {
                    label2.Enabled = checkBox2.Enabled = textBox2.Enabled = button2.Enabled = false;
                    backgroundWorker2.RunWorkerAsync();
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            ScrapingCSV.ReadAll();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label2.Enabled = checkBox2.Enabled = textBox2.Enabled = button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = label3.Text;
            dialog.Filter = radioFileTypeExcel.Checked ? "Excelファイル|*.xlsx;*.xlsm" : "CSVファイル|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dialog.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
            SetContolsEnabled(false);
            toolStripStatusLabel1.Text = "00:00:00";
            toolStripStatusLabel2.Text = "検索処理を実行中です．．．";
            timer1.Enabled = true;
            backgroundWorker4.RunWorkerAsync();
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            finish = DateTime.Now;
            var time = finish - start;
            MessageBox.Show(time.ToString());
            SetContolsEnabled(true);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var fileType = radioFileTypeExcel.Checked ? "Excel" : "CSV";
            label3.Text = $"出力{fileType}ファイル";
        }

        private void SetContolsEnabled(bool enabled)
        {
            groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = groupBox4.Enabled = groupBox5.Enabled = groupBox6.Enabled = groupBox7.Enabled = enabled;
            bookColumnSetting.Enabled = scrapingColumnSetting.Enabled = enabled;
        }
    }
}
