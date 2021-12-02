using System;
using System.IO;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            #region Part One
            int horizontal = 0;
            int vertical = 0;
            foreach(var dir in input)
            {
                string[] dirParts = dir.Split(" ");
                switch (dirParts[0])
                {
                    case "forward":
                        horizontal += int.Parse(dirParts[1]);
                        break;
                    case "back":
                        horizontal -= int.Parse(dirParts[1]);
                        break;
                    case "up":
                        vertical -= int.Parse(dirParts[1]);
                        break;
                    case "down":
                        vertical += int.Parse(dirParts[1]);
                        break;
                }
            }
            Console.WriteLine($"{vertical * horizontal}");
            #endregion
            #region Part Two
            horizontal = 0;
            vertical = 0;
            int aim = 0;

            foreach (var dir in input)
            {
                string[] dirParts = dir.Split(" ");
                switch (dirParts[0])
                {
                    case "forward":
                        horizontal += int.Parse(dirParts[1]);
                        vertical += aim * int.Parse(dirParts[1]);
                        break;
                    case "back":
                        horizontal -= int.Parse(dirParts[1]);
                        vertical -= aim * int.Parse(dirParts[1]);
                        break;
                    case "up":
                        aim -= int.Parse(dirParts[1]);
                        break;
                    case "down":
                        aim += int.Parse(dirParts[1]);
                        break;
                }
            }
            Console.WriteLine($"{vertical * horizontal}");
            #endregion
        }
    }
}
