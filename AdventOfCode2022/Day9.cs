using System;
using System.Collections;
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

        /*
        int Visited(int numberOfKnots)
        {
            HashSet<(int, int)> visited = new();
            var knots = new (int X, int Y)[numberOfKnots];

            foreach (var move in input)
            {
                for (int i = 0; i < move.Distance; i++)
                {
                    knots[0] = move.Direction switch
                    {
                        'L' => (--knots[0].X, knots[0].Y),
                        'R' => (++knots[0].X, knots[0].Y),
                        'U' => (knots[0].X, ++knots[0].Y),
                        'D' => (knots[0].X, --knots[0].Y),
                        _ => throw new InvalidOperationException("we broke"),
                    };

                    for (int j = 1; j < numberOfKnots; j++)
                    {
                        var xDist = knots[j - 1].X - knots[j].X;
                        var yDist = knots[j - 1].Y - knots[j].Y;

                        if (Math.Abs(xDist) > 1 || Math.Abs(yDist) > 1)
                        {
                            knots[j].X += Math.Sign(xDist);
                            knots[j].Y += Math.Sign(yDist);
                        }
                    }

                    visited.Add(knots.Last());
                }
            }

            return visited.Count;
        }
        */

        public static void Part1()
        {
            string[] data = DataReader();

            (int, int) posHead = (0, 0);
            Tuple<int, int> posTail = Tuple.Create(0, 0);
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
                    posHead.Item1 += directionDict[move.Item1].Item1;
                    posHead.Item2 += directionDict[move.Item1].Item2;

                    // Console.WriteLine(posHead);
                }
            }

            var input = data.Select(x => new { Direction = x[0], Distance = int.Parse(x.Substring(2)) });

            int Visited(int numberOfKnots)
            {
                HashSet<(int, int)> visited = new();
                var knots = new (int X, int Y)[numberOfKnots];

                foreach (var move in input)
                {
                    for (int i = 0; i < move.Distance; i++)
                    {
                        knots[0] = move.Direction switch
                        {
                            'L' => (--knots[0].X, knots[0].Y),
                            'R' => (++knots[0].X, knots[0].Y),
                            'U' => (knots[0].X, ++knots[0].Y),
                            'D' => (knots[0].X, --knots[0].Y),
                            _ => throw new InvalidOperationException("we broke"),
                        };

                        for (int j = 1; j < numberOfKnots; j++)
                        {
                            var xDist = knots[j - 1].X - knots[j].X;
                            var yDist = knots[j - 1].Y - knots[j].Y;

                            if (Math.Abs(xDist) > 1 || Math.Abs(yDist) > 1)
                            {
                                knots[j].X += Math.Sign(xDist);
                                knots[j].Y += Math.Sign(yDist);
                            }
                        }

                        visited.Add(knots.Last());
                    }
                }

                return visited.Count;
            }

            Console.WriteLine(Visited(2));
        }

        public static void Part2()
        {
            string[] data = DataReader();
            var input = data.Select(x => new { Direction = x[0], Distance = int.Parse(x.Substring(2)) });

            int Visited(int numberOfKnots)
            {
                HashSet<(int, int)> visited = new();
                var knots = new (int X, int Y)[numberOfKnots];

                foreach (var move in input)
                {
                    for (int i = 0; i < move.Distance; i++)
                    {
                        knots[0] = move.Direction switch
                        {
                            'L' => (--knots[0].X, knots[0].Y),
                            'R' => (++knots[0].X, knots[0].Y),
                            'U' => (knots[0].X, ++knots[0].Y),
                            'D' => (knots[0].X, --knots[0].Y),
                            _ => throw new InvalidOperationException("we broke"),
                        };

                        for (int j = 1; j < numberOfKnots; j++)
                        {
                            var xDist = knots[j - 1].X - knots[j].X;
                            var yDist = knots[j - 1].Y - knots[j].Y;

                            if (Math.Abs(xDist) > 1 || Math.Abs(yDist) > 1)
                            {
                                knots[j].X += Math.Sign(xDist);
                                knots[j].Y += Math.Sign(yDist);
                            }
                        }

                        visited.Add(knots.Last());
                    }
                }

                return visited.Count;
            }

            Console.WriteLine(Visited(10));
        }
    }
}
