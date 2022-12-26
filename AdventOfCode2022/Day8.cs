using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day8
    {
        static string[] DataReader()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day8.txt");

            return lines;
        }

        public static int[,] MapGenerator(string[] data)
        {
            int[,] treeMap = new int[data.Length, data[0].Length];

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[0].Length; j++)
                {
                    // Console.WriteLine(data[i][j]);
                    treeMap[i, j] = int.Parse(data[i][j].ToString());
                }
            }

            return treeMap;
        }

        public static bool CheckVisibilityTop(int i, int j, int startH, int[,] map)
        {
            if (i == 0)
            {
                return true;
            }
            else
            {
                try
                {
                    if (map[i - 1, j] < startH)
                    {
                        return CheckVisibilityTop(i - 1, j, startH, map);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return true;
                }
            }
        }

        public static bool CheckVisibilityDown(int i, int j, int startH, int[,] map)
        {
            if (i == map.Length - 1)
            {
                return true;
            }
            else
            {
                try
                {
                    if (map[i + 1, j] < startH)
                    {
                        return CheckVisibilityDown(i + 1, j, startH, map);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return true;
                }
            }
        }

        public static bool CheckVisibilityLeft(int i, int j, int startH, int[,] map)
        {
            if (j == 0)
            {
                return true;
            }
            else
            {
                try
                {
                    if (map[i, j - 1] < startH)
                    {
                        return CheckVisibilityLeft(i, j - 1, startH, map);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return true;
                }
            }
        }

        public static bool CheckVisibilityRight(int i, int j, int startH, int[,] map)
        {
            if (j == map.Length - 1)
            {
                return true;
            }
            else
            {
                try
                {
                    if (map[i, j + 1] < startH)
                    {
                        return CheckVisibilityRight(i, j + 1, startH, map);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return true;
                }
            }
        }

        public static void Part1()
        {
            string[] data = DataReader();
            int[,] treeMap = MapGenerator(data);

            int visibleTrees = 0;

            for (int i = 0; i < treeMap.GetLength(0); i++)
            {
                for (int j = 0; j < treeMap.GetLength(1); j++)
                {
                    if (CheckVisibilityTop(i, j, treeMap[i, j], treeMap) |
                        CheckVisibilityDown(i, j, treeMap[i, j], treeMap) |
                        CheckVisibilityLeft(i, j, treeMap[i, j], treeMap) |
                        CheckVisibilityRight(i, j, treeMap[i, j], treeMap))
                    {
                        visibleTrees++;
                    }
                }
            }

            Console.WriteLine(visibleTrees);
        }
    }
}
