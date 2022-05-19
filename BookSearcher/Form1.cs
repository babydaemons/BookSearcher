using System;
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
                    LabelInput1.Enabled = TextBoxInput1.Enabled = Button1.Enabled = BookColumnSetting.Enabled = GroupBox5.Enabled = false;
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
            LabelInput1.Enabled = TextBoxInput1.Enabled = Button1.Enabled = BookColumnSetting.Enabled = GroupBox5.Enabled = true;
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
                    LabelInput2.Enabled = TextBoxInput2.Enabled = Button2.Enabled = ScrapingColumnSetting.Enabled = GroupBox6.Enabled = false;
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
            LabelInput2.Enabled = TextBoxInput2.Enabled = Button2.Enabled = ScrapingColumnSetting.Enabled = GroupBox6.Enabled = true;
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
                    Title = "CSVファイル出力フォルダー",
                    FileName = "フォルダー選択",
                    Filter = "CSVファイル出力フォルダー|.",
                    CheckFileExists = false
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var folderName = Path.GetDirectoryName(dialog.FileName);
                    var fileName = Path.GetFileName(folderName);
                    if (RadioButtonFileTypeCSV1.Checked)
                    {
                        TextBoxOutput1.Text = $"{folderName}\\{fileName}_パターン1.csv";
                    }
                    else
                    {
                        TextBoxOutput1.Text = $"{folderName}\\{fileName}_パターン2.csv";
                    }
                    TextBoxOutput2.Text = $"{folderName}\\{fileName}_共通出力1.csv";
                    TextBoxOutput3.Text = $"{folderName}\\{fileName}_共通出力2.csv";
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
            SetSearchContolsEnabled(false);
            ToolStripStatusLabel1.Text = "00:00:00";
            ToolStripStatusLabel2.Text = "検索処理を実行中です．．．";
            Timer1.Enabled = true;
            BackgroundWorker4.RunWorkerAsync();
        }

        private void BackgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            BookSearcher searcher = null;
            Dictionary<ColumnType, ColumnInfo> columnInfo = new Dictionary<ColumnType, ColumnInfo>();
            string searchTypeName = "";
            try
            {
                if (RadioButtonSearchType01.Checked)
                {
                    searchTypeName = RadioButtonSearchType01.Text;
                }
                if (RadioButtonSearchType02.Checked)
                {
                    searchTypeName = RadioButtonSearchType02.Text;
                }
                if (RadioButtonSearchType03.Checked)
                {
                    searchTypeName = RadioButtonSearchType03.Text;
                }
                if (RadioButtonSearchType04.Checked)
                {
                    searchTypeName = RadioButtonSearchType04.Text;
                }
                if (RadioButtonSearchType05.Checked)
                {
                    searchTypeName = RadioButtonSearchType05.Text;
                }
                if (RadioButtonSearchType06.Checked)
                {
                    searchTypeName = RadioButtonSearchType06.Text;
                }
                if (RadioButtonSearchType07.Checked)
                {
                    searchTypeName = RadioButtonSearchType07.Text;
                }
                if (RadioButtonSearchType08.Checked)
                {
                    searchTypeName = RadioButtonSearchType08.Text;
                }
                if (RadioButtonSearchType09.Checked)
                {
                    searchTypeName = RadioButtonSearchType09.Text;
                }
                if (RadioButtonSearchType10.Checked)
                {
                    searchTypeName = RadioButtonSearchType10.Text;
                }
                if (RadioButtonSearchType11.Checked)
                {
                    searchTypeName = RadioButtonSearchType11.Text;
                }
                if (RadioButtonSearchType12.Checked)
                {
                    searchTypeName = RadioButtonSearchType12.Text;
                }
                if (RadioButtonSearchType13.Checked)
                {
                    searchTypeName = RadioButtonSearchType13.Text;
                }
                if (RadioButtonSearchType14.Checked)
                {
                    searcher = new BookSearcher14(BookCSV, ScrapingCSV);
                    columnInfo.Add(ColumnType.ISBN, new ColumnInfo(MatchType.CompleteMatch, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.ISBN), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.ISBN)));
                    searchTypeName = RadioButtonSearchType14.Text;
                }
                if (RadioButtonSearchType15.Checked)
                {
                    searcher = new BookSearcher15(BookCSV, ScrapingCSV);
                    columnInfo.Add(ColumnType.BookTitle, new ColumnInfo(MatchType.CompleteMatch, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.BookTitle), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.BookTitle)));
                    searchTypeName = RadioButtonSearchType15.Text;
                }
                if (RadioButtonSearchType16.Checked)
                {
                    searchTypeName = RadioButtonSearchType16.Text;
                }
                if (RadioButtonSearchType17.Checked)
                {
                    searchTypeName = RadioButtonSearchType17.Text;
                }
                if (searcher != null)
                {
                    searcher.Search(columnInfo);
                }
                else
                {
                    MessageBox.Show("未サポートの検索パターンです。\n" + searchTypeName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            finish = DateTime.Now;
            var time = finish - start;
            MessageBox.Show(time.ToString());
            SetSearchContolsEnabled(true);
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

        private void SetSearchContolsEnabled(bool enabled)
        {
            GroupBox1.Enabled = GroupBox2.Enabled = GroupBox3.Enabled = GroupBox4.Enabled = GroupBox5.Enabled = GroupBox6.Enabled = GroupBox7.Enabled = enabled;
            BookColumnSetting.Enabled = ScrapingColumnSetting.Enabled = enabled;
        }

        private void RadioButtonSearchType_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            var csvFile = (dataGridView == BookColumnSetting) ? BookCSV : ScrapingCSV;
            var form = new Form2(csvFile);
            form.ShowDialog();
        }
    }
}
