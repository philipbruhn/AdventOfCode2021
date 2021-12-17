using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16
{
    public abstract class Packet
    {
        public int Version { get; set; }
        public int TypeID { get; set; }
        public long Value { get; set; }
        public int Length { get; set; }
        public int SumOfVersions { get; set; }
        public int GetVersion(string input)
        {
            return Convert.ToInt32(input.Substring(0, 3), 2);
        }
        public int GetType(string input)
        {
            return Convert.ToInt32(input.Substring(0, 3), 2);
        }
    }
}
