using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day6
    {
        static string DataReader()
        {
            string line = System.IO.File.ReadAllText(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day6.txt");

            return line;
        }

        public static void Part1()
        {
            string datastream = DataReader();
            string last4 = "";
            int processed = 0;

            foreach (char data in datastream)
            {
                bool allUnique = false;

                // Console.WriteLine(last4);
                // Console.WriteLine(data);

                if (last4.Length == 4)
                {
                    // Console.WriteLine(last4.Substring(1));

                    last4 = last4.Substring(1, 3) + data;

                    if (last4.Distinct().Count() == last4.Length)
                    {
                        allUnique = true;
                    }
                }
                else
                {
                    last4 += data;
                }

                // Console.WriteLine(allUnique);

                processed++;

                if (allUnique)
                {
                    break;
                }
            }

            Console.WriteLine(processed);
        }

        public static void Part2()
        {
            string datastream = DataReader();
            string last4 = "";
            int markerDistance = 14;
            int processed = 0;

            foreach (char data in datastream)
            {
                bool allUnique = false;

                // Console.WriteLine(last4);
                // Console.WriteLine(data);

                if (last4.Length == markerDistance)
                {
                    // Console.WriteLine(last4.Substring(1));

                    last4 = last4.Substring(1, markerDistance - 1) + data;

                    if (last4.Distinct().Count() == last4.Length)
                    {
                        allUnique = true;
                    }
                }
                else
                {
                    last4 += data;
                }

                // Console.WriteLine(allUnique);

                processed++;

                if (allUnique)
                {
                    break;
                }
            }

            Console.WriteLine(processed);
        }
    }
}
