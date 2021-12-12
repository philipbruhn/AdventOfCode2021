using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    public static class Day12
    {
        public static Dictionary<string, Cave> caves = new();

        public static int PartOne(string[] input)
        {
            caves = CreateCaveSystem(input);
            int exits = 0;
            foreach (var caveName in caves["start"].AdjecentCaves)
            {
                List<string> newPath = new() { "start", caveName };
                exits += GetExits(newPath,false);
            }
            return exits;
        }

        public static int PartTwo(string[] input)
        {
            caves = CreateCaveSystem(input);

            int exits = 0;
            foreach (var caveName in caves["start"].AdjecentCaves)
            {
                List<string> newPath = new() { "start", caveName };
                exits += GetExits(newPath, true);
            }
            return exits;
        }

        private static int GetExits(List<string> currentExitPath, bool canVisitSmallCavesTwice)
        {
            int exits = 0; 
            foreach (var adjecentCave in caves[currentExitPath[currentExitPath.Count - 1]].AdjecentCaves)
            {
                List<string> newPath = new(currentExitPath);
                if (caves[adjecentCave].Name.Equals("start"))
                {
                    continue;
                }
                if (caves[adjecentCave].Name.Equals("end"))
                {
                    newPath.Add(adjecentCave);
                    exits++;
                }
                else if (currentExitPath.Exists(a => a == adjecentCave && !caves[adjecentCave].IsLarge))
                {
                    if (!canVisitSmallCavesTwice)
                    {
                        continue;
                    }
                    else
                    {
                        newPath.Add(adjecentCave);
                        exits += GetExits(newPath, false);
                    }
                }
                else if (currentExitPath.Exists(a => a != adjecentCave))
                {
                    newPath.Add(adjecentCave);
                    exits += GetExits(newPath, canVisitSmallCavesTwice);
                }
            }
            return exits;
        }

        private static Dictionary<string, Cave> CreateCaveSystem(string[] input)
        {
            Dictionary<string, Cave> caves = new();
            foreach (var line in input)
            {
                string[] caveNames = line.Split("-");
                foreach (var caveName in caveNames)
                {
                    if (!caves.ContainsKey(caveName))
                    {
                        caves.Add(caveName, new Cave(caveName));
                    }
                    caves[caveName].AddAdjecentCave(caveNames);
                }
            }
            return caves;
        }
    }
}
