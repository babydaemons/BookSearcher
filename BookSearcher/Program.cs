using System;
using System.Threading;
using System.Windows.Forms;

namespace BookSearcherApp
{
    internal static class Program
    {
        public static bool Debugging { get; private set; } = false;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var value0 = int.Parse(args[0]);
            var value1 = int.Parse(args[1]);

            // ThreadExceptionイベント・ハンドラを登録する
            Application.ThreadException += new ThreadExceptionEventHandler(MyExceptionHandler.Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 1 && args[0] == "--debug")
            {
                Debugging = true;
            }

            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex) // for internal error handling
            {
                MyExceptionHandler.Show(ex);
            }
        }
    }
}
