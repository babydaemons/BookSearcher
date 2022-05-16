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
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
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
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.BookColumnSetting = new System.Windows.Forms.DataGridView();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.ScrapingColumnSetting = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioButtonFileTypeCSV2 = new System.Windows.Forms.RadioButton();
            this.RadioButtonFileTypeCSV1 = new System.Windows.Forms.RadioButton();
            this.RadioButtonFileTypeExcel = new System.Windows.Forms.RadioButton();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.NumericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.RadioButtonSpaceContains = new System.Windows.Forms.RadioButton();
            this.RadioButtonSpaceIgnore = new System.Windows.Forms.RadioButton();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.Button4 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelOutput3 = new System.Windows.Forms.Label();
            this.LabelOutput2 = new System.Windows.Forms.Label();
            this.TextBoxOutput3 = new System.Windows.Forms.TextBox();
            this.TextBoxOutput2 = new System.Windows.Forms.TextBox();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.TextBoxOutput1 = new System.Windows.Forms.TextBox();
            this.TextBoxInput2 = new System.Windows.Forms.TextBox();
            this.TextBoxInput1 = new System.Windows.Forms.TextBox();
            this.LabelOutput1 = new System.Windows.Forms.Label();
            this.LabelInput2 = new System.Windows.Forms.Label();
            this.LabelInput1 = new System.Windows.Forms.Label();
            this.BookColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ScrapingColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StatusStrip1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookColumnSetting)).BeginInit();
            this.GroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScrapingColumnSetting)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLength)).BeginInit();
            this.GroupBox7.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // BackgroundWorker4
            // 
            this.BackgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker4_DoWork);
            this.BackgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker4_RunWorkerCompleted);
            // 
            // BackgroundWorker2
            // 
            this.BackgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker2_DoWork);
            this.BackgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker2_RunWorkerCompleted);
            // 
            // BackgroundWorker1
            // 
            this.BackgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.BackgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripStatusLabel2});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 798);
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
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType17);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType16);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType15);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType14);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType13);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType12);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType11);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType10);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType09);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType08);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType07);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType06);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType05);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType04);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType03);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType02);
            this.GroupBox4.Controls.Add(this.RadioButtonSearchType01);
            this.GroupBox4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox4.Location = new System.Drawing.Point(12, 285);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(747, 501);
            this.GroupBox4.TabIndex = 3;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "検索パターン";
            // 
            // RadioButtonSearchType17
            // 
            this.RadioButtonSearchType17.AutoSize = true;
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
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.BookColumnSetting);
            this.GroupBox5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox5.Location = new System.Drawing.Point(771, 285);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(497, 150);
            this.GroupBox5.TabIndex = 4;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "書籍データベースカラム";
            // 
            // BookColumnSetting
            // 
            this.BookColumnSetting.AllowUserToAddRows = false;
            this.BookColumnSetting.AllowUserToDeleteRows = false;
            this.BookColumnSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookColumnSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookColumnNumber,
            this.BookColumnName,
            this.BookColumnValue,
            this.BookColumnType});
            this.BookColumnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BookColumnSetting.Location = new System.Drawing.Point(3, 19);
            this.BookColumnSetting.Name = "BookColumnSetting";
            this.BookColumnSetting.RowTemplate.Height = 21;
            this.BookColumnSetting.Size = new System.Drawing.Size(491, 128);
            this.BookColumnSetting.TabIndex = 0;
            this.BookColumnSetting.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.ScrapingColumnSetting);
            this.GroupBox6.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox6.Location = new System.Drawing.Point(774, 452);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(491, 334);
            this.GroupBox6.TabIndex = 5;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "スクレイピングデータカラム";
            // 
            // ScrapingColumnSetting
            // 
            this.ScrapingColumnSetting.AllowUserToAddRows = false;
            this.ScrapingColumnSetting.AllowUserToDeleteRows = false;
            this.ScrapingColumnSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScrapingColumnSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScrapingColumnNumber,
            this.ScrapingColumnName,
            this.ScrapingColumnValue,
            this.ScrapingColumnType});
            this.ScrapingColumnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScrapingColumnSetting.Location = new System.Drawing.Point(3, 19);
            this.ScrapingColumnSetting.Name = "ScrapingColumnSetting";
            this.ScrapingColumnSetting.RowTemplate.Height = 21;
            this.ScrapingColumnSetting.Size = new System.Drawing.Size(485, 312);
            this.ScrapingColumnSetting.TabIndex = 0;
            this.ScrapingColumnSetting.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.RadioButtonFileTypeCSV2);
            this.GroupBox2.Controls.Add(this.RadioButtonFileTypeCSV1);
            this.GroupBox2.Controls.Add(this.RadioButtonFileTypeExcel);
            this.GroupBox2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox2.Location = new System.Drawing.Point(12, 211);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(459, 57);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "出力データファイル種類";
            // 
            // RadioButtonFileTypeCSV2
            // 
            this.RadioButtonFileTypeCSV2.AutoSize = true;
            this.RadioButtonFileTypeCSV2.Location = new System.Drawing.Point(300, 24);
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
            this.RadioButtonFileTypeCSV1.Location = new System.Drawing.Point(136, 24);
            this.RadioButtonFileTypeCSV1.Name = "RadioButtonFileTypeCSV1";
            this.RadioButtonFileTypeCSV1.Size = new System.Drawing.Size(137, 19);
            this.RadioButtonFileTypeCSV1.TabIndex = 1;
            this.RadioButtonFileTypeCSV1.Text = "CSVファイル(パターン1)";
            this.RadioButtonFileTypeCSV1.UseVisualStyleBackColor = true;
            this.RadioButtonFileTypeCSV1.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // RadioButtonFileTypeExcel
            // 
            this.RadioButtonFileTypeExcel.AutoSize = true;
            this.RadioButtonFileTypeExcel.Checked = true;
            this.RadioButtonFileTypeExcel.Location = new System.Drawing.Point(20, 24);
            this.RadioButtonFileTypeExcel.Name = "RadioButtonFileTypeExcel";
            this.RadioButtonFileTypeExcel.Size = new System.Drawing.Size(89, 19);
            this.RadioButtonFileTypeExcel.TabIndex = 0;
            this.RadioButtonFileTypeExcel.TabStop = true;
            this.RadioButtonFileTypeExcel.Text = "Excelファイル";
            this.RadioButtonFileTypeExcel.UseVisualStyleBackColor = true;
            this.RadioButtonFileTypeExcel.CheckedChanged += new System.EventHandler(this.RadioButtonFileType_CheckedChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.NumericUpDownLength);
            this.GroupBox3.Controls.Add(this.RadioButtonSpaceContains);
            this.GroupBox3.Controls.Add(this.RadioButtonSpaceIgnore);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox3.Location = new System.Drawing.Point(491, 211);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(598, 57);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "比較条件";
            // 
            // NumericUpDownLength
            // 
            this.NumericUpDownLength.Location = new System.Drawing.Point(183, 20);
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
            // RadioButtonSpaceContains
            // 
            this.RadioButtonSpaceContains.AutoSize = true;
            this.RadioButtonSpaceContains.Location = new System.Drawing.Point(478, 22);
            this.RadioButtonSpaceContains.Name = "RadioButtonSpaceContains";
            this.RadioButtonSpaceContains.Size = new System.Drawing.Size(95, 19);
            this.RadioButtonSpaceContains.TabIndex = 4;
            this.RadioButtonSpaceContains.Text = "空白文字含む";
            this.RadioButtonSpaceContains.UseVisualStyleBackColor = true;
            // 
            // RadioButtonSpaceIgnore
            // 
            this.RadioButtonSpaceIgnore.AutoSize = true;
            this.RadioButtonSpaceIgnore.Checked = true;
            this.RadioButtonSpaceIgnore.Location = new System.Drawing.Point(365, 22);
            this.RadioButtonSpaceIgnore.Name = "RadioButtonSpaceIgnore";
            this.RadioButtonSpaceIgnore.Size = new System.Drawing.Size(97, 19);
            this.RadioButtonSpaceIgnore.TabIndex = 3;
            this.RadioButtonSpaceIgnore.TabStop = true;
            this.RadioButtonSpaceIgnore.Text = "空白文字無視";
            this.RadioButtonSpaceIgnore.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label5.Location = new System.Drawing.Point(242, 24);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(97, 15);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "文字　(空白無視)";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(32, 24);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(145, 15);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "前方一致・部分一致文字数";
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.Button4);
            this.GroupBox7.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox7.Location = new System.Drawing.Point(1103, 211);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(162, 57);
            this.GroupBox7.TabIndex = 6;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "突き合わせ処理";
            // 
            // Button4
            // 
            this.Button4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Button4.Location = new System.Drawing.Point(46, 22);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(75, 23);
            this.Button4.TabIndex = 0;
            this.Button4.Text = "実行";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.LabelOutput3);
            this.GroupBox1.Controls.Add(this.LabelOutput2);
            this.GroupBox1.Controls.Add(this.TextBoxOutput3);
            this.GroupBox1.Controls.Add(this.TextBoxOutput2);
            this.GroupBox1.Controls.Add(this.Button3);
            this.GroupBox1.Controls.Add(this.Button2);
            this.GroupBox1.Controls.Add(this.Button1);
            this.GroupBox1.Controls.Add(this.TextBoxOutput1);
            this.GroupBox1.Controls.Add(this.TextBoxInput2);
            this.GroupBox1.Controls.Add(this.TextBoxInput1);
            this.GroupBox1.Controls.Add(this.LabelOutput1);
            this.GroupBox1.Controls.Add(this.LabelInput2);
            this.GroupBox1.Controls.Add(this.LabelInput1);
            this.GroupBox1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(1253, 183);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "入力・出力データファイル指定";
            // 
            // LabelOutput3
            // 
            this.LabelOutput3.AutoSize = true;
            this.LabelOutput3.Enabled = false;
            this.LabelOutput3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelOutput3.Location = new System.Drawing.Point(31, 144);
            this.LabelOutput3.Name = "LabelOutput3";
            this.LabelOutput3.Size = new System.Drawing.Size(120, 15);
            this.LabelOutput3.TabIndex = 12;
            this.LabelOutput3.Text = "共通出力CSVファイル2";
            // 
            // LabelOutput2
            // 
            this.LabelOutput2.AutoSize = true;
            this.LabelOutput2.Enabled = false;
            this.LabelOutput2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelOutput2.Location = new System.Drawing.Point(31, 115);
            this.LabelOutput2.Name = "LabelOutput2";
            this.LabelOutput2.Size = new System.Drawing.Size(120, 15);
            this.LabelOutput2.TabIndex = 11;
            this.LabelOutput2.Text = "共通出力CSVファイル1";
            // 
            // TextBoxOutput3
            // 
            this.TextBoxOutput3.Enabled = false;
            this.TextBoxOutput3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxOutput3.Location = new System.Drawing.Point(179, 141);
            this.TextBoxOutput3.Name = "TextBoxOutput3";
            this.TextBoxOutput3.Size = new System.Drawing.Size(952, 23);
            this.TextBoxOutput3.TabIndex = 10;
            // 
            // TextBoxOutput2
            // 
            this.TextBoxOutput2.Enabled = false;
            this.TextBoxOutput2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxOutput2.Location = new System.Drawing.Point(179, 112);
            this.TextBoxOutput2.Name = "TextBoxOutput2";
            this.TextBoxOutput2.Size = new System.Drawing.Size(952, 23);
            this.TextBoxOutput2.TabIndex = 9;
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Button3.Location = new System.Drawing.Point(1137, 83);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(75, 23);
            this.Button3.TabIndex = 8;
            this.Button3.Text = "参照";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Button2.Location = new System.Drawing.Point(1137, 53);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 23);
            this.Button2.TabIndex = 5;
            this.Button2.Text = "参照";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Button1.Location = new System.Drawing.Point(1137, 25);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "参照";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TextBoxOutput1
            // 
            this.TextBoxOutput1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxOutput1.Location = new System.Drawing.Point(179, 83);
            this.TextBoxOutput1.Name = "TextBoxOutput1";
            this.TextBoxOutput1.Size = new System.Drawing.Size(952, 23);
            this.TextBoxOutput1.TabIndex = 7;
            // 
            // TextBoxInput2
            // 
            this.TextBoxInput2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxInput2.Location = new System.Drawing.Point(179, 54);
            this.TextBoxInput2.Name = "TextBoxInput2";
            this.TextBoxInput2.Size = new System.Drawing.Size(952, 23);
            this.TextBoxInput2.TabIndex = 4;
            // 
            // TextBoxInput1
            // 
            this.TextBoxInput1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBoxInput1.Location = new System.Drawing.Point(179, 25);
            this.TextBoxInput1.Name = "TextBoxInput1";
            this.TextBoxInput1.Size = new System.Drawing.Size(952, 23);
            this.TextBoxInput1.TabIndex = 1;
            // 
            // LabelOutput1
            // 
            this.LabelOutput1.AutoSize = true;
            this.LabelOutput1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelOutput1.Location = new System.Drawing.Point(31, 86);
            this.LabelOutput1.Name = "LabelOutput1";
            this.LabelOutput1.Size = new System.Drawing.Size(95, 15);
            this.LabelOutput1.TabIndex = 6;
            this.LabelOutput1.Text = "出力Excelファイル";
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
            this.LabelInput1.Location = new System.Drawing.Point(33, 28);
            this.LabelInput1.Name = "LabelInput1";
            this.LabelInput1.Size = new System.Drawing.Size(122, 15);
            this.LabelInput1.TabIndex = 0;
            this.LabelInput1.Text = "書籍データベースファイル";
            // 
            // BookColumnNumber
            // 
            this.BookColumnNumber.HeaderText = "列番号";
            this.BookColumnNumber.Name = "BookColumnNumber";
            this.BookColumnNumber.ReadOnly = true;
            this.BookColumnNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BookColumnNumber.Width = 70;
            // 
            // BookColumnName
            // 
            this.BookColumnName.HeaderText = "列名";
            this.BookColumnName.Name = "BookColumnName";
            this.BookColumnName.ReadOnly = true;
            this.BookColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BookColumnValue
            // 
            this.BookColumnValue.HeaderText = "列データ";
            this.BookColumnValue.Name = "BookColumnValue";
            this.BookColumnValue.ReadOnly = true;
            this.BookColumnValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BookColumnValue.Width = 150;
            // 
            // BookColumnType
            // 
            this.BookColumnType.HeaderText = "比較データ種別";
            this.BookColumnType.Items.AddRange(new object[] {
            "",
            "書籍名",
            "出版年",
            "出版社名",
            "著者名",
            "URL",
            "ISBN"});
            this.BookColumnType.Name = "BookColumnType";
            // 
            // ScrapingColumnNumber
            // 
            this.ScrapingColumnNumber.HeaderText = "列番号";
            this.ScrapingColumnNumber.Name = "ScrapingColumnNumber";
            this.ScrapingColumnNumber.ReadOnly = true;
            this.ScrapingColumnNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ScrapingColumnNumber.Width = 70;
            // 
            // ScrapingColumnName
            // 
            this.ScrapingColumnName.HeaderText = "列名";
            this.ScrapingColumnName.Name = "ScrapingColumnName";
            this.ScrapingColumnName.ReadOnly = true;
            this.ScrapingColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ScrapingColumnValue
            // 
            this.ScrapingColumnValue.HeaderText = "列データ";
            this.ScrapingColumnValue.Name = "ScrapingColumnValue";
            this.ScrapingColumnValue.ReadOnly = true;
            this.ScrapingColumnValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ScrapingColumnValue.Width = 150;
            // 
            // ScrapingColumnType
            // 
            this.ScrapingColumnType.HeaderText = "比較データ種別";
            this.ScrapingColumnType.Items.AddRange(new object[] {
            "",
            "書籍名",
            "出版年",
            "出版社名",
            "著者名",
            "URL",
            "ISBN",
            "(メルカリ)",
            "(日本の古書屋)"});
            this.ScrapingColumnType.Name = "ScrapingColumnType";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1295, 820);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox7);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BookSearcher";
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BookColumnSetting)).EndInit();
            this.GroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScrapingColumnSetting)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownLength)).EndInit();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox GroupBox4;
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
        private System.Windows.Forms.GroupBox GroupBox5;
        private System.Windows.Forms.DataGridView BookColumnSetting;
        private System.Windows.Forms.GroupBox GroupBox6;
        private System.Windows.Forms.DataGridView ScrapingColumnSetting;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.RadioButton RadioButtonFileTypeCSV1;
        private System.Windows.Forms.RadioButton RadioButtonFileTypeExcel;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox GroupBox7;
        private System.Windows.Forms.Button Button4;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button Button3;
        private System.Windows.Forms.TextBox TextBoxOutput1;
        private System.Windows.Forms.Label LabelOutput1;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.TextBox TextBoxInput2;
        private System.Windows.Forms.TextBox TextBoxInput1;
        private System.Windows.Forms.Label LabelInput2;
        private System.Windows.Forms.Label LabelInput1;
        private System.Windows.Forms.RadioButton RadioButtonSpaceContains;
        private System.Windows.Forms.RadioButton RadioButtonSpaceIgnore;
        private System.Windows.Forms.RadioButton RadioButtonFileTypeCSV2;
        private System.Windows.Forms.TextBox TextBoxOutput3;
        private System.Windows.Forms.TextBox TextBoxOutput2;
        private System.Windows.Forms.Label LabelOutput2;
        private System.Windows.Forms.Label LabelOutput3;
        private System.Windows.Forms.NumericUpDown NumericUpDownLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookColumnValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn BookColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapingColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapingColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapingColumnValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn ScrapingColumnType;
    }
}

