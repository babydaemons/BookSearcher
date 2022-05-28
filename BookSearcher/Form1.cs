using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public partial class Form1 : Form
    {
        protected CSVFile BookCSV;
        protected CSVFile ScrapingCSV;
        protected SpaceMatch spaceMatch;
        protected int prefixLength;
        protected BookSearcher searcher = null;
        private string searchTypeName = "";
        private string folderPath = "";
        private bool searchInitFailed = false;
        private TimeSpan searchTime;

        public Form1()
        {
            InitializeComponent();
            BookSearcher.InitColumnSettings(BookColumnSetting, ScrapingColumnSetting);

            DataGridViewOutputPattern1.Rows.Add(new object[] { "商品管理番号(真ん中2文字)", "sku", "" });
            DataGridViewOutputPattern1.Rows.Add(new object[] { "商品コードのタイプ", "product-id-type", "" });
            DataGridViewOutputPattern1.Rows.Add(new object[] { "配送パターン", "merchant_shipping_group_name", "" });
            DataGridViewOutputPattern1.Rows.Add(new object[] { "ポイントパーセント", "standard-price-points-percent", "" });
            DataGridViewOutputPattern1.Rows.Add(new object[] { "商品のコンディション", "item-condition", "" });
            DataGridViewOutputPattern1.Rows.Add(new object[] { "在庫数", "quantity", "" });
            DataGridViewOutputPattern1.Rows.Add(new object[] { "商品メモ", "item-note", "" });

            DataGridViewOutputPattern2.Rows.Add(new object[] { "商品管理番号(真ん中2文字)", "sku", "" });
            DataGridViewOutputPattern2.Rows.Add(new object[] { "商品コードのタイプ", "product-id-type", "" });
            DataGridViewOutputPattern2.Rows.Add(new object[] { "配送パターン", "merchant_shipping_group_name", "" });
            DataGridViewOutputPattern2.Rows.Add(new object[] { "ポイントパーセント", "standard-price-points-percent", "" });
            DataGridViewOutputPattern2.Rows.Add(new object[] { "商品のコンディション", "item-condition", "" });
            DataGridViewOutputPattern2.Rows.Add(new object[] { "在庫数", "quantity", "" });
            DataGridViewOutputPattern2.Rows.Add(new object[] { "商品メモ", "item-note", "" });

            DataGridViewCommonOutput1.Rows.Add(new object[] { "商品管理番号(真ん中2文字)", "sku", "" });
            DataGridViewCommonOutput1.Rows.Add(new object[] { "数量", "quantity", "" });
            DataGridViewCommonOutput1.Rows.Add(new object[] { "リードタイム", "leadtime", "" });
            DataGridViewCommonOutput1.Rows.Add(new object[] { "自動価格モードID", "autoprice_template_mode", "" });
            DataGridViewCommonOutput1.Rows.Add(new object[] { "自動価格テンプレートID", "autoprice_template_id", "" });
            DataGridViewCommonOutput1.Rows.Add(new object[] { "下限ストッパー", "autoprice_stopper", "" });
            DataGridViewCommonOutput1.Rows.Add(new object[] { "上限ストッパー", "autoprice_stopper_upper", "" });

            DataGridViewCommonOutput2.Rows.Add(new object[] { "商品管理番号(真ん中2文字)", "sku", "" });
            DataGridViewCommonOutput2.Rows.Add(new object[] { "登録/削除", "add-delete", "" });
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
                var path = dialog.FileName;
                BookCSV = CSVFile.ParseTitle(path);
                BookColumnSetting.Rows.Clear();
                if (BookCSV != null)
                {
                    for (int i = 0; i < BookCSV.Titles.Length; ++i)
                    {
                        BookColumnSetting.Rows.Add(new object[] { BookCSV.Titles[i], BookCSV.Fields[i], "" });
                    }
                    if (BookCSV.Titles.Length > 0)
                    {
                        LabelInput1.Enabled = TextBoxInput1.Enabled = ButtonInput1.Enabled = ButtonPreviewDatabase.Enabled = false;
                        SetExecuteControlsEnabled(false);
                        BackgroundWorker1.RunWorkerAsync();
                    }
                    TextBoxInput1.Text = path;
                }
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BookCSV.ReadAll(BackgroundWorker1);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LabelInput1.Enabled = TextBoxInput1.Enabled = ButtonInput1.Enabled = ButtonPreviewDatabase.Enabled = true;
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
                var path = dialog.FileName;
                ScrapingCSV = CSVFile.ParseTitle(path);
                ScrapingColumnSetting.Rows.Clear();
                if (ScrapingCSV != null)
                {
                    for (int i = 0; i < ScrapingCSV.Titles.Length; ++i)
                    {
                        ScrapingColumnSetting.Rows.Add(new object[] { ScrapingCSV.Titles[i], ScrapingCSV.Fields[i], "" });
                    }
                    if (ScrapingCSV.Titles.Length > 0)
                    {
                        LabelInput2.Enabled = TextBoxInput2.Enabled = ButtonInput2.Enabled = ButtonPreviewScraping.Enabled = false;
                        SetExecuteControlsEnabled(false);
                        BackgroundWorker2.RunWorkerAsync();
                    }
                    TextBoxInput2.Text = path;
                }
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            ScrapingCSV.ReadAll(BackgroundWorker2);
        }

        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LabelInput2.Enabled = TextBoxInput2.Enabled = ButtonInput2.Enabled = ButtonPreviewScraping.Enabled = true;
            SetExecuteControlsEnabled();
            ProgressBarInput2.Value = 100;
        }

        private void ButtonPreview_Click(object sender, EventArgs e)
        {
            var buttonPreview = (Button)sender;
            var csvFile = (buttonPreview == ButtonPreviewDatabase) ? BookCSV : ScrapingCSV;
            if (csvFile.Loaded)
            {
                var form = new Form2(csvFile);
                form.ShowDialog();
            }
        }

        private void RadioButtonFileType_CheckedChanged(object sender, EventArgs e)
        {
            string fileType = RadioButtonFileTypeCSV1.Checked ? "出力CSVファイル(パターン1)" : "出力CSVファイル(パターン2)";
            LabelOutputCSV.Text = fileType;
            SetOutputFileNames();
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
                folderPath = dialog.FileName;
                SetOutputFileNames();
            }
        }

        private void RadioButtonSearchType_CheckedChanged(object sender, EventArgs e) => SetOutputFileNames();

        private void SetOutputFileNames()
        {
            if (folderPath == null || folderPath == "")
            {
                return;
            }
            var folderName = Path.GetDirectoryName(folderPath);
            var fileName = Path.GetFileName(folderName);
            var matchingPatternName = GetMatchingPatternName();
            TextBoxOutputExcel.Text = $"{folderName}\\{fileName}_{matchingPatternName}.xlsx";
            TextBoxOutputCSV.Text = RadioButtonFileTypeCSV1.Checked ? $"{folderName}\\{fileName}_{matchingPatternName}_パターン1.csv" : $"{folderName}\\{fileName}_{matchingPatternName}_パターン2.csv";
            TextBoxOutputCSV1.Text = $"{folderName}\\{fileName}_{matchingPatternName}_共通出力1.csv";
            TextBoxOutputCSV2.Text = $"{folderName}\\{fileName}_{matchingPatternName}_共通出力2.csv";
            SetExecuteControlsEnabled();
        }

        private string GetMatchingPatternName()
        {
            var matchingPatternName = "";
            try
            {
                if (RadioButtonSearchType01.Checked)
                {
                    matchingPatternName = RadioButtonSearchType01.Text;
                }
                if (RadioButtonSearchType02.Checked)
                {
                    matchingPatternName = RadioButtonSearchType02.Text;
                }
                if (RadioButtonSearchType03.Checked)
                {
                    matchingPatternName = RadioButtonSearchType03.Text;
                }
                if (RadioButtonSearchType04.Checked)
                {
                    matchingPatternName = RadioButtonSearchType04.Text;
                }
                if (RadioButtonSearchType05.Checked)
                {
                    matchingPatternName = RadioButtonSearchType05.Text;
                }
                if (RadioButtonSearchType06.Checked)
                {
                    matchingPatternName = RadioButtonSearchType06.Text;
                }
                if (RadioButtonSearchType07.Checked)
                {
                    matchingPatternName = RadioButtonSearchType07.Text;
                }
                if (RadioButtonSearchType08.Checked)
                {
                    matchingPatternName = RadioButtonSearchType08.Text;
                }
                if (RadioButtonSearchType09.Checked)
                {
                    matchingPatternName = RadioButtonSearchType09.Text;
                }
                if (RadioButtonSearchType10.Checked)
                {
                    matchingPatternName = RadioButtonSearchType10.Text;
                }
                if (RadioButtonSearchType11.Checked)
                {
                    matchingPatternName = RadioButtonSearchType11.Text;
                }
                if (RadioButtonSearchType12.Checked)
                {
                    matchingPatternName = RadioButtonSearchType12.Text;
                }
                if (RadioButtonSearchType13.Checked)
                {
                    matchingPatternName = RadioButtonSearchType13.Text;
                }
                if (RadioButtonSearchType14.Checked)
                {
                    matchingPatternName = RadioButtonSearchType14.Text;
                }
                if (RadioButtonSearchType15.Checked)
                {
                    matchingPatternName = RadioButtonSearchType15.Text;
                }
                if (RadioButtonSearchType16.Checked)
                {
                    matchingPatternName = RadioButtonSearchType16.Text;
                }
                if (RadioButtonSearchType17.Checked)
                {
                    matchingPatternName = RadioButtonSearchType17.Text;
                }
                else if (matchingPatternName == "")
                {
                    MessageBox.Show("未サポートの検索パターンです。\n" + matchingPatternName);
                    return "未サポート";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "未サポート";
            }

            return "照合パターン" + matchingPatternName.Substring(0, 1);
        }


        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            spaceMatch = RadioButtonSpaceContains.Checked ? SpaceMatch.All : SpaceMatch.Ignore;
            prefixLength = (int)NumericUpDownLength.Value;

            if (!InvokeMatching())
            {
                return;
            }

            SetSearchControlsEnabled(false);
            Timer1.Enabled = true;
            BackgroundWorker4.RunWorkerAsync();
        }

        private bool InvokeMatching()
        {
            searcher = null;
            searchTypeName = "";
            try
            {
                BookSearcher.InitSearchSettings(BookCSV, ScrapingCSV, spaceMatch, prefixLength);

                if (RadioButtonSearchType01.Checked)
                {
                    searcher = new BookSearcher01();
                    searchTypeName = RadioButtonSearchType01.Text;
                }
                if (RadioButtonSearchType02.Checked)
                {
                    searcher = new BookSearcher02();
                    searchTypeName = RadioButtonSearchType02.Text;
                }
                if (RadioButtonSearchType03.Checked)
                {
                    searcher = new BookSearcher03();
                    searchTypeName = RadioButtonSearchType03.Text;
                }
                if (RadioButtonSearchType04.Checked)
                {
                    searcher = new BookSearcher04();
                    searchTypeName = RadioButtonSearchType04.Text;
                }
                if (RadioButtonSearchType05.Checked)
                {
                    searcher = new BookSearcher05();
                    searchTypeName = RadioButtonSearchType05.Text;
                }
                if (RadioButtonSearchType06.Checked)
                {
                    searcher = new BookSearcher06();
                    searchTypeName = RadioButtonSearchType06.Text;
                }
                if (RadioButtonSearchType07.Checked)
                {
                    searcher = new BookSearcher07();
                    searchTypeName = RadioButtonSearchType07.Text;
                }
                if (RadioButtonSearchType08.Checked)
                {
                    searcher = new BookSearcher08();
                    searchTypeName = RadioButtonSearchType08.Text;
                }
                if (RadioButtonSearchType09.Checked)
                {
                    searcher = new BookSearcher09();
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
                    searcher = new BookSearcher12();
                    searchTypeName = RadioButtonSearchType12.Text;
                }
                if (RadioButtonSearchType13.Checked)
                {
                    searcher = new BookSearcher13();
                    searchTypeName = RadioButtonSearchType13.Text;
                }
                if (RadioButtonSearchType14.Checked)
                {
                    searcher = new BookSearcher14();
                    searchTypeName = RadioButtonSearchType14.Text;
                }
                if (RadioButtonSearchType15.Checked)
                {
                    searcher = new BookSearcher15();
                    searchTypeName = RadioButtonSearchType15.Text;
                }
                if (RadioButtonSearchType16.Checked)
                {
                    searcher = new BookSearcher16();
                    searchTypeName = RadioButtonSearchType16.Text;
                }
                if (RadioButtonSearchType17.Checked)
                {
                    searcher = new BookSearcher17();
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
            try
            {
                if (searcher != null)
                {
                    searchTime = searcher.Search();
                    searchInitFailed = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                searchInitFailed = true;
            }
        }

        private void BackgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!searchInitFailed)
            {
                Timer1.Enabled = false;
                MessageBox.Show(searchTime.ToString());

                var form = new Form2(BookSearcher.ResultTable, searchTypeName);
                form.ShowDialog();
            }
            SetSearchControlsEnabled(true);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
        }

        private void SetExecuteControlsEnabled()
        {
            bool enabled = (BookCSV != null && BookCSV.Loaded) && (ScrapingCSV != null && ScrapingCSV.Loaded) &&
                            TextBoxInput1.Text.Length > 0 && TextBoxInput2.Text.Length > 0 &&
                            TextBoxOutputExcel.Text.Length > 0 && TextBoxOutputCSV.Text.Length > 0 && TextBoxOutputCSV1.Text.Length > 0 && TextBoxOutputCSV2.Text.Length > 0;
            SetExecuteControlsEnabled(enabled);
        }

        private void SetExecuteControlsEnabled(bool enabled) => GroupBoxExecute.Enabled = ButtonExecute.Enabled = enabled;

        private void TextBoxFileName_TextChanged(object sender, EventArgs e) => SetExecuteControlsEnabled();


        private void SetSearchControlsEnabled(bool enabled)
        {
            GroupBoxFiles.Enabled = GroupBoxOutput.Enabled = GroupBoxPartMatch.Enabled = GroupBoxExecute.Enabled = enabled;
            BookColumnSetting.Enabled = ScrapingColumnSetting.Enabled = enabled;
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarInput1.Value = e.ProgressPercentage;

        private void BackgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarInput2.Value = e.ProgressPercentage;
    }
}
