using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17
{
    public static class Day17
    {
        public static int PartOne(string input)
        {
            char[] seperator = { '=', '.', ',' };
            int[] y = Array.ConvertAll(input.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[4..6], s => int.Parse(s));
            int maxYVelocity = Math.Abs(y.Min()) - 1;
            return (maxYVelocity * (maxYVelocity + 1)) / 2;
        }
        public static int PartTwo(string input)
        {
            char[] seperator = { '=', '.', ',' };
            int[] x = Array.ConvertAll(input.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[1..3], s => int.Parse(s));
            int[] y = Array.ConvertAll(input.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[4..6], s => int.Parse(s));

            int minXVelocity = (int)Math.Round((-1 + Math.Sqrt(1 + 8 * x.Min())) / 2, MidpointRounding.AwayFromZero);
            int maxYVelocity = Math.Abs(y.Min()) - 1;

            List<int> xVelocities = Enumerable.Range(minXVelocity, x.Max() - minXVelocity + 1).ToList();
            List<int> yVelocities = Enumerable.Range(y.Min(),maxYVelocity - y.Min() + 1).ToList();
            List<(int x, int y)> velocities = xVelocities.SelectMany(x => yVelocities.Select(y => (x, y))).ToList();

            List<(int x, int y)> hits = new();

            foreach (var velocity in velocities)
            {
                if(IsHit(velocity, x, y))
                {
                    hits.Add(velocity);
                }
            }
            return hits.Count;
        }
        public static bool IsHit((int x, int y) velocity, int[] targetX, int[] targetY)
        {
            (int x, int y) position = (0, 0);
            while (true)
            {
                position = (position.x + velocity.x, position.y + velocity.y);
                if (position.y < targetY[0] || position.x > targetX[1])
                {
                    return false;
                }

                if (position.y >= targetY[0] && position.y <= targetY[1] && position.x <= targetX[1] && position.x >= targetX[0])
                {
                    return true;
                }

                velocity.y--;

                if (velocity.x > 0)
                {
                    velocity.x--;
                }
            } 
        }

    }
}
