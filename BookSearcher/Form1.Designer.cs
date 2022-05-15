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
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.BackgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.RadioButton17 = new System.Windows.Forms.RadioButton();
            this.RadioButton16 = new System.Windows.Forms.RadioButton();
            this.RadioButton15 = new System.Windows.Forms.RadioButton();
            this.RadioButton14 = new System.Windows.Forms.RadioButton();
            this.RadioButton13 = new System.Windows.Forms.RadioButton();
            this.RadioButton12 = new System.Windows.Forms.RadioButton();
            this.RadioButton11 = new System.Windows.Forms.RadioButton();
            this.RadioButton10 = new System.Windows.Forms.RadioButton();
            this.RadioButton09 = new System.Windows.Forms.RadioButton();
            this.RadioButton08 = new System.Windows.Forms.RadioButton();
            this.RadioButton07 = new System.Windows.Forms.RadioButton();
            this.RadioButton06 = new System.Windows.Forms.RadioButton();
            this.RadioButton05 = new System.Windows.Forms.RadioButton();
            this.RadioButton04 = new System.Windows.Forms.RadioButton();
            this.RadioButton03 = new System.Windows.Forms.RadioButton();
            this.RadioButton02 = new System.Windows.Forms.RadioButton();
            this.RadioButton01 = new System.Windows.Forms.RadioButton();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.BookColumnSetting = new System.Windows.Forms.DataGridView();
            this.BookColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.ScrapingColumnSetting = new System.Windows.Forms.DataGridView();
            this.ScrapingColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapingColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioButtonFileTypeCSV = new System.Windows.Forms.RadioButton();
            this.RadioButtonFileTypeExcel = new System.Windows.Forms.RadioButton();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.RadioSpaceContains = new System.Windows.Forms.RadioButton();
            this.RadioSpaceIgnore = new System.Windows.Forms.RadioButton();
            this.Label5 = new System.Windows.Forms.Label();
            this.ComboBoxLength = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.Button4 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox4.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BookColumnSetting)).BeginInit();
            this.GroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScrapingColumnSetting)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackgroundWorker4
            // 
            this.BackgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker4_DoWork);
            this.BackgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker4_RunWorkerCompleted);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.RadioButton17);
            this.GroupBox4.Controls.Add(this.RadioButton16);
            this.GroupBox4.Controls.Add(this.RadioButton15);
            this.GroupBox4.Controls.Add(this.RadioButton14);
            this.GroupBox4.Controls.Add(this.RadioButton13);
            this.GroupBox4.Controls.Add(this.RadioButton12);
            this.GroupBox4.Controls.Add(this.RadioButton11);
            this.GroupBox4.Controls.Add(this.RadioButton10);
            this.GroupBox4.Controls.Add(this.RadioButton09);
            this.GroupBox4.Controls.Add(this.RadioButton08);
            this.GroupBox4.Controls.Add(this.RadioButton07);
            this.GroupBox4.Controls.Add(this.RadioButton06);
            this.GroupBox4.Controls.Add(this.RadioButton05);
            this.GroupBox4.Controls.Add(this.RadioButton04);
            this.GroupBox4.Controls.Add(this.RadioButton03);
            this.GroupBox4.Controls.Add(this.RadioButton02);
            this.GroupBox4.Controls.Add(this.RadioButton01);
            this.GroupBox4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox4.Location = new System.Drawing.Point(12, 226);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(747, 501);
            this.GroupBox4.TabIndex = 3;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "検索パターン";
            // 
            // RadioButton17
            // 
            this.RadioButton17.AutoSize = true;
            this.RadioButton17.Location = new System.Drawing.Point(20, 468);
            this.RadioButton17.Name = "RadioButton17";
            this.RadioButton17.Size = new System.Drawing.Size(710, 19);
            this.RadioButton17.TabIndex = 16;
            this.RadioButton17.Text = "⑰「書籍名(前方一致)」+「出版年(部分一致)」+「出版社名(部分一致)」　【データベース側参照セル3つ⇔スクレイピングデータ側参照セル3つ】";
            this.RadioButton17.UseVisualStyleBackColor = true;
            // 
            // RadioButton16
            // 
            this.RadioButton16.AutoSize = true;
            this.RadioButton16.Location = new System.Drawing.Point(20, 443);
            this.RadioButton16.Name = "RadioButton16";
            this.RadioButton16.Size = new System.Drawing.Size(710, 19);
            this.RadioButton16.TabIndex = 15;
            this.RadioButton16.Text = "⑯「書籍名(部分一致)」+「出版年(部分一致)」+「出版社名(部分一致)」　【データベース側参照セル3つ⇔スクレイピングデータ側参照セル3つ】";
            this.RadioButton16.UseVisualStyleBackColor = true;
            // 
            // RadioButton15
            // 
            this.RadioButton15.AutoSize = true;
            this.RadioButton15.Location = new System.Drawing.Point(20, 409);
            this.RadioButton15.Name = "RadioButton15";
            this.RadioButton15.Size = new System.Drawing.Size(466, 19);
            this.RadioButton15.TabIndex = 14;
            this.RadioButton15.Text = "⑮「書籍名(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButton15.UseVisualStyleBackColor = true;
            // 
            // RadioButton14
            // 
            this.RadioButton14.AutoSize = true;
            this.RadioButton14.Location = new System.Drawing.Point(20, 384);
            this.RadioButton14.Name = "RadioButton14";
            this.RadioButton14.Size = new System.Drawing.Size(460, 19);
            this.RadioButton14.TabIndex = 13;
            this.RadioButton14.Text = "⑭「ISBN(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButton14.UseVisualStyleBackColor = true;
            // 
            // RadioButton13
            // 
            this.RadioButton13.AutoSize = true;
            this.RadioButton13.Location = new System.Drawing.Point(20, 359);
            this.RadioButton13.Name = "RadioButton13";
            this.RadioButton13.Size = new System.Drawing.Size(454, 19);
            this.RadioButton13.TabIndex = 12;
            this.RadioButton13.Text = "⑬「URL(完全一致)」　【データベース側参照セル1つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButton13.UseVisualStyleBackColor = true;
            // 
            // RadioButton12
            // 
            this.RadioButton12.AutoSize = true;
            this.RadioButton12.Location = new System.Drawing.Point(20, 325);
            this.RadioButton12.Name = "RadioButton12";
            this.RadioButton12.Size = new System.Drawing.Size(582, 19);
            this.RadioButton12.TabIndex = 11;
            this.RadioButton12.Text = "⑫「書籍名(部分一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButton12.UseVisualStyleBackColor = true;
            // 
            // RadioButton11
            // 
            this.RadioButton11.AutoSize = true;
            this.RadioButton11.Location = new System.Drawing.Point(20, 300);
            this.RadioButton11.Name = "RadioButton11";
            this.RadioButton11.Size = new System.Drawing.Size(594, 19);
            this.RadioButton11.TabIndex = 10;
            this.RadioButton11.Text = "⑪「書籍名(部分一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButton11.UseVisualStyleBackColor = true;
            // 
            // RadioButton10
            // 
            this.RadioButton10.AutoSize = true;
            this.RadioButton10.Location = new System.Drawing.Point(20, 275);
            this.RadioButton10.Name = "RadioButton10";
            this.RadioButton10.Size = new System.Drawing.Size(582, 19);
            this.RadioButton10.TabIndex = 9;
            this.RadioButton10.Text = "⑩「書籍名(部分一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル1つ】";
            this.RadioButton10.UseVisualStyleBackColor = true;
            // 
            // RadioButton09
            // 
            this.RadioButton09.AutoSize = true;
            this.RadioButton09.Location = new System.Drawing.Point(20, 241);
            this.RadioButton09.Name = "RadioButton09";
            this.RadioButton09.Size = new System.Drawing.Size(582, 19);
            this.RadioButton09.TabIndex = 8;
            this.RadioButton09.Text = "⑨「書籍名(部分一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButton09.UseVisualStyleBackColor = true;
            // 
            // RadioButton08
            // 
            this.RadioButton08.AutoSize = true;
            this.RadioButton08.Location = new System.Drawing.Point(20, 216);
            this.RadioButton08.Name = "RadioButton08";
            this.RadioButton08.Size = new System.Drawing.Size(582, 19);
            this.RadioButton08.TabIndex = 7;
            this.RadioButton08.Text = "⑧「書籍名(前方一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButton08.UseVisualStyleBackColor = true;
            // 
            // RadioButton07
            // 
            this.RadioButton07.AutoSize = true;
            this.RadioButton07.Location = new System.Drawing.Point(20, 191);
            this.RadioButton07.Name = "RadioButton07";
            this.RadioButton07.Size = new System.Drawing.Size(582, 19);
            this.RadioButton07.TabIndex = 6;
            this.RadioButton07.Text = "⑦「書籍名(完全一致)」+「著者名(部分一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButton07.UseVisualStyleBackColor = true;
            // 
            // RadioButton06
            // 
            this.RadioButton06.AutoSize = true;
            this.RadioButton06.Location = new System.Drawing.Point(20, 156);
            this.RadioButton06.Name = "RadioButton06";
            this.RadioButton06.Size = new System.Drawing.Size(594, 19);
            this.RadioButton06.TabIndex = 5;
            this.RadioButton06.Text = "⑥「書籍名(部分一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButton06.UseVisualStyleBackColor = true;
            // 
            // RadioButton05
            // 
            this.RadioButton05.AutoSize = true;
            this.RadioButton05.Location = new System.Drawing.Point(20, 131);
            this.RadioButton05.Name = "RadioButton05";
            this.RadioButton05.Size = new System.Drawing.Size(594, 19);
            this.RadioButton05.TabIndex = 4;
            this.RadioButton05.Text = "⑤「書籍名(前方一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButton05.UseVisualStyleBackColor = true;
            // 
            // RadioButton04
            // 
            this.RadioButton04.AutoSize = true;
            this.RadioButton04.Location = new System.Drawing.Point(20, 106);
            this.RadioButton04.Name = "RadioButton04";
            this.RadioButton04.Size = new System.Drawing.Size(594, 19);
            this.RadioButton04.TabIndex = 3;
            this.RadioButton04.Text = "④「書籍名(完全一致)」+「出版社名(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButton04.UseVisualStyleBackColor = true;
            // 
            // RadioButton03
            // 
            this.RadioButton03.AutoSize = true;
            this.RadioButton03.Location = new System.Drawing.Point(20, 72);
            this.RadioButton03.Name = "RadioButton03";
            this.RadioButton03.Size = new System.Drawing.Size(582, 19);
            this.RadioButton03.TabIndex = 2;
            this.RadioButton03.Text = "③「書籍名(部分一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButton03.UseVisualStyleBackColor = true;
            // 
            // RadioButton02
            // 
            this.RadioButton02.AutoSize = true;
            this.RadioButton02.Location = new System.Drawing.Point(20, 47);
            this.RadioButton02.Name = "RadioButton02";
            this.RadioButton02.Size = new System.Drawing.Size(582, 19);
            this.RadioButton02.TabIndex = 1;
            this.RadioButton02.Text = "②「書籍名(前方一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButton02.UseVisualStyleBackColor = true;
            // 
            // RadioButton01
            // 
            this.RadioButton01.AutoSize = true;
            this.RadioButton01.Checked = true;
            this.RadioButton01.Location = new System.Drawing.Point(20, 22);
            this.RadioButton01.Name = "RadioButton01";
            this.RadioButton01.Size = new System.Drawing.Size(582, 19);
            this.RadioButton01.TabIndex = 0;
            this.RadioButton01.TabStop = true;
            this.RadioButton01.Text = "①「書籍名(完全一致)」+「出版年(完全一致)」　【データベース側参照セル2つ⇔スクレイピングデータ側参照セル2つ】";
            this.RadioButton01.UseVisualStyleBackColor = true;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.BookColumnSetting);
            this.GroupBox5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox5.Location = new System.Drawing.Point(771, 226);
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
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.ScrapingColumnSetting);
            this.GroupBox6.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox6.Location = new System.Drawing.Point(774, 393);
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
            // StatusStrip1
            // 
            this.StatusStrip1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripStatusLabel2});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 738);
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
            // Timer1
            // 
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.RadioButtonFileTypeCSV);
            this.GroupBox2.Controls.Add(this.RadioButtonFileTypeExcel);
            this.GroupBox2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox2.Location = new System.Drawing.Point(12, 152);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(237, 57);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "出力データファイル種類";
            // 
            // RadioButtonFileTypeCSV
            // 
            this.RadioButtonFileTypeCSV.AutoSize = true;
            this.RadioButtonFileTypeCSV.Location = new System.Drawing.Point(136, 24);
            this.RadioButtonFileTypeCSV.Name = "RadioButtonFileTypeCSV";
            this.RadioButtonFileTypeCSV.Size = new System.Drawing.Size(83, 19);
            this.RadioButtonFileTypeCSV.TabIndex = 1;
            this.RadioButtonFileTypeCSV.Text = "CSVファイル";
            this.RadioButtonFileTypeCSV.UseVisualStyleBackColor = true;
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
            this.RadioButtonFileTypeExcel.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.RadioSpaceContains);
            this.GroupBox3.Controls.Add(this.RadioSpaceIgnore);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.ComboBoxLength);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox3.Location = new System.Drawing.Point(269, 152);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(764, 57);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "比較条件";
            // 
            // RadioSpaceContains
            // 
            this.RadioSpaceContains.AutoSize = true;
            this.RadioSpaceContains.Location = new System.Drawing.Point(599, 24);
            this.RadioSpaceContains.Name = "RadioSpaceContains";
            this.RadioSpaceContains.Size = new System.Drawing.Size(95, 19);
            this.RadioSpaceContains.TabIndex = 4;
            this.RadioSpaceContains.Text = "空白文字含む";
            this.RadioSpaceContains.UseVisualStyleBackColor = true;
            // 
            // RadioSpaceIgnore
            // 
            this.RadioSpaceIgnore.AutoSize = true;
            this.RadioSpaceIgnore.Checked = true;
            this.RadioSpaceIgnore.Location = new System.Drawing.Point(466, 24);
            this.RadioSpaceIgnore.Name = "RadioSpaceIgnore";
            this.RadioSpaceIgnore.Size = new System.Drawing.Size(97, 19);
            this.RadioSpaceIgnore.TabIndex = 3;
            this.RadioSpaceIgnore.TabStop = true;
            this.RadioSpaceIgnore.Text = "空白文字無視";
            this.RadioSpaceIgnore.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label5.Location = new System.Drawing.Point(271, 26);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(97, 15);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "文字　(空白無視)";
            // 
            // ComboBoxLength
            // 
            this.ComboBoxLength.FormattingEnabled = true;
            this.ComboBoxLength.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.ComboBoxLength.Location = new System.Drawing.Point(212, 23);
            this.ComboBoxLength.Name = "ComboBoxLength";
            this.ComboBoxLength.Size = new System.Drawing.Size(53, 23);
            this.ComboBoxLength.TabIndex = 1;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label4.Location = new System.Drawing.Point(61, 26);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(145, 15);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "前方一致・部分一致文字数";
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.Button4);
            this.GroupBox7.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox7.Location = new System.Drawing.Point(1103, 152);
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
            this.GroupBox1.Controls.Add(this.Button3);
            this.GroupBox1.Controls.Add(this.Button2);
            this.GroupBox1.Controls.Add(this.Button1);
            this.GroupBox1.Controls.Add(this.TextBox3);
            this.GroupBox1.Controls.Add(this.TextBox2);
            this.GroupBox1.Controls.Add(this.TextBox1);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(1253, 125);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "入力・出力データファイル指定";
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
            // TextBox3
            // 
            this.TextBox3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBox3.Location = new System.Drawing.Point(161, 83);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(970, 23);
            this.TextBox3.TabIndex = 7;
            // 
            // TextBox2
            // 
            this.TextBox2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBox2.Location = new System.Drawing.Point(161, 54);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(970, 23);
            this.TextBox2.TabIndex = 4;
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TextBox1.Location = new System.Drawing.Point(161, 25);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(970, 23);
            this.TextBox1.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label3.Location = new System.Drawing.Point(31, 86);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(95, 15);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "出力Excelファイル";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label2.Location = new System.Drawing.Point(31, 57);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(131, 15);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "スクレイピングデータファイル";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.Location = new System.Drawing.Point(33, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(122, 15);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "書籍データベースファイル";
            // 
            // BackgroundWorker1
            // 
            this.BackgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.BackgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // BackgroundWorker2
            // 
            this.BackgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker2_DoWork);
            this.BackgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker2_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1295, 760);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox7);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BookSearcher";
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BookColumnSetting)).EndInit();
            this.GroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScrapingColumnSetting)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
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
        private System.Windows.Forms.RadioButton RadioButton16;
        private System.Windows.Forms.RadioButton RadioButton17;
        private System.Windows.Forms.RadioButton RadioButton15;
        private System.Windows.Forms.RadioButton RadioButton14;
        private System.Windows.Forms.RadioButton RadioButton13;
        private System.Windows.Forms.RadioButton RadioButton12;
        private System.Windows.Forms.RadioButton RadioButton11;
        private System.Windows.Forms.RadioButton RadioButton10;
        private System.Windows.Forms.RadioButton RadioButton09;
        private System.Windows.Forms.RadioButton RadioButton08;
        private System.Windows.Forms.RadioButton RadioButton07;
        private System.Windows.Forms.RadioButton RadioButton06;
        private System.Windows.Forms.RadioButton RadioButton05;
        private System.Windows.Forms.RadioButton RadioButton04;
        private System.Windows.Forms.RadioButton RadioButton03;
        private System.Windows.Forms.RadioButton RadioButton02;
        private System.Windows.Forms.RadioButton RadioButton01;
        private System.Windows.Forms.GroupBox GroupBox5;
        private System.Windows.Forms.DataGridView BookColumnSetting;
        private System.Windows.Forms.GroupBox GroupBox6;
        private System.Windows.Forms.DataGridView ScrapingColumnSetting;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.RadioButton RadioButtonFileTypeCSV;
        private System.Windows.Forms.RadioButton RadioButtonFileTypeExcel;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.ComboBox ComboBoxLength;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox GroupBox7;
        private System.Windows.Forms.Button Button4;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button Button3;
        private System.Windows.Forms.TextBox TextBox3;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.RadioButton RadioSpaceContains;
        private System.Windows.Forms.RadioButton RadioSpaceIgnore;
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

