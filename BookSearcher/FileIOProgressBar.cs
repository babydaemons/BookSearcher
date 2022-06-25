using System.Diagnostics;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public class FileIOProgressBar : ProgressBar
    {
        public const int MAX_VALUE = 10000;
        public const int DIV_VALUE = 100;

        public bool Completed => Value >= Maximum;

        // https://dobon.net/vb/dotnet/control/pbshowtext.html
        private const int WM_PAINT = 0x000F;
        private static TextFormatFlags textFormatFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine;

        public void Start()
        {
            Maximum = MAX_VALUE;
            Value = 0;
        }

        public void Stop(FileIO fileIO)
        {
            Value = MAX_VALUE;
            if (fileIO == null)
            {
                return;
            }
            Form1.UpdateProgressBar(fileIO, this);
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                // 文字列を描画する
                Graphics g = CreateGraphics();
                TextRenderer.DrawText(g, Text, Font, ClientRectangle, SystemColors.ControlText, textFormatFlags);
                g.Dispose();
            }
        }
    }
}
