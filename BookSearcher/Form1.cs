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
        private BookSearcher searcher = null;
        private Dictionary<ColumnType, ColumnInfo> columnInfo;
        private string searchTypeName = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonInput1_Click(object sender, EventArgs e)
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
                    BookColumnSetting.Rows.Add(new object[] { BookCSV.Titles[i], BookCSV.Fields[i], "" });
                }
                if (BookCSV.Titles.Length > 0)
                {
                    LabelInput1.Enabled = TextBoxInput1.Enabled = ButtonInput1.Enabled = false;
                    SetExecuteControlsEnabled(false);
                    BackgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BookCSV.ReadAll(BackgroundWorker1);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LabelInput1.Enabled = TextBoxInput1.Enabled = ButtonInput1.Enabled = true;
            SetExecuteControlsEnabled();
            ProgressBarInput1.Value = 100;
        }

        private void ButtonInput2_Click(object sender, EventArgs e)
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
                    ScrapingColumnSetting.Rows.Add(new object[] { ScrapingCSV.Titles[i], ScrapingCSV.Fields[i], "" });
                }
                if (ScrapingCSV.Titles.Length > 0)
                {
                    LabelInput2.Enabled = TextBoxInput2.Enabled = ButtonInput2.Enabled = false;
                    SetExecuteControlsEnabled(false);
                    BackgroundWorker2.RunWorkerAsync();
                }
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            ScrapingCSV.ReadAll(BackgroundWorker2);
        }

        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LabelInput2.Enabled = TextBoxInput2.Enabled = ButtonInput2.Enabled = true;
            SetExecuteControlsEnabled();
            ProgressBarInput2.Value = 100;
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            var csvFile = (dataGridView == BookColumnSetting) ? BookCSV : ScrapingCSV;
            if (csvFile.Loaded)
            {
                var form = new Form2(csvFile);
                form.ShowDialog();
            }
        }

        private void RadioButtonFileType_CheckedChanged(object sender, EventArgs e)
        {
            string fileType = RadioButtonFileTypeCSV1.Checked ? "出力CSVファイル(パターン1)" : "出力CSVファイル(パターン2)";
            TextBoxOutputExcel.Text = TextBoxOutputCSV.Text = TextBoxOutputCSV1.Text = "";
            LabelOutputCSV.Text = fileType;
        }

        private void ButtonOutput1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "ファイル出力フォルダー",
                FileName = "フォルダー選択",
                Filter = "ファイル出力フォルダー|.",
                CheckFileExists = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var folderName = Path.GetDirectoryName(dialog.FileName);
                var fileName = Path.GetFileName(folderName);
                TextBoxOutputExcel.Text = $"{folderName}\\{fileName}.xlsx";
                TextBoxOutputCSV.Text = RadioButtonFileTypeCSV1.Checked ? $"{folderName}\\{fileName}_パターン1.csv" : $"{folderName}\\{fileName}_パターン2.csv";
                TextBoxOutputCSV1.Text = $"{folderName}\\{fileName}_共通出力1.csv";
                TextBoxOutputCSV2.Text = $"{folderName}\\{fileName}_共通出力2.csv";
            }
        }

        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            if (!InvokeMatching())
            {
                return;
            }

            start = DateTime.Now;
            SetSearchContolsEnabled(false);
            ToolStripStatusLabel1.Text = "00:00:00";
            ToolStripStatusLabel2.Text = "検索処理を実行中です．．．";
            Timer1.Enabled = true;
            BackgroundWorker4.RunWorkerAsync();
        }

        private bool InvokeMatching()
        {
            SpaceMatch spaceMatch = RadioButtonSpaceContains.Checked ? SpaceMatch.All : SpaceMatch.Ignore;
            searcher = null;
            columnInfo = new Dictionary<ColumnType, ColumnInfo>();
            searchTypeName = "";
            try
            {
                if (RadioButtonSearchType01.Checked)
                {
                    searcher = new BookSearcher01(BookCSV, ScrapingCSV);
                    columnInfo.Add(ColumnType.BookTitle, new ColumnInfo(MatchType.CompleteMatch, spaceMatch, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.BookTitle), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.BookTitle)));
                    columnInfo.Add(ColumnType.Year, new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.Year), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.Year)));
                    searchTypeName = RadioButtonSearchType01.Text;
                }
                if (RadioButtonSearchType02.Checked)
                {
                    searcher = new BookSearcher02(BookCSV, ScrapingCSV, (int)NumericUpDownLength.Value);
                    columnInfo.Add(ColumnType.BookTitle, new ColumnInfo(MatchType.BeginningMatch, spaceMatch, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.BookTitle), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.BookTitle)));
                    columnInfo.Add(ColumnType.Year, new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.Year), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.Year)));
                    searchTypeName = RadioButtonSearchType02.Text;
                }
                if (RadioButtonSearchType03.Checked)
                {
                    searcher = new BookSearcher03(BookCSV, ScrapingCSV, (int)NumericUpDownLength.Value);
                    columnInfo.Add(ColumnType.BookTitle, new ColumnInfo(MatchType.PartialMatch, spaceMatch, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.BookTitle), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.BookTitle)));
                    columnInfo.Add(ColumnType.Year, new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.Year), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.Year)));
                    searchTypeName = RadioButtonSearchType03.Text;
                }
                if (RadioButtonSearchType04.Checked)
                {
                    searcher = new BookSearcher04(BookCSV, ScrapingCSV);
                    columnInfo.Add(ColumnType.BookTitle, new ColumnInfo(MatchType.CompleteMatch, spaceMatch, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.BookTitle), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.BookTitle)));
                    columnInfo.Add(ColumnType.Publisher, new ColumnInfo(MatchType.CompleteMatch, spaceMatch, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.Publisher), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.Publisher)));
                    searchTypeName = RadioButtonSearchType04.Text;
                }
                if (RadioButtonSearchType05.Checked)
                {
                    searcher = new BookSearcher05(BookCSV, ScrapingCSV, (int)NumericUpDownLength.Value);
                    columnInfo.Add(ColumnType.BookTitle, new ColumnInfo(MatchType.BeginningMatch, spaceMatch, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.BookTitle), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.BookTitle)));
                    columnInfo.Add(ColumnType.Publisher, new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.Publisher), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.Publisher)));
                    searchTypeName = RadioButtonSearchType05.Text;
                }
                if (RadioButtonSearchType06.Checked)
                {
                    searcher = new BookSearcher06(BookCSV, ScrapingCSV, (int)NumericUpDownLength.Value);
                    columnInfo.Add(ColumnType.BookTitle, new ColumnInfo(MatchType.PartialMatch, spaceMatch, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.BookTitle), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.BookTitle)));
                    columnInfo.Add(ColumnType.Publisher, new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.Publisher), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.Publisher)));
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
                    searcher = new BookSearcher13(BookCSV, ScrapingCSV);
                    columnInfo.Add(ColumnType.URL, new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.URL), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.URL)));
                    searchTypeName = RadioButtonSearchType13.Text;
                }
                if (RadioButtonSearchType14.Checked)
                {
                    searcher = new BookSearcher14(BookCSV, ScrapingCSV);
                    columnInfo.Add(ColumnType.ISBN, new ColumnInfo(MatchType.CompleteMatch, SpaceMatch.Ignore, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.ISBN), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.ISBN)));
                    searchTypeName = RadioButtonSearchType14.Text;
                }
                if (RadioButtonSearchType15.Checked)
                {
                    searcher = new BookSearcher15(BookCSV, ScrapingCSV);
                    columnInfo.Add(ColumnType.BookTitle, new ColumnInfo(MatchType.CompleteMatch, spaceMatch, BookSearcher.SelectColumnIndex(BookColumnSetting, ColumnType.BookTitle), BookSearcher.SelectColumnIndex(ScrapingColumnSetting, ColumnType.BookTitle)));
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
                else if (searcher == null)
                {
                    MessageBox.Show("未サポートの検索パターンです。\n" + searchTypeName);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return searcher != null;
        }

        private void BackgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            if (searcher != null)
            {
                searcher.Search(columnInfo);
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

            var form = new Form2(BookSearcher.ResultTable, searchTypeName);
            form.ShowDialog();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
        }

        private void SetExecuteControlsEnabled()
        {
            bool enabled = (BookCSV != null && BookCSV.Loaded) && (ScrapingCSV != null && ScrapingCSV.Loaded);
            SetExecuteControlsEnabled(enabled);
        }
        private void SetExecuteControlsEnabled(bool enabled)
        {
            GroupBoxExecute.Enabled = ButtonExecute.Enabled = enabled;
        }

        private void SetSearchContolsEnabled(bool enabled)
        {
            GroupBoxFiles.Enabled = GroupBoxOutput.Enabled = GroupBoxPartMatch.Enabled = GroupBoxMatchType.Enabled = GroupBoxDatabase.Enabled = GroupBoxScraping.Enabled = GroupBoxExecute.Enabled = enabled;
            BookColumnSetting.Enabled = ScrapingColumnSetting.Enabled = enabled;
        }

        private void RadioButtonSearchType_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarInput1.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarInput2.Value = e.ProgressPercentage;
        }
    }
}
