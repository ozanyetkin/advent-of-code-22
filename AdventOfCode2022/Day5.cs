using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day5
    {
        static string[] DataReader()
        {
            string[] lines = File.ReadAllText(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day5.txt").Split("\r\n\r\n");

            return lines;
        }

        /*
        static Dictionary<int, Stack<string>> ParseStacks(string input)
        {
            var stacks = new Dictionary<int, Stack<string>>();
            var re = new Regex(@"^(.(.).\s?){9}$");

            var lines = input
                .Split("\r\n")
                .Reverse()
                .ToArray();

            foreach (Capture capture in re.Match(lines.First()).Groups[2].Captures)
            {
                stacks[int.Parse(capture.Value)] = new Stack<string>();
            }

            foreach (var line in lines.Skip(1))
            {
                var captures = re.Match(line).Groups[2].Captures;
                for (var i = 0; i < captures.Count; i++)
                {
                    if (!String.IsNullOrWhiteSpace(captures[i].Value))
                    {
                        stacks[i + 1].Push(captures[i].Value);
                    }
                }
            }

            return stacks;
        }
        */

        static Dictionary<int, Stack<string>> PopulateCrateStacks(IReadOnlyList<int> labelPositions, IReadOnlyList<string> supplyCratesInput)
        {
            var crateStacks = new Dictionary<int, Stack<string>>();
            for (var i = 0; i < labelPositions.Count; i++) crateStacks.Add(i + 1, new Stack<string>());

            for (var i = 0; i < labelPositions.Count; i++)
            {
                var alphabetPosition = labelPositions[i];
                // for each crate row, except the last one, add crate labels to stack
                for (var j = supplyCratesInput.Count - 1; j >= 0; j--)
                {
                    var crateRow = supplyCratesInput[j];
                    var crateLabel = crateRow[alphabetPosition];
                    if (char.IsLetter(crateLabel)) crateStacks[i + 1].Push(crateLabel.ToString());
                }
            }

            return crateStacks;
        }

        static List<int> GetLabelPositions(string row)
        {
            var positions = new List<int>();
            row
                .Select((c, idx) => new { character = c, index = idx })
                .ToList()
                .ForEach(c =>
                {
                    if (char.IsDigit(c.character)) positions.Add(c.index);
                });
            return positions;
        }

        public static void Part1()
        {
            string[] lines = DataReader();
            // Console.WriteLine(lines[0]);
            // Dictionary<int, Stack<string>> parsedStacks = ParseStacks(lines[0]);

            var moveInstructions = lines[1].Split(Environment.NewLine);
            var crateRows = lines[0].Split(Environment.NewLine);
            var crateNumberRow = crateRows.Last();
            var crateLabelPositions = GetLabelPositions(crateNumberRow);
            Dictionary<int, Stack<string>> crateStacks = PopulateCrateStacks(crateLabelPositions, crateRows);

            foreach (KeyValuePair<int, Stack<string>> entry in crateStacks)
            {
                // Console.WriteLine(entry);
                Console.WriteLine($"{entry.Key}");

                foreach (string item in entry.Value)
                {
                    Console.WriteLine(item);
                }
            }

            /*
            foreach (string line in lines)
            {
                bool stackFinished = false;

                if (line == "")
                {
                    stackFinished = true;
                }

                if (stackFinished)
                {

                }
                else
                {
                    int containerSeparator = 0;
                    IDictionary<int, string> containerDictionary = new Dictionary<int, string>();

                    foreach (char c in line)
                    {
                        if (c == ' ')
                        {
                            containerSeparator++;
                        }
                        else if (c == '[' | c == ']')
                        {
                            containerSeparator = 0;
                        }
                        else
                        {
                            if (containerDictionary.ContainsKey(containerSeparator / 3))
                            {
                                containerDictionary[containerSeparator / 3] += c.ToString();
                            }
                            else
                            {
                                containerDictionary.Add(containerSeparator / 3, c.ToString());
                            }
                        }
                    }

                    Console.WriteLine(containerSeparator);

                    foreach (KeyValuePair<int, string> entry in containerDictionary)
                    {
                        Console.WriteLine($"{entry.Key}: {entry.Value}");
                    }

                }
            }
            */
        }
    }
}
