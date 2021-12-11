using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    public static class Day11
    {
        private static Dictionary<(int x, int y), Octopus> octopuses = new();
        public static int PartOne(string[] input)
        {
            int flashes = 0;
            SetOctopusues(input);
            for(int i = 0; i < 100; i++)
            {
                foreach (var octopus in octopuses.Values)
                {
                    flashes += Flash(octopus);
                }
                foreach (var octopus in octopuses.Values)
                {
                    octopus.CanChange = true;
                }
            }
            return flashes;
        }
        public static int PartTwo(string[] input)
        {
            SetOctopusues(input);
            int i = 1;
            while (true)
            {
                int flashes = 0;
                foreach (var octopus in octopuses.Values)
                {
                    flashes += Flash(octopus);
                }
                if (flashes == 100)
                {
                    break;
                }
                foreach (var octopus in octopuses.Values)
                {
                    octopus.CanChange = true;
                }
                i++;
            }
            return i;
        }

        private static int Flash(Octopus octopus)
        {
            int flashes = 0;
            if (octopus.CanChange)
            {
                octopus.Energy++;
                if(octopus.Energy > 9)
                {
                    octopus.Energy = 0;
                    flashes++;
                    octopus.CanChange = false;
                    foreach (var neighbour in octopus.Neighbours)
                    {
                        if (octopuses[neighbour].CanChange)
                        {
                            flashes += Flash(octopuses[neighbour]);
                        }
                    }
                }

            }
            return flashes;
        }
        private static void SetOctopusues(string[] input)
        {
            octopuses = new();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    octopuses.Add((j, i), new Octopus((j, i), int.Parse(input[i][j].ToString())));
                }
            }
        }
    }
}
