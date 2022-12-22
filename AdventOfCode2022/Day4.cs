using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day4
    {
        static string[] DataReader()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day4.txt");

            return lines;
        }

        static (int, int, int, int) DataParser(string line)
        {
            string[] ranges = line.Split(',');

            int firstStart = Int32.Parse(ranges[0].Split('-')[0]);
            int firstEnd = Int32.Parse(ranges[0].Split('-')[1]);

            int secondStart = Int32.Parse(ranges[1].Split('-')[0]);
            int secondEnd = Int32.Parse(ranges[1].Split('-')[1]);

            return (firstStart, firstEnd, secondStart, secondEnd);
        }

        public static void Part1()
        {
            string[] lines = DataReader();

            int fullyContained = 0;

            foreach (string line in lines)
            {
                var (firstStart, firstEnd, secondStart, secondEnd) = DataParser(line);

                if (firstStart >= secondStart && firstEnd <= secondEnd)
                {
                    fullyContained++;
                }
                else if (secondStart >= firstStart && secondEnd <= firstEnd)
                {
                    fullyContained++;
                }
            }

            Console.WriteLine(fullyContained);
        }

        public static void Part2()
        {
            string[] lines = DataReader();

            int overlapWork = 0;

            foreach (string line in lines)
            {
                var (firstStart, firstEnd, secondStart, secondEnd) = DataParser(line);
                bool overlapped = false;

                for (int i = firstStart; i <= firstEnd; i++)
                {
                    for (int j = secondStart; j <= secondEnd; j++)
                    {
                        // Console.WriteLine($"{i}, {j}");

                        if (i == j)
                        {
                            // Console.WriteLine("Overlap detected");
                            overlapped = true;
                        }
                    }
                }

                if (overlapped)
                {
                    overlapWork++;
                }
            }

            Console.WriteLine(overlapWork);
        }
    }
}
