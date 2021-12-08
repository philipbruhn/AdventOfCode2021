using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    public static class Day7
    {
        public static int PartOne(string input)
        {
            List<int> crabPositions = Array.ConvertAll(input.Split(","), s => int.Parse(s)).ToList();
            crabPositions.Sort();
            int median = crabPositions[(int)Math.Round((double)crabPositions.Count / 2) -1];
            int fuel = 0;
            foreach (var position in crabPositions)
            {
                fuel += Math.Abs(position - median);
            }
            return fuel;
        }
        public static int PartTwo(string input)
        {
            int[] crabPositions = Array.ConvertAll(input.Split(","), s => int.Parse(s));
            return GetBestPositionFuel((int)Math.Round(crabPositions.Average()), crabPositions);
        }
        private static int GetBestPositionFuel( int tryPosition, int[] crabPositions)
        {
            int[] tryPositions = {tryPosition - 1, tryPosition, tryPosition + 1};
            int[] fuel = new int[3];
            for (int i = 0; i < tryPositions.Length; i++)
            {
                foreach (var position in crabPositions)
                {
                    int singleCrabFuel = 0;
                    for (int j = 1; j <= Math.Abs(position - tryPositions[i]); j++)
                    {
                        singleCrabFuel += j;
                    }
                    fuel[i] += singleCrabFuel;
                }
            }
            int bestPosition = Array.IndexOf(fuel, fuel.Min());
            if (bestPosition != 1)
            {
                fuel[1] = GetBestPositionFuel(tryPositions[bestPosition], crabPositions);
            }
            return fuel[1]; 
        }
    }
}
