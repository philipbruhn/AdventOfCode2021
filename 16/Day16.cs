using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16
{
    public static class Day16
    {
        private static List<Packet> packets = new();
        public static int PartOne(string input)
        {
            string binaryInput = Hex2binary(input);
            bool isDone = false;
            while (!isDone)
            {
                if (binaryInput[3..6].Equals("100"))
                {
                    var literalVal = new LiteralValue(binaryInput);
                    binaryInput = binaryInput[(literalVal.Length)..];
                    packets.Add(literalVal);
                }
                else
                {
                    var operators = new Operator(binaryInput);
                    binaryInput = binaryInput[(operators.Length)..];
                    packets.Add(operators);
                }
                if (!binaryInput.Contains('1'))
                {
                    isDone = true;
                }
            }
            return packets.Sum(a => a.SumOfVersions);
        }

        public static long PartTwo()
        {

            return packets.First().Value;
        }


        private static string Hex2binary(string hexInput)
        {
            string binaryInput = "";
            foreach (char sign in hexInput)
            {
                string binary = Convert.ToString(Convert.ToInt32(sign.ToString(), 16), 2);
                for (int i = binary.Length; i < 4; i++)
                {
                    binary = "0" + binary;
                }
                binaryInput += binary;

            }
            return binaryInput;
        }
    }
}
