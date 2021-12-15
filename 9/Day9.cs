using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    public static class Day9
    {
        static Dictionary<(int, int), int> oceanFloor = new();
        
        public static int PartOne(string[] input)
        {
            SetOceanFloor(input);
            int riskLevel = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if (CheckNeigboursPartOne((j,i)))
                    {
                        riskLevel += oceanFloor[(j, i)] + 1;
                    }
                }
            }
            return riskLevel;
        }
            
        public static int PartTwo(string[] input)
        {
            SetOceanFloor(input);
            List<(int, int)> checkedCoords = new();
            List<int> sizes = new();
            foreach(var coord in oceanFloor.Keys)
            {
                if (!checkedCoords.Contains(coord) && oceanFloor[coord] != 9)
                {
                    List<(int, int)> basin = CheckNeigboursPartTwo(coord, new List<(int, int)>());
                    sizes.Add(basin.Count);
                    checkedCoords.AddRange(basin);
                }
            }
            sizes.Sort();
            sizes.Reverse();
            return sizes[0] * sizes[1] * sizes[2];
        }

        private static bool CheckNeigboursPartOne((int x, int y) coords)
        {
            (int x, int y)[] directions = { (1, 0), (-1, 0), (0, 1), (0, -1) };
            List<int> neigbours = new();
            foreach (var direction in directions)
            {
                if (oceanFloor.TryGetValue((coords.x + direction.x, coords.y + direction.y), out int neigbour))
                {
                    neigbours.Add(neigbour);
                }
            }
            if(oceanFloor[coords] < neigbours.Min())
            {
                return true;
            }
            return false;
        }

        private static List<(int, int)> CheckNeigboursPartTwo((int x, int y) coords, List<(int, int)> basin)
        {
            (int x, int y)[] directions = { (1, 0), (-1, 0), (0, 1), (0, -1) };
            basin.Add(coords);
            foreach(var direction in directions)
            {
                if (oceanFloor.TryGetValue((coords.x + direction.x, coords.y + direction.y), out int neigbour))
                {
                    if (neigbour != 9 && !basin.Contains((coords.x + direction.x, coords.y + direction.y)))
                    {
                        basin = CheckNeigboursPartTwo((coords.x + direction.x, coords.y + direction.y), basin);
                    }
                }
            }
            return basin;
        }

        private static void SetOceanFloor(string[] input)
        {
            if(oceanFloor.Count == 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        oceanFloor.Add((j, i), int.Parse(input[i][j].ToString()));
                    }
                }
            }
        }
    }
}
