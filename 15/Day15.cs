using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    public static class Day15
    {


        public static int PartOne(string[] input)
        {

            return FindSafestWay(GetSmallCave(input));
        }

        public static int PartTwo(string[] input)
        {
            return FindSafestWay(GetBigCave(input));
        }

        private static int FindSafestWay(Dictionary<(int x, int y), (int risk, int riskSoFar)> cave)
        {
            cave[(0, 0)] = (1,0);
            (int x, int y) endPos = cave.Keys.Max();
            (int x, int y)[] directions = { (1, 0), (-1, 0), (0, 1), (0, -1) };
            bool hasChanged = true;
            while (hasChanged)
            {
                hasChanged = false;
                for (int i = 0; i <= endPos.x; i++)
                {
                    for (int j = 0; j <= endPos.y; j++)
                    {
                        foreach (var (x, y) in directions)
                        {
                            if (cave.TryGetValue((i + x, j + y), out (int risk, int riskSoFar) neighbour))
                            {
                                int cost = cave[(i, j)].riskSoFar + neighbour.risk;
                                if (neighbour.riskSoFar > cost)
                                {
                                    cave[(i + x, j + y)] = (neighbour.risk, cost);
                                    hasChanged = true;
                                }
                            }
                        }
                    }
                }
            }
            return cave[endPos].riskSoFar;
        }


        private static Dictionary<(int x, int y), (int risk, int cost)> GetSmallCave(string[] input)
        {
            Dictionary<(int x, int y), (int risk, int cost)> smallCave = new();
            if (smallCave.Count == 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        smallCave.Add((j, i), (int.Parse(input[i][j].ToString()),int.MaxValue));
                    }
                }
            }
            return smallCave;
        }
        private static Dictionary<(int x, int y), (int risk, int cost)> GetBigCave(string[] input)
        {
            Dictionary<(int x, int y), (int risk, int cost)> smallCave = GetSmallCave(input);
            (int x, int y) smallMax = smallCave.Keys.Max();
            Dictionary<(int x, int y), (int risk, int cost)> bigCave = new();
            foreach (var position in smallCave)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int risk = position.Value.risk + i + j;
                        if (risk > 9)
                        {
                            risk -= 9;
                        }
                        bigCave.Add((position.Key.x + (i * (smallMax.x + 1)), position.Key.y + (j * (smallMax.x + 1))), (risk, position.Value.cost));
                    }
                }
            }
            return bigCave;
        }
    }
}
