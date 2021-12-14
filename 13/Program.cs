using System;
using System.IO;

namespace _13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Day13.PartOne(File.ReadAllLines("input.txt"))}\n");
            Day13.PartTwo(File.ReadAllLines("input.txt"));
        }
    }
}
