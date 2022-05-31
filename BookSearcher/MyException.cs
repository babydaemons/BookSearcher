using System;
using System.Windows.Forms;

namespace BookSearcherApp
{
    internal class MyException : Exception
    {
        private readonly string caption;
        private readonly string message;

        public MyException(string caption, string message) : base()
        {
            this.caption = caption;
            this.message = message;
        }

        public void Show()
        {
            MessageBox.Show(message, caption);
        }
    }
}
