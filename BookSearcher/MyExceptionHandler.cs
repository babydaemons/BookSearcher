using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BookSearcherApp
{
    internal class MyExceptionHandler
    {
        // ユーザー・フレンドリなダイアログを表示するメソッド
        public static void Show(Exception ex)
        {
            var path = "BookSearcher-" + DateTime.Now.ToString("yyyyMMddHHmm") + ".log";

            var message =
                "ご迷惑をお掛けします。内部エラーが発生しました。\n" +
                "ログファイル「" + path + "」をお送りください。\n\n" +
                "【エラー内容】\n" + ex.Message + "\n\n" +
                "【スタックトレース】\n" + ex.StackTrace;

            using (var writer = new StreamWriter(path)) { writer.WriteLine(message); }

            MessageBox.Show(message, "内部エラーが発生しました");
        }

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Show(e.Exception);
        }
    }
}
