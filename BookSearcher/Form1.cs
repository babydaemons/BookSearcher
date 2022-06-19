﻿using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public partial class Form1 : Form
    {
        public readonly ParallelOptions parallelOptions = new ParallelOptions();
        public static int ProcessorCount { get; private set; }
        protected CSVFile BookCSV;
        protected CSVFile ScrapingCSV;
        protected ExcelSaver excelSaver;
        protected CSVSaver saver0;
        protected CSVSaver saver1;
        protected CSVSaver saver2;
        protected SpaceMatch spaceMatch;
        protected int prefixLength;
        protected BookSearcher searcher = null;
        protected Stopwatch searchTimer = new Stopwatch();
        private string searchTypeName = "";
        private string folderPath = "";
        private bool searchInitFailed = false;

        public Form1()
        {
            InitializeComponent();
            Text = Properties.Resources.Version;

            BookSearcher.InitColumnSettings(BookColumnSetting, ScrapingColumnSetting);
            ProcessorCount = Environment.ProcessorCount;
            NumericUpDownUseCpuCoreCount.Maximum = ProcessorCount;
            NumericUpDownUseCpuCoreCount.Value = ProcessorCount;
            LabelTotalCpuCoreCount.Text = $"コア / 全 {ProcessorCount} コア";

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
                Filter = "Excelファイル|*.xlsx|CSVファイル|*.csv"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var path = dialog.FileName;
                BookCSV = CSVFile.ParseTitle(path);
                BookColumnSetting.Rows.Clear();
                if (BookCSV != null)
                {
                    TextBoxInput1.Text = path;
                    LabelInput1.Enabled = TextBoxInput1.Enabled = ButtonInput1.Enabled = ButtonPreviewDatabase.Enabled = ButtonPreviewOutputs.Enabled = false;
                    ProgressBarOutputExcel.Value = ProgressBarOutputPatternCSV.Value = ProgressBarOutputCommonCSV1.Value = ProgressBarOutputCommonCSV2.Value = 0;
                    SetExecuteControlsEnabled(false);
                    InitColumnSetting(BookCSV, BookColumnSetting);
                    ProgressBarInput1.Start();
                    BackgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BookCSV.ReadAll(BackgroundWorker1, ProgressBarInput1);
            }
            catch (Exception ex) // for internal error handling
            {
                MyExceptionHandler.Show(ex);
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LabelInput1.Enabled = TextBoxInput1.Enabled = ButtonInput1.Enabled = ButtonPreviewDatabase.Enabled = true;
            SetExecuteControlsEnabled();
            InitColumnSetting(BookCSV, BookColumnSetting);
            ProgressBarInput1.Stop();
        }

        private void InitColumnSetting(CSVFile csvFile, DataGridView columnSetting)
        {
            if (csvFile == null) { return; }
            if (columnSetting.Rows.Count > 0) { return; }

            if (csvFile.Titles != null)
            {
                for (int i = 0; i < csvFile.Titles.Length; ++i)
                {
                    columnSetting.Rows.Add(new object[] { csvFile.Titles[i], csvFile.Fields[i], "" });
                }
            }
        }

        private void ButtonInput2_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "スクレイピングデータファイル",
                Filter = "CSVファイル|*.csv|Excelファイル|*.xlsx"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var path = dialog.FileName;
                ScrapingCSV = CSVFile.ParseTitle(path);
                ScrapingColumnSetting.Rows.Clear();
                if (ScrapingCSV != null)
                {
                    LabelInput2.Enabled = TextBoxInput2.Enabled = ButtonInput2.Enabled = ButtonPreviewScraping.Enabled = ButtonPreviewOutputs.Enabled = false;
                    ProgressBarOutputExcel.Value = ProgressBarOutputPatternCSV.Value = ProgressBarOutputCommonCSV1.Value = ProgressBarOutputCommonCSV2.Value = 0;
                    SetExecuteControlsEnabled(false);
                    InitColumnSetting(ScrapingCSV, ScrapingColumnSetting);
                    ProgressBarInput2.Start();
                    BackgroundWorker2.RunWorkerAsync();
                    TextBoxInput2.Text = path;
                }
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ScrapingCSV.ReadAll(BackgroundWorker2, ProgressBarInput2);
            }
            catch (Exception ex) // for internal error handling
            {
                MyExceptionHandler.Show(ex);
            }
        }

        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LabelInput2.Enabled = TextBoxInput2.Enabled = ButtonInput2.Enabled = ButtonPreviewScraping.Enabled = true;
            SetExecuteControlsEnabled();
            InitColumnSetting(ScrapingCSV, ScrapingColumnSetting);
            ProgressBarInput2.Stop();
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
#if DEBUG
            SetSearchControlsEnabled(true);
            SetExecuteControlsEnabled(true);
