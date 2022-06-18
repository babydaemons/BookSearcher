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
        private FileIO fileIO;

        public void Start(FileIO fileIO)
        {
            Value = 0;
            this.fileIO = fileIO;
        }

        public void Stop()
        {
            Value = MAX_VALUE;
            Refresh();
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                DrawText();
            }
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void DrawText()
        {
            // 文字列を描画する
            Graphics g = CreateGraphics();
            TextRenderer.DrawText(g, Text, Font, ClientRectangle, SystemColors.ControlText, textFormatFlags);
            g.Dispose();
        }
    }
}
