﻿namespace BookSearcherApp
{
    partial class Form1
    {
        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TimerSearch = new System.Windows.Forms.Timer(this.components);
            this.BackgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GroupBoxOutput = new System.Windows.Forms.GroupBox();
            this.RadioButtonFileTypeCSV2 = new System.Windows.Forms.RadioButton();
            this.RadioButtonFileTypeCSV1 = new System.Windows.Forms.RadioButton();
            this.GroupBoxPartMatch = new System.Windows.Forms.GroupBox();
            this.NumericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBoxExecute = new System.Windows.Forms.GroupBox();
            this.LabelResultRows = new System.Windows.Forms.Label();
            this.LabelElapsed = new System.Windows.Forms.Label();
            this.ButtonExecute = new System.Windows.Forms.Button();
            this.GroupBoxFiles = new System.Windows.Forms.GroupBox();
            this.LabelOutputCSV = new System.Windows.Forms.Label();
            this.TextBoxOutputCSV2 = new System.Windows.Forms.TextBox();
            this.LabelOutputCSV2 = new System.Windows.Forms.Label();
            this.LabelOutputCSV1 = new System.Windows.Forms.Label();
            this.TextBoxOutputCSV1 = new System.Windows.Forms.TextBox();
            this.TextBoxOutputCSV = new System.Windows.Forms.TextBox();
            this.ButtonOutput1 = new System.Windows.Forms.Button();
            this.ButtonInput2 = new System.Windows.Forms.Button();
            this.ButtonInput1 = new System.Windows.Forms.Button();
            this.TextBoxOutputExcel = new System.Windows.Forms.TextBox();
            this.TextBoxInput2 = new System.Windows.Forms.TextBox();
            this.TextBoxInput1 = new System.Windows.Forms.TextBox();
            this.LabelOutputExcel = new System.Windows.Forms.Label();
            this.LabelInput2 = new System.Windows.Forms.Label();
            this.LabelInput1 = new System.Windows.Forms.Label();
            this.GroupBoxAllMatch = new System.Windows.Forms.GroupBox();
            this.RadioButtonSpaceIgnore = new System.Windows.Forms.RadioButton();
            this.RadioButtonSpaceContains = new System.Windows.Forms.RadioButton();
            this.TabControlOutputSetting = new System.Windows.Forms.TabControl();
            this.TabPageDatabaseColumn = new System.Windows.Forms.TabPage();
            this.TableLayoutPanelBook = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonPreviewDatabase = new System.Windows.Forms.Button();
            this.BookColumnSetting = new System.Windows.Forms.DataGridView();
            this.BookColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CheckBoxBookISBN = new System.Windows.Forms.CheckBox();
            this.CheckBoxBookCost = new System.Windows.Forms.CheckBox();
            this.TabPageScrapingColumn = new System.Windows.Forms.TabPage();
            this.TableLayoutPanelScraping = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonPreviewScraping = new System.Windows.Forms.Button();
            this.ScrapingColumnSetting = new System.Windows.Forms.DataGridView();
            this.ScrapingColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CheckBoxScrapingISBN = new System.Windows.Forms.CheckBox();
            this.CheckBoxScrapingCost = new System.Windows.Forms.CheckBox();
            this.TabControlMatchingOutput = new System.Windows.Forms.TabControl();
            this.TabPageMatching = new System.Windows.Forms.TabPage();
            this.PanelMatchCondition = new System.Windows.Forms.Panel();
            this.RadioButtonSearchType17 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType16 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType15 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType14 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType13 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType12 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType11 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType10 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType09 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType08 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType07 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType06 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType05 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType04 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType03 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType02 = new System.Windows.Forms.RadioButton();
            this.RadioButtonSearchType01 = new System.Windows.Forms.RadioButton();
            this.TabPageOutputSetting = new System.Windows.Forms.TabPage();
            this.TabControlOutputFileSetting = new System.Windows.Forms.TabControl();
            this.TabPageOutputPattern1 = new System.Windows.Forms.TabPage();
            this.DataGridViewOutputPattern1 = new System.Windows.Forms.DataGridView();
            this.ColumnJapaneseName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnglishName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettingValue1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataTableOutputPattern1 = new System.Data.DataTable();
            this.DataColumnNameJP1 = new System.Data.DataColumn();
            this.DataColumnNameEN1 = new System.Data.DataColumn();
            this.DataColumnValue1 = new System.Data.DataColumn();
            this.TabPageOutputPattern2 = new System.Windows.Forms.TabPage();
            this.DataGridViewOutputPattern2 = new System.Windows.Forms.DataGridView();
            this.ColumnJapaneseName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnglishName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettingValue2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataTableOutputPattern2 = new System.Data.DataTable();
            this.DataColumnNameJP2 = new System.Data.DataColumn();
            this.DataColumnNameEN2 = new System.Data.DataColumn();
            this.DataColumnValue2 = new System.Data.DataColumn();
            this.TabPageCommonOutput1 = new System.Windows.Forms.TabPage();
            this.DataGridViewCommonOutput1 = new System.Windows.Forms.DataGridView();
            this.ColumnJapaneseName3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnglishName3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettingValue3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataTableCommonOutput1 = new System.Data.DataTable();
            this.DataColumnNameJP3 = new System.Data.DataColumn();
            this.DataColumnNameEN3 = new System.Data.DataColumn();
            this.DataColumnValue3 = new System.Data.DataColumn();
            this.TabPageCommonOutput2 = new System.Windows.Forms.TabPage();
            this.DataGridViewCommonOutput2 = new System.Windows.Forms.DataGridView();
            this.ColumnJapaneseName4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnglishName4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSettingValue4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataTableCommonOutput2 = new System.Data.DataTable();
            this.DataColumnNameJP4 = new System.Data.DataColumn();
            this.DataColumnNameEN4 = new System.Data.DataColumn();
            this.DataColumnValue4 = new System.Data.DataColumn();
            this.TabPageCostRatio = new System.Windows.Forms.TabPage();
            this.DataGridViewCostRatio = new System.Windows.Forms.DataGridView();
            this.ColumnCostLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataTableCostRatio = new System.Data.DataTable();
            this.DataColumnCostLower = new System.Data.DataColumn();
            this.DataColumnCostRatio = new System.Data.DataColumn();
            this.ButtonPreviewOutputs = new System.Windows.Forms.Button();
            this.BackgroundWorker10 = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorker11 = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorker12 = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorker13 = new System.ComponentModel.BackgroundWorker();
            this.GroupBoxCpuCores = new System.Windows.Forms.GroupBox();
            this.LabelCpuCoreCountTitle = new System.Windows.Forms.Label();
            this.LabelTotalCpuCoreCount = new System.Windows.Forms.Label();
            this.NumericUpDownUseCpuCoreCount = new System.Windows.Forms.NumericUpDown();
            this.TimerFileIO = new System.Windows.Forms.Timer(this.components);
            this.DataSetSetting = new System.Data.DataSet();
            this.ProgressBarOutputCommonCSV2 = new BookSearcherApp.FileIOProgressBar();
            this.ProgressBarOutputCommonCSV1 = new BookSearcherApp.FileIOProgressBar();
            this.ProgressBarOutputPatternCSV = new BookSearcherApp.FileIOProgressBar();
            this.ProgressBarOutputExcel = new BookSearcherApp.FileIOProgressBar();
            this.ProgressBarInput2 = new BookSearcherApp.FileIOProgressBar();
            this.ProgressBarInput1 = new BookSearcherApp.FileIOProgressBar();
            this.GroupBoxOutput.SuspendLayout();
            this.GroupBoxPartMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLength)).BeginInit();
            this.GroupBoxExecute.SuspendLayout();
            this.GroupBoxFiles.SuspendLayout();
            this.GroupBoxAllMatch.SuspendLayout();
            this.TabControlOutputSetting.SuspendLayout();
            this.TabPageDatabaseColumn.SuspendLayout();
            this.TableLayoutPanelBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookColumnSetting)).BeginInit();
            this.TabPageScrapingColumn.SuspendLayout();
            this.TableLayoutPanelScraping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScrapingColumnSetting)).BeginInit();
            this.TabControlMatchingOutput.SuspendLayout();
            this.TabPageMatching.SuspendLayout();
            this.PanelMatchCondition.SuspendLayout();
            this.TabPageOutputSetting.SuspendLayout();
            this.TabControlOutputFileSetting.SuspendLayout();
            this.TabPageOutputPattern1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewOutputPattern1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableOutputPattern1)).BeginInit();
            this.TabPageOutputPattern2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewOutputPattern2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableOutputPattern2)).BeginInit();
            this.TabPageCommonOutput1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCommonOutput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableCommonOutput1)).BeginInit();
            this.TabPageCommonOutput2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCommonOutput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableCommonOutput2)).BeginInit();
            this.TabPageCostRatio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCostRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableCostRatio)).BeginInit();
            this.GroupBoxCpuCores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownUseCpuCoreCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerSearch
            // 
            this.TimerSearch.Tick += new System.EventHandler(this.TimerSearch_Tick);
            // 
            // BackgroundWorker4
            // 
            this.BackgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker4_DoWork);
            this.BackgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker4_RunWorkerCompleted);
            // 
            // BackgroundWorker2
            // 
            this.BackgroundWorker2.WorkerReportsProgress = true;
            this.BackgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker2_DoWork);
            this.BackgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker2_ProgressChanged);
            this.BackgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker2_RunWorkerCompleted);
            // 
            // BackgroundWorker1
            // 
            this.BackgroundWorker1.WorkerReportsProgress = true;
            this.BackgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.BackgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.BackgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // GroupBoxOutput
            // 
            this.GroupBoxOutput.Controls.Add(this.RadioButtonFileTypeCSV2);
            this.GroupBoxOutput.Controls.Add(this.RadioButtonFileTypeCSV1);
            this.GroupBoxOutput.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxOutput.Location = new System.Drawing.Point(12, 228);
            this.GroupBoxOutput.Name = "GroupBoxOutput";
            this.GroupBoxOutput.Size = new System.Drawing.Size(207, 57);
            this.GroupBoxOutput.TabIndex = 1;
            this.GroupBoxOutput.TabStop = false;
            this.GroupBoxOutput.Text = "出力CSVファイルパターン";
            // 
            // RadioButtonFileTypeCSV2
            // 
            this.RadioButtonFileTypeCSV2.AutoSize = true;
            this.RadioButtonFileTypeCSV2.Location = new System.Drawing.Point(109, 24);
            this.RadioButtonFileTypeCSV2.Name = "RadioButtonFileTypeCSV2";
            this.RadioButtonFileTypeCSV2.Size = new System.Drawing.Size(69, 19);
            this.RadioButtonFileTypeCSV2.TabIndex = 2;
            this.RadioButtonFileTypeCSV2.Text = "パターン2";
            this.RadioButtonFileTypeCSV2.UseVisualStyleBackColor = true;
            this.RadioButtonFileTypeCSV2.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonFileTypeCSV1
            // 
            this.RadioButtonFileTypeCSV1.AutoSize = true;
            this.RadioButtonFileTypeCSV1.Checked = true;
            this.RadioButtonFileTypeCSV1.Location = new System.Drawing.Point(34, 24);
            this.RadioButtonFileTypeCSV1.Name = "RadioButtonFileTypeCSV1";
            this.RadioButtonFileTypeCSV1.Size = new System.Drawing.Size(69, 19);
            this.RadioButtonFileTypeCSV1.TabIndex = 1;
            this.RadioButtonFileTypeCSV1.TabStop = true;
            this.RadioButtonFileTypeCSV1.Text = "パターン1";
            this.RadioButtonFileTypeCSV1.UseVisualStyleBackColor = true;
            this.RadioButtonFileTypeCSV1.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // GroupBoxPartMatch
            // 
            this.GroupBoxPartMatch.Controls.Add(this.NumericUpDownLength);
            this.GroupBoxPartMatch.Controls.Add(this.Label4);
            this.GroupBoxPartMatch.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxPartMatch.Location = new System.Drawing.Point(479, 228);
            this.GroupBoxPartMatch.Name = "GroupBoxPartMatch";
            this.GroupBoxPartMatch.Size = new System.Drawing.Size(233, 57);
            this.GroupBoxPartMatch.TabIndex = 3;
            this.GroupBoxPartMatch.TabStop = false;
            this.GroupBoxPartMatch.Text = "前方一致照合条件";
            // 
            // NumericUpDownLength
            // 
            this.NumericUpDownLength.Location = new System.Drawing.Point(153, 22);
            this.NumericUpDownLength.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumericUpDownLength.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericUpDownLength.Name = "NumericUpDownLength";
            this.NumericUpDownLength.Size = new System.Drawing.Size(53, 23);
            this.NumericUpDownLength.TabIndex = 5;
            this.NumericUpDownLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericUpDownLength.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(22, 25);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(125, 15);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "一致文字数(空白無視)";
            // 
            // GroupBoxExecute
            // 
            this.GroupBoxExecute.Controls.Add(this.LabelResultRows);
            this.GroupBoxExecute.Controls.Add(this.LabelElapsed);
            this.GroupBoxExecute.Controls.Add(this.ButtonExecute);
            this.GroupBoxExecute.Enabled = false;
            this.GroupBoxExecute.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxExecute.Location = new System.Drawing.Point(930, 228);
            this.GroupBoxExecute.Name = "GroupBoxExecute";
            this.GroupBoxExecute.Size = new System.Drawing.Size(373, 57);
            this.GroupBoxExecute.TabIndex = 7;
            this.GroupBoxExecute.TabStop = false;
            this.GroupBoxExecute.Text = "照合処理";
            // 
            // LabelResultRows
            // 
            this.LabelResultRows.Location = new System.Drawing.Point(255, 25);
            this.LabelResultRows.Name = "LabelResultRows";
            this.LabelResultRows.Size = new System.Drawing.Size(85, 18);
            this.LabelResultRows.TabIndex = 2;
            this.LabelResultRows.Text = "0 件";
            this.LabelResultRows.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelElapsed
            // 
            this.LabelElapsed.Location = new System.Drawing.Point(109, 25);
            this.LabelElapsed.Name = "LabelElapsed";
            this.LabelElapsed.Size = new System.Drawing.Size(140, 18);
            this.LabelElapsed.TabIndex = 1;
            this.LabelElapsed.Text = "経過時間 00:00:00.000";
            this.LabelElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonExecute
            // 
            this.ButtonExecute.Enabled = false;
            this.ButtonExecute.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonExecute.Location = new System.Drawing.Point(28, 22);
            this.ButtonExecute.Name = "ButtonExecute";
            this.ButtonExecute.Size = new System.Drawing.Size(75, 23);
            this.ButtonExecute.TabIndex = 0;
            this.ButtonExecute.Text = "実行";
            this.ButtonExecute.UseVisualStyleBackColor = true;
            this.ButtonExecute.Click += new System.EventHandler(this.ButtonExecute_Click);
            // 
            // GroupBoxFiles
            // 
            this.GroupBoxFiles.Controls.Add(this.ProgressBarOutputCommonCSV2);
            this.GroupBoxFiles.Controls.Add(this.ProgressBarOutputCommonCSV1);
            this.GroupBoxFiles.Controls.Add(this.ProgressBarOutputPatternCSV);
            this.GroupBoxFiles.Controls.Add(this.ProgressBarOutputExcel);
            this.GroupBoxFiles.Controls.Add(this.ProgressBarInput2);
            this.GroupBoxFiles.Controls.Add(this.ProgressBarInput1);
            this.GroupBoxFiles.Controls.Add(this.LabelOutputCSV);
            this.GroupBoxFiles.Controls.Add(this.TextBoxOutputCSV2);
            this.GroupBoxFiles.Controls.Add(this.LabelOutputCSV2);
            this.GroupBoxFiles.Controls.Add(this.LabelOutputCSV1);
            this.GroupBoxFiles.Controls.Add(this.TextBoxOutputCSV1);
            this.GroupBoxFiles.Controls.Add(this.TextBoxOutputCSV);
            this.GroupBoxFiles.Controls.Add(this.ButtonOutput1);
            this.GroupBoxFiles.Controls.Add(this.ButtonInput2);
            this.GroupBoxFiles.Controls.Add(this.ButtonInput1);
            this.GroupBoxFiles.Controls.Add(this.TextBoxOutputExcel);
            this.GroupBoxFiles.Controls.Add(this.TextBoxInput2);
            this.GroupBoxFiles.Controls.Add(this.TextBoxInput1);
            this.GroupBoxFiles.Controls.Add(this.LabelOutputExcel);
            this.GroupBoxFiles.Controls.Add(this.LabelInput2);
            this.GroupBoxFiles.Controls.Add(this.LabelInput1);
            this.GroupBoxFiles.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxFiles.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxFiles.Name = "GroupBoxFiles";
            this.GroupBoxFiles.Size = new System.Drawing.Size(1291, 210);
            this.GroupBoxFiles.TabIndex = 0;
            this.GroupBoxFiles.TabStop = false;
            this.GroupBoxFiles.Text = "入力・出力データファイル指定";
            // 
            // LabelOutputCSV
            // 
            this.LabelOutputCSV.AutoSize = true;
            this.LabelOutputCSV.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelOutputCSV.Location = new System.Drawing.Point(31, 115);
            this.LabelOutputCSV.Name = "LabelOutputCSV";
            this.LabelOutputCSV.Size = new System.Drawing.Size(143, 15);
            this.LabelOutputCSV.TabIndex = 9;
            this.LabelOutputCSV.Text = "出力CSVファイル(パターン1)";
            // 
            // TextBoxOutputCSV2
            // 
            this.TextBoxOutputCSV2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxOutputCSV2.Location = new System.Drawing.Point(179, 170);
            this.TextBoxOutputCSV2.Name = "TextBoxOutputCSV2";
            this.TextBoxOutputCSV2.Size = new System.Drawing.Size(761, 23);
            this.TextBoxOutputCSV2.TabIndex = 14;
            this.TextBoxOutputCSV2.TextChanged += new System.EventHandler(this.TextBoxFileName_TextChanged);
            // 
            // LabelOutputCSV2
            // 
            this.LabelOutputCSV2.AutoSize = true;
            this.LabelOutputCSV2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelOutputCSV2.Location = new System.Drawing.Point(31, 173);
            this.LabelOutputCSV2.Name = "LabelOutputCSV2";
            this.LabelOutputCSV2.Size = new System.Drawing.Size(120, 15);
            this.LabelOutputCSV2.TabIndex = 13;
            this.LabelOutputCSV2.Text = "共通出力CSVファイル2";
            // 
            // LabelOutputCSV1
            // 
            this.LabelOutputCSV1.AutoSize = true;
            this.LabelOutputCSV1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelOutputCSV1.Location = new System.Drawing.Point(31, 144);
            this.LabelOutputCSV1.Name = "LabelOutputCSV1";
            this.LabelOutputCSV1.Size = new System.Drawing.Size(120, 15);
            this.LabelOutputCSV1.TabIndex = 11;
            this.LabelOutputCSV1.Text = "共通出力CSVファイル1";
            // 
            // TextBoxOutputCSV1
            // 
            this.TextBoxOutputCSV1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxOutputCSV1.Location = new System.Drawing.Point(179, 141);
            this.TextBoxOutputCSV1.Name = "TextBoxOutputCSV1";
            this.TextBoxOutputCSV1.Size = new System.Drawing.Size(761, 23);
            this.TextBoxOutputCSV1.TabIndex = 12;
            this.TextBoxOutputCSV1.TextChanged += new System.EventHandler(this.TextBoxFileName_TextChanged);
            // 
            // TextBoxOutputCSV
            // 
            this.TextBoxOutputCSV.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxOutputCSV.Location = new System.Drawing.Point(179, 112);
            this.TextBoxOutputCSV.Name = "TextBoxOutputCSV";
            this.TextBoxOutputCSV.Size = new System.Drawing.Size(761, 23);
            this.TextBoxOutputCSV.TabIndex = 10;
            this.TextBoxOutputCSV.TextChanged += new System.EventHandler(this.TextBoxFileName_TextChanged);
            // 
            // ButtonOutput1
            // 
            this.ButtonOutput1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonOutput1.Location = new System.Drawing.Point(946, 82);
            this.ButtonOutput1.Name = "ButtonOutput1";
            this.ButtonOutput1.Size = new System.Drawing.Size(75, 23);
            this.ButtonOutput1.TabIndex = 8;
            this.ButtonOutput1.Text = "参照";
            this.ButtonOutput1.UseVisualStyleBackColor = true;
            this.ButtonOutput1.Click += new System.EventHandler(this.ButtonOutput1_Click);
            // 
            // ButtonInput2
            // 
            this.ButtonInput2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonInput2.Location = new System.Drawing.Point(946, 54);
            this.ButtonInput2.Name = "ButtonInput2";
            this.ButtonInput2.Size = new System.Drawing.Size(75, 23);
            this.ButtonInput2.TabIndex = 5;
            this.ButtonInput2.Text = "参照";
            this.ButtonInput2.UseVisualStyleBackColor = true;
            this.ButtonInput2.Click += new System.EventHandler(this.ButtonInput2_Click);
            // 
            // ButtonInput1
            // 
            this.ButtonInput1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonInput1.Location = new System.Drawing.Point(946, 25);
            this.ButtonInput1.Name = "ButtonInput1";
            this.ButtonInput1.Size = new System.Drawing.Size(75, 23);
            this.ButtonInput1.TabIndex = 2;
            this.ButtonInput1.Text = "参照";
            this.ButtonInput1.UseVisualStyleBackColor = true;
            this.ButtonInput1.Click += new System.EventHandler(this.ButtonInput1_Click);
            // 
            // TextBoxOutputExcel
            // 
            this.TextBoxOutputExcel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxOutputExcel.Location = new System.Drawing.Point(179, 83);
            this.TextBoxOutputExcel.Name = "TextBoxOutputExcel";
            this.TextBoxOutputExcel.Size = new System.Drawing.Size(761, 23);
            this.TextBoxOutputExcel.TabIndex = 7;
            this.TextBoxOutputExcel.TextChanged += new System.EventHandler(this.TextBoxFileName_TextChanged);
            // 
            // TextBoxInput2
            // 
            this.TextBoxInput2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxInput2.Location = new System.Drawing.Point(179, 54);
            this.TextBoxInput2.Name = "TextBoxInput2";
            this.TextBoxInput2.Size = new System.Drawing.Size(761, 23);
            this.TextBoxInput2.TabIndex = 4;
            this.TextBoxInput2.TextChanged += new System.EventHandler(this.TextBoxFileName_TextChanged);
            // 
            // TextBoxInput1
            // 
            this.TextBoxInput1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxInput1.Location = new System.Drawing.Point(179, 25);
            this.TextBoxInput1.Name = "TextBoxInput1";
            this.TextBoxInput1.Size = new System.Drawing.Size(761, 23);
            this.TextBoxInput1.TabIndex = 1;
            this.TextBoxInput1.TextChanged += new System.EventHandler(this.TextBoxFileName_TextChanged);
            // 
            // LabelOutputExcel
            // 
            this.LabelOutputExcel.AutoSize = true;
            this.LabelOutputExcel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelOutputExcel.Location = new System.Drawing.Point(31, 86);
            this.LabelOutputExcel.Name = "LabelOutputExcel";
            this.LabelOutputExcel.Size = new System.Drawing.Size(95, 15);
            this.LabelOutputExcel.TabIndex = 6;
            this.LabelOutputExcel.Text = "出力Excelファイル";
            // 
            // LabelInput2
            // 
            this.LabelInput2.AutoSize = true;
            this.LabelInput2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelInput2.Location = new System.Drawing.Point(31, 57);
            this.LabelInput2.Name = "LabelInput2";
            this.LabelInput2.Size = new System.Drawing.Size(131, 15);
            this.LabelInput2.TabIndex = 3;
            this.LabelInput2.Text = "スクレイピングデータファイル";
            // 
            // LabelInput1
            // 
            this.LabelInput1.AutoSize = true;
            this.LabelInput1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelInput1.Location = new System.Drawing.Point(31, 29);
            this.LabelInput1.Name = "LabelInput1";
            this.LabelInput1.Size = new System.Drawing.Size(122, 15);
            this.LabelInput1.TabIndex = 0;
            this.LabelInput1.Text = "書籍データベースファイル";
            // 
            // GroupBoxAllMatch
            // 
            this.GroupBoxAllMatch.Controls.Add(this.RadioButtonSpaceIgnore);
            this.GroupBoxAllMatch.Controls.Add(this.RadioButtonSpaceContains);
            this.GroupBoxAllMatch.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxAllMatch.Location = new System.Drawing.Point(225, 228);
            this.GroupBoxAllMatch.Name = "GroupBoxAllMatch";
            this.GroupBoxAllMatch.Size = new System.Drawing.Size(248, 57);
            this.GroupBoxAllMatch.TabIndex = 2;
            this.GroupBoxAllMatch.TabStop = false;
            this.GroupBoxAllMatch.Text = "完全一致照合条件";
            // 
            // RadioButtonSpaceIgnore
            // 
            this.RadioButtonSpaceIgnore.AutoSize = true;
            this.RadioButtonSpaceIgnore.Checked = true;
            this.RadioButtonSpaceIgnore.Location = new System.Drawing.Point(130, 24);
            this.RadioButtonSpaceIgnore.Name = "RadioButtonSpaceIgnore";
            this.RadioButtonSpaceIgnore.Size = new System.Drawing.Size(97, 19);
            this.RadioButtonSpaceIgnore.TabIndex = 6;
            this.RadioButtonSpaceIgnore.TabStop = true;
            this.RadioButtonSpaceIgnore.Text = "空白文字無視";
            this.RadioButtonSpaceIgnore.UseVisualStyleBackColor = true;
            // 
            // RadioButtonSpaceContains
            // 
            this.RadioButtonSpaceContains.AutoSize = true;
            this.RadioButtonSpaceContains.Location = new System.Drawing.Point(29, 24);
            this.RadioButtonSpaceContains.Name = "RadioButtonSpaceContains";
            this.RadioButtonSpaceContains.Size = new System.Drawing.Size(95, 19);
            this.RadioButtonSpaceContains.TabIndex = 5;
            this.RadioButtonSpaceContains.Text = "空白文字含む";
            this.RadioButtonSpaceContains.UseVisualStyleBackColor = true;
            // 
            // TabControlOutputSetting
            // 
            this.TabControlOutputSetting.Controls.Add(this.TabPageDatabaseColumn);
            this.TabControlOutputSetting.Controls.Add(this.TabPageScrapingColumn);
            this.TabControlOutputSetting.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TabControlOutputSetting.Location = new System.Drawing.Point(789, 291);
            this.TabControlOutputSetting.Name = "TabControlOutputSetting";
            this.TabControlOutputSetting.SelectedIndex = 0;
            this.TabControlOutputSetting.Size = new System.Drawing.Size(518, 519);
            this.TabControlOutputSetting.TabIndex = 6;
            // 
            // TabPageDatabaseColumn
            // 
            this.TabPageDatabaseColumn.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageDatabaseColumn.Controls.Add(this.TableLayoutPanelBook);
            this.TabPageDatabaseColumn.Location = new System.Drawing.Point(4, 24);
            this.TabPageDatabaseColumn.Name = "TabPageDatabaseColumn";
            this.TabPageDatabaseColumn.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageDatabaseColumn.Size = new System.Drawing.Size(510, 491);
            this.TabPageDatabaseColumn.TabIndex = 0;
            this.TabPageDatabaseColumn.Text = "書籍データベース列指定";
            // 
            // TableLayoutPanelBook
            // 
            this.TableLayoutPanelBook.ColumnCount = 2;
            this.TableLayoutPanelBook.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelBook.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelBook.Controls.Add(this.ButtonPreviewDatabase, 0, 2);
            this.TableLayoutPanelBook.Controls.Add(this.BookColumnSetting, 0, 1);
            this.TableLayoutPanelBook.Controls.Add(this.CheckBoxBookISBN, 0, 0);
            this.TableLayoutPanelBook.Controls.Add(this.CheckBoxBookCost, 1, 0);
            this.TableLayoutPanelBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelBook.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanelBook.Name = "TableLayoutPanelBook";
            this.TableLayoutPanelBook.RowCount = 3;
            this.TableLayoutPanelBook.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelBook.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanelBook.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.TableLayoutPanelBook.Size = new System.Drawing.Size(504, 485);
            this.TableLayoutPanelBook.TabIndex = 2;
            // 
            // ButtonPreviewDatabase
            // 
            this.TableLayoutPanelBook.SetColumnSpan(this.ButtonPreviewDatabase, 2);
            this.ButtonPreviewDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonPreviewDatabase.Enabled = false;
            this.ButtonPreviewDatabase.Location = new System.Drawing.Point(3, 461);
            this.ButtonPreviewDatabase.Name = "ButtonPreviewDatabase";
            this.ButtonPreviewDatabase.Size = new System.Drawing.Size(498, 22);
            this.ButtonPreviewDatabase.TabIndex = 3;
            this.ButtonPreviewDatabase.Text = "詳細確認";
            this.ButtonPreviewDatabase.UseVisualStyleBackColor = true;
            this.ButtonPreviewDatabase.Click += new System.EventHandler(this.ButtonPreview_Click);
            // 
            // BookColumnSetting
            // 
            this.BookColumnSetting.AllowUserToAddRows = false;
            this.BookColumnSetting.AllowUserToDeleteRows = false;
            this.BookColumnSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookColumnSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookColumnName,
            this.BookColumnValue,
            this.BookColumnType});
            this.TableLayoutPanelBook.SetColumnSpan(this.BookColumnSetting, 2);
            this.BookColumnSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.BookColumnSetting.Location = new System.Drawing.Point(3, 27);
            this.BookColumnSetting.Name = "BookColumnSetting";
            this.BookColumnSetting.RowTemplate.Height = 21;
            this.BookColumnSetting.Size = new System.Drawing.Size(498, 428);
            this.BookColumnSetting.TabIndex = 2;
            this.BookColumnSetting.Tag = "書籍データベース列指定";
            // 
            // BookColumnName
            // 
            this.BookColumnName.HeaderText = "列名";
            this.BookColumnName.Name = "BookColumnName";
            this.BookColumnName.ReadOnly = true;
            this.BookColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BookColumnName.Width = 140;
            // 
            // BookColumnValue
            // 
            this.BookColumnValue.HeaderText = "列データ";
            this.BookColumnValue.Name = "BookColumnValue";
            this.BookColumnValue.ReadOnly = true;
            this.BookColumnValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BookColumnValue.Width = 208;
            // 
            // BookColumnType
            // 
            this.BookColumnType.HeaderText = "データ種別";
            this.BookColumnType.Items.AddRange(new object[] {
            "",
            "書籍名",
            "著者名",
            "出版社名",
            "出版年",
            "商品コード",
            "URL",
            "価格"});
            this.BookColumnType.Name = "BookColumnType";
            this.BookColumnType.Width = 90;
            // 
            // CheckBoxBookISBN
            // 
            this.CheckBoxBookISBN.AutoSize = true;
            this.CheckBoxBookISBN.Checked = true;
            this.CheckBoxBookISBN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxBookISBN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxBookISBN.Location = new System.Drawing.Point(3, 3);
            this.CheckBoxBookISBN.Name = "CheckBoxBookISBN";
            this.CheckBoxBookISBN.Size = new System.Drawing.Size(246, 18);
            this.CheckBoxBookISBN.TabIndex = 0;
            this.CheckBoxBookISBN.Text = "商品コードは書籍データベースから取得";
            this.CheckBoxBookISBN.UseVisualStyleBackColor = true;
            this.CheckBoxBookISBN.CheckedChanged += new System.EventHandler(this.CheckBoxISBN_CheckedChanged);
            // 
            // CheckBoxBookCost
            // 
            this.CheckBoxBookCost.AutoSize = true;
            this.CheckBoxBookCost.Checked = true;
            this.CheckBoxBookCost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxBookCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxBookCost.Location = new System.Drawing.Point(255, 3);
            this.CheckBoxBookCost.Name = "CheckBoxBookCost";
            this.CheckBoxBookCost.Size = new System.Drawing.Size(246, 18);
            this.CheckBoxBookCost.TabIndex = 1;
            this.CheckBoxBookCost.Text = "価格情報は書籍データベースから取得";
            this.CheckBoxBookCost.UseVisualStyleBackColor = true;
            this.CheckBoxBookCost.CheckedChanged += new System.EventHandler(this.CheckBoxCost_CheckedChanged);
            // 
            // TabPageScrapingColumn
            // 
            this.TabPageScrapingColumn.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageScrapingColumn.Controls.Add(this.TableLayoutPanelScraping);
            this.TabPageScrapingColumn.Location = new System.Drawing.Point(4, 24);
            this.TabPageScrapingColumn.Name = "TabPageScrapingColumn";
            this.TabPageScrapingColumn.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageScrapingColumn.Size = new System.Drawing.Size(510, 491);
            this.TabPageScrapingColumn.TabIndex = 1;
            this.TabPageScrapingColumn.Text = "スクレイピングデータ列指定";
            // 
            // TableLayoutPanelScraping
            // 
            this.TableLayoutPanelScraping.ColumnCount = 2;
            this.TableLayoutPanelScraping.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelScraping.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelScraping.Controls.Add(this.ButtonPreviewScraping, 0, 2);
            this.TableLayoutPanelScraping.Controls.Add(this.ScrapingColumnSetting, 0, 1);
            this.TableLayoutPanelScraping.Controls.Add(this.CheckBoxScrapingISBN, 0, 0);
            this.TableLayoutPanelScraping.Controls.Add(this.CheckBoxScrapingCost, 1, 0);
            this.TableLayoutPanelScraping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelScraping.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanelScraping.Name = "TableLayoutPanelScraping";
            this.TableLayoutPanelScraping.RowCount = 3;
            this.TableLayoutPanelScraping.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelScraping.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanelScraping.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.TableLayoutPanelScraping.Size = new System.Drawing.Size(504, 485);
            this.TableLayoutPanelScraping.TabIndex = 3;
            // 
            // ButtonPreviewScraping
            // 
            this.TableLayoutPanelScraping.SetColumnSpan(this.ButtonPreviewScraping, 2);
            this.ButtonPreviewScraping.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonPreviewScraping.Enabled = false;
            this.ButtonPreviewScraping.Location = new System.Drawing.Point(3, 461);
            this.ButtonPreviewScraping.Name = "ButtonPreviewScraping";
            this.ButtonPreviewScraping.Size = new System.Drawing.Size(498, 22);
            this.ButtonPreviewScraping.TabIndex = 4;
            this.ButtonPreviewScraping.Text = "詳細確認";
            this.ButtonPreviewScraping.UseVisualStyleBackColor = true;
            this.ButtonPreviewScraping.Click += new System.EventHandler(this.ButtonPreview_Click);
            // 
            // ScrapingColumnSetting
            // 
            this.ScrapingColumnSetting.AllowUserToAddRows = false;
            this.ScrapingColumnSetting.AllowUserToDeleteRows = false;
            this.ScrapingColumnSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScrapingColumnSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScrapingColumnName,
            this.ScrapingColumnValue,
            this.ScrapingColumnType});
            this.TableLayoutPanelScraping.SetColumnSpan(this.ScrapingColumnSetting, 2);
            this.ScrapingColumnSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScrapingColumnSetting.Location = new System.Drawing.Point(3, 27);
            this.ScrapingColumnSetting.Name = "ScrapingColumnSetting";
            this.ScrapingColumnSetting.RowTemplate.Height = 21;
            this.ScrapingColumnSetting.Size = new System.Drawing.Size(498, 428);
            this.ScrapingColumnSetting.TabIndex = 3;
            this.ScrapingColumnSetting.Tag = "スクレイピングデータ列指定";
            // 
            // ScrapingColumnName
            // 
            this.ScrapingColumnName.HeaderText = "列名";
            this.ScrapingColumnName.Name = "ScrapingColumnName";
            this.ScrapingColumnName.ReadOnly = true;
            this.ScrapingColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ScrapingColumnName.Width = 140;
            // 
            // ScrapingColumnValue
            // 
            this.ScrapingColumnValue.HeaderText = "列データ";
            this.ScrapingColumnValue.Name = "ScrapingColumnValue";
            this.ScrapingColumnValue.ReadOnly = true;
            this.ScrapingColumnValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ScrapingColumnValue.Width = 208;
            // 
            // ScrapingColumnType
            // 
            this.ScrapingColumnType.HeaderText = "データ種別";
            this.ScrapingColumnType.Items.AddRange(new object[] {
            "",
            "書籍名",
            "著者名",
            "出版社名",
            "出版年",
            "商品コード",
            "URL",
            "価格",
            "複合データ"});
            this.ScrapingColumnType.Name = "ScrapingColumnType";
            this.ScrapingColumnType.Width = 90;
            // 
            // CheckBoxScrapingISBN
            // 
            this.CheckBoxScrapingISBN.AutoSize = true;
            this.CheckBoxScrapingISBN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxScrapingISBN.Location = new System.Drawing.Point(3, 3);
            this.CheckBoxScrapingISBN.Name = "CheckBoxScrapingISBN";
            this.CheckBoxScrapingISBN.Size = new System.Drawing.Size(246, 18);
            this.CheckBoxScrapingISBN.TabIndex = 0;
            this.CheckBoxScrapingISBN.Text = "商品コードはスクレイピングデータから取得";
            this.CheckBoxScrapingISBN.UseVisualStyleBackColor = true;
            this.CheckBoxScrapingISBN.CheckedChanged += new System.EventHandler(this.CheckBoxISBN_CheckedChanged);
            // 
            // CheckBoxScrapingCost
            // 
            this.CheckBoxScrapingCost.AutoSize = true;
            this.CheckBoxScrapingCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckBoxScrapingCost.Location = new System.Drawing.Point(255, 3);
            this.CheckBoxScrapingCost.Name = "CheckBoxScrapingCost";
            this.CheckBoxScrapingCost.Size = new System.Drawing.Size(246, 18);
            this.CheckBoxScrapingCost.TabIndex = 1;
            this.CheckBoxScrapingCost.Text = "価格情報はスクレイピングデータから取得";
            this.CheckBoxScrapingCost.UseVisualStyleBackColor = true;
            this.CheckBoxScrapingCost.CheckedChanged += new System.EventHandler(this.CheckBoxCost_CheckedChanged);
            // 
            // TabControlMatchingOutput
            // 
            this.TabControlMatchingOutput.Controls.Add(this.TabPageMatching);
            this.TabControlMatchingOutput.Controls.Add(this.TabPageOutputSetting);
            this.TabControlMatchingOutput.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TabControlMatchingOutput.Location = new System.Drawing.Point(12, 291);
            this.TabControlMatchingOutput.Name = "TabControlMatchingOutput";
            this.TabControlMatchingOutput.SelectedIndex = 0;
            this.TabControlMatchingOutput.Size = new System.Drawing.Size(775, 519);
            this.TabControlMatchingOutput.TabIndex = 5;
            // 
            // TabPageMatching
            // 
            this.TabPageMatching.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageMatching.Controls.Add(this.PanelMatchCondition);
            this.TabPageMatching.Location = new System.Drawing.Point(4, 24);
            this.TabPageMatching.Name = "TabPageMatching";
            this.TabPageMatching.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMatching.Size = new System.Drawing.Size(767, 491);
            this.TabPageMatching.TabIndex = 0;
            this.TabPageMatching.Text = "照合パターン指定";
            // 
            // PanelMatchCondition
            // 
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType17);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType16);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType15);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType14);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType13);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType12);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType11);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType10);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType09);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType08);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType07);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType06);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType05);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType04);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType03);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType02);
            this.PanelMatchCondition.Controls.Add(this.RadioButtonSearchType01);
            this.PanelMatchCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMatchCondition.Location = new System.Drawing.Point(3, 3);
            this.PanelMatchCondition.Name = "PanelMatchCondition";
            this.PanelMatchCondition.Size = new System.Drawing.Size(761, 485);
            this.PanelMatchCondition.TabIndex = 0;
            // 
            // RadioButtonSearchType17
            // 
            this.RadioButtonSearchType17.AutoSize = true;
            this.RadioButtonSearchType17.Location = new System.Drawing.Point(25, 456);
            this.RadioButtonSearchType17.Name = "RadioButtonSearchType17";
            this.RadioButtonSearchType17.Size = new System.Drawing.Size(710, 19);
            this.RadioButtonSearchType17.TabIndex = 50;
            this.RadioButtonSearchType17.Text = "⑰「書籍名(前方一致)」+「出版年(部分一致)」+「出版社名(部分一致)」　【データベース側参照セル3つ⇔スクレイピングデータ側参照セル3つ】";
            this.RadioButtonSearchType17.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType17.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType16
            // 
            this.RadioButtonSearchType16.AutoSize = true;
            this.RadioButtonSearchType16.Location = new System.Drawing.Point(25, 431);
            this.RadioButtonSearchType16.Name = "RadioButtonSearchType16";
            this.RadioButtonSearchType16.Size = new System.Drawing.Size(710, 19);
            this.RadioButtonSearchType16.TabIndex = 49;
            this.RadioButtonSearchType16.Text = "⑯「書籍名(部分一致)」+「出版年(部分一致)」+「出版社名(部分一致)」　【データベース側参照セル3つ⇔スクレイピングデータ側参照セル3つ】";
            this.RadioButtonSearchType16.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType16.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType15
            // 
            this.RadioButtonSearchType15.AutoSize = true;
            this.RadioButtonSearchType15.Location = new System.Drawing.Point(25, 397);
            this.RadioButtonSearchType15.Name = "RadioButtonSearchType15";
            this.RadioButtonSearchType15.Size = new System.Drawing.Size(466, 19);
            this.RadioButtonSearchType15.TabIndex = 48;
            this.RadioButtonSearchType15.Text = "⑮「書籍名(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType15.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType15.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType14
            // 
            this.RadioButtonSearchType14.AutoSize = true;
            this.RadioButtonSearchType14.Location = new System.Drawing.Point(25, 372);
            this.RadioButtonSearchType14.Name = "RadioButtonSearchType14";
            this.RadioButtonSearchType14.Size = new System.Drawing.Size(460, 19);
            this.RadioButtonSearchType14.TabIndex = 47;
            this.RadioButtonSearchType14.Text = "⑭「ISBN(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType14.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType14.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType13
            // 
            this.RadioButtonSearchType13.AutoSize = true;
            this.RadioButtonSearchType13.Location = new System.Drawing.Point(25, 347);
            this.RadioButtonSearchType13.Name = "RadioButtonSearchType13";
            this.RadioButtonSearchType13.Size = new System.Drawing.Size(454, 19);
            this.RadioButtonSearchType13.TabIndex = 46;
            this.RadioButtonSearchType13.Text = "⑬「URL(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType13.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType13.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType12
            // 
            this.RadioButtonSearchType12.AutoSize = true;
            this.RadioButtonSearchType12.Location = new System.Drawing.Point(25, 313);
            this.RadioButtonSearchType12.Name = "RadioButtonSearchType12";
            this.RadioButtonSearchType12.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType12.TabIndex = 45;
            this.RadioButtonSearchType12.Text = "⑫「書籍名(部分一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType12.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType12.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType11
            // 
            this.RadioButtonSearchType11.AutoSize = true;
            this.RadioButtonSearchType11.Location = new System.Drawing.Point(25, 288);
            this.RadioButtonSearchType11.Name = "RadioButtonSearchType11";
            this.RadioButtonSearchType11.Size = new System.Drawing.Size(594, 19);
            this.RadioButtonSearchType11.TabIndex = 44;
            this.RadioButtonSearchType11.Text = "⑪「書籍名(部分一致)」+「出版社名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType11.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType11.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType10
            // 
            this.RadioButtonSearchType10.AutoSize = true;
            this.RadioButtonSearchType10.Location = new System.Drawing.Point(25, 263);
            this.RadioButtonSearchType10.Name = "RadioButtonSearchType10";
            this.RadioButtonSearchType10.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType10.TabIndex = 43;
            this.RadioButtonSearchType10.Text = "⑩「書籍名(部分一致)」+「出版年(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType10.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType10.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType09
            // 
            this.RadioButtonSearchType09.AutoSize = true;
            this.RadioButtonSearchType09.Location = new System.Drawing.Point(25, 229);
            this.RadioButtonSearchType09.Name = "RadioButtonSearchType09";
            this.RadioButtonSearchType09.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType09.TabIndex = 42;
            this.RadioButtonSearchType09.Text = "⑨「書籍名(部分一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType09.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType09.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType08
            // 
            this.RadioButtonSearchType08.AutoSize = true;
            this.RadioButtonSearchType08.Location = new System.Drawing.Point(25, 204);
            this.RadioButtonSearchType08.Name = "RadioButtonSearchType08";
            this.RadioButtonSearchType08.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType08.TabIndex = 41;
            this.RadioButtonSearchType08.Text = "⑧「書籍名(前方一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType08.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType08.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType07
            // 
            this.RadioButtonSearchType07.AutoSize = true;
            this.RadioButtonSearchType07.Location = new System.Drawing.Point(25, 179);
            this.RadioButtonSearchType07.Name = "RadioButtonSearchType07";
            this.RadioButtonSearchType07.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType07.TabIndex = 40;
            this.RadioButtonSearchType07.Text = "⑦「書籍名(完全一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType07.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType07.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType06
            // 
            this.RadioButtonSearchType06.AutoSize = true;
            this.RadioButtonSearchType06.Location = new System.Drawing.Point(25, 144);
            this.RadioButtonSearchType06.Name = "RadioButtonSearchType06";
            this.RadioButtonSearchType06.Size = new System.Drawing.Size(594, 19);
            this.RadioButtonSearchType06.TabIndex = 39;
            this.RadioButtonSearchType06.Text = "⑥「書籍名(部分一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType06.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType06.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType05
            // 
            this.RadioButtonSearchType05.AutoSize = true;
            this.RadioButtonSearchType05.Location = new System.Drawing.Point(25, 119);
            this.RadioButtonSearchType05.Name = "RadioButtonSearchType05";
            this.RadioButtonSearchType05.Size = new System.Drawing.Size(594, 19);
            this.RadioButtonSearchType05.TabIndex = 38;
            this.RadioButtonSearchType05.Text = "⑤「書籍名(前方一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType05.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType05.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType04
            // 
            this.RadioButtonSearchType04.AutoSize = true;
            this.RadioButtonSearchType04.Location = new System.Drawing.Point(25, 94);
            this.RadioButtonSearchType04.Name = "RadioButtonSearchType04";
            this.RadioButtonSearchType04.Size = new System.Drawing.Size(594, 19);
            this.RadioButtonSearchType04.TabIndex = 37;
            this.RadioButtonSearchType04.Text = "④「書籍名(完全一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType04.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType04.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType03
            // 
            this.RadioButtonSearchType03.AutoSize = true;
            this.RadioButtonSearchType03.Location = new System.Drawing.Point(25, 60);
            this.RadioButtonSearchType03.Name = "RadioButtonSearchType03";
            this.RadioButtonSearchType03.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType03.TabIndex = 36;
            this.RadioButtonSearchType03.Text = "③「書籍名(部分一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType03.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType03.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType02
            // 
            this.RadioButtonSearchType02.AutoSize = true;
            this.RadioButtonSearchType02.Location = new System.Drawing.Point(25, 35);
            this.RadioButtonSearchType02.Name = "RadioButtonSearchType02";
            this.RadioButtonSearchType02.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType02.TabIndex = 35;
            this.RadioButtonSearchType02.Text = "②「書籍名(前方一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType02.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType02.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonSearchType01
            // 
            this.RadioButtonSearchType01.AutoSize = true;
            this.RadioButtonSearchType01.Checked = true;
            this.RadioButtonSearchType01.Location = new System.Drawing.Point(25, 10);
            this.RadioButtonSearchType01.Name = "RadioButtonSearchType01";
            this.RadioButtonSearchType01.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType01.TabIndex = 34;
            this.RadioButtonSearchType01.TabStop = true;
            this.RadioButtonSearchType01.Text = "①「書籍名(完全一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType01.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType01.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // TabPageOutputSetting
            // 
            this.TabPageOutputSetting.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageOutputSetting.Controls.Add(this.TabControlOutputFileSetting);
            this.TabPageOutputSetting.Controls.Add(this.ButtonPreviewOutputs);
            this.TabPageOutputSetting.Location = new System.Drawing.Point(4, 24);
            this.TabPageOutputSetting.Name = "TabPageOutputSetting";
            this.TabPageOutputSetting.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageOutputSetting.Size = new System.Drawing.Size(767, 491);
            this.TabPageOutputSetting.TabIndex = 1;
            this.TabPageOutputSetting.Text = "出力CSVファイル列指定";
            // 
            // TabControlOutputFileSetting
            // 
            this.TabControlOutputFileSetting.Controls.Add(this.TabPageOutputPattern1);
            this.TabControlOutputFileSetting.Controls.Add(this.TabPageOutputPattern2);
            this.TabControlOutputFileSetting.Controls.Add(this.TabPageCommonOutput1);
            this.TabControlOutputFileSetting.Controls.Add(this.TabPageCommonOutput2);
            this.TabControlOutputFileSetting.Controls.Add(this.TabPageCostRatio);
            this.TabControlOutputFileSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlOutputFileSetting.Location = new System.Drawing.Point(3, 3);
            this.TabControlOutputFileSetting.Margin = new System.Windows.Forms.Padding(12);
            this.TabControlOutputFileSetting.Name = "TabControlOutputFileSetting";
            this.TabControlOutputFileSetting.SelectedIndex = 0;
            this.TabControlOutputFileSetting.Size = new System.Drawing.Size(761, 462);
            this.TabControlOutputFileSetting.TabIndex = 2;
            // 
            // TabPageOutputPattern1
            // 
            this.TabPageOutputPattern1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageOutputPattern1.Controls.Add(this.DataGridViewOutputPattern1);
            this.TabPageOutputPattern1.Location = new System.Drawing.Point(4, 24);
            this.TabPageOutputPattern1.Name = "TabPageOutputPattern1";
            this.TabPageOutputPattern1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageOutputPattern1.Size = new System.Drawing.Size(753, 434);
            this.TabPageOutputPattern1.TabIndex = 0;
            this.TabPageOutputPattern1.Text = "出力CSVパターン1";
            // 
            // DataGridViewOutputPattern1
            // 
            this.DataGridViewOutputPattern1.AllowUserToAddRows = false;
            this.DataGridViewOutputPattern1.AllowUserToDeleteRows = false;
            this.DataGridViewOutputPattern1.AutoGenerateColumns = false;
            this.DataGridViewOutputPattern1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewOutputPattern1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnJapaneseName1,
            this.ColumnEnglishName1,
            this.ColumnSettingValue1});
            this.DataGridViewOutputPattern1.DataSource = this.DataTableOutputPattern1;
            this.DataGridViewOutputPattern1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewOutputPattern1.Location = new System.Drawing.Point(3, 3);
            this.DataGridViewOutputPattern1.Name = "DataGridViewOutputPattern1";
            this.DataGridViewOutputPattern1.RowTemplate.Height = 21;
            this.DataGridViewOutputPattern1.Size = new System.Drawing.Size(747, 428);
            this.DataGridViewOutputPattern1.TabIndex = 1;
            this.DataGridViewOutputPattern1.Tag = "出力CSVパターン1";
            // 
            // ColumnJapaneseName1
            // 
            this.ColumnJapaneseName1.DataPropertyName = "NameJP";
            this.ColumnJapaneseName1.Frozen = true;
            this.ColumnJapaneseName1.HeaderText = "列名(日本語)";
            this.ColumnJapaneseName1.Name = "ColumnJapaneseName1";
            this.ColumnJapaneseName1.ReadOnly = true;
            this.ColumnJapaneseName1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnJapaneseName1.Width = 205;
            // 
            // ColumnEnglishName1
            // 
            this.ColumnEnglishName1.DataPropertyName = "NameEN";
            this.ColumnEnglishName1.Frozen = true;
            this.ColumnEnglishName1.HeaderText = "列名(英語)";
            this.ColumnEnglishName1.Name = "ColumnEnglishName1";
            this.ColumnEnglishName1.ReadOnly = true;
            this.ColumnEnglishName1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnEnglishName1.Width = 250;
            // 
            // ColumnSettingValue1
            // 
            this.ColumnSettingValue1.DataPropertyName = "Value";
            this.ColumnSettingValue1.Frozen = true;
            this.ColumnSettingValue1.HeaderText = "設定値(固定出力値)";
            this.ColumnSettingValue1.Name = "ColumnSettingValue1";
            this.ColumnSettingValue1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSettingValue1.Width = 250;
            // 
            // DataTableOutputPattern1
            // 
            this.DataTableOutputPattern1.Columns.AddRange(new System.Data.DataColumn[] {
            this.DataColumnNameJP1,
            this.DataColumnNameEN1,
            this.DataColumnValue1});
            this.DataTableOutputPattern1.TableName = "TableOutputPattern1";
            // 
            // DataColumnNameJP1
            // 
            this.DataColumnNameJP1.Caption = "列名(日本語)";
            this.DataColumnNameJP1.ColumnName = "NameJP";
            // 
            // DataColumnNameEN1
            // 
            this.DataColumnNameEN1.Caption = "列名(英語)";
            this.DataColumnNameEN1.ColumnName = "NameEN";
            // 
            // DataColumnValue1
            // 
            this.DataColumnValue1.Caption = "設定値(固定出力値)";
            this.DataColumnValue1.ColumnName = "Value";
            // 
            // TabPageOutputPattern2
            // 
            this.TabPageOutputPattern2.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageOutputPattern2.Controls.Add(this.DataGridViewOutputPattern2);
            this.TabPageOutputPattern2.Location = new System.Drawing.Point(4, 24);
            this.TabPageOutputPattern2.Name = "TabPageOutputPattern2";
            this.TabPageOutputPattern2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageOutputPattern2.Size = new System.Drawing.Size(753, 434);
            this.TabPageOutputPattern2.TabIndex = 1;
            this.TabPageOutputPattern2.Text = "出力CSVパターン2";
            // 
            // DataGridViewOutputPattern2
            // 
            this.DataGridViewOutputPattern2.AllowUserToAddRows = false;
            this.DataGridViewOutputPattern2.AllowUserToDeleteRows = false;
            this.DataGridViewOutputPattern2.AutoGenerateColumns = false;
            this.DataGridViewOutputPattern2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewOutputPattern2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnJapaneseName2,
            this.ColumnEnglishName2,
            this.ColumnSettingValue2});
            this.DataGridViewOutputPattern2.DataSource = this.DataTableOutputPattern2;
            this.DataGridViewOutputPattern2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewOutputPattern2.Location = new System.Drawing.Point(3, 3);
            this.DataGridViewOutputPattern2.Name = "DataGridViewOutputPattern2";
            this.DataGridViewOutputPattern2.RowTemplate.Height = 21;
            this.DataGridViewOutputPattern2.Size = new System.Drawing.Size(747, 430);
            this.DataGridViewOutputPattern2.TabIndex = 2;
            this.DataGridViewOutputPattern2.Tag = "出力CSVパターン2";
            // 
            // ColumnJapaneseName2
            // 
            this.ColumnJapaneseName2.DataPropertyName = "NameJP";
            this.ColumnJapaneseName2.Frozen = true;
            this.ColumnJapaneseName2.HeaderText = "列名(日本語)";
            this.ColumnJapaneseName2.Name = "ColumnJapaneseName2";
            this.ColumnJapaneseName2.ReadOnly = true;
            this.ColumnJapaneseName2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnJapaneseName2.Width = 205;
            // 
            // ColumnEnglishName2
            // 
            this.ColumnEnglishName2.DataPropertyName = "NameEN";
            this.ColumnEnglishName2.Frozen = true;
            this.ColumnEnglishName2.HeaderText = "列名(英語)";
            this.ColumnEnglishName2.Name = "ColumnEnglishName2";
            this.ColumnEnglishName2.ReadOnly = true;
            this.ColumnEnglishName2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnEnglishName2.Width = 250;
            // 
            // ColumnSettingValue2
            // 
            this.ColumnSettingValue2.DataPropertyName = "Value";
            this.ColumnSettingValue2.Frozen = true;
            this.ColumnSettingValue2.HeaderText = "設定値(固定出力値)";
            this.ColumnSettingValue2.Name = "ColumnSettingValue2";
            this.ColumnSettingValue2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSettingValue2.Width = 250;
            // 
            // DataTableOutputPattern2
            // 
            this.DataTableOutputPattern2.Columns.AddRange(new System.Data.DataColumn[] {
            this.DataColumnNameJP2,
            this.DataColumnNameEN2,
            this.DataColumnValue2});
            this.DataTableOutputPattern2.TableName = "TableOutputPattern2";
            // 
            // DataColumnNameJP2
            // 
            this.DataColumnNameJP2.Caption = "列名(日本語)";
            this.DataColumnNameJP2.ColumnName = "NameJP";
            // 
            // DataColumnNameEN2
            // 
            this.DataColumnNameEN2.Caption = "列名(英語)";
            this.DataColumnNameEN2.ColumnName = "NameEN";
            // 
            // DataColumnValue2
            // 
            this.DataColumnValue2.Caption = "設定値(固定出力値)";
            this.DataColumnValue2.ColumnName = "Value";
            // 
            // TabPageCommonOutput1
            // 
            this.TabPageCommonOutput1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageCommonOutput1.Controls.Add(this.DataGridViewCommonOutput1);
            this.TabPageCommonOutput1.Location = new System.Drawing.Point(4, 24);
            this.TabPageCommonOutput1.Name = "TabPageCommonOutput1";
            this.TabPageCommonOutput1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCommonOutput1.Size = new System.Drawing.Size(753, 434);
            this.TabPageCommonOutput1.TabIndex = 2;
            this.TabPageCommonOutput1.Text = "共通CSV出力1";
            // 
            // DataGridViewCommonOutput1
            // 
            this.DataGridViewCommonOutput1.AllowUserToAddRows = false;
            this.DataGridViewCommonOutput1.AllowUserToDeleteRows = false;
            this.DataGridViewCommonOutput1.AutoGenerateColumns = false;
            this.DataGridViewCommonOutput1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewCommonOutput1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnJapaneseName3,
            this.ColumnEnglishName3,
            this.ColumnSettingValue3});
            this.DataGridViewCommonOutput1.DataSource = this.DataTableCommonOutput1;
            this.DataGridViewCommonOutput1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewCommonOutput1.Location = new System.Drawing.Point(3, 3);
            this.DataGridViewCommonOutput1.Name = "DataGridViewCommonOutput1";
            this.DataGridViewCommonOutput1.RowTemplate.Height = 21;
            this.DataGridViewCommonOutput1.Size = new System.Drawing.Size(747, 430);
            this.DataGridViewCommonOutput1.TabIndex = 3;
            this.DataGridViewCommonOutput1.Tag = "共通CSV出力1";
            // 
            // ColumnJapaneseName3
            // 
            this.ColumnJapaneseName3.DataPropertyName = "NameJP";
            this.ColumnJapaneseName3.Frozen = true;
            this.ColumnJapaneseName3.HeaderText = "列名(日本語)";
            this.ColumnJapaneseName3.Name = "ColumnJapaneseName3";
            this.ColumnJapaneseName3.ReadOnly = true;
            this.ColumnJapaneseName3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnJapaneseName3.Width = 205;
            // 
            // ColumnEnglishName3
            // 
            this.ColumnEnglishName3.DataPropertyName = "NameEN";
            this.ColumnEnglishName3.Frozen = true;
            this.ColumnEnglishName3.HeaderText = "列名(英語)";
            this.ColumnEnglishName3.Name = "ColumnEnglishName3";
            this.ColumnEnglishName3.ReadOnly = true;
            this.ColumnEnglishName3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnEnglishName3.Width = 250;
            // 
            // ColumnSettingValue3
            // 
            this.ColumnSettingValue3.DataPropertyName = "Value";
            this.ColumnSettingValue3.Frozen = true;
            this.ColumnSettingValue3.HeaderText = "設定値(固定出力値)";
            this.ColumnSettingValue3.Name = "ColumnSettingValue3";
            this.ColumnSettingValue3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSettingValue3.Width = 250;
            // 
            // DataTableCommonOutput1
            // 
            this.DataTableCommonOutput1.Columns.AddRange(new System.Data.DataColumn[] {
            this.DataColumnNameJP3,
            this.DataColumnNameEN3,
            this.DataColumnValue3});
            this.DataTableCommonOutput1.TableName = "TableCommonOutput1";
            // 
            // DataColumnNameJP3
            // 
            this.DataColumnNameJP3.Caption = "列名(日本語)";
            this.DataColumnNameJP3.ColumnName = "NameJP";
            // 
            // DataColumnNameEN3
            // 
            this.DataColumnNameEN3.Caption = "列名(英語)";
            this.DataColumnNameEN3.ColumnName = "NameEN";
            // 
            // DataColumnValue3
            // 
            this.DataColumnValue3.Caption = "設定値(固定出力値)";
            this.DataColumnValue3.ColumnName = "Value";
            // 
            // TabPageCommonOutput2
            // 
            this.TabPageCommonOutput2.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageCommonOutput2.Controls.Add(this.DataGridViewCommonOutput2);
            this.TabPageCommonOutput2.Location = new System.Drawing.Point(4, 24);
            this.TabPageCommonOutput2.Name = "TabPageCommonOutput2";
            this.TabPageCommonOutput2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCommonOutput2.Size = new System.Drawing.Size(753, 434);
            this.TabPageCommonOutput2.TabIndex = 3;
            this.TabPageCommonOutput2.Text = "共通CSV出力2";
            // 
            // DataGridViewCommonOutput2
            // 
            this.DataGridViewCommonOutput2.AllowUserToAddRows = false;
            this.DataGridViewCommonOutput2.AllowUserToDeleteRows = false;
            this.DataGridViewCommonOutput2.AutoGenerateColumns = false;
            this.DataGridViewCommonOutput2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewCommonOutput2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnJapaneseName4,
            this.ColumnEnglishName4,
            this.ColumnSettingValue4});
            this.DataGridViewCommonOutput2.DataSource = this.DataTableCommonOutput2;
            this.DataGridViewCommonOutput2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewCommonOutput2.Location = new System.Drawing.Point(3, 3);
            this.DataGridViewCommonOutput2.Name = "DataGridViewCommonOutput2";
            this.DataGridViewCommonOutput2.RowTemplate.Height = 21;
            this.DataGridViewCommonOutput2.Size = new System.Drawing.Size(747, 430);
            this.DataGridViewCommonOutput2.TabIndex = 3;
            this.DataGridViewCommonOutput2.Tag = "共通CSV出力2";
            // 
            // ColumnJapaneseName4
            // 
            this.ColumnJapaneseName4.DataPropertyName = "NameJP";
            this.ColumnJapaneseName4.Frozen = true;
            this.ColumnJapaneseName4.HeaderText = "列名(日本語)";
            this.ColumnJapaneseName4.Name = "ColumnJapaneseName4";
            this.ColumnJapaneseName4.ReadOnly = true;
            this.ColumnJapaneseName4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnJapaneseName4.Width = 205;
            // 
            // ColumnEnglishName4
            // 
            this.ColumnEnglishName4.DataPropertyName = "NameEN";
            this.ColumnEnglishName4.Frozen = true;
            this.ColumnEnglishName4.HeaderText = "列名(英語)";
            this.ColumnEnglishName4.Name = "ColumnEnglishName4";
            this.ColumnEnglishName4.ReadOnly = true;
            this.ColumnEnglishName4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnEnglishName4.Width = 250;
            // 
            // ColumnSettingValue4
            // 
            this.ColumnSettingValue4.DataPropertyName = "Value";
            this.ColumnSettingValue4.Frozen = true;
            this.ColumnSettingValue4.HeaderText = "設定値(固定出力値)";
            this.ColumnSettingValue4.Name = "ColumnSettingValue4";
            this.ColumnSettingValue4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSettingValue4.Width = 250;
            // 
            // DataTableCommonOutput2
            // 
            this.DataTableCommonOutput2.Columns.AddRange(new System.Data.DataColumn[] {
            this.DataColumnNameJP4,
            this.DataColumnNameEN4,
            this.DataColumnValue4});
            this.DataTableCommonOutput2.TableName = "TableCommonOutput2";
            // 
            // DataColumnNameJP4
            // 
            this.DataColumnNameJP4.Caption = "列名(日本語)";
            this.DataColumnNameJP4.ColumnName = "NameJP";
            // 
            // DataColumnNameEN4
            // 
            this.DataColumnNameEN4.Caption = "列名(英語)";
            this.DataColumnNameEN4.ColumnName = "NameEN";
            // 
            // DataColumnValue4
            // 
            this.DataColumnValue4.Caption = "設定値(固定出力値)";
            this.DataColumnValue4.ColumnName = "Value";
            // 
            // TabPageCostRatio
            // 
            this.TabPageCostRatio.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageCostRatio.Controls.Add(this.DataGridViewCostRatio);
            this.TabPageCostRatio.Location = new System.Drawing.Point(4, 24);
            this.TabPageCostRatio.Name = "TabPageCostRatio";
            this.TabPageCostRatio.Size = new System.Drawing.Size(753, 434);
            this.TabPageCostRatio.TabIndex = 4;
            this.TabPageCostRatio.Text = "料率";
            // 
            // DataGridViewCostRatio
            // 
            this.DataGridViewCostRatio.AllowUserToAddRows = false;
            this.DataGridViewCostRatio.AllowUserToDeleteRows = false;
            this.DataGridViewCostRatio.AutoGenerateColumns = false;
            this.DataGridViewCostRatio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewCostRatio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCostLower,
            this.ColumnCostRatio});
            this.DataGridViewCostRatio.DataSource = this.DataTableCostRatio;
            this.DataGridViewCostRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewCostRatio.Location = new System.Drawing.Point(0, 0);
            this.DataGridViewCostRatio.Name = "DataGridViewCostRatio";
            this.DataGridViewCostRatio.RowTemplate.Height = 21;
            this.DataGridViewCostRatio.Size = new System.Drawing.Size(753, 436);
            this.DataGridViewCostRatio.TabIndex = 0;
            // 
            // ColumnCostLower
            // 
            this.ColumnCostLower.DataPropertyName = "CostLower";
            this.ColumnCostLower.Frozen = true;
            this.ColumnCostLower.HeaderText = "原価下限";
            this.ColumnCostLower.Name = "ColumnCostLower";
            this.ColumnCostLower.Width = 355;
            // 
            // ColumnCostRatio
            // 
            this.ColumnCostRatio.DataPropertyName = "CostRatio";
            this.ColumnCostRatio.Frozen = true;
            this.ColumnCostRatio.HeaderText = "料率";
            this.ColumnCostRatio.Name = "ColumnCostRatio";
            this.ColumnCostRatio.Width = 355;
            // 
            // DataTableCostRatio
            // 
            this.DataTableCostRatio.Columns.AddRange(new System.Data.DataColumn[] {
            this.DataColumnCostLower,
            this.DataColumnCostRatio});
            this.DataTableCostRatio.TableName = "TableCostRatio";
            // 
            // DataColumnCostLower
            // 
            this.DataColumnCostLower.Caption = "原価下限";
            this.DataColumnCostLower.ColumnName = "CostLower";
            // 
            // DataColumnCostRatio
            // 
            this.DataColumnCostRatio.Caption = "料率";
            this.DataColumnCostRatio.ColumnName = "CostRatio";
            // 
            // ButtonPreviewOutputs
            // 
            this.ButtonPreviewOutputs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPreviewOutputs.Enabled = false;
            this.ButtonPreviewOutputs.Location = new System.Drawing.Point(3, 465);
            this.ButtonPreviewOutputs.Name = "ButtonPreviewOutputs";
            this.ButtonPreviewOutputs.Size = new System.Drawing.Size(761, 23);
            this.ButtonPreviewOutputs.TabIndex = 0;
            this.ButtonPreviewOutputs.Text = "詳細確認";
            this.ButtonPreviewOutputs.UseVisualStyleBackColor = true;
            this.ButtonPreviewOutputs.Click += new System.EventHandler(this.ButtonPreviewOutputs_Click);
            // 
            // BackgroundWorker10
            // 
            this.BackgroundWorker10.WorkerReportsProgress = true;
            this.BackgroundWorker10.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker10_DoWork);
            this.BackgroundWorker10.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker10_ProgressChanged);
            this.BackgroundWorker10.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker10_RunWorkerCompleted);
            // 
            // BackgroundWorker11
            // 
            this.BackgroundWorker11.WorkerReportsProgress = true;
            this.BackgroundWorker11.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker11_DoWork);
            this.BackgroundWorker11.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker11_ProgressChanged);
            this.BackgroundWorker11.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker11_RunWorkerCompleted);
            // 
            // BackgroundWorker12
            // 
            this.BackgroundWorker12.WorkerReportsProgress = true;
            this.BackgroundWorker12.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker12_DoWork);
            this.BackgroundWorker12.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker12_ProgressChanged);
            this.BackgroundWorker12.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker12_RunWorkerCompleted);
            // 
            // BackgroundWorker13
            // 
            this.BackgroundWorker13.WorkerReportsProgress = true;
            this.BackgroundWorker13.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker13_DoWork);
            this.BackgroundWorker13.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker13_ProgressChanged);
            this.BackgroundWorker13.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker13_RunWorkerCompleted);
            // 
            // GroupBoxCpuCores
            // 
            this.GroupBoxCpuCores.Controls.Add(this.LabelCpuCoreCountTitle);
            this.GroupBoxCpuCores.Controls.Add(this.LabelTotalCpuCoreCount);
            this.GroupBoxCpuCores.Controls.Add(this.NumericUpDownUseCpuCoreCount);
            this.GroupBoxCpuCores.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxCpuCores.Location = new System.Drawing.Point(718, 228);
            this.GroupBoxCpuCores.Name = "GroupBoxCpuCores";
            this.GroupBoxCpuCores.Size = new System.Drawing.Size(206, 57);
            this.GroupBoxCpuCores.TabIndex = 4;
            this.GroupBoxCpuCores.TabStop = false;
            this.GroupBoxCpuCores.Text = "使用CPUコア数";
            // 
            // LabelCpuCoreCountTitle
            // 
            this.LabelCpuCoreCountTitle.AutoSize = true;
            this.LabelCpuCoreCountTitle.Location = new System.Drawing.Point(19, 26);
            this.LabelCpuCoreCountTitle.Name = "LabelCpuCoreCountTitle";
            this.LabelCpuCoreCountTitle.Size = new System.Drawing.Size(31, 15);
            this.LabelCpuCoreCountTitle.TabIndex = 7;
            this.LabelCpuCoreCountTitle.Text = "使用";
            // 
            // LabelTotalCpuCoreCount
            // 
            this.LabelTotalCpuCoreCount.AutoSize = true;
            this.LabelTotalCpuCoreCount.Location = new System.Drawing.Point(105, 26);
            this.LabelTotalCpuCoreCount.Name = "LabelTotalCpuCoreCount";
            this.LabelTotalCpuCoreCount.Size = new System.Drawing.Size(81, 15);
            this.LabelTotalCpuCoreCount.TabIndex = 6;
            this.LabelTotalCpuCoreCount.Text = "コア / 全 8 コア";
            // 
            // NumericUpDownUseCpuCoreCount
            // 
            this.NumericUpDownUseCpuCoreCount.Location = new System.Drawing.Point(55, 23);
            this.NumericUpDownUseCpuCoreCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NumericUpDownUseCpuCoreCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownUseCpuCoreCount.Name = "NumericUpDownUseCpuCoreCount";
            this.NumericUpDownUseCpuCoreCount.Size = new System.Drawing.Size(44, 23);
            this.NumericUpDownUseCpuCoreCount.TabIndex = 5;
            this.NumericUpDownUseCpuCoreCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericUpDownUseCpuCoreCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TimerFileIO
            // 
            this.TimerFileIO.Enabled = true;
            this.TimerFileIO.Tick += new System.EventHandler(this.TimerFileIO_Tick);
            // 
            // DataSetSetting
            // 
            this.DataSetSetting.DataSetName = "DataSetSetting";
            this.DataSetSetting.Tables.AddRange(new System.Data.DataTable[] {
            this.DataTableOutputPattern1,
            this.DataTableOutputPattern2,
            this.DataTableCommonOutput1,
            this.DataTableCommonOutput2,
            this.DataTableCostRatio});
            // 
            // ProgressBarOutputCommonCSV2
            // 
            this.ProgressBarOutputCommonCSV2.Location = new System.Drawing.Point(1026, 170);
            this.ProgressBarOutputCommonCSV2.Maximum = 1000;
            this.ProgressBarOutputCommonCSV2.Name = "ProgressBarOutputCommonCSV2";
            this.ProgressBarOutputCommonCSV2.Size = new System.Drawing.Size(232, 20);
            this.ProgressBarOutputCommonCSV2.TabIndex = 20;
            // 
            // ProgressBarOutputCommonCSV1
            // 
            this.ProgressBarOutputCommonCSV1.Location = new System.Drawing.Point(1027, 141);
            this.ProgressBarOutputCommonCSV1.Maximum = 1000;
            this.ProgressBarOutputCommonCSV1.Name = "ProgressBarOutputCommonCSV1";
            this.ProgressBarOutputCommonCSV1.Size = new System.Drawing.Size(232, 20);
            this.ProgressBarOutputCommonCSV1.TabIndex = 19;
            // 
            // ProgressBarOutputPatternCSV
            // 
            this.ProgressBarOutputPatternCSV.Location = new System.Drawing.Point(1027, 112);
            this.ProgressBarOutputPatternCSV.Maximum = 1000;
            this.ProgressBarOutputPatternCSV.Name = "ProgressBarOutputPatternCSV";
            this.ProgressBarOutputPatternCSV.Size = new System.Drawing.Size(232, 20);
            this.ProgressBarOutputPatternCSV.TabIndex = 18;
            // 
            // ProgressBarOutputExcel
            // 
            this.ProgressBarOutputExcel.Location = new System.Drawing.Point(1027, 83);
            this.ProgressBarOutputExcel.Maximum = 1000;
            this.ProgressBarOutputExcel.Name = "ProgressBarOutputExcel";
            this.ProgressBarOutputExcel.Size = new System.Drawing.Size(232, 20);
            this.ProgressBarOutputExcel.TabIndex = 17;
            // 
            // ProgressBarInput2
            // 
            this.ProgressBarInput2.Location = new System.Drawing.Point(1027, 54);
            this.ProgressBarInput2.Maximum = 1000;
            this.ProgressBarInput2.Name = "ProgressBarInput2";
            this.ProgressBarInput2.Size = new System.Drawing.Size(232, 20);
            this.ProgressBarInput2.TabIndex = 16;
            // 
            // ProgressBarInput1
            // 
            this.ProgressBarInput1.Location = new System.Drawing.Point(1027, 25);
            this.ProgressBarInput1.Maximum = 1000;
            this.ProgressBarInput1.Name = "ProgressBarInput1";
            this.ProgressBarInput1.Size = new System.Drawing.Size(232, 20);
            this.ProgressBarInput1.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1316, 821);
            this.Controls.Add(this.GroupBoxCpuCores);
            this.Controls.Add(this.TabControlMatchingOutput);
            this.Controls.Add(this.TabControlOutputSetting);
            this.Controls.Add(this.GroupBoxAllMatch);
            this.Controls.Add(this.GroupBoxFiles);
            this.Controls.Add(this.GroupBoxExecute);
            this.Controls.Add(this.GroupBoxPartMatch);
            this.Controls.Add(this.GroupBoxOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BookSearcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.GroupBoxOutput.ResumeLayout(false);
            this.GroupBoxOutput.PerformLayout();
            this.GroupBoxPartMatch.ResumeLayout(false);
            this.GroupBoxPartMatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLength)).EndInit();
            this.GroupBoxExecute.ResumeLayout(false);
            this.GroupBoxFiles.ResumeLayout(false);
            this.GroupBoxFiles.PerformLayout();
            this.GroupBoxAllMatch.ResumeLayout(false);
            this.GroupBoxAllMatch.PerformLayout();
            this.TabControlOutputSetting.ResumeLayout(false);
            this.TabPageDatabaseColumn.ResumeLayout(false);
            this.TableLayoutPanelBook.ResumeLayout(false);
            this.TableLayoutPanelBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookColumnSetting)).EndInit();
            this.TabPageScrapingColumn.ResumeLayout(false);
            this.TableLayoutPanelScraping.ResumeLayout(false);
            this.TableLayoutPanelScraping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScrapingColumnSetting)).EndInit();
            this.TabControlMatchingOutput.ResumeLayout(false);
            this.TabPageMatching.ResumeLayout(false);
            this.PanelMatchCondition.ResumeLayout(false);
            this.PanelMatchCondition.PerformLayout();
            this.TabPageOutputSetting.ResumeLayout(false);
            this.TabControlOutputFileSetting.ResumeLayout(false);
            this.TabPageOutputPattern1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewOutputPattern1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableOutputPattern1)).EndInit();
            this.TabPageOutputPattern2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewOutputPattern2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableOutputPattern2)).EndInit();
            this.TabPageCommonOutput1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCommonOutput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableCommonOutput1)).EndInit();
            this.TabPageCommonOutput2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCommonOutput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableCommonOutput2)).EndInit();
            this.TabPageCostRatio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCostRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableCostRatio)).EndInit();
            this.GroupBoxCpuCores.ResumeLayout(false);
            this.GroupBoxCpuCores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownUseCpuCoreCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Timer TimerSearch;
        protected System.ComponentModel.BackgroundWorker BackgroundWorker4;
        protected System.ComponentModel.BackgroundWorker BackgroundWorker2;
        protected System.ComponentModel.BackgroundWorker BackgroundWorker1;
        protected System.Windows.Forms.GroupBox GroupBoxOutput;
        protected System.Windows.Forms.RadioButton RadioButtonFileTypeCSV1;
        protected System.Windows.Forms.GroupBox GroupBoxPartMatch;
        protected System.Windows.Forms.Label Label4;
        protected System.Windows.Forms.GroupBox GroupBoxExecute;
        protected System.Windows.Forms.Button ButtonExecute;
        protected System.Windows.Forms.GroupBox GroupBoxFiles;
        protected System.Windows.Forms.Button ButtonOutput1;
        protected System.Windows.Forms.TextBox TextBoxOutputExcel;
        protected System.Windows.Forms.Label LabelOutputExcel;
        protected System.Windows.Forms.Button ButtonInput2;
        protected System.Windows.Forms.Button ButtonInput1;
        protected System.Windows.Forms.TextBox TextBoxInput2;
        protected System.Windows.Forms.TextBox TextBoxInput1;
        protected System.Windows.Forms.Label LabelInput2;
        protected System.Windows.Forms.Label LabelInput1;
        protected System.Windows.Forms.RadioButton RadioButtonFileTypeCSV2;
        protected System.Windows.Forms.TextBox TextBoxOutputCSV1;
        protected System.Windows.Forms.TextBox TextBoxOutputCSV;
        protected System.Windows.Forms.Label LabelOutputCSV1;
        protected System.Windows.Forms.Label LabelOutputCSV2;
        protected System.Windows.Forms.NumericUpDown NumericUpDownLength;
        protected System.Windows.Forms.GroupBox GroupBoxAllMatch;
        protected System.Windows.Forms.RadioButton RadioButtonSpaceIgnore;
        protected System.Windows.Forms.RadioButton RadioButtonSpaceContains;
        protected System.Windows.Forms.Label LabelOutputCSV;
        protected System.Windows.Forms.TextBox TextBoxOutputCSV2;
        protected BookSearcherApp.FileIOProgressBar ProgressBarOutputExcel;
        protected BookSearcherApp.FileIOProgressBar ProgressBarInput2;
        protected BookSearcherApp.FileIOProgressBar ProgressBarInput1;
        protected System.Windows.Forms.TabControl TabControlOutputSetting;
        protected System.Windows.Forms.TabPage TabPageDatabaseColumn;
        protected System.Windows.Forms.TabPage TabPageScrapingColumn;
        protected System.Windows.Forms.TabControl TabControlMatchingOutput;
        protected System.Windows.Forms.TabPage TabPageMatching;
        protected System.Windows.Forms.TabPage TabPageOutputSetting;
        protected System.Windows.Forms.Label LabelElapsed;
        protected System.Windows.Forms.Label LabelResultRows;
        protected System.Windows.Forms.Panel PanelMatchCondition;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType17;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType16;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType15;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType14;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType13;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType12;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType11;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType10;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType09;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType08;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType07;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType06;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType05;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType04;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType03;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType02;
        protected System.Windows.Forms.RadioButton RadioButtonSearchType01;
        protected System.Windows.Forms.TabControl TabControlOutputFileSetting;
        protected System.Windows.Forms.TabPage TabPageOutputPattern1;
        protected System.Windows.Forms.DataGridView DataGridViewOutputPattern1;
        protected System.Windows.Forms.TabPage TabPageOutputPattern2;
        protected System.Windows.Forms.DataGridView DataGridViewOutputPattern2;
        protected System.Windows.Forms.TabPage TabPageCommonOutput1;
        protected System.Windows.Forms.DataGridView DataGridViewCommonOutput1;
        protected System.Windows.Forms.TabPage TabPageCommonOutput2;
        protected System.Windows.Forms.DataGridView DataGridViewCommonOutput2;
        protected System.Windows.Forms.TabPage TabPageCostRatio;
        protected System.Windows.Forms.DataGridView DataGridViewCostRatio;
        protected System.Windows.Forms.Button ButtonPreviewOutputs;
        protected BookSearcherApp.FileIOProgressBar ProgressBarOutputCommonCSV2;
        protected BookSearcherApp.FileIOProgressBar ProgressBarOutputCommonCSV1;
        protected BookSearcherApp.FileIOProgressBar ProgressBarOutputPatternCSV;
        protected System.ComponentModel.BackgroundWorker BackgroundWorker10;
        protected System.ComponentModel.BackgroundWorker BackgroundWorker11;
        protected System.ComponentModel.BackgroundWorker BackgroundWorker12;
        protected System.ComponentModel.BackgroundWorker BackgroundWorker13;
        protected System.Windows.Forms.GroupBox GroupBoxCpuCores;
        protected System.Windows.Forms.NumericUpDown NumericUpDownUseCpuCoreCount;
        protected System.Windows.Forms.Label LabelCpuCoreCountTitle;
        protected System.Windows.Forms.Label LabelTotalCpuCoreCount;
        protected System.Windows.Forms.Timer TimerFileIO;
        protected System.Windows.Forms.TableLayoutPanel TableLayoutPanelBook;
        protected System.Windows.Forms.DataGridView BookColumnSetting;
        protected System.Windows.Forms.CheckBox CheckBoxBookISBN;
        protected System.Windows.Forms.CheckBox CheckBoxBookCost;
        protected System.Windows.Forms.TableLayoutPanel TableLayoutPanelScraping;
        protected System.Windows.Forms.DataGridView ScrapingColumnSetting;
        protected System.Windows.Forms.CheckBox CheckBoxScrapingISBN;
        protected System.Windows.Forms.CheckBox CheckBoxScrapingCost;
        protected System.Windows.Forms.Button ButtonPreviewDatabase;
        protected System.Windows.Forms.Button ButtonPreviewScraping;
        protected System.Windows.Forms.DataGridViewTextBoxColumn BookColumnName;
        protected System.Windows.Forms.DataGridViewTextBoxColumn BookColumnValue;
        protected System.Windows.Forms.DataGridViewComboBoxColumn BookColumnType;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ScrapingColumnName;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ScrapingColumnValue;
        protected System.Windows.Forms.DataGridViewComboBoxColumn ScrapingColumnType;
        protected System.Data.DataSet DataSetSetting;
        protected System.Data.DataTable DataTableOutputPattern1;
        protected System.Data.DataColumn DataColumnNameJP1;
        protected System.Data.DataColumn DataColumnNameEN1;
        protected System.Data.DataColumn DataColumnValue1;
        protected System.Data.DataTable DataTableOutputPattern2;
        protected System.Data.DataColumn DataColumnNameJP2;
        protected System.Data.DataColumn DataColumnNameEN2;
        protected System.Data.DataColumn DataColumnValue2;
        protected System.Data.DataTable DataTableCommonOutput1;
        protected System.Data.DataColumn DataColumnNameJP3;
        protected System.Data.DataColumn DataColumnNameEN3;
        protected System.Data.DataColumn DataColumnValue3;
        protected System.Data.DataTable DataTableCommonOutput2;
        protected System.Data.DataColumn DataColumnNameJP4;
        protected System.Data.DataColumn DataColumnNameEN4;
        protected System.Data.DataColumn DataColumnValue4;
        protected System.Data.DataTable DataTableCostRatio;
        protected System.Data.DataColumn DataColumnCostLower;
        protected System.Data.DataColumn DataColumnCostRatio;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnJapaneseName1;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnEnglishName1;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettingValue1;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnJapaneseName2;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnEnglishName2;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettingValue2;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnJapaneseName3;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnEnglishName3;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettingValue3;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnJapaneseName4;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnEnglishName4;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnSettingValue4;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostLower;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostRatio;
        private System.ComponentModel.IContainer components;
    }
}

