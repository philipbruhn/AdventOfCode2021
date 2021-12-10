using System;
using System.IO;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            Console.WriteLine($"{Day10.PartOne(input)}");
            Console.WriteLine($"{Day10.PartTwo(input)}");
        }
    }
}
