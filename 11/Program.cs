using System;
using System.IO;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            Console.WriteLine($"{Day11.PartOne(input)}");
            Console.WriteLine($"{Day11.PartTwo(input)}");
        }
    }
}
