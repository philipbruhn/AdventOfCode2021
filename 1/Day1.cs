using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class Day1
    {
        public static int PartOne(string[] input)
        {
            int[] inputNum = Array.ConvertAll(input, s => int.Parse(s));
            int numberOfIncreace = 0;
            for (int i = 1; i < inputNum.Length; i++)
            {
                if (inputNum[i - 1] < inputNum[i])
                {
                    numberOfIncreace++;
                }
            }
            return numberOfIncreace;
        }
        public static int PartTwo(string[] input)
        {
            int[] inputNum = Array.ConvertAll(input, s => int.Parse(s));
            int numberOfIncreace = 0;
            int currentDepth, nextDepth;
            for (int i = 0; i < inputNum.Length - 3; i++)
            {
                currentDepth = inputNum[i] + inputNum[i + 1] + inputNum[i + 2];
                nextDepth = inputNum[i + 1] + inputNum[i + 2] + inputNum[i + 3];
                if (currentDepth < nextDepth)
                {
                    numberOfIncreace++;
                }
            }
            return numberOfIncreace;
        }
    }
}
