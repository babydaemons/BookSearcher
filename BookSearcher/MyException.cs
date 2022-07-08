using System;
using System.IO;
using System.Windows.Forms;

namespace BookSearcherApp
{
    internal class MyException : Exception
    {
        private readonly string caption;

        public MyException(string caption, string message) : base(message)
        {
            this.caption = caption;
            GC.Collect(0, GCCollectionMode.Forced);
        }

        public MyException(string caption, string path, Exception ex) : base(GetExceptionMessage(caption, path, ex), ex)
        {
            this.caption = caption;
            GC.Collect(0, GCCollectionMode.Forced);
        }

        private static string GetExceptionMessage(string caption, string path, Exception ex)
        {
            if (ex is FileNotFoundException)
            {
                return $"ファイルまたはフォルダが見つかりませんでした。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is DirectoryNotFoundException)
            {
                return $"ファイルまたはフォルダが見つかりませんでした。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is DriveNotFoundException)
            {
                return $"ディスクドライブが見つかりませんでした。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is PathTooLongException)
            {
                return $"フォルダ名とファイル名を連結したファイルパスが長すぎます。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is UnauthorizedAccessException)
            {
                return $"読み書きする権限がありませんでした。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is IOException && (ex.HResult & 0x0000FFFF) == 32)
            {
                return $"共有違反です。他のアプリケーションで開いていないか確認してください。\n{path}\n\nエラー詳細：\n{ex.Message}";
            }
            else if (ex is IOException && (ex.HResult & 0x0000FFFF) == 80)
            {
                return $"指定された場所には既にファイルまたはフォルダが存在します。\n{path}\n\nエラー詳細：\n{ex.Message}";
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
            if (InnerException == null)
            {
                MessageBox.Show(Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
