using System;
using System.IO;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            Console.WriteLine($"{Day9.PartOne(input)}");
            Console.WriteLine($"{Day9.PartTwo(input)}");
        }
    }
}
