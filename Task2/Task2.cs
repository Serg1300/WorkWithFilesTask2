using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Task2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки");
            string path = Console.ReadLine();
            var di = new DirectoryInfo(path);
            if (di.Exists)
            {
                try
                {
                    Console.WriteLine(di.Name + $"- {DirSize(di)}");

                }
                catch (Exception ex)
                { 
                    Console.WriteLine(di.Name + $"- Не удалось рассчитать размер:{ex.Message}"); 
                }

            }
            else { Console.WriteLine("Такой папки нет");}
        }

        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            foreach (FileInfo fi in d.GetFiles())
            {
                size += fi.Length;
            }
            foreach (DirectoryInfo fi in d.GetDirectories())
            {
                size += DirSize(fi);
            }
            return size;
        }
    }
}
