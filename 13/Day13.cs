using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    public static class Day13
    {
        private static List<(int x, int y)> dots = new();
        private static List<(int x, int y)> fold = new();

        public static int PartOne(string[] input)
        {
            FormatInput(input);
            for (int i = 0; i < 1; i++)
            {

                if (fold[i].x > 1)
                {
                    FoldX(fold[i].x);
                }
                if (fold[i].y > 1)
                {
                    FoldY(fold[i].y);
                }

            }
            return dots.Count();
        }

        public static void PartTwo(string[] input)
        {
            FormatInput(input);
            for (int i = 0; i < fold.Count; i++)
            {
                if (fold[i].x > 1)
                {
                    FoldX(fold[i].x);
                }
                if (fold[i].y > 1)
                {
                    FoldY(fold[i].y);
                }
            }
            List<string> uiList = GenerateUI(dots.Max(x => x.x), dots.Max(x => x.y));
            foreach(var line in uiList)
            {
                Console.WriteLine(line);
            }
        }

        private static void FormatInput(string[] input)
        {
            List<string> inputList = input.ToList();
            List<string> foldInstructions = inputList.FindAll(a => a.Contains("fold"));
            inputList.RemoveAll(a => a.Contains("fold"));
            dots = new();
            foreach(var line in inputList)
            {
                if(line != "")
                {
                    string[] coords = line.Split(",");
                    dots.Add((int.Parse(coords[0]), int.Parse(coords[1])));
                }
            }
            fold = new();
            foreach (var instruction in foldInstructions)
            {
                
                if (instruction.Contains("x"))
                {
                    fold.Add((int.Parse(instruction.Split('=')[1]), 1));
                }
                else
                {
                    fold.Add((1, int.Parse(instruction.Split('=')[1])));
                }
            }
        }
        private static int NewCoord(int fold, int dot)
        {
            return fold - (dot - fold);
        }
        private static void FoldX(int fold)
        {
            List<(int x, int y)> foldedSide = dots.Where(a => a.x > fold).ToList();
            dots.RemoveAll(a => foldedSide.Contains(a));
            foreach (var dot in foldedSide)
            {
                (int, int) newDot = (NewCoord(fold, dot.x), dot.y);
                if (!dots.Contains(newDot))
                {
                    dots.Add(newDot);
                }
            }
        }
        private static void FoldY(int fold)
        {
            List<(int x, int y)> foldedSide = dots.Where(a => a.y > fold).ToList();
            dots.RemoveAll(a => foldedSide.Contains(a));
            foreach (var dot in foldedSide)
            {
                (int, int) newDot = (dot.x, NewCoord(fold, dot.y));
                if (!dots.Contains(newDot))
                {
                    dots.Add(newDot);
                }
            }
        }
        private static List<string> GenerateUI(int maxX, int maxY)
        {
            List<string> uiList = new();
            for(int y = 0; y <= maxY; y++)
            {
                string line = "";
                for (int x = 0; x <= maxX; x++)
                {
                    if(dots.Contains((x, y)))
                    {
                        line += "#";
                    }
                    else
                    {
                        line += ".";
                    }
                }
                uiList.Add(line);
            }
            return uiList;
        }

    }
}
