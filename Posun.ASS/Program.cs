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
            //todo
            // Parse without ,
            // Save



            StreamReader sr = new StreamReader("..\\..\\Assets\\Titulky.ASS");
            sr.ReadLine();


            while (true)
            {
                String line = sr.ReadLine();
                if (line == null) break;
                String[] tmp = line.Split(',');


                //startTimes
                Console.WriteLine("Cas start : " + tmp[1]);
                Console.WriteLine("O kolko by ste chceli posunut zaciatok (hh:mm:ss.msms)");
                String[] startTimesInput = Console.ReadLine().Split(':');
                String[] startTimesLoaded = tmp[1].Split(':');



                int newStartHour = Convert.ToInt32(startTimesLoaded[0]) + Convert.ToInt32(startTimesInput[0]);
                int newStartMinute = Convert.ToInt32(startTimesLoaded[1]) + Convert.ToInt32(startTimesInput[1]);
                float newStartSecMil = float.Parse(startTimesLoaded[2]) + float.Parse(startTimesInput[2]);

                //endTimes
                Console.WriteLine("Cas end : " + tmp[2]);
                Console.WriteLine("O kolko by ste chceli posunut koniec (hh:mm:ss.msms)");
                String[] endTimesInput = Console.ReadLine().Split(':');
                String[] endTimesLoaded = tmp[2].Split(':');


                int newEndHour = Convert.ToInt32(endTimesLoaded[0]) + Convert.ToInt32(endTimesInput[0]);
                int newEndMinute = Convert.ToInt32(endTimesLoaded[1]) + Convert.ToInt32(endTimesInput[1]);
                float newEndSecMil = float.Parse(endTimesLoaded[2]) + float.Parse(endTimesInput[2]);

                // Parse int to string
                String newStartTime = newStartHour + ":" + newStartMinute + ":" + newStartSecMil;
                String newEndTime = newEndHour + ":" + newEndMinute + ":" + newEndSecMil;

                Console.WriteLine("Novy start time: " + newStartTime);
                Console.WriteLine("Novy end time: " + newEndTime);

            }
        }
    }
}
