using System;
using System.IO;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Day12.PartOne(File.ReadAllLines("input.txt"))}");
            Console.WriteLine($"{Day12.PartTwo(File.ReadAllLines("input.txt"))}");
        }
    }
}
