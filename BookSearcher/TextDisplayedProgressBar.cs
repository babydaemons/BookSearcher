using System.Diagnostics;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public class TextDisplayedProgressBar : ProgressBar
    {
        // https://dobon.net/vb/dotnet/control/pbshowtext.html
        private const int WM_PAINT = 0x000F;
        private Stopwatch StopWatch;

        public void Start()
        {
            Value = 0;
            StopWatch = Stopwatch.StartNew();
        }

        public void Stop()
        {
            Value = 100;
            StopWatch.Stop();
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT && StopWatch != null)
            {
                var text = StopWatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");

                // 文字列を描画する
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine;
                Graphics g = CreateGraphics();
                TextRenderer.DrawText(g, text, Font, ClientRectangle, SystemColors.ControlText, flags);
                g.Dispose();
            }
        }
    }
}