#endif
        }

        private void RadioButtonFileType_CheckedChanged(object sender, EventArgs e)
        {
            string fileType = RadioButtonFileTypeCSV1.Checked ? "出力CSVファイル(パターン1)" : "出力CSVファイル(パターン2)";
            DataGridViewOutputPattern1.Enabled = RadioButtonFileTypeCSV1.Checked;
            DataGridViewOutputPattern2.Enabled = RadioButtonFileTypeCSV2.Checked;
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
            return "照合パターン" + matchingPatternName.Substring(0, 1);
        }


        private void ButtonExecute_Click(object sender, EventArgs e)
        {
            try
            {
                excelSaver = new ExcelSaver(TextBoxOutputExcel.Text);
                if (RadioButtonFileTypeCSV1.Checked)
                {
                    saver0 = new CSVSaverPattern1(DataGridViewOutputPattern1, TextBoxOutputCSV.Text);
                }
                else
                {
                    saver0 = new CSVSaverPattern2(DataGridViewOutputPattern2, TextBoxOutputCSV.Text);
                }
                saver1 = new CSVSaverCommon1(DataGridViewCommonOutput1, TextBoxOutputCSV1.Text);
                saver2 = new CSVSaverCommon2(DataGridViewCommonOutput2, TextBoxOutputCSV2.Text);

                spaceMatch = RadioButtonSpaceContains.Checked ? SpaceMatch.All : SpaceMatch.Ignore;
                prefixLength = (int)NumericUpDownLength.Value;

                if (!InvokeMatching())
                {
                    return;
                }

                SetSearchControlsEnabled(false);
                ProgressBarOutputExcel.Value = ProgressBarOutputPatternCSV.Value = ProgressBarOutputCommonCSV1.Value = ProgressBarOutputCommonCSV2.Value = 0;
                TimerSearch.Enabled = true;
                searchTimer = Stopwatch.StartNew();
                ProcessorCount = (int)NumericUpDownUseCpuCoreCount.Value;
                parallelOptions.MaxDegreeOfParallelism = ProcessorCount;
                BackgroundWorker4.RunWorkerAsync();
            }
            catch (MyException ex)
            {
                ex.Show();
            }
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
                    searcher = new BookSearcher10();
                    searchTypeName = RadioButtonSearchType10.Text;
                }
                if (RadioButtonSearchType11.Checked)
                {
                    searcher = new BookSearcher11();
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
            catch (MyException ex)
            {
                ex.Show();
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
                    searcher.Search();
                    searchInitFailed = false;
                }
            }
            catch (Exception ex) // for internal error handling
            {
                MyExceptionHandler.Show(ex);
                searchInitFailed = true;
            }
        }

        private void BackgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (searchInitFailed)
            {
                return;
            }
            searchTimer.Stop();
            ProgressBarOutputExcel.Start();
            ProgressBarOutputPatternCSV.Start();
            ProgressBarOutputCommonCSV1.Start();
            ProgressBarOutputCommonCSV2.Start();
            BackgroundWorker10.RunWorkerAsync();
            BackgroundWorker11.RunWorkerAsync();
            BackgroundWorker12.RunWorkerAsync();
            BackgroundWorker13.RunWorkerAsync();
        }

        private void TimerSearch_Tick(object sender, EventArgs e)
        {
            if (searchInitFailed || searchTimer == null)
            {
                return;
            }
            LabelElapsed.Text = "経過時間 " + searchTimer.Elapsed.ToString(@"hh\:mm\:ss\.fff");
            LabelResultRows.Text = $"{BookSearcher.ResultCount} 件";
        }

        private void SetExecuteControlsEnabled()
        {
            bool enabled = (BookCSV != null && BookCSV.Loaded) && (ScrapingCSV != null && ScrapingCSV.Loaded) &&
                            TextBoxInput1.Text.Length > 0 && TextBoxInput2.Text.Length > 0 &&
                            TextBoxOutputExcel.Text.Length > 0 && TextBoxOutputCSV.Text.Length > 0 && TextBoxOutputCSV1.Text.Length > 0 && TextBoxOutputCSV2.Text.Length > 0;
            SetExecuteControlsEnabled(enabled);
        }

        private void SetExecuteControlsEnabled(bool enabled) => GroupBoxExecute.Enabled = ButtonExecute.Enabled = enabled;

        private void UpdateExecuteControlsEnabled()
        {
            bool enabled = ProgressBarOutputExcel.Completed && ProgressBarOutputPatternCSV.Completed && ProgressBarOutputCommonCSV1.Completed && ProgressBarOutputCommonCSV2.Completed;
            if (enabled)
            {
                TimerSearch.Enabled = false;
                searchTimer.Stop();
                SetExecuteControlsEnabled(enabled);
                SetSearchControlsEnabled(enabled);
                ButtonPreviewOutputs.Enabled = enabled;
            }
        }

        private void TextBoxFileName_TextChanged(object sender, EventArgs e) => SetExecuteControlsEnabled();


        private void SetSearchControlsEnabled(bool enabled)
        {
            GroupBoxFiles.Enabled = GroupBoxOutput.Enabled = GroupBoxPartMatch.Enabled = GroupBoxCpuCores.Enabled = GroupBoxExecute.Enabled = GroupBoxAllMatch.Enabled = PanelMatchCondition.Enabled = enabled;
            BookColumnSetting.Enabled = ScrapingColumnSetting.Enabled = enabled;
            DataGridViewOutputPattern1.Enabled = DataGridViewOutputPattern2.Enabled = DataGridViewCommonOutput1.Enabled = DataGridViewCommonOutput2.Enabled = enabled;
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarInput1.Value = e.ProgressPercentage;

        private void BackgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarInput2.Value = e.ProgressPercentage;

        private void BackgroundWorker10_DoWork(object sender, DoWorkEventArgs e) => excelSaver.Save(BackgroundWorker10, ProgressBarOutputExcel);

        private void BackgroundWorker10_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarOutputExcel.Value = e.ProgressPercentage;

        private void BackgroundWorker10_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarOutputExcel.Stop();
            UpdateExecuteControlsEnabled();
        }

        private void BackgroundWorker11_DoWork(object sender, DoWorkEventArgs e) => saver0.Save(BackgroundWorker11, ProgressBarOutputPatternCSV);

        private void BackgroundWorker11_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarOutputPatternCSV.Value = e.ProgressPercentage;

        private void BackgroundWorker11_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarOutputPatternCSV.Stop();
            UpdateExecuteControlsEnabled();
        }

        private void BackgroundWorker12_DoWork(object sender, DoWorkEventArgs e) => saver1.Save(BackgroundWorker12, ProgressBarOutputCommonCSV1);

        private void BackgroundWorker12_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarOutputCommonCSV1.Value = e.ProgressPercentage;

        private void BackgroundWorker12_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarOutputCommonCSV1.Stop();
            UpdateExecuteControlsEnabled();
        }

        private void BackgroundWorker13_DoWork(object sender, DoWorkEventArgs e) => saver2.Save(BackgroundWorker13, ProgressBarOutputCommonCSV2);

        private void BackgroundWorker13_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarOutputCommonCSV2.Value = e.ProgressPercentage;

        private void BackgroundWorker13_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarOutputCommonCSV2.Stop();
            UpdateExecuteControlsEnabled();
        }

        private void ButtonPreviewOutputs_Click(object sender, EventArgs e)
        {
            var form3 = RadioButtonFileTypeCSV1.Checked ?
                new Form3(searchTypeName, BookSearcher.ResultTables[0], saver0.DataTable, new DataTable(), saver1.DataTable, saver2.DataTable) :
                new Form3(searchTypeName, BookSearcher.ResultTables[0], new DataTable(), saver0.DataTable, saver1.DataTable, saver2.DataTable);
            form3.ShowDialog();
        }

        private void TimerFileIO_Tick(object sender, EventArgs e)
        {
            UpdateProgressBar(BookCSV, ProgressBarInput1);
            UpdateProgressBar(ScrapingCSV, ProgressBarInput2);
            UpdateProgressBar(excelSaver, ProgressBarOutputExcel);
            UpdateProgressBar(saver0, ProgressBarOutputPatternCSV);
            UpdateProgressBar(saver1, ProgressBarOutputCommonCSV1);
            UpdateProgressBar(saver2, ProgressBarOutputCommonCSV2);
        }

        private void UpdateProgressBar(FileIO fileIO, ProgressBar progressBar)
        {
            if (fileIO != null && fileIO.IsRunning)
            {
                progressBar.Value = fileIO.Progress;
                progressBar.Text = fileIO.CurrentProgress;
                progressBar.Invalidate();
            }
        }
    }
}
