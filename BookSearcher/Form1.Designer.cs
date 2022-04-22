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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton01 = new System.Windows.Forms.RadioButton();
            this.radioButton02 = new System.Windows.Forms.RadioButton();
            this.radioButton03 = new System.Windows.Forms.RadioButton();
            this.radioButton04 = new System.Windows.Forms.RadioButton();
            this.radioButton05 = new System.Windows.Forms.RadioButton();
            this.radioButton06 = new System.Windows.Forms.RadioButton();
            this.radioButton07 = new System.Windows.Forms.RadioButton();
            this.radioButton08 = new System.Windows.Forms.RadioButton();
            this.radioButton09 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "書籍データベースファイル";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "スクレイピングデータファイル";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(147, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(550, 23);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox2.Location = new System.Drawing.Point(147, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(550, 23);
            this.textBox2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(703, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "参照";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(703, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "参照";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button3.Location = new System.Drawing.Point(703, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "参照";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox3.Location = new System.Drawing.Point(147, 67);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(550, 23);
            this.textBox3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(10, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "出力Excelファイル";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.Location = new System.Drawing.Point(703, 599);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 26;
            this.button4.Text = "実行";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.radioButton15);
            this.groupBox1.Controls.Add(this.radioButton14);
            this.groupBox1.Controls.Add(this.radioButton13);
            this.groupBox1.Controls.Add(this.radioButton12);
            this.groupBox1.Controls.Add(this.radioButton11);
            this.groupBox1.Controls.Add(this.radioButton10);
            this.groupBox1.Controls.Add(this.radioButton09);
            this.groupBox1.Controls.Add(this.radioButton08);
            this.groupBox1.Controls.Add(this.radioButton07);
            this.groupBox1.Controls.Add(this.radioButton06);
            this.groupBox1.Controls.Add(this.radioButton05);
            this.groupBox1.Controls.Add(this.radioButton04);
            this.groupBox1.Controls.Add(this.radioButton03);
            this.groupBox1.Controls.Add(this.radioButton02);
            this.groupBox1.Controls.Add(this.radioButton01);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(15, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 479);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索パターン";
            // 
            // radioButton01
            // 
            this.radioButton01.AutoSize = true;
            this.radioButton01.Location = new System.Drawing.Point(20, 22);
            this.radioButton01.Name = "radioButton01";
            this.radioButton01.Size = new System.Drawing.Size(568, 19);
            this.radioButton01.TabIndex = 9;
            this.radioButton01.TabStop = true;
            this.radioButton01.Text = "①「書籍名(完全一致)」＆「出版年(完全一致)」　データベース側参照セル2つ　スクレイピングデータ側参照セル2つ";
            this.radioButton01.UseVisualStyleBackColor = true;
            // 
            // radioButton02
            // 
            this.radioButton02.AutoSize = true;
            this.radioButton02.Location = new System.Drawing.Point(20, 47);
            this.radioButton02.Name = "radioButton02";
            this.radioButton02.Size = new System.Drawing.Size(568, 19);
            this.radioButton02.TabIndex = 10;
            this.radioButton02.TabStop = true;
            this.radioButton02.Text = "②「書籍名(前方一致)」＆「出版年(完全一致)」　データベース側参照セル2つ　スクレイピングデータ側参照セル2つ";
            this.radioButton02.UseVisualStyleBackColor = true;
            // 
            // radioButton03
            // 
            this.radioButton03.AutoSize = true;
            this.radioButton03.Location = new System.Drawing.Point(20, 72);
            this.radioButton03.Name = "radioButton03";
            this.radioButton03.Size = new System.Drawing.Size(568, 19);
            this.radioButton03.TabIndex = 11;
            this.radioButton03.TabStop = true;
            this.radioButton03.Text = "③「書籍名(部分一致)」＆「出版年(完全一致)」　データベース側参照セル2つ　スクレイピングデータ側参照セル2つ";
            this.radioButton03.UseVisualStyleBackColor = true;
            // 
            // radioButton04
            // 
            this.radioButton04.AutoSize = true;
            this.radioButton04.Location = new System.Drawing.Point(20, 106);
            this.radioButton04.Name = "radioButton04";
            this.radioButton04.Size = new System.Drawing.Size(580, 19);
            this.radioButton04.TabIndex = 12;
            this.radioButton04.TabStop = true;
            this.radioButton04.Text = "④「書籍名(完全一致)」＆「出版社名(完全一致)」　データベース側参照セル2つ　スクレイピングデータ側参照セル2つ";
            this.radioButton04.UseVisualStyleBackColor = true;
            // 
            // radioButton05
            // 
            this.radioButton05.AutoSize = true;
            this.radioButton05.Location = new System.Drawing.Point(20, 131);
            this.radioButton05.Name = "radioButton05";
            this.radioButton05.Size = new System.Drawing.Size(580, 19);
            this.radioButton05.TabIndex = 13;
            this.radioButton05.TabStop = true;
            this.radioButton05.Text = "⑤「書籍名(前方一致)」＆「出版社名(完全一致)」　データベース側参照セル2つ　スクレイピングデータ側参照セル2つ";
            this.radioButton05.UseVisualStyleBackColor = true;
            // 
            // radioButton06
            // 
            this.radioButton06.AutoSize = true;
            this.radioButton06.Location = new System.Drawing.Point(20, 156);
            this.radioButton06.Name = "radioButton06";
            this.radioButton06.Size = new System.Drawing.Size(580, 19);
            this.radioButton06.TabIndex = 14;
            this.radioButton06.TabStop = true;
            this.radioButton06.Text = "⑥「書籍名(部分一致)」＆「出版社名(完全一致)」　データベース側参照セル2つ　スクレイピングデータ側参照セル2つ";
            this.radioButton06.UseVisualStyleBackColor = true;
            // 
            // radioButton07
            // 
            this.radioButton07.AutoSize = true;
            this.radioButton07.Location = new System.Drawing.Point(20, 191);
            this.radioButton07.Name = "radioButton07";
            this.radioButton07.Size = new System.Drawing.Size(640, 19);
            this.radioButton07.TabIndex = 15;
            this.radioButton07.TabStop = true;
            this.radioButton07.Text = "⑦「書籍名(完全一致)」＆「著者名(部分一致(スペース無視))」　データベース側参照セル2つ　スクレイピングデータ側参照セル2つ";
            this.radioButton07.UseVisualStyleBackColor = true;
            // 
            // radioButton08
            // 
            this.radioButton08.AutoSize = true;
            this.radioButton08.Location = new System.Drawing.Point(20, 216);
            this.radioButton08.Name = "radioButton08";
            this.radioButton08.Size = new System.Drawing.Size(640, 19);
            this.radioButton08.TabIndex = 16;
            this.radioButton08.TabStop = true;
            this.radioButton08.Text = "⑧「書籍名(前方一致)」＆「著者名(部分一致(スペース無視))」　データベース側参照セル2つ　スクレイピングデータ側参照セル2つ";
            this.radioButton08.UseVisualStyleBackColor = true;
            // 
            // radioButton09
            // 
            this.radioButton09.AutoSize = true;
            this.radioButton09.Location = new System.Drawing.Point(20, 241);
            this.radioButton09.Name = "radioButton09";
            this.radioButton09.Size = new System.Drawing.Size(640, 19);
            this.radioButton09.TabIndex = 17;
            this.radioButton09.TabStop = true;
            this.radioButton09.Text = "⑨「書籍名(部分一致)」＆「著者名(部分一致(スペース無視))」　データベース側参照セル2つ　スクレイピングデータ側参照セル2つ";
            this.radioButton09.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(20, 275);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(544, 19);
            this.radioButton10.TabIndex = 18;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "⑩「書籍名(部分)」＆「出版年(完全一致)」　データベース側参照セル2つ　スクレイピングデータ側参照セル1つ";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(20, 300);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(556, 19);
            this.radioButton11.TabIndex = 19;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "⑪「書籍名(部分)」＆「出版社名(完全一致)」　データベース側参照セル2つ　スクレイピングデータ側参照セル1つ";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(20, 325);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(616, 19);
            this.radioButton12.TabIndex = 20;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "⑫「書籍名(部分)」＆「著者名(部分一致(スペース無視))」　データベース側参照セル2つ　スクレイピングデータ側参照セル1つ";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(20, 359);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(438, 19);
            this.radioButton13.TabIndex = 21;
            this.radioButton13.TabStop = true;
            this.radioButton13.Text = "⑬「URL(完全一致)」　データベース側参照セル1つ　スクレイピングデータ側参照セル1つ";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(20, 384);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(444, 19);
            this.radioButton14.TabIndex = 22;
            this.radioButton14.TabStop = true;
            this.radioButton14.Text = "⑭「ISBN(完全一致)」　データベース側参照セル1つ　スクレイピングデータ側参照セル1つ";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(20, 409);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(450, 19);
            this.radioButton15.TabIndex = 23;
            this.radioButton15.TabStop = true;
            this.radioButton15.Text = "⑮「書籍名(完全一致)」　データベース側参照セル1つ　スクレイピングデータ側参照セル1つ";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(17, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "前方一致・部分一致文字数";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox1.Location = new System.Drawing.Point(168, 441);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(53, 23);
            this.comboBox1.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 642);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "BookSearcher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton03;
        private System.Windows.Forms.RadioButton radioButton02;
        private System.Windows.Forms.RadioButton radioButton01;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
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
    }
}

