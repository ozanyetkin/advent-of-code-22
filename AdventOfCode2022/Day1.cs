using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day1
    {
        public static void Part1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day1.txt");

            int maxCalorie = 0;
            int agentCalorie = 0;

            foreach (string line in lines)
            {
                if (line == "")
                {
                    agentCalorie = 0;
                }
                else
                {
                    agentCalorie += int.Parse(line);
                }

                if (agentCalorie > maxCalorie)
                {
                    maxCalorie = agentCalorie;
                }
            }

            Console.WriteLine(maxCalorie);
        }

        public static void Part2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day1.txt");

            List<int> caloriesList = new List<int>();
            int agentCalorie = 0;

            foreach (string line in lines)
            {
                if (line == "")
                {
                    agentCalorie = 0;
                }
                else
                {
                    agentCalorie += int.Parse(line);
                }
                caloriesList.Add(agentCalorie);
            }

            caloriesList.Sort();
            caloriesList.Reverse();

            Console.WriteLine(caloriesList[0] + caloriesList[1] + caloriesList[2]);
        }
    }
}
