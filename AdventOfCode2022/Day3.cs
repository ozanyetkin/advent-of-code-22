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

        /*
        int getPriority(char itemType) => Char.IsUpper(itemType) switch
        {
            true => (int)itemType - 38,
            false => (int)itemType - 96,
        };
        */

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

            IEnumerable<string[]> chunks = lines.Chunk(3);

            foreach (string[] bags in chunks)
            {
                string currentBag = bags[0];
                // Console.WriteLine($"Current bag is: {currentBag}");
                char mostCommonLetter = " "[0];

                foreach (string bag in bags)
                {
                    foreach (var letter in currentBag.Intersect(bag))
                    {
                        mostCommonLetter = letter;
                        // Console.WriteLine($"Intersected letter is: {letter}");
                    }

                    currentBag = bag;
                    // Console.WriteLine(currentBag);
                }

                // Console.WriteLine($"Most common letter is: {mostCommonLetter}");
                indexTotal += FindLetterIndex(mostCommonLetter);

            }

            // Console.WriteLine(indexTotal.ToString());


            int p2Sum = lines.Chunk(3).Select(ls =>
            {
                var first = ls[0];
                var second = ls[1];
                var third = ls[2];

                return first.Intersect(second).Intersect(third).Select(c => Char.IsUpper(c) ? c - 38 : c - 96).Sum();

            }).Sum();

            Console.WriteLine(p2Sum.ToString());
        }
    }
}
