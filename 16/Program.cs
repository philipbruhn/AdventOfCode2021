using System;
using System.IO;

namespace _16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Day16.PartOne(File.ReadAllText("input.txt").Replace("\n", ""))}");
            Console.WriteLine($"{Day16.PartTwo()}");
        }
    }
}
