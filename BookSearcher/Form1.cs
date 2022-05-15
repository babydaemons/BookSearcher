﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
                TextBoxInput1.Text = dialog.FileName;
                BookCSV = CSVFile.ParseTitle(TextBoxInput1.Text);
                BookColumnSetting.Rows.Clear();
                for (int i = 0; i < BookCSV.Titles.Length; ++i)
                {
                    BookColumnSetting.Rows.Add(new object[] { i + 1, BookCSV.Titles[i], BookCSV.Fields[i], "" });
                }
                if (BookCSV.Titles.Length > 0)
                {
                    LabelInput1.Enabled = TextBoxInput1.Enabled = Button1.Enabled = false;
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
            LabelInput1.Enabled = TextBoxInput1.Enabled = Button1.Enabled = true;
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
                TextBoxInput2.Text = dialog.FileName;
                ScrapingCSV = CSVFile.ParseTitle(TextBoxInput2.Text);
                ScrapingColumnSetting.Rows.Clear();
                for (int i = 0; i < ScrapingCSV.Titles.Length; ++i)
                {
                    ScrapingColumnSetting.Rows.Add(new object[] { i + 1, ScrapingCSV.Titles[i], ScrapingCSV.Fields[i], "" });
                }
                if (ScrapingCSV.Titles.Length > 0)
                {
                    LabelInput2.Enabled = TextBoxInput2.Enabled = Button2.Enabled = false;
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
            LabelInput2.Enabled = TextBoxInput2.Enabled = Button2.Enabled = true;
        }
        private void RadioButtonFileType_CheckedChanged(object sender, EventArgs e)
        {
            string fileType;
            if (RadioButtonFileTypeExcel.Checked)
            {
                fileType = "出力Excelファイル";
            }
            else
            {
                fileType = RadioButtonFileTypeCSV1.Checked ? "出力CSVファイル(パターン1)" : "出力CSVファイル(パターン2)";
            }
            TextBoxOutput1.Text = TextBoxOutput2.Text = TextBoxOutput3.Text = "";
            TextBoxOutput2.Enabled = TextBoxOutput3.Enabled = LabelOutput2.Enabled = LabelOutput3.Enabled = !RadioButtonFileTypeExcel.Checked;
            LabelOutput1.Text = fileType;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (RadioButtonFileTypeExcel.Checked)
            {
                var dialog = new OpenFileDialog
                {
                    Title = LabelOutput1.Text,
                    Filter = "Excelファイル|*.xlsx;*.xlsm"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TextBoxOutput1.Text = dialog.FileName;
                }
            }
            else
            {
                var dialog = new OpenFileDialog
                {
                    Title = LabelOutput1.Text,
                    Filter = "CSVファイル|*.csv",
                    CheckFileExists = false
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var path = dialog.FileName;
                    var dir = Path.GetDirectoryName(path);
                    var file = Path.GetFileNameWithoutExtension(path);
                    TextBoxOutput1.Text = path;
                    TextBoxOutput2.Text = $"{dir}\\{file}_共通出力1.csv";
                    TextBoxOutput3.Text = $"{dir}\\{file}_共通出力2.csv";
                }
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

        private void SetContolsEnabled(bool enabled)
        {
            GroupBox1.Enabled = GroupBox2.Enabled = GroupBox3.Enabled = GroupBox4.Enabled = GroupBox5.Enabled = GroupBox6.Enabled = GroupBox7.Enabled = enabled;
            BookColumnSetting.Enabled = ScrapingColumnSetting.Enabled = enabled;
        }
    }
}
