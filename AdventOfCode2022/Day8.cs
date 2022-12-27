using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    static internal class Day8
    {
        public static void GetGridMetadata(this ReadOnlySpan<char> input, out int rowSize, out int rowSkip)
        {
            // Row size == index of the first newline from the start of the input
            rowSize = input.IndexOfAny('\r', '\n');
            if (rowSize < 1) throw new ArgumentException("First line does not have any content", nameof(input));

            // Newline size == distance between the first newline character and the next non-newline character
            if (input[rowSize + 1] is not '\r' or '\n') rowSkip = rowSize + 1;
            else if (input[rowSize + 2] is not '\r' or '\n') rowSkip = rowSize + 2;
            else throw new ArgumentException("Newline is not \\r\\n (CRLF) or \\n (LF)", nameof(input));
        }

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

        public static int ScenicScoreUp(int i, int j, int startH, int[,] map, int scenicScore=0)
        {
            if (i == 0)
            {
                return scenicScore;
            }
            else
            {
                try
                {
                    if (map[i - 1, j] < startH)
                    {
                        scenicScore++;
                        return ScenicScoreUp(i - 1, j, startH, map, scenicScore);
                    }
                    else
                    {
                        return scenicScore;
                    }
                }
                catch
                {
                    return scenicScore;
                }
            }
        }

        public static int ScenicScoreDown(int i, int j, int startH, int[,] map, int scenicScore=0)
        {
            if (i == map.Length - 1)
            {
                return scenicScore;
            }
            else
            {
                try
                {
                    if (map[i + 1, j] < startH)
                    {
                        scenicScore++;
                        return ScenicScoreDown(i + 1, j, startH, map, scenicScore);
                    }
                    else
                    {
                        return scenicScore;
                    }
                }
                catch
                {
                    return scenicScore;
                }
            }
        }

        public static int ScenicScoreLeft(int i, int j, int startH, int[,] map, int scenicScore=0)
        {
            if (j == 0)
            {
                return scenicScore;
            }
            else
            {
                try
                {
                    if (map[i, j - 1] < startH)
                    {
                        scenicScore++;
                        return ScenicScoreLeft(i, j - 1, startH, map, scenicScore);
                    }
                    else
                    {
                        return scenicScore;
                    }
                }
                catch
                {
                    return scenicScore;
                }
            }
        }

        public static int ScenicScoreRight(int i, int j, int startH, int[,] map, int scenicScore=0)
        {
            if (j == map.Length - 1)
            {
                return scenicScore;
            }
            else
            {
                try
                {
                    if (map[i, j + 1] < startH)
                    {
                        scenicScore++;
                        return ScenicScoreRight(i, j + 1, startH, map, scenicScore);
                    }
                    else
                    {
                        return scenicScore;
                    }
                }
                catch
                {
                    return scenicScore;
                }
            }
        }

        private static int ComputeScenicValue(int row, int col, ReadOnlySpan<char> input, int rowSkip, int gridSize)
        {
            var tree = ReadTree(row, col, input, rowSkip);

            // MULTIPLY, not add!!
            return
                // Top
                CountVisibleTreesFrom(tree, row, col, 0, -1, input, rowSkip, gridSize) *

                // Right
                CountVisibleTreesFrom(tree, row, col, 1, 0, input, rowSkip, gridSize) *

                // Bottom
                CountVisibleTreesFrom(tree, row, col, 0, 1, input, rowSkip, gridSize) *

                // Left
                CountVisibleTreesFrom(tree, row, col, -1, 0, input, rowSkip, gridSize);
        }

        static char ReadTree(int row, int col, ReadOnlySpan<char> input, int rowSkip)
        {
            var index = (row * rowSkip) + col;
            return input[index];
        }

        private static int CountVisibleTreesFrom(char fromTree, int row, int col, int rowIncrement, int colIncrement, ReadOnlySpan<char> input, int rowSkip, int gridSize)
        {
            var count = 0;

            do
            {
                row += rowIncrement;
                col += colIncrement;

                // Need to break early to avoid counting outside the edges
                if (row < 0 || row >= gridSize || col < 0 || col >= gridSize)
                {
                    break;
                }

                count++;
            } while (ReadTree(row, col, input, rowSkip) < fromTree);

            return count;
        }

        static IEnumerable<(int dx, int dy)> EnumDirections()
        {
            yield return (0, -1);
            yield return (-1, 0);
            yield return (0, 1);
            yield return (1, 0);
        }
        static IEnumerable<(int x, int y)> EnumPositions((int x, int y) start, (int x, int y) dir, int size)
            => from i in Enumerable.Range(0, size)
            let x = start.x + (i * dir.x)
            let y = start.y + (i * dir.y)
            where x >= 0 && x < size && y >= 0 && y < size
            select (x, y);

        static int GetViewDistance(int[][] map, (int x, int y) start, (int x, int y) dir, int size)
        {
            var height = map[start.y][start.x];
            var count = 0;
            foreach (var (x, y) in EnumPositions(start, dir, size).Skip(1))
            {
                ++count;
                if (map[y][x] >= height)
                    break;
            }

            return count;
        }

        static int GetScenicScore(int[][] map, (int x, int y) start, int size) 
            => EnumDirections().Select(d => GetViewDistance(map, start, d, size))
            .Aggregate(1, (a, n) => a * n);


        public static void Part2()
        {
            string[] data = DataReader();
            int[,] treeMap = MapGenerator(data);

            var map = System.IO.File.ReadLines(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day8.txt")
                .Select(line => line.Select(ch => ch - '0').ToArray())
                .ToArray();

            /*
            int scenicScore = 1;
            int maxScenicScore = 0;

            for (int i = 0; i < treeMap.GetLength(0); i++)
            {
                for (int j = 0; j < treeMap.GetLength(1); j++)
                {
                    scenicScore *= ScenicScoreUp(i, j, treeMap[i, j], treeMap);
                    scenicScore *= ScenicScoreDown(i, j, treeMap[i, j], treeMap);
                    scenicScore *= ScenicScoreLeft(i, j, treeMap[i, j], treeMap);
                    scenicScore *= ScenicScoreRight(i, j, treeMap[i, j], treeMap);

                    Console.WriteLine(scenicScore);

                    if (scenicScore > maxScenicScore)
                    {
                        maxScenicScore = scenicScore;
                    }
                }
            }
            */

            /*
            var maxScenic = 0;

            string inputFile = "C:\\Users\\Yetkin\\OneDrive\\Desktop\\Projects\\AdventOfCode2022\\AdventOfCode2022\\Day8.txt";
            var input = inputFile.AsSpan().TrimEnd();

            // Map the input to be indexed as a grid
            input.GetGridMetadata(out var gridSize, out var rowSkip);

            // Brute force this thing:    
            // Check each tree against each other tree in O(n^2) worst-case time!
            for (var row = 0; row < treeMap.GetLength(0); row++)
            {
                for (var col = 0; col < treeMap.GetLength(1); col++)
                {
                    var scenicValue = ComputeScenicValue(row, col, input, rowSkip, gridSize);
                    if (scenicValue > maxScenic)
                    {
                        maxScenic = scenicValue;
                    }
                }
            }

            Console.WriteLine(maxScenic);
            */

            var size = map.Length;
            var viewDistances = from x in Enumerable.Range(0, size)
                                from y in Enumerable.Range(0, size)
                                select GetScenicScore(map, (x, y), size);

            Console.WriteLine(viewDistances.Max());
        }
    }
}
