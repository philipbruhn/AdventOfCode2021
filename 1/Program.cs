using System;
using System.IO;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            Console.WriteLine($"{Day1.PartOne(input)}");
            Console.WriteLine($"{Day1.PartTwo(input)}");
        }
    }
}
