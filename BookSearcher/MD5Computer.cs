using System;
using System.IO;
using System.Security.Cryptography;

namespace BookSearcher
{
    internal static class MD5Computer
    {
        private static readonly MD5 hash = MD5.Create();

        public static string Hash(string value)
        {
            char[] chars = value.ToCharArray();
            byte[] bytes = new byte[chars.Length * 2];
            int i = 0;
            foreach (char c in chars)
            {
                bytes[i++] = (byte)(0xff & (c >> 8));
                bytes[i++] = (byte)(0xff & c);
            }
            return BitConverter.ToString(hash.ComputeHash(bytes));
        }
    }
}
