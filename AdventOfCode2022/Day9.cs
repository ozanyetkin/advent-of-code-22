using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day9
    {
        static string[] DataReader()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day9.txt");

            return lines;
        }

        static List<(string, int)> DataParser(string[] data)
        {
            List<(string, int)> movesList = new List<(string, int)>();

            foreach (string line in data)
            {
                string direction = line.Split(' ')[0];
                int amount = int.Parse(line.Split(' ')[1]);

                movesList.Add((direction, amount));
            }

            return movesList;
        }

        static bool CheckAlignment((int, int) headPosition, (int, int) tailPosition)
        {
            if (headPosition.Item1 == tailPosition.Item1 | headPosition.Item2 == tailPosition.Item2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static (int, int) MoveTail((int, int) headPosition, (int, int) tailPosition)
        {
            if (CheckAlignment(headPosition, tailPosition))
            {
                double distance = Math.Sqrt(Math.Pow(headPosition.Item1 - tailPosition.Item1, 2) + Math.Pow(headPosition.Item2 - tailPosition.Item2, 2));

                if (distance > 1)
                {
                    return headPosition;
                }
            }

            return tailPosition;
        }

        public static void Part1()
        {
            string[] data = DataReader();

            (int, int) startHead = (0, 0);
            Tuple<int, int> startTail = Tuple.Create(0, 0);
            List<(string, int)> movesList = DataParser(data);

            var directionDict = new Dictionary<string, (int, int)>
            {
                ["U"] = (-1, 0),
                ["R"] = (0, 1),
                ["D"] = (1, 0),
                ["L"] = (0, -1)
            };

            foreach ((string, int) move in movesList)
            {
                for (int i = 0; i < move.Item2; i++)
                {
                    startHead.Item1 += directionDict[move.Item1].Item1;
                    startHead.Item2 += directionDict[move.Item1].Item2;

                    Console.WriteLine(startHead);
                }
            }
        }
    }
}
