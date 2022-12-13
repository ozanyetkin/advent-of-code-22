using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day3
    {
        static string[] DataReader()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day3.txt");

            return lines;
        }

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        static int FindLetterIndex(char letter)
        {
            int index = 0;

            if (char.IsLower(letter))
            {
                index = (int)letter % 32;
            }
            else
            {
                index = ((int)letter % 32) + 26;
            }

            return index;
        }

        public static void Part1()
        {
            string[] lines = DataReader();

            int indexTotal = 0;

            foreach (string line in lines)
            {
                string[] compartments = Split(line, line.Length / 2).ToArray();

                var commonLetter = compartments[0].Intersect(compartments[1]);

                foreach (var letter in commonLetter)
                {
                    indexTotal += FindLetterIndex(letter);
                }
            }

            Console.WriteLine(indexTotal.ToString());
        }

        public static void Part2()
        {
            string[] lines = DataReader();
            int indexTotal = 0;

            IEnumerable<string[]> chunks = lines.Chunk(lines.Length / 2);

            foreach (string[] bags in chunks)
            {
                string currentBag = bags[0];
                char mostCommonLetter = " "[0];

                foreach (string bag in bags)
                {
                    foreach (var letter in currentBag.Intersect(bag))
                    {
                        mostCommonLetter = letter;
                    }

                    currentBag = bag;
                    indexTotal += FindLetterIndex(mostCommonLetter);
                }

                // Console.WriteLine("\n");
                Console.WriteLine(indexTotal.ToString());
            }
        }
    }
}
