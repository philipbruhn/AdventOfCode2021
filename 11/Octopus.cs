using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    public class Octopus
    {
        public int Energy { get; set; }
        public (int x, int y)[] Neighbours { get; set; }
        public bool CanChange { get; set; } = true;
        public Octopus((int x, int y) position, int energy)
        {
            Energy = energy;
            Neighbours = SetNeighbours(position);
        }
        private (int x, int y)[] SetNeighbours((int x, int y) position)
        {
            List<(int x, int y)> neighbours = new();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if(position.x + i > -1 && position.y + j > -1 && position.x + i < 10 && position.y + j < 10)
                    {
                        neighbours.Add((position.x + i, position.y + j));
                    }
                }
            }
            neighbours.Remove(position);
            return neighbours.ToArray();
        }
    }
}
