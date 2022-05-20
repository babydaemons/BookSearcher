namespace BookSearcher
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.BackgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.GroupBoxMatchType = new System.Windows.Forms.GroupBox();
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
            this.GroupBoxDatabase = new System.Windows.Forms.GroupBox();
            this.BookColumnSetting = new System.Windows.Forms.DataGridView();
            this.BookColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GroupBoxScraping = new System.Windows.Forms.GroupBox();
            this.ScrapingColumnSetting = new System.Windows.Forms.DataGridView();
            this.ScrapingColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GroupBoxOutput = new System.Windows.Forms.GroupBox();
            this.RadioButtonFileTypeCSV2 = new System.Windows.Forms.RadioButton();
            this.RadioButtonFileTypeCSV1 = new System.Windows.Forms.RadioButton();
            this.GroupBoxPartMatch = new System.Windows.Forms.GroupBox();
            this.NumericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBoxExecute = new System.Windows.Forms.GroupBox();
            this.ProgressBarExecute = new System.Windows.Forms.ProgressBar();
            this.ButtonExecute = new System.Windows.Forms.Button();
            this.GroupBoxFiles = new System.Windows.Forms.GroupBox();
            this.ProgressBarOutputExcel = new System.Windows.Forms.ProgressBar();
            this.ProgressBarInput2 = new System.Windows.Forms.ProgressBar();
            this.ProgressBarInput1 = new System.Windows.Forms.ProgressBar();
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
            this.StatusStrip1.SuspendLayout();
            this.GroupBoxMatchType.SuspendLayout();
            this.GroupBoxDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookColumnSetting)).BeginInit();
            this.GroupBoxScraping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScrapingColumnSetting)).BeginInit();
            this.GroupBoxOutput.SuspendLayout();
            this.GroupBoxPartMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLength)).BeginInit();
            this.GroupBoxExecute.SuspendLayout();
            this.GroupBoxFiles.SuspendLayout();
            this.GroupBoxAllMatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 10;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
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
            // StatusStrip1
            // 
            this.StatusStrip1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripStatusLabel2});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 805);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(1295, 22);
            this.StatusStrip1.TabIndex = 29;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.ToolStripStatusLabel1.Text = "00:00:00";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(175, 17);
            this.ToolStripStatusLabel2.Text = "検索条件を指定してください．．．";
            // 
            // GroupBoxMatchType
            // 
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType17);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType16);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType15);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType14);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType13);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType12);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType11);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType10);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType09);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType08);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType07);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType06);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType05);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType04);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType03);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType02);
            this.GroupBoxMatchType.Controls.Add(this.RadioButtonSearchType01);
            this.GroupBoxMatchType.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxMatchType.Location = new System.Drawing.Point(12, 291);
            this.GroupBoxMatchType.Name = "GroupBoxMatchType";
            this.GroupBoxMatchType.Size = new System.Drawing.Size(747, 501);
            this.GroupBoxMatchType.TabIndex = 4;
            this.GroupBoxMatchType.TabStop = false;
            this.GroupBoxMatchType.Text = "検索パターン";
            // 
            // RadioButtonSearchType17
            // 
            this.RadioButtonSearchType17.AutoSize = true;
            this.RadioButtonSearchType17.Enabled = false;
            this.RadioButtonSearchType17.Location = new System.Drawing.Point(20, 468);
            this.RadioButtonSearchType17.Name = "RadioButtonSearchType17";
            this.RadioButtonSearchType17.Size = new System.Drawing.Size(710, 19);
            this.RadioButtonSearchType17.TabIndex = 16;
            this.RadioButtonSearchType17.Text = "⑰「書籍名(前方一致)」+「出版年(部分一致)」+「出版社名(部分一致)」　【データベース側参照セル3つ⇔スクレイピングデータ側参照セル3つ】";
            this.RadioButtonSearchType17.UseVisualStyleBackColor = true;
            // 
            // RadioButtonSearchType16
            // 
            this.RadioButtonSearchType16.AutoSize = true;
            this.RadioButtonSearchType16.Enabled = false;
            this.RadioButtonSearchType16.Location = new System.Drawing.Point(20, 443);
            this.RadioButtonSearchType16.Name = "RadioButtonSearchType16";
            this.RadioButtonSearchType16.Size = new System.Drawing.Size(710, 19);
            this.RadioButtonSearchType16.TabIndex = 15;
            this.RadioButtonSearchType16.Text = "⑯「書籍名(部分一致)」+「出版年(部分一致)」+「出版社名(部分一致)」　【データベース側参照セル3つ⇔スクレイピングデータ側参照セル3つ】";
            this.RadioButtonSearchType16.UseVisualStyleBackColor = true;
            // 
            // RadioButtonSearchType15
            // 
            this.RadioButtonSearchType15.AutoSize = true;
            this.RadioButtonSearchType15.Location = new System.Drawing.Point(20, 409);
            this.RadioButtonSearchType15.Name = "RadioButtonSearchType15";
            this.RadioButtonSearchType15.Size = new System.Drawing.Size(466, 19);
            this.RadioButtonSearchType15.TabIndex = 14;
            this.RadioButtonSearchType15.Text = "⑮「書籍名(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType15.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType15.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType14
            // 
            this.RadioButtonSearchType14.AutoSize = true;
            this.RadioButtonSearchType14.Location = new System.Drawing.Point(20, 384);
            this.RadioButtonSearchType14.Name = "RadioButtonSearchType14";
            this.RadioButtonSearchType14.Size = new System.Drawing.Size(460, 19);
            this.RadioButtonSearchType14.TabIndex = 13;
            this.RadioButtonSearchType14.Text = "⑭「ISBN(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType14.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType14.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType13
            // 
            this.RadioButtonSearchType13.AutoSize = true;
            this.RadioButtonSearchType13.Location = new System.Drawing.Point(20, 359);
            this.RadioButtonSearchType13.Name = "RadioButtonSearchType13";
            this.RadioButtonSearchType13.Size = new System.Drawing.Size(454, 19);
            this.RadioButtonSearchType13.TabIndex = 12;
            this.RadioButtonSearchType13.Text = "⑬「URL(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType13.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType13.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType12
            // 
            this.RadioButtonSearchType12.AutoSize = true;
            this.RadioButtonSearchType12.Enabled = false;
            this.RadioButtonSearchType12.Location = new System.Drawing.Point(20, 325);
            this.RadioButtonSearchType12.Name = "RadioButtonSearchType12";
            this.RadioButtonSearchType12.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType12.TabIndex = 11;
            this.RadioButtonSearchType12.Text = "⑫「書籍名(部分一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType12.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType12.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType11
            // 
            this.RadioButtonSearchType11.AutoSize = true;
            this.RadioButtonSearchType11.Enabled = false;
            this.RadioButtonSearchType11.Location = new System.Drawing.Point(20, 300);
            this.RadioButtonSearchType11.Name = "RadioButtonSearchType11";
            this.RadioButtonSearchType11.Size = new System.Drawing.Size(594, 19);
            this.RadioButtonSearchType11.TabIndex = 10;
            this.RadioButtonSearchType11.Text = "⑪「書籍名(部分一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType11.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType11.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType10
            // 
            this.RadioButtonSearchType10.AutoSize = true;
            this.RadioButtonSearchType10.Enabled = false;
            this.RadioButtonSearchType10.Location = new System.Drawing.Point(20, 275);
            this.RadioButtonSearchType10.Name = "RadioButtonSearchType10";
            this.RadioButtonSearchType10.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType10.TabIndex = 9;
            this.RadioButtonSearchType10.Text = "⑩「書籍名(部分一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButtonSearchType10.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType10.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType09
            // 
            this.RadioButtonSearchType09.AutoSize = true;
            this.RadioButtonSearchType09.Enabled = false;
            this.RadioButtonSearchType09.Location = new System.Drawing.Point(20, 241);
            this.RadioButtonSearchType09.Name = "RadioButtonSearchType09";
            this.RadioButtonSearchType09.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType09.TabIndex = 8;
            this.RadioButtonSearchType09.Text = "⑨「書籍名(部分一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType09.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType09.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType08
            // 
            this.RadioButtonSearchType08.AutoSize = true;
            this.RadioButtonSearchType08.Enabled = false;
            this.RadioButtonSearchType08.Location = new System.Drawing.Point(20, 216);
            this.RadioButtonSearchType08.Name = "RadioButtonSearchType08";
            this.RadioButtonSearchType08.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType08.TabIndex = 7;
            this.RadioButtonSearchType08.Text = "⑧「書籍名(前方一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType08.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType08.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType07
            // 
            this.RadioButtonSearchType07.AutoSize = true;
            this.RadioButtonSearchType07.Enabled = false;
            this.RadioButtonSearchType07.Location = new System.Drawing.Point(20, 191);
            this.RadioButtonSearchType07.Name = "RadioButtonSearchType07";
            this.RadioButtonSearchType07.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType07.TabIndex = 6;
            this.RadioButtonSearchType07.Text = "⑦「書籍名(完全一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType07.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType07.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType06
            // 
            this.RadioButtonSearchType06.AutoSize = true;
            this.RadioButtonSearchType06.Enabled = false;
            this.RadioButtonSearchType06.Location = new System.Drawing.Point(20, 156);
            this.RadioButtonSearchType06.Name = "RadioButtonSearchType06";
            this.RadioButtonSearchType06.Size = new System.Drawing.Size(594, 19);
            this.RadioButtonSearchType06.TabIndex = 5;
            this.RadioButtonSearchType06.Text = "⑥「書籍名(部分一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType06.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType06.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType05
            // 
            this.RadioButtonSearchType05.AutoSize = true;
            this.RadioButtonSearchType05.Location = new System.Drawing.Point(20, 131);
            this.RadioButtonSearchType05.Name = "RadioButtonSearchType05";
            this.RadioButtonSearchType05.Size = new System.Drawing.Size(594, 19);
            this.RadioButtonSearchType05.TabIndex = 4;
            this.RadioButtonSearchType05.Text = "⑤「書籍名(前方一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType05.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType05.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType04
            // 
            this.RadioButtonSearchType04.AutoSize = true;
            this.RadioButtonSearchType04.Location = new System.Drawing.Point(20, 106);
            this.RadioButtonSearchType04.Name = "RadioButtonSearchType04";
            this.RadioButtonSearchType04.Size = new System.Drawing.Size(594, 19);
            this.RadioButtonSearchType04.TabIndex = 3;
            this.RadioButtonSearchType04.Text = "④「書籍名(完全一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType04.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType04.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType03
            // 
            this.RadioButtonSearchType03.AutoSize = true;
            this.RadioButtonSearchType03.Enabled = false;
            this.RadioButtonSearchType03.Location = new System.Drawing.Point(20, 72);
            this.RadioButtonSearchType03.Name = "RadioButtonSearchType03";
            this.RadioButtonSearchType03.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType03.TabIndex = 2;
            this.RadioButtonSearchType03.Text = "③「書籍名(部分一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType03.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType03.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType02
            // 
            this.RadioButtonSearchType02.AutoSize = true;
            this.RadioButtonSearchType02.Location = new System.Drawing.Point(20, 47);
            this.RadioButtonSearchType02.Name = "RadioButtonSearchType02";
            this.RadioButtonSearchType02.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType02.TabIndex = 1;
            this.RadioButtonSearchType02.Text = "②「書籍名(前方一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType02.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType02.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // RadioButtonSearchType01
            // 
            this.RadioButtonSearchType01.AutoSize = true;
            this.RadioButtonSearchType01.Checked = true;
            this.RadioButtonSearchType01.Location = new System.Drawing.Point(20, 22);
            this.RadioButtonSearchType01.Name = "RadioButtonSearchType01";
            this.RadioButtonSearchType01.Size = new System.Drawing.Size(582, 19);
            this.RadioButtonSearchType01.TabIndex = 0;
            this.RadioButtonSearchType01.TabStop = true;
            this.RadioButtonSearchType01.Text = "①「書籍名(完全一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButtonSearchType01.UseVisualStyleBackColor = true;
            this.RadioButtonSearchType01.CheckedChanged += new System.EventHandler(this.RadioButtonSearchType_CheckedChanged);
            // 
            // GroupBoxDatabase
            // 
            this.GroupBoxDatabase.Controls.Add(this.BookColumnSetting);
            this.GroupBoxDatabase.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxDatabase.Location = new System.Drawing.Point(765, 291);
            this.GroupBoxDatabase.Name = "GroupBoxDatabase";
            this.GroupBoxDatabase.Size = new System.Drawing.Size(518, 150);
            this.GroupBoxDatabase.TabIndex = 5;
            this.GroupBoxDatabase.TabStop = false;
            this.GroupBoxDatabase.Text = "書籍データベースカラム(テーブルをダブルクリックして詳細表示)";
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
            this.BookColumnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookColumnSetting.Location = new System.Drawing.Point(3, 19);
            this.BookColumnSetting.Name = "BookColumnSetting";
            this.BookColumnSetting.RowTemplate.Height = 21;
            this.BookColumnSetting.Size = new System.Drawing.Size(512, 128);
            this.BookColumnSetting.TabIndex = 0;
            this.BookColumnSetting.Tag = "書籍データベースカラム";
            this.BookColumnSetting.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
            // 
            // BookColumnName
            // 
            this.BookColumnName.HeaderText = "列名";
            this.BookColumnName.Name = "BookColumnName";
            this.BookColumnName.ReadOnly = true;
            this.BookColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BookColumnName.Width = 150;
            // 
            // BookColumnValue
            // 
            this.BookColumnValue.HeaderText = "列データ";
            this.BookColumnValue.Name = "BookColumnValue";
            this.BookColumnValue.ReadOnly = true;
            this.BookColumnValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BookColumnValue.Width = 200;
            // 
            // BookColumnType
            // 
            this.BookColumnType.HeaderText = "比較データ種別";
            this.BookColumnType.Items.AddRange(new object[] {
            "",
            "書籍名",
            "著者名",
            "出版社名",
            "出版年",
            "ISBN",
            "URL"});
            this.BookColumnType.Name = "BookColumnType";
            this.BookColumnType.Width = 90;
            // 
            // GroupBoxScraping
            // 
            this.GroupBoxScraping.Controls.Add(this.ScrapingColumnSetting);
            this.GroupBoxScraping.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxScraping.Location = new System.Drawing.Point(765, 447);
            this.GroupBoxScraping.Name = "GroupBoxScraping";
            this.GroupBoxScraping.Size = new System.Drawing.Size(518, 345);
            this.GroupBoxScraping.TabIndex = 6;
            this.GroupBoxScraping.TabStop = false;
            this.GroupBoxScraping.Text = "スクレイピングデータカラム(テーブルをダブルクリックして詳細表示)";
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
            this.ScrapingColumnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScrapingColumnSetting.Location = new System.Drawing.Point(3, 19);
            this.ScrapingColumnSetting.Name = "ScrapingColumnSetting";
            this.ScrapingColumnSetting.RowTemplate.Height = 21;
            this.ScrapingColumnSetting.Size = new System.Drawing.Size(512, 323);
            this.ScrapingColumnSetting.TabIndex = 0;
            this.ScrapingColumnSetting.Tag = "スクレイピングデータカラム";
            this.ScrapingColumnSetting.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
            // 
            // ScrapingColumnName
            // 
            this.ScrapingColumnName.HeaderText = "列名";
            this.ScrapingColumnName.Name = "ScrapingColumnName";
            this.ScrapingColumnName.ReadOnly = true;
            this.ScrapingColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ScrapingColumnName.Width = 150;
            // 
            // ScrapingColumnValue
            // 
            this.ScrapingColumnValue.HeaderText = "列データ";
            this.ScrapingColumnValue.Name = "ScrapingColumnValue";
            this.ScrapingColumnValue.ReadOnly = true;
            this.ScrapingColumnValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ScrapingColumnValue.Width = 200;
            // 
            // ScrapingColumnType
            // 
            this.ScrapingColumnType.HeaderText = "比較データ種別";
            this.ScrapingColumnType.Items.AddRange(new object[] {
            "",
            "書籍名",
            "著者名",
            "出版社名",
            "出版年",
            "ISBN",
            "URL"});
            this.ScrapingColumnType.Name = "ScrapingColumnType";
            this.ScrapingColumnType.Width = 90;
            // 
            // GroupBoxOutput
            // 
            this.GroupBoxOutput.Controls.Add(this.RadioButtonFileTypeCSV2);
            this.GroupBoxOutput.Controls.Add(this.RadioButtonFileTypeCSV1);
            this.GroupBoxOutput.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxOutput.Location = new System.Drawing.Point(12, 228);
            this.GroupBoxOutput.Name = "GroupBoxOutput";
            this.GroupBoxOutput.Size = new System.Drawing.Size(347, 57);
            this.GroupBoxOutput.TabIndex = 1;
            this.GroupBoxOutput.TabStop = false;
            this.GroupBoxOutput.Text = "出力CSVファイルパターン";
            // 
            // RadioButtonFileTypeCSV2
            // 
            this.RadioButtonFileTypeCSV2.AutoSize = true;
            this.RadioButtonFileTypeCSV2.Location = new System.Drawing.Point(179, 24);
            this.RadioButtonFileTypeCSV2.Name = "RadioButtonFileTypeCSV2";
            this.RadioButtonFileTypeCSV2.Size = new System.Drawing.Size(137, 19);
            this.RadioButtonFileTypeCSV2.TabIndex = 2;
            this.RadioButtonFileTypeCSV2.Text = "CSVファイル(パターン2)";
            this.RadioButtonFileTypeCSV2.UseVisualStyleBackColor = true;
            this.RadioButtonFileTypeCSV2.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonFileTypeCSV1
            // 
            this.RadioButtonFileTypeCSV1.AutoSize = true;
            this.RadioButtonFileTypeCSV1.Checked = true;
            this.RadioButtonFileTypeCSV1.Location = new System.Drawing.Point(34, 24);
            this.RadioButtonFileTypeCSV1.Name = "RadioButtonFileTypeCSV1";
            this.RadioButtonFileTypeCSV1.Size = new System.Drawing.Size(137, 19);
            this.RadioButtonFileTypeCSV1.TabIndex = 1;
            this.RadioButtonFileTypeCSV1.TabStop = true;
            this.RadioButtonFileTypeCSV1.Text = "CSVファイル(パターン1)";
            this.RadioButtonFileTypeCSV1.UseVisualStyleBackColor = true;
            this.RadioButtonFileTypeCSV1.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // GroupBoxPartMatch
            // 
            this.GroupBoxPartMatch.Controls.Add(this.NumericUpDownLength);
            this.GroupBoxPartMatch.Controls.Add(this.Label4);
            this.GroupBoxPartMatch.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxPartMatch.Location = new System.Drawing.Point(673, 228);
            this.GroupBoxPartMatch.Name = "GroupBoxPartMatch";
            this.GroupBoxPartMatch.Size = new System.Drawing.Size(251, 57);
            this.GroupBoxPartMatch.TabIndex = 3;
            this.GroupBoxPartMatch.TabStop = false;
            this.GroupBoxPartMatch.Text = "前方一致・部分一致比較条件";
            // 
            // NumericUpDownLength
            // 
            this.NumericUpDownLength.Location = new System.Drawing.Point(162, 20);
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
            4,
            0,
            0,
            0});
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(31, 24);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(125, 15);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "一致文字数(空白無視)";
            // 
            // GroupBoxExecute
            // 
            this.GroupBoxExecute.Controls.Add(this.ProgressBarExecute);
            this.GroupBoxExecute.Controls.Add(this.ButtonExecute);
            this.GroupBoxExecute.Enabled = false;
            this.GroupBoxExecute.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBoxExecute.Location = new System.Drawing.Point(930, 228);
            this.GroupBoxExecute.Name = "GroupBoxExecute";
            this.GroupBoxExecute.Size = new System.Drawing.Size(353, 57);
            this.GroupBoxExecute.TabIndex = 7;
            this.GroupBoxExecute.TabStop = false;
            this.GroupBoxExecute.Text = "突き合わせ処理";
            // 
            // ProgressBarExecute
            // 
            this.ProgressBarExecute.Location = new System.Drawing.Point(109, 24);
            this.ProgressBarExecute.Name = "ProgressBarExecute";
            this.ProgressBarExecute.Size = new System.Drawing.Size(222, 20);
            this.ProgressBarExecute.TabIndex = 1;
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
            this.GroupBoxFiles.Size = new System.Drawing.Size(1271, 210);
            this.GroupBoxFiles.TabIndex = 0;
            this.GroupBoxFiles.TabStop = false;
            this.GroupBoxFiles.Text = "入力・出力データファイル指定";
            // 
            // ProgressBarOutputExcel
            // 
            this.ProgressBarOutputExcel.Location = new System.Drawing.Point(1027, 83);
            this.ProgressBarOutputExcel.Name = "ProgressBarOutputExcel";
            this.ProgressBarOutputExcel.Size = new System.Drawing.Size(222, 20);
            this.ProgressBarOutputExcel.TabIndex = 17;
            // 
            // ProgressBarInput2
            // 
            this.ProgressBarInput2.Location = new System.Drawing.Point(1027, 54);
            this.ProgressBarInput2.Name = "ProgressBarInput2";
            this.ProgressBarInput2.Size = new System.Drawing.Size(222, 20);
            this.ProgressBarInput2.TabIndex = 16;
            // 
            // ProgressBarInput1
            // 
            this.ProgressBarInput1.Location = new System.Drawing.Point(1027, 25);
            this.ProgressBarInput1.Name = "ProgressBarInput1";
            this.ProgressBarInput1.Size = new System.Drawing.Size(222, 20);
            this.ProgressBarInput1.TabIndex = 15;
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
            // 
            // TextBoxOutputCSV
            // 
            this.TextBoxOutputCSV.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxOutputCSV.Location = new System.Drawing.Point(179, 112);
            this.TextBoxOutputCSV.Name = "TextBoxOutputCSV";
            this.TextBoxOutputCSV.Size = new System.Drawing.Size(761, 23);
            this.TextBoxOutputCSV.TabIndex = 10;
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
            // 
            // TextBoxInput2
            // 
            this.TextBoxInput2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxInput2.Location = new System.Drawing.Point(179, 54);
            this.TextBoxInput2.Name = "TextBoxInput2";
            this.TextBoxInput2.Size = new System.Drawing.Size(761, 23);
            this.TextBoxInput2.TabIndex = 4;
            // 
            // TextBoxInput1
            // 
            this.TextBoxInput1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxInput1.Location = new System.Drawing.Point(179, 25);
            this.TextBoxInput1.Name = "TextBoxInput1";
            this.TextBoxInput1.Size = new System.Drawing.Size(761, 23);
            this.TextBoxInput1.TabIndex = 1;
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
            this.GroupBoxAllMatch.Location = new System.Drawing.Point(365, 228);
            this.GroupBoxAllMatch.Name = "GroupBoxAllMatch";
            this.GroupBoxAllMatch.Size = new System.Drawing.Size(302, 57);
            this.GroupBoxAllMatch.TabIndex = 2;
            this.GroupBoxAllMatch.TabStop = false;
            this.GroupBoxAllMatch.Text = "完全一致照合条件";
            // 
            // RadioButtonSpaceIgnore
            // 
            this.RadioButtonSpaceIgnore.AutoSize = true;
            this.RadioButtonSpaceIgnore.Checked = true;
            this.RadioButtonSpaceIgnore.Location = new System.Drawing.Point(168, 24);
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
            this.RadioButtonSpaceContains.Location = new System.Drawing.Point(42, 24);
            this.RadioButtonSpaceContains.Name = "RadioButtonSpaceContains";
            this.RadioButtonSpaceContains.Size = new System.Drawing.Size(95, 19);
            this.RadioButtonSpaceContains.TabIndex = 5;
            this.RadioButtonSpaceContains.Text = "空白文字含む";
            this.RadioButtonSpaceContains.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1295, 827);
            this.Controls.Add(this.GroupBoxAllMatch);
            this.Controls.Add(this.GroupBoxFiles);
            this.Controls.Add(this.GroupBoxExecute);
            this.Controls.Add(this.GroupBoxPartMatch);
            this.Controls.Add(this.GroupBoxOutput);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.GroupBoxScraping);
            this.Controls.Add(this.GroupBoxDatabase);
            this.Controls.Add(this.GroupBoxMatchType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BookSearcher";
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.GroupBoxMatchType.ResumeLayout(false);
            this.GroupBoxMatchType.PerformLayout();
            this.GroupBoxDatabase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BookColumnSetting)).EndInit();
            this.GroupBoxScraping.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScrapingColumnSetting)).EndInit();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Timer1;
        private System.ComponentModel.BackgroundWorker BackgroundWorker4;
        private System.ComponentModel.BackgroundWorker BackgroundWorker2;
        private System.ComponentModel.BackgroundWorker BackgroundWorker1;
        private System.Windows.Forms.StatusStrip StatusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel2;
        private System.Windows.Forms.GroupBox GroupBoxMatchType;
        private System.Windows.Forms.RadioButton RadioButtonSearchType16;
        private System.Windows.Forms.RadioButton RadioButtonSearchType17;
        private System.Windows.Forms.RadioButton RadioButtonSearchType15;
        private System.Windows.Forms.RadioButton RadioButtonSearchType14;
        private System.Windows.Forms.RadioButton RadioButtonSearchType13;
        private System.Windows.Forms.RadioButton RadioButtonSearchType12;
        private System.Windows.Forms.RadioButton RadioButtonSearchType11;
        private System.Windows.Forms.RadioButton RadioButtonSearchType10;
        private System.Windows.Forms.RadioButton RadioButtonSearchType09;
        private System.Windows.Forms.RadioButton RadioButtonSearchType08;
        private System.Windows.Forms.RadioButton RadioButtonSearchType07;
        private System.Windows.Forms.RadioButton RadioButtonSearchType06;
        private System.Windows.Forms.RadioButton RadioButtonSearchType05;
        private System.Windows.Forms.RadioButton RadioButtonSearchType04;
        private System.Windows.Forms.RadioButton RadioButtonSearchType03;
        private System.Windows.Forms.RadioButton RadioButtonSearchType02;
        private System.Windows.Forms.RadioButton RadioButtonSearchType01;
        private System.Windows.Forms.GroupBox GroupBoxDatabase;
        private System.Windows.Forms.DataGridView BookColumnSetting;
        private System.Windows.Forms.GroupBox GroupBoxScraping;
        private System.Windows.Forms.DataGridView ScrapingColumnSetting;
        private System.Windows.Forms.GroupBox GroupBoxOutput;
        private System.Windows.Forms.RadioButton RadioButtonFileTypeCSV1;
        private System.Windows.Forms.GroupBox GroupBoxPartMatch;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox GroupBoxExecute;
        private System.Windows.Forms.Button ButtonExecute;
        private System.Windows.Forms.GroupBox GroupBoxFiles;
        private System.Windows.Forms.Button ButtonOutput1;
        private System.Windows.Forms.TextBox TextBoxOutputExcel;
        private System.Windows.Forms.Label LabelOutputExcel;
        private System.Windows.Forms.Button ButtonInput2;
        private System.Windows.Forms.Button ButtonInput1;
        private System.Windows.Forms.TextBox TextBoxInput2;
        private System.Windows.Forms.TextBox TextBoxInput1;
        private System.Windows.Forms.Label LabelInput2;
        private System.Windows.Forms.Label LabelInput1;
        private System.Windows.Forms.RadioButton RadioButtonFileTypeCSV2;
        private System.Windows.Forms.TextBox TextBoxOutputCSV1;
        private System.Windows.Forms.TextBox TextBoxOutputCSV;
        private System.Windows.Forms.Label LabelOutputCSV1;
        private System.Windows.Forms.Label LabelOutputCSV2;
        private System.Windows.Forms.NumericUpDown NumericUpDownLength;
        private System.Windows.Forms.GroupBox GroupBoxAllMatch;
        private System.Windows.Forms.RadioButton RadioButtonSpaceIgnore;
        private System.Windows.Forms.RadioButton RadioButtonSpaceContains;
        private System.Windows.Forms.ProgressBar ProgressBarExecute;
        private System.Windows.Forms.Label LabelOutputCSV;
        private System.Windows.Forms.TextBox TextBoxOutputCSV2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookColumnValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn BookColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapingColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapingColumnValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn ScrapingColumnType;
        private System.Windows.Forms.ProgressBar ProgressBarOutputExcel;
        private System.Windows.Forms.ProgressBar ProgressBarInput2;
        private System.Windows.Forms.ProgressBar ProgressBarInput1;
    }
}

