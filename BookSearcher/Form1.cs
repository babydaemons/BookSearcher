using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public partial class Form1 : Form
    {
        public readonly ParallelOptions parallelOptions = new ParallelOptions();
        public static int ProcessorCount { get; private set; }
        public string ConfigXml { get; private set; }

        protected CSVFile BookCSV;
        protected CSVFile ScrapingCSV;
        protected ExcelSaver excelSaver;
        protected DataSaver saver0;
        protected DataSaver saver1;
        protected DataSaver saver2;
        protected SpaceMatch spaceMatch;
        protected int prefixLength;
        protected BookSearcher searcher = null;
        protected Stopwatch searchTimer = new Stopwatch();
        private string searchTypeName = "";
        private string folderPath = "";
        private bool searchInitFailed = false;
        private readonly string[] extensions = new string[] { ".csv", ".txt", ".xlsx" };

        public Form1()
        {
            InitializeComponent();
            Text = Properties.Resources.Version;

            BookSearcher.InitColumnSettings(BookColumnSetting, ScrapingColumnSetting);
            ProcessorCount = Environment.ProcessorCount;
            NumericUpDownUseCpuCoreCount.Maximum = ProcessorCount;
            NumericUpDownUseCpuCoreCount.Value = ProcessorCount;
            LabelTotalCpuCoreCount.Text = $"コア / 全 {ProcessorCount} コア";

            var textBoxList = new TextBox[] { TextBoxOutputCSV, TextBoxOutputCSV1, TextBoxOutputCSV2 };
            var comboBoxList = new ComboBox[] { ComboBoxOutputPattern, ComboBoxOutputCommon1, ComboBoxOutputCommon2 };
            foreach (var i in Enumerable.Range(0, comboBoxList.Length))
            {
                textBoxList[i].Tag = 0;
                comboBoxList[i].Tag = textBoxList[i];
                comboBoxList[i].SelectedIndex = 0;
            }

            var assembly = Assembly.GetEntryAssembly();
            if (assembly != null)
            {
                var appPath = Assembly.GetEntryAssembly().Location;
                var appDir = Path.GetDirectoryName(appPath);
                var fileName = Path.GetFileNameWithoutExtension(appPath);
                ConfigXml = $"{appDir}\\{fileName}.xml";
            }
            InitDataSettings(true, true);

            DataSaver.InitHeaders();
        }

        public Form1(bool readXml, bool reportError)
        {
            InitializeComponent();
            BookSearcher.InitColumnSettings(BookColumnSetting, ScrapingColumnSetting);
            ProcessorCount = Environment.ProcessorCount;
            InitDataSettings(readXml, reportError);
        }

        protected void InitDataSettings(bool readXml, bool reportError)
        {
            if (readXml && ConfigXml != null && File.Exists(ConfigXml))
            {
                DataSetSetting.ReadXml(ConfigXml);
            }

            if (!IsValidTable(DataTableOutputPattern1, "CSVパターン1", 7, reportError))
            {
                DataTableOutputPattern1.Rows.Clear();
                DataTableOutputPattern1.Rows.Add(new object[] { "商品管理番号(商品コード以降)", "sku", "" });
                DataTableOutputPattern1.Rows.Add(new object[] { "商品コードのタイプ", "product-id-type", "" });
                DataTableOutputPattern1.Rows.Add(new object[] { "配送パターン", "merchant_shipping_group_name", "" });
                DataTableOutputPattern1.Rows.Add(new object[] { "ポイントパーセント", "standard-price-points-percent", "" });
                DataTableOutputPattern1.Rows.Add(new object[] { "商品のコンディション", "item-condition", "" });
                DataTableOutputPattern1.Rows.Add(new object[] { "在庫数", "quantity", "" });
                DataTableOutputPattern1.Rows.Add(new object[] { "商品メモ", "item-note", "" });
            }

            if (!IsValidTable(DataTableOutputPattern2, "CSVパターン2", 7, reportError))
            {
                DataTableOutputPattern2.Rows.Clear();
                DataTableOutputPattern2.Rows.Add(new object[] { "商品管理番号(商品コード以降)", "sku", "" });
                DataTableOutputPattern2.Rows.Add(new object[] { "商品コードのタイプ", "product-id-type", "" });
                DataTableOutputPattern2.Rows.Add(new object[] { "配送パターン", "merchant_shipping_group_name", "" });
                DataTableOutputPattern2.Rows.Add(new object[] { "ポイントパーセント", "standard-price-points-percent", "" });
                DataTableOutputPattern2.Rows.Add(new object[] { "商品のコンディション", "item-condition", "" });
                DataTableOutputPattern2.Rows.Add(new object[] { "在庫数", "quantity", "" });
                DataTableOutputPattern2.Rows.Add(new object[] { "商品メモ", "item-note", "" });
            }

            if (!IsValidTable(DataTableCommonOutput1, "共通CSV1", 7, reportError))
            {
                DataTableCommonOutput1.Rows.Clear();
                DataTableCommonOutput1.Rows.Add(new object[] { "商品管理番号(商品コード以降)", "sku", "" });
                DataTableCommonOutput1.Rows.Add(new object[] { "数量", "quantity", "" });
                DataTableCommonOutput1.Rows.Add(new object[] { "リードタイム", "leadtime", "" });
                DataTableCommonOutput1.Rows.Add(new object[] { "自動価格モードID", "autoprice_template_mode", "" });
                DataTableCommonOutput1.Rows.Add(new object[] { "自動価格テンプレートID", "autoprice_template_id", "" });
                DataTableCommonOutput1.Rows.Add(new object[] { "下限ストッパー", "autoprice_stopper", "" });
                DataTableCommonOutput1.Rows.Add(new object[] { "上限ストッパー", "autoprice_stopper_upper", "" });
            }

            if (!IsValidTable(DataTableCommonOutput2, "共通CSV2", 2, reportError))
            {
                DataTableCommonOutput2.Rows.Clear();
                DataTableCommonOutput2.Rows.Add(new object[] { "商品管理番号(商品コード以降)", "sku", "" });
                DataTableCommonOutput2.Rows.Add(new object[] { "登録/削除", "add-delete", "" });
            }

            if (!IsValidTable(DataTableCostRatio, "料率", 5, reportError))
            {
                // double selling_price = (cost + 88 + 110 + 330 + 550 + (cost * 0.15)) * IF(cost > 20000, 1.52, IF(cost > 10000, 1.49, IF(cost > 5000, 1.46, IF(cost > 3000, 1.43, IF(cost >= 1, 1.42, 0.00)))));
                DataTableCostRatio.Rows.Clear();
                DataTableCostRatio.Rows.Add(new object[] { 20000, 1.52 });
                DataTableCostRatio.Rows.Add(new object[] { 10000, 1.49 });
                DataTableCostRatio.Rows.Add(new object[] { 5000, 1.46 });
                DataTableCostRatio.Rows.Add(new object[] { 3000, 1.43 });
                DataTableCostRatio.Rows.Add(new object[] { 0, 1.42 });
            }
        }

        protected bool IsValidTable(DataTable table, string dataName, int rowCount, bool reportError)
        {
            bool ok = true;
            try
            {
                if (table.Rows.Count != rowCount)
                {
                    ok = false;
                    if (reportError)
                    {
                        throw new MyException($"「{dataName}」設定破損エラー", "リリース出荷時の初期値に復旧しました。");
                    }
                }

                foreach (DataRow row in table.Rows)
                {
                    if (row[0] == DBNull.Value || row[1] == DBNull.Value)
                    {
                        ok = false;
                        if (reportError)
                        {
                            throw new MyException($"「{dataName}」設定破損エラー", "リリース出荷時の初期値に復旧しました。");
                        }
                    }
                }
            }
            catch (MyException ex)
            {
                ex.Show();
            }
            return ok;
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
                try
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
                catch (MyException ex)
                {
                    ex.Show();
                }
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BookCSV.ReadAll(BackgroundWorker1, ProgressBarInput1);
            }
            catch (MyException ex)
            {
                ex.Show();
            }
            catch (Exception ex)
            {
                MyExceptionHandler.Show(ex);
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LabelInput1.Enabled = TextBoxInput1.Enabled = ButtonInput1.Enabled = ButtonPreviewDatabase.Enabled = true;
            SetExecuteControlsEnabled();
            InitColumnSetting(BookCSV, BookColumnSetting);
            ProgressBarInput1.Stop(BookCSV);
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
            try
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
            catch (MyException ex)
            {
                ex.Show();
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ScrapingCSV.ReadAll(BackgroundWorker2, ProgressBarInput2);
            }
            catch (MyException ex)
            {
                ex.Show();
            }
            catch (Exception ex)
            {
                MyExceptionHandler.Show(ex);
            }
        }

        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LabelInput2.Enabled = TextBoxInput2.Enabled = ButtonInput2.Enabled = ButtonPreviewScraping.Enabled = true;
            SetExecuteControlsEnabled();
            InitColumnSetting(ScrapingCSV, ScrapingColumnSetting);
            ProgressBarInput2.Stop(ScrapingCSV);
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
            DataGridViewOutputPattern1.Enabled = RadioButtonFileTypeCSV1.Checked;
            DataGridViewOutputPattern2.Enabled = RadioButtonFileTypeCSV2.Checked;
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
            var n = RadioButtonFileTypeCSV1.Checked ? 1 : 2;
            TextBoxOutputExcel.Text = $"{folderName}\\{fileName}_{matchingPatternName}.xlsx";
            TextBoxOutputCSV.Text = $"{folderName}\\{fileName}_{matchingPatternName}_パターン{n}{extensions[ComboBoxOutputPattern.SelectedIndex]}";
            TextBoxOutputCSV1.Text = $"{folderName}\\{fileName}_{matchingPatternName}_共通出力1{extensions[ComboBoxOutputCommon1.SelectedIndex]}";
            TextBoxOutputCSV2.Text = $"{folderName}\\{fileName}_{matchingPatternName}_共通出力2{extensions[ComboBoxOutputCommon2.SelectedIndex]}";
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
            bool search_started = false;

            excelSaver = null;
            saver0 = null;
            saver1 = null;
            saver2 = null;

            try
            {
                DataSaver.InitCostTable(DataTableCostRatio);

                ProgressBarOutputExcel.Start();
                ProgressBarOutputPatternCSV.Start();
                ProgressBarOutputCommonCSV1.Start();
                ProgressBarOutputCommonCSV2.Start();

                if (!InvokeMatching())
                {
                    return;
                }

                excelSaver = new ExcelSaver(TextBoxOutputExcel.Text);
                if (RadioButtonFileTypeCSV1.Checked)
                {
                    saver0 = new DataSaverPattern1(DataGridViewOutputPattern1, TextBoxOutputCSV.Text);
                }
                else
                {
                    saver0 = new DataSaverPattern2(DataGridViewOutputPattern2, TextBoxOutputCSV.Text);
                }
                saver1 = new DataSaverCommon1(DataGridViewCommonOutput1, TextBoxOutputCSV1.Text);
                saver2 = new DataSaverCommon2(DataGridViewCommonOutput2, TextBoxOutputCSV2.Text);

                spaceMatch = RadioButtonSpaceContains.Checked ? SpaceMatch.All : SpaceMatch.Ignore;
                prefixLength = (int)NumericUpDownLength.Value;

                search_started = true;
                SetSearchControlsEnabled(false);
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
            catch (Exception ex)
            {
                MyExceptionHandler.Show(ex);
            }
            finally
            {
                if (!search_started)
                {
                    excelSaver?.Dispose();
                    excelSaver = null;
                    saver0?.Dispose();
                    saver0 = null;
                    saver1?.Dispose();
                    saver1 = null;
                    saver2?.Dispose();
                    saver2 = null;
                    GC.Collect(0, GCCollectionMode.Forced);
                }
            }
        }

        private bool InvokeMatching()
        {
            searcher = null;
            searchTypeName = "";
            try
            {
                BookSearcher.InitOutputSetting(CheckBoxBookISBN.Checked, CheckBoxBookCost.Checked);
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
            catch (Exception ex)
            {
                MyExceptionHandler.Show(ex);
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
            catch (MyException ex)
            {
                ex.Show();
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

        private void BackgroundWorker10_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                excelSaver.Save(BackgroundWorker10, ProgressBarOutputExcel);
            }
            catch (MyException ex)
            {
                ex.Show();
            }
            catch (Exception ex) // for internal error handling
            {
                MyExceptionHandler.Show(ex);
            }
            finally
            {
                excelSaver.Dispose();
            }
        }

        private void BackgroundWorker10_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarOutputExcel.Value = e.ProgressPercentage;

        private void BackgroundWorker10_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarOutputExcel.Stop(excelSaver);
            UpdateExecuteControlsEnabled();
        }

        private void BackgroundWorker11_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                saver0.Save(BackgroundWorker11, ProgressBarOutputPatternCSV);
            }
            catch (MyException ex)
            {
                ex.Show();
            }
            catch (Exception ex) // for internal error handling
            {
                MyExceptionHandler.Show(ex);
            }
            finally
            {
                saver0.Dispose();
            }
        }

        private void BackgroundWorker11_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarOutputPatternCSV.Value = e.ProgressPercentage;

        private void BackgroundWorker11_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarOutputPatternCSV.Stop(saver0);
            UpdateExecuteControlsEnabled();
        }

        private void BackgroundWorker12_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                saver1.Save(BackgroundWorker12, ProgressBarOutputCommonCSV1);
            }
            catch (MyException ex)
            {
                ex.Show();
            }
            catch (Exception ex) // for internal error handling
            {
                MyExceptionHandler.Show(ex);
            }
            finally
            {
                saver1.Dispose();
            }
        }

        private void BackgroundWorker12_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarOutputCommonCSV1.Value = e.ProgressPercentage;

        private void BackgroundWorker12_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarOutputCommonCSV1.Stop(saver1);
            UpdateExecuteControlsEnabled();
        }

        private void BackgroundWorker13_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                saver2.Save(BackgroundWorker13, ProgressBarOutputCommonCSV2);
            }
            catch (MyException ex)
            {
                ex.Show();
            }
            catch (Exception ex) // for internal error handling
            {
                MyExceptionHandler.Show(ex);
            }
            finally
            {
                saver2.Dispose();
            }
        }

        private void BackgroundWorker13_ProgressChanged(object sender, ProgressChangedEventArgs e) => ProgressBarOutputCommonCSV2.Value = e.ProgressPercentage;

        private void BackgroundWorker13_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarOutputCommonCSV2.Stop(saver2);
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

        public static void UpdateProgressBar(DataIO fileIO, ProgressBar progressBar)
        {
            if (fileIO == null)
            {
                return;
            }
            progressBar.Value = fileIO.Progress;
            progressBar.Text = fileIO.CurrentProgress;
            progressBar.Invalidate();
        }

        private void CheckBoxISBN_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                if (checkBox == CheckBoxBookISBN && CheckBoxScrapingISBN.Checked)
                {
                    CheckBoxScrapingISBN.Checked = false;
                }
                else if (checkBox == CheckBoxScrapingISBN && CheckBoxBookISBN.Checked)
                {
                    CheckBoxBookISBN.Checked = false;
                }
            }
            else
            {
                if (checkBox == CheckBoxBookISBN && !CheckBoxScrapingISBN.Checked)
                {
                    CheckBoxScrapingISBN.Checked = true;
                }
                else if (checkBox == CheckBoxScrapingISBN && !CheckBoxBookISBN.Checked)
                {
                    CheckBoxBookISBN.Checked = true;
                }
            }
        }

        private void CheckBoxCost_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                if (checkBox == CheckBoxBookCost && CheckBoxScrapingCost.Checked)
                {
                    CheckBoxScrapingCost.Checked = false;
                }
                else if (checkBox == CheckBoxScrapingCost && CheckBoxBookCost.Checked)
                {
                    CheckBoxBookCost.Checked = false;
                }
            }
            else
            {
                if (checkBox == CheckBoxBookCost && !CheckBoxScrapingCost.Checked)
                {
                    CheckBoxScrapingCost.Checked = true;
                }
                else if (checkBox == CheckBoxScrapingCost && !CheckBoxBookCost.Checked)
                {
                    CheckBoxBookCost.Checked = true;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DataSetSetting.WriteXml(ConfigXml);
            }
            catch (Exception ex)
            {
                var myException = new MyException("設定ファイル保存エラー", ConfigXml, ex);
                myException.Show();
            }
        }

        private void TextBoxFileName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var textBox = sender as TextBox;
                if (!File.Exists(textBox.Text))
                {
                    throw new MyException("ファイルが見つかりませんでした", $"ダブルクリックで開こうとしたファイルが見つかりませんでした。\n\n{textBox.Text}");
                }
                Process.Start(textBox.Text);
            }
            catch (MyException ex)
            {
                ex.Show();
            }
            catch (Exception ex)
            {
                MyExceptionHandler.Show(ex);
            }
        }

        private void ComboBoxOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var textBox = comboBox.Tag as TextBox;
            if (comboBox.SelectedIndex == -1)
            {
                comboBox.SelectedIndex = (int)textBox.Tag;
            }
            textBox.Tag = comboBox.SelectedIndex;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                return;
            }
            var outputPath = textBox.Text;
            var outputDir = Path.GetDirectoryName(outputPath);
            var outputFileName = Path.GetFileNameWithoutExtension(outputPath);
            var extension = extensions[comboBox.SelectedIndex];
            textBox.Text = $"{outputDir}\\{outputFileName}{extension}";
        }
    }
}
