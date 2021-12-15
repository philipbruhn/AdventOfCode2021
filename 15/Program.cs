using System;
using System.IO;

namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Day15.PartOne(File.ReadAllLines("input.txt"))}");
            Console.WriteLine($"{Day15.PartTwo(File.ReadAllLines("input.txt"))}");
        }
    }
}
