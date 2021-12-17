using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16
{
    class LiteralValue : Packet
    {
        public LiteralValue(string input)
        {
            Version = GetVersion(input);
            Value = GetValue(input[6..]);
            TypeID = 4;
            SumOfVersions = Version;
        }

        private long GetValue(string input)
        {
            bool isDone = false;
            string binaryValue = "";
            int i = 0;
            while (!isDone)
            {
                string part = input.Substring(0, 5);
                if (part[0].Equals('0'))
                {
                    isDone = true;
                }
                binaryValue += part[1..];
                input = input[5..];
                i++;
            }
            
            Length = 6 + i * 5;
            
            return Convert.ToInt64(binaryValue, 2);
        }
    }
}
