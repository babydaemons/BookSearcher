﻿using System.ComponentModel;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public class CSVSaverCommon1 : CSVSaver2
    {
        public override int ColumnIndexPrice => 5;

        public override int ColumnIndexISBN => 1;

        public CSVSaverCommon1(DataGridView view, string path, BackgroundWorker worker = null) : base(view, path, worker) { }
    }
}
