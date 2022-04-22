using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSearcher
{
    public partial class Form1 : Form
    {
        private DateTime start;
        private DateTime finish;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSVファイル|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSVファイル|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            //dialog.Filter = "Excelファイル|*.xlsx;*.xlsm";
            dialog.Filter = "CSVファイル|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dialog.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = false;
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var searcher = new BookSearcher();
            searcher.Load(textBox1.Text, textBox2.Text);
            searcher.SearchType09(textBox3.Text, 7);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            finish = DateTime.Now;
            var time = finish - start;
            MessageBox.Show(time.ToString());
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = true;
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = true;
        }
    }
}
