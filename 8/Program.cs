using System;
using System.IO;

namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Day8.PartOne(File.ReadAllLines(@"input.txt"))}");
            Console.WriteLine($"{Day8.PartTwo(File.ReadAllLines(@"input.txt"))}");
        }
    }
}
