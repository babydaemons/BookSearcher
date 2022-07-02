using System;
using System.IO;
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

        public MyException(string caption, string path, Exception ex) : base()
        {
            this.caption = caption;

            if (ex is FileNotFoundException)
            {
                message = $"ファイルまたはフォルダが見つかりませんでした。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is DirectoryNotFoundException)
            {
                message = $"ファイルまたはフォルダが見つかりませんでした。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is DriveNotFoundException)
            {
                message = $"ディスクドライブが見つかりませんでした。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is PathTooLongException)
            {
                message = $"フォルダ名とファイル名を連結したファイルパスが長すぎます。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is UnauthorizedAccessException)
            {
                message = $"読み書きする権限がありませんでした。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is IOException && (ex.HResult & 0x0000FFFF) == 32)
            {
                message = $"共有違反です。他のアプリケーションで開いていないか確認してください。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is IOException && (ex.HResult & 0x0000FFFF) == 80)
            {
                message = $"指定された場所には既にファイルまたはフォルダが存在します。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is IOException)
            {
                throw new Exception($"[{caption}]ファイル入出力例外エラーが発生しました。\n{path}\n\nエラーコード：{ex.HResult & 0x0000FFFF}\nエラー詳細：\n{ex.Message}");
            }
            else if (ex is Exception)
            {
                throw new Exception($"[{caption}]例外エラーが発生しました。\n{path}\n\nエラーコード：{ex.HResult & 0x0000FFFF}\n例外種別：\n{ex.GetType().FullName}\nエラー詳細：\n{ex.Message}");
            }
            else
            {
                throw new Exception($"[{caption}]引数指定の内部エラーです。\n{path}\n\n引数種別：\n{ex.GetType().FullName}");
            }
        }

        public void Show()
        {
            MessageBox.Show(message, caption);
        }
    }
}
