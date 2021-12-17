using System;
using System.IO;

namespace _18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Day18.PartOne(File.ReadAllText("input.txt"))}");
            Console.WriteLine($"{Day18.PartTwo(File.ReadAllText("input.txt"))}");
        }
    }
}
