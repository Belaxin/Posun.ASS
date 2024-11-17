using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Posun.ASS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("..\\..\\Assets\\Titulky.ASS");
            sr.ReadLine();
            while (true)
            {
                String line = sr.ReadLine();
                if (line == null) break;
                String[] tmp = line.Split(',');
                Console.WriteLine(tmp[1]);
                Console.WriteLine(tmp[2]);
                Console.WriteLine("");
            }
        }
    }
}
