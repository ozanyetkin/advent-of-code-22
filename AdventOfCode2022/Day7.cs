using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventOfCode2022
{
    record Child(string Name);
    record File(string Name, long Size) : Child(Name);
    record Directory(string Name, Directory Parent, Dictionary<string, Child> Children) : Child(Name);

    internal class Day7
    {
        static string[] DataReader()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Yetkin\OneDrive\Desktop\Projects\AdventOfCode2022\AdventOfCode2022\Day7.txt");

            return lines;
        }

        static void parseData(Directory root, string[] input)
        {
            var cd = root;
            foreach (var line in input)
            {
                if (line.StartsWith(@"$ cd /"))
                {
                    cd = root;
                }
                else if (line.StartsWith(@"$ cd .."))
                {
                    cd = cd.Parent;
                }
                else if (line.StartsWith(@"$ cd "))
                {
                    var name = line.Split(" ").Last().Trim();
                    cd = (Directory)cd.Children[name];
                }
                else if (line.StartsWith("dir"))
                {
                    var name = line.Split(" ").Last().Trim();
                    cd.Children[name] = new Directory(name, cd, new Dictionary<string, Child>());
                }
                else if (Char.IsNumber(line[0]))
                {
                    var split = line.Split(" ");
                    var size = long.Parse(split.First().Trim());
                    var name = split.Last().Trim();
                    cd.Children[name] = new File(name, size);
                }
            }
        }

        static void calculateDirectorySizes(Directory dir, Dictionary<Directory, long> sizes)
        {
            long size = 0;
            foreach (var child in dir.Children)
            {
                if (child.Value is File f)
                {
                    size += f.Size;
                }
                else if (child.Value is Directory d)
                {
                    calculateDirectorySizes(d, sizes);
                    size += sizes[d];
                }
            }
            sizes[dir] = size;
        }

        public static void Part1()
        {
            string[] lines = DataReader();

            var root = new Directory("/", null, new Dictionary<string, Child>());
            parseData(root, lines);

            var sizes = new Dictionary<Directory, long>();
            calculateDirectorySizes(root, sizes);

            Console.WriteLine(sizes.Values.Where(size => size <= 100000).Sum());
        }

        public static void Part2()
        {
            string[] lines = DataReader();

            var root = new Directory("/", null, new Dictionary<string, Child>());
            parseData(root, lines);

            var sizes = new Dictionary<Directory, long>();
            calculateDirectorySizes(root, sizes);

            Console.WriteLine(sizes.Values.Where(size => size >= sizes[root] - 40000000).Min());
        }
    }
}
