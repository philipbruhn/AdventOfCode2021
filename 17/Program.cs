using System;
using System.IO;

namespace _17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Day17.PartOne(File.ReadAllText("input.txt"))}");
            Console.WriteLine($"{Day17.PartTwo(File.ReadAllText("input.txt"))}");
        }
    }
}
