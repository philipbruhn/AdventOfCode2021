using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    public class Cave
    {
        public Cave(string name)
        {
            Name = name;
            if (char.IsUpper(name[0]))
            {
                IsLarge = true;
            }
            AdjecentCaves = new();
        }

        public string Name { get; set; }
        public bool IsLarge { get; set; } = false;
        public List<string> AdjecentCaves { get; set; }
        public int Solutions { get; set; } = 0;
        public void AddAdjecentCave(string[] caves)
        {
            AdjecentCaves.AddRange(caves.ToList());
            AdjecentCaves.Remove(Name);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
