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
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton09 = new System.Windows.Forms.RadioButton();
            this.radioButton08 = new System.Windows.Forms.RadioButton();
            this.radioButton07 = new System.Windows.Forms.RadioButton();
            this.radioButton06 = new System.Windows.Forms.RadioButton();
            this.radioButton05 = new System.Windows.Forms.RadioButton();
            this.radioButton04 = new System.Windows.Forms.RadioButton();
            this.radioButton03 = new System.Windows.Forms.RadioButton();
            this.radioButton02 = new System.Windows.Forms.RadioButton();
            this.radioButton01 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bookColumnSetting = new System.Windows.Forms.DataGridView();
            this.BookColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.scrapingColumnSetting = new System.Windows.Forms.DataGridView();
            this.ScrapingColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioFileTypeCSV = new System.Windows.Forms.RadioButton();
            this.radioFileTypeExcel = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioSpaceContains = new System.Windows.Forms.RadioButton();
            this.radioSpaceIgnore = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxLength = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookColumnSetting)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrapingColumnSetting)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            this.backgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker4_RunWorkerCompleted);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton17);
            this.groupBox4.Controls.Add(this.radioButton16);
            this.groupBox4.Controls.Add(this.radioButton15);
            this.groupBox4.Controls.Add(this.radioButton14);
            this.groupBox4.Controls.Add(this.radioButton13);
            this.groupBox4.Controls.Add(this.radioButton12);
            this.groupBox4.Controls.Add(this.radioButton11);
            this.groupBox4.Controls.Add(this.radioButton10);
            this.groupBox4.Controls.Add(this.radioButton09);
            this.groupBox4.Controls.Add(this.radioButton08);
            this.groupBox4.Controls.Add(this.radioButton07);
            this.groupBox4.Controls.Add(this.radioButton06);
            this.groupBox4.Controls.Add(this.radioButton05);
            this.groupBox4.Controls.Add(this.radioButton04);
            this.groupBox4.Controls.Add(this.radioButton03);
            this.groupBox4.Controls.Add(this.radioButton02);
            this.groupBox4.Controls.Add(this.radioButton01);
            this.groupBox4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox4.Location = new System.Drawing.Point(12, 226);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(747, 501);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "検索パターン";
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.Location = new System.Drawing.Point(20, 468);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(710, 19);
            this.radioButton17.TabIndex = 16;
            this.radioButton17.Text = "⑰「書籍名(前方一致)」+「出版年(部分一致)」+「出版社名(部分一致)」　【データベース側参照セル3つ⇔スクレイピングデータ側参照セル3つ】";
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(20, 443);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(710, 19);
            this.radioButton16.TabIndex = 15;
            this.radioButton16.Text = "⑯「書籍名(部分一致)」+「出版年(部分一致)」+「出版社名(部分一致)」　【データベース側参照セル3つ⇔スクレイピングデータ側参照セル3つ】";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(20, 409);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(466, 19);
            this.radioButton15.TabIndex = 14;
            this.radioButton15.Text = "⑮「書籍名(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(20, 384);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(460, 19);
            this.radioButton14.TabIndex = 13;
            this.radioButton14.Text = "⑭「ISBN(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(20, 359);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(454, 19);
            this.radioButton13.TabIndex = 12;
            this.radioButton13.Text = "⑬「URL(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(20, 325);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(582, 19);
            this.radioButton12.TabIndex = 11;
            this.radioButton12.Text = "⑫「書籍名(部分一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(20, 300);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(594, 19);
            this.radioButton11.TabIndex = 10;
            this.radioButton11.Text = "⑪「書籍名(部分一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(20, 275);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(582, 19);
            this.radioButton10.TabIndex = 9;
            this.radioButton10.Text = "⑩「書籍名(部分一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton09
            // 
            this.radioButton09.AutoSize = true;
            this.radioButton09.Location = new System.Drawing.Point(20, 241);
            this.radioButton09.Name = "radioButton09";
            this.radioButton09.Size = new System.Drawing.Size(582, 19);
            this.radioButton09.TabIndex = 8;
            this.radioButton09.Text = "⑨「書籍名(部分一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.radioButton09.UseVisualStyleBackColor = true;
            // 
            // radioButton08
            // 
            this.radioButton08.AutoSize = true;
            this.radioButton08.Location = new System.Drawing.Point(20, 216);
            this.radioButton08.Name = "radioButton08";
            this.radioButton08.Size = new System.Drawing.Size(582, 19);
            this.radioButton08.TabIndex = 7;
            this.radioButton08.Text = "⑧「書籍名(前方一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.radioButton08.UseVisualStyleBackColor = true;
            // 
            // radioButton07
            // 
            this.radioButton07.AutoSize = true;
            this.radioButton07.Location = new System.Drawing.Point(20, 191);
            this.radioButton07.Name = "radioButton07";
            this.radioButton07.Size = new System.Drawing.Size(582, 19);
            this.radioButton07.TabIndex = 6;
            this.radioButton07.Text = "⑦「書籍名(完全一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.radioButton07.UseVisualStyleBackColor = true;
            // 
            // radioButton06
            // 
            this.radioButton06.AutoSize = true;
            this.radioButton06.Location = new System.Drawing.Point(20, 156);
            this.radioButton06.Name = "radioButton06";
            this.radioButton06.Size = new System.Drawing.Size(594, 19);
            this.radioButton06.TabIndex = 5;
            this.radioButton06.Text = "⑥「書籍名(部分一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.radioButton06.UseVisualStyleBackColor = true;
            // 
            // radioButton05
            // 
            this.radioButton05.AutoSize = true;
            this.radioButton05.Location = new System.Drawing.Point(20, 131);
            this.radioButton05.Name = "radioButton05";
            this.radioButton05.Size = new System.Drawing.Size(594, 19);
            this.radioButton05.TabIndex = 4;
            this.radioButton05.Text = "⑤「書籍名(前方一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.radioButton05.UseVisualStyleBackColor = true;
            // 
            // radioButton04
            // 
            this.radioButton04.AutoSize = true;
            this.radioButton04.Location = new System.Drawing.Point(20, 106);
            this.radioButton04.Name = "radioButton04";
            this.radioButton04.Size = new System.Drawing.Size(594, 19);
            this.radioButton04.TabIndex = 3;
            this.radioButton04.Text = "④「書籍名(完全一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.radioButton04.UseVisualStyleBackColor = true;
            // 
            // radioButton03
            // 
            this.radioButton03.AutoSize = true;
            this.radioButton03.Location = new System.Drawing.Point(20, 72);
            this.radioButton03.Name = "radioButton03";
            this.radioButton03.Size = new System.Drawing.Size(582, 19);
            this.radioButton03.TabIndex = 2;
            this.radioButton03.Text = "③「書籍名(部分一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.radioButton03.UseVisualStyleBackColor = true;
            // 
            // radioButton02
            // 
            this.radioButton02.AutoSize = true;
            this.radioButton02.Location = new System.Drawing.Point(20, 47);
            this.radioButton02.Name = "radioButton02";
            this.radioButton02.Size = new System.Drawing.Size(582, 19);
            this.radioButton02.TabIndex = 1;
            this.radioButton02.Text = "②「書籍名(前方一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.radioButton02.UseVisualStyleBackColor = true;
            // 
            // radioButton01
            // 
            this.radioButton01.AutoSize = true;
            this.radioButton01.Checked = true;
            this.radioButton01.Location = new System.Drawing.Point(20, 22);
            this.radioButton01.Name = "radioButton01";
            this.radioButton01.Size = new System.Drawing.Size(582, 19);
            this.radioButton01.TabIndex = 0;
            this.radioButton01.TabStop = true;
            this.radioButton01.Text = "①「書籍名(完全一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.radioButton01.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bookColumnSetting);
            this.groupBox5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox5.Location = new System.Drawing.Point(771, 226);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(497, 150);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "書籍データベースカラム";
            // 
            // bookColumnSetting
            // 
            this.bookColumnSetting.AllowUserToAddRows = false;
            this.bookColumnSetting.AllowUserToDeleteRows = false;
            this.bookColumnSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookColumnSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookColumnNumber,
            this.BookColumnName,
            this.BookColumnValue,
            this.BookColumnType});
            this.bookColumnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookColumnSetting.Location = new System.Drawing.Point(3, 19);
            this.bookColumnSetting.Name = "bookColumnSetting";
            this.bookColumnSetting.RowTemplate.Height = 21;
            this.bookColumnSetting.Size = new System.Drawing.Size(491, 128);
            this.bookColumnSetting.TabIndex = 0;
            // 
            // BookColumnNumber
            // 
            this.BookColumnNumber.HeaderText = "列番号";
            this.BookColumnNumber.Name = "BookColumnNumber";
            this.BookColumnNumber.ReadOnly = true;
            this.BookColumnNumber.Width = 70;
            // 
            // BookColumnName
            // 
            this.BookColumnName.HeaderText = "列名";
            this.BookColumnName.Name = "BookColumnName";
            this.BookColumnName.ReadOnly = true;
            // 
            // BookColumnValue
            // 
            this.BookColumnValue.HeaderText = "列データ";
            this.BookColumnValue.Name = "BookColumnValue";
            this.BookColumnValue.ReadOnly = true;
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.scrapingColumnSetting);
            this.groupBox6.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox6.Location = new System.Drawing.Point(774, 393);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(491, 334);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "スクレイピングデータカラム";
            // 
            // scrapingColumnSetting
            // 
            this.scrapingColumnSetting.AllowUserToAddRows = false;
            this.scrapingColumnSetting.AllowUserToDeleteRows = false;
            this.scrapingColumnSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scrapingColumnSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScrapingColumnNumber,
            this.ScrapingColumnName,
            this.ScrapingColumnValue,
            this.ScrapingColumnType});
            this.scrapingColumnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrapingColumnSetting.Location = new System.Drawing.Point(3, 19);
            this.scrapingColumnSetting.Name = "scrapingColumnSetting";
            this.scrapingColumnSetting.RowTemplate.Height = 21;
            this.scrapingColumnSetting.Size = new System.Drawing.Size(485, 312);
            this.scrapingColumnSetting.TabIndex = 0;
            // 
            // ScrapingColumnNumber
            // 
            this.ScrapingColumnNumber.HeaderText = "列番号";
            this.ScrapingColumnNumber.Name = "ScrapingColumnNumber";
            this.ScrapingColumnNumber.ReadOnly = true;
            this.ScrapingColumnNumber.Width = 70;
            // 
            // ScrapingColumnName
            // 
            this.ScrapingColumnName.HeaderText = "列名";
            this.ScrapingColumnName.Name = "ScrapingColumnName";
            this.ScrapingColumnName.ReadOnly = true;
            // 
            // ScrapingColumnValue
            // 
            this.ScrapingColumnValue.HeaderText = "列データ";
            this.ScrapingColumnValue.Name = "ScrapingColumnValue";
            this.ScrapingColumnValue.ReadOnly = true;
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
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 738);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1295, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "00:00:00";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(175, 17);
            this.toolStripStatusLabel2.Text = "検索条件を指定してください．．．";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioFileTypeCSV);
            this.groupBox2.Controls.Add(this.radioFileTypeExcel);
            this.groupBox2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(12, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出力データファイル種類";
            // 
            // radioFileTypeCSV
            // 
            this.radioFileTypeCSV.AutoSize = true;
            this.radioFileTypeCSV.Location = new System.Drawing.Point(136, 24);
            this.radioFileTypeCSV.Name = "radioFileTypeCSV";
            this.radioFileTypeCSV.Size = new System.Drawing.Size(83, 19);
            this.radioFileTypeCSV.TabIndex = 1;
            this.radioFileTypeCSV.Text = "CSVファイル";
            this.radioFileTypeCSV.UseVisualStyleBackColor = true;
            // 
            // radioFileTypeExcel
            // 
            this.radioFileTypeExcel.AutoSize = true;
            this.radioFileTypeExcel.Checked = true;
            this.radioFileTypeExcel.Location = new System.Drawing.Point(20, 24);
            this.radioFileTypeExcel.Name = "radioFileTypeExcel";
            this.radioFileTypeExcel.Size = new System.Drawing.Size(89, 19);
            this.radioFileTypeExcel.TabIndex = 0;
            this.radioFileTypeExcel.TabStop = true;
            this.radioFileTypeExcel.Text = "Excelファイル";
            this.radioFileTypeExcel.UseVisualStyleBackColor = true;
            this.radioFileTypeExcel.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioSpaceContains);
            this.groupBox3.Controls.Add(this.radioSpaceIgnore);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.comboBoxLength);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(269, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(764, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "比較条件";
            // 
            // radioSpaceContains
            // 
            this.radioSpaceContains.AutoSize = true;
            this.radioSpaceContains.Location = new System.Drawing.Point(599, 24);
            this.radioSpaceContains.Name = "radioSpaceContains";
            this.radioSpaceContains.Size = new System.Drawing.Size(95, 19);
            this.radioSpaceContains.TabIndex = 4;
            this.radioSpaceContains.Text = "空白文字含む";
            this.radioSpaceContains.UseVisualStyleBackColor = true;
            // 
            // radioSpaceIgnore
            // 
            this.radioSpaceIgnore.AutoSize = true;
            this.radioSpaceIgnore.Checked = true;
            this.radioSpaceIgnore.Location = new System.Drawing.Point(466, 24);
            this.radioSpaceIgnore.Name = "radioSpaceIgnore";
            this.radioSpaceIgnore.Size = new System.Drawing.Size(97, 19);
            this.radioSpaceIgnore.TabIndex = 3;
            this.radioSpaceIgnore.TabStop = true;
            this.radioSpaceIgnore.Text = "空白文字無視";
            this.radioSpaceIgnore.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(271, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "文字　(空白無視)";
            // 
            // comboBoxLength
            // 
            this.comboBoxLength.FormattingEnabled = true;
            this.comboBoxLength.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBoxLength.Location = new System.Drawing.Point(212, 23);
            this.comboBoxLength.Name = "comboBoxLength";
            this.comboBoxLength.Size = new System.Drawing.Size(53, 23);
            this.comboBoxLength.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(61, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "前方一致・部分一致文字数";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button4);
            this.groupBox7.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox7.Location = new System.Drawing.Point(1103, 152);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(162, 57);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "突き合わせ処理";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.Location = new System.Drawing.Point(46, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "実行";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1253, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入力・出力データファイル指定";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button3.Location = new System.Drawing.Point(1137, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "参照";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(1137, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "参照";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(1137, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "参照";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox3.Location = new System.Drawing.Point(324, 83);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(807, 23);
            this.textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox2.Location = new System.Drawing.Point(324, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(807, 23);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(324, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(807, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(31, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "出力Excelファイル";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(31, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "スクレイピングデータファイル";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "書籍データベースファイル";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(168, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 19);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "複数行に渡る列データあり";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(168, 56);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(150, 19);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "複数行に渡る列データあり";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(168, 85);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(150, 19);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "複数行に渡る列データあり";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1295, 760);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BookSearcher";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookColumnSetting)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scrapingColumnSetting)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.RadioButton radioButton17;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton09;
        private System.Windows.Forms.RadioButton radioButton08;
        private System.Windows.Forms.RadioButton radioButton07;
        private System.Windows.Forms.RadioButton radioButton06;
        private System.Windows.Forms.RadioButton radioButton05;
        private System.Windows.Forms.RadioButton radioButton04;
        private System.Windows.Forms.RadioButton radioButton03;
        private System.Windows.Forms.RadioButton radioButton02;
        private System.Windows.Forms.RadioButton radioButton01;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView bookColumnSetting;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView scrapingColumnSetting;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioFileTypeCSV;
        private System.Windows.Forms.RadioButton radioFileTypeExcel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioSpaceContains;
        private System.Windows.Forms.RadioButton radioSpaceIgnore;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookColumnValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn BookColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapingColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapingColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapingColumnValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn ScrapingColumnType;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

