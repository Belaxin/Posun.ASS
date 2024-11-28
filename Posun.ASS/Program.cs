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
            Console.WriteLine("Zadajte nazov suboru");
            string nazovSuboru = Console.ReadLine();
            StreamWriter sw = new StreamWriter($"..\\..\\Assets\\{nazovSuboru}.ASS");
            StreamReader sr = new StreamReader("..\\..\\Assets\\Titulky.ASS");
            // Skips first line
            sw.WriteLine(sr.ReadLine());
            while (true)
            {
                String line = sr.ReadLine();
                if (line == null) break;
                String[] lineSplit = line.Split(',');
                
                // startTimes
                Console.WriteLine("Cas start : " + lineSplit[1]);
                Console.WriteLine("O kolko by ste chceli posunut zaciatok (h:m:s.ms)");
                String[] startTimesInput = Console.ReadLine().Split(':');
                String[] startTimesLoaded = lineSplit[1].Split(':');
                int newStartHour = Convert.ToInt32(startTimesLoaded[0]) + Convert.ToInt32(startTimesInput[0]);
                int newStartMinute = Convert.ToInt32(startTimesLoaded[1]) + Convert.ToInt32(startTimesInput[1]);
                float newStartSecMil = float.Parse(startTimesLoaded[2]) + float.Parse(startTimesInput[2]);
                // if secs >= 60 convert
                while (newStartSecMil >= (float)60) { newStartMinute++; newStartSecMil -= (float)60; }
                // if mins >= 60 convert
                while (newStartMinute >= 60) { newStartHour++; newStartMinute -= 60; }
                Console.WriteLine("----------");
                
                // endTimes
                Console.WriteLine("Cas end : " + lineSplit[2]);
                Console.WriteLine("O kolko by ste chceli posunut koniec (h:m:s.ms)");
                String[] endTimesInput = Console.ReadLine().Split(':');
                String[] endTimesLoaded = lineSplit[2].Split(':');
                int newEndHour = Convert.ToInt32(endTimesLoaded[0]) + Convert.ToInt32(endTimesInput[0]);
                int newEndMinute = Convert.ToInt32(endTimesLoaded[1]) + Convert.ToInt32(endTimesInput[1]);
                float newEndSecMil = float.Parse(endTimesLoaded[2]) + float.Parse(endTimesInput[2]);
                // if secs >= 60 convert
                while (newEndSecMil >= (float)60) { newEndMinute++; newEndSecMil -= (float)60; }
                // if mins >= 60 convert
                while (newEndMinute >= 60) { newEndHour++; newEndMinute -= 60; }
                
                // Parse int to string
                // format is for going from t to tt
                String newStartTime = string.Format("{0:00}:{1:00}:{2:00.00}", newStartHour, newStartMinute, newStartSecMil);
                String newEndTime = string.Format("{0:00}:{1:00}:{2:00.00}", newEndHour, newEndMinute, newEndSecMil);
                // Connect strings
                string newLine = lineSplit[0] ;
                newLine += "," + newStartTime;
                newLine += "," + newEndTime;
                for (int i = 3; i < lineSplit.Length; i++)
                {
                    newLine += "," + lineSplit[i];
                }
                sw.WriteLine(newLine);
                sw.Flush();
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("");
            }
            // Output of the text into console
            sw.Close();
            StreamReader outputSr = new StreamReader($"..\\..\\Assets\\{nazovSuboru}.ASS");
            while (true)
            {
                string outputChangedLine = outputSr.ReadLine();
                if (outputChangedLine == null) break;
                Console.WriteLine(outputChangedLine);
            }
        }
    }
}
