using System;
using System.IO;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            int[] inputNum = Array.ConvertAll(input, s => int.Parse(s));

            #region Part One
            int numberOfIncreace = 0;
            for (int i = 1; i < inputNum.Length; i++)
            {
                if (inputNum[i-1] < inputNum[i])
                {
                    numberOfIncreace++;
                }
            }
            Console.WriteLine($"{numberOfIncreace}");
            #endregion
            #region Part Two
            numberOfIncreace = 0;
            int currentDepth, nextDepth;
            for (int i = 0; i < inputNum.Length-3; i++)
            {
                currentDepth = inputNum[i] + inputNum[i + 1] + inputNum[i + 2];
                nextDepth = inputNum[i + 1] + inputNum[i + 2] + inputNum[i + 3];
                if (currentDepth < nextDepth)
                {
                    numberOfIncreace++;
                }
                
            }
            Console.WriteLine($"{numberOfIncreace}");
            #endregion
        }
    }
}
