using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day2
    {

        public static string[] DataReader()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day2.txt");

            return lines;
        }

        public static void Part1()
        {
            string[] lines = DataReader();
            int totalPoints = 0;

            foreach (string line in lines)
            {
                int turnPoints = 0;
                int winPoints = 0;

                string opponentMove = line.Split(" ")[0];
                string myMove = line.Split(" ")[1];

                if (opponentMove == "A")
                {
                    if (myMove == "X")
                    {
                        winPoints += 3;
                        turnPoints += 1;
                    }
                    else if (myMove == "Y")
                    {
                        winPoints += 6;
                        turnPoints += 2;
                    }
                    else if (myMove == "Z")
                    {
                        winPoints += 0;
                        turnPoints += 3;
                    }
                }
                else if (opponentMove == "B")
                {
                    if (myMove == "X")
                    {
                        winPoints += 0;
                        turnPoints += 1;
                    }
                    else if (myMove == "Y")
                    {
                        winPoints += 3;
                        turnPoints += 2;
                    }
                    else if (myMove == "Z")
                    {
                        winPoints += 6;
                        turnPoints += 3;
                    }
                }
                else if (opponentMove == "C")
                {
                    if (myMove == "X")
                    {
                        winPoints += 6;
                        turnPoints += 1;
                    }
                    else if (myMove == "Y")
                    {
                        winPoints += 0;
                        turnPoints += 2;
                    }
                    else if (myMove == "Z")
                    {
                        winPoints += 3;
                        turnPoints += 3;
                    }
                }

                // Console.WriteLine(turnPoints);
                // Console.WriteLine(winPoints);

                totalPoints += turnPoints + winPoints;

                // Console.WriteLine(totalPoints);
            }

            Console.WriteLine(totalPoints);
        }

        public static void Part2()
        {
            string[] lines = DataReader();
            int totalPoints = 0;

            foreach (string line in lines)
            {
                string opponentMove = line.Split(' ')[0];
                string turnState = line.Split(" ")[1];

                int turnPoints = 0;
                int winPoints = 0;

                if (opponentMove == "A")
                {
                    if (turnState == "X")
                    {
                        winPoints += 0;
                        turnPoints += 3;
                    }
                    else if (turnState == "Y")
                    {
                        winPoints += 3;
                        turnPoints += 1;
                    }
                    else if (turnState == "Z")
                    {
                        winPoints += 6;
                        turnPoints += 2;
                    }
                }

                else if (opponentMove == "B")
                {
                    if (turnState == "X")
                    {
                        winPoints += 0;
                        turnPoints += 1;
                    }
                    else if (turnState == "Y")
                    {
                        winPoints += 3;
                        turnPoints += 2;
                    }
                    else if (turnState == "Z")
                    {
                        winPoints += 6;
                        turnPoints += 3;
                    }
                }

                else if (opponentMove == "C")
                {
                    if (turnState == "X")
                    {
                        winPoints += 0;
                        turnPoints += 2;
                    }
                    else if (turnState == "Y")
                    {
                        winPoints += 3;
                        turnPoints += 3;
                    }
                    else if (turnState == "Z")
                    {
                        winPoints += 6;
                        turnPoints += 1;
                    }
                }

                totalPoints += turnPoints + winPoints;
            }

            Console.WriteLine(totalPoints);
        }
    }
}
