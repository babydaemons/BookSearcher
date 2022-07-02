using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearcherLocker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Lock Target File: ");
            var path = Console.ReadLine();
            using (var file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                Console.Write("Enter To Exit: ");
                _ = Console.ReadLine();
            }
        }
    }
}
