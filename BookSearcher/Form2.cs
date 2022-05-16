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
    public partial class Form2 : Form
    {
        private readonly CSVFile csvFile;

        public Form2(CSVFile csvFile)
        {
            this.csvFile = csvFile;
            InitializeComponent();
            this.Text = $"BookSearcher - {csvFile.Path}";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataGridPreView.DataSource = csvFile.Table;
        }
    }
}
