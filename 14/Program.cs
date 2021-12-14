using System;
using System.IO;

namespace _14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Day14.PartOne(File.ReadAllLines("input.txt"))}");
            Console.WriteLine($"{Day14.PartTwo(File.ReadAllLines("input.txt"))}");
        }
    }
}
