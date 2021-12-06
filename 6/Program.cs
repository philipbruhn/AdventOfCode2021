using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText(@"input.txt").Split(",");
            List<int> fishes = Array.ConvertAll(input, s => int.Parse(s)).ToList();

            Console.WriteLine($"{GetFishesInAmountOfDays(80)}");
            Console.WriteLine($"{GetFishesInAmountOfDays(256)}");

            double GetFishesInAmountOfDays(int days)
            {
                double fishCount = fishes.Count;
                double[] newFishesOnDay = new double[days];
                foreach(var fish in fishes)
                {
                    newFishesOnDay[fish]++;
                }
                for (int i = 1; i < days; i++)
                {
                    fishCount += newFishesOnDay[i];
                    if(newFishesOnDay.Length -1 > i + 6)
                    {
                        newFishesOnDay[i + 7] += newFishesOnDay[i];
                    }
                    if (newFishesOnDay.Length - 1 > i + 8)
                    {
                        newFishesOnDay[i + 9] += newFishesOnDay[i];
                    }
                }
                return fishCount;
            }
        }
    }
}
