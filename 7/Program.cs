using System;
using System.IO;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine($"{Day7.PartOne(File.ReadAllText(@"input.txt"))}");
            Console.WriteLine($"{Day7.PartTwo(File.ReadAllText(@"input.txt"))}");
        }
    }
}
