using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            Dictionary<(int,int),int> oceanFloor = new();
            CreateOceanFloor();
            DrawHydroLines(FormatInput(input));
            int overlaps = oceanFloor.Count(a => a.Value > 1);
            Console.WriteLine($"{overlaps}");

            void CreateOceanFloor()
            {
                for(int x = 0; x < 1000; x++)
                {
                    for(int y = 0; y < 1000; y++)
                    {
                        oceanFloor[(x, y)] = 0;
                    }
                }
            }
            void DrawHydroLines(List<Point[]>lines)
            {
                foreach(var line in lines)
                {
                    int[] dir = GetDir(line);
                    bool hasDrawnLine = false;
                    int i = 0; 
                    while (!hasDrawnLine)
                    {
                        (int x, int y) currentPoint = (line[0].X + dir[0] * i, line[0].Y + dir[1] * i);
                        if(currentPoint.x == line[1].X && currentPoint.y == line[1].Y)
                        {
                            hasDrawnLine = true;
                        }
                        oceanFloor[currentPoint]++;
                        i++;
                    }
                }
            }
            List<Point[]> FormatInput(string[] input)
            {
                List<Point[]> lines = new();
                foreach (var inputLine in input)
                {
                    string[] stringPoints = inputLine.Split(" -> ");
                    Point[] line = new Point[2];
                    for (int i = 0; i < stringPoints.Length; i++)
                    {
                        int[] xy = Array.ConvertAll(stringPoints[i].Split(","), s => int.Parse(s));
                        line[i] = new Point(xy[0], xy[1]);
                    }
                    lines.Add(line);
                }
                return lines;
            }
            int[] GetDir(Point[] line)
            {
                int[] dir = new int[2];

                if (line[0].X < line[1].X)
                {
                    dir[0] = 1;
                }
                else if (line[0].X > line[1].X)
                {
                    dir[0] = -1;
                }
                else 
                {
                    dir[0] = 0;
                }
                if (line[0].Y < line[1].Y)
                {
                    dir[1] = 1;
                }
                else if (line[0].Y > line[1].Y)
                {
                    dir[1] = -1;
                }
                else
                {
                    dir[1] = 0;
                }
                return dir;
            }
        }
    }
}
