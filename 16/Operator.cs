using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16
{
    class Operator : Packet
    {
        public Operator(string input)
        {
            Version = GetVersion(input[0..3]);
            TypeID = GetType(input[3..6]);
            LengthID = input[6];
            if (LengthID.Equals('0'))
            {
                PacketsBasedOnLengthIDZero(input[7..]);
            }
            else
            {
                PacketsBasedOnLengthIDOne(input[7..]);
            }
            SumOfVersions = packets.Sum(a => a.SumOfVersions) + Version;
            Value = GetOperatorValue(TypeID);
        }
        public char LengthID { get; set; }
        public List<Packet> packets = new();
        private void PacketsBasedOnLengthIDZero(string input)
        {
            int numberOfBits = Convert.ToInt32(input.Substring(0, 15), 2);
            input = input[15..];
            bool isDone = false;
            while (!isDone)
            {
                if (input[3..6].Equals("100"))
                {
                    packets.Add(new LiteralValue(input));
                }
                else
                {
                    packets.Add(new Operator(input));
                }
                if(packets.Sum(a => a.Length) == numberOfBits)
                {
                    isDone = true;
                }
                input = input.Substring(packets.Last().Length);
            }
            Length = 3 + 3 + 1 + 15 + numberOfBits;
        }
        private void PacketsBasedOnLengthIDOne(string input)
        {
            int numberOfPackets = Convert.ToInt32(input.Substring(0, 11), 2);
            input = input[11..];
            bool isDone = false;
            while (!isDone)
            {
                if (input[3..6].Equals("100"))
                {
                    packets.Add(new LiteralValue(input));
                }
                else
                {
                    packets.Add(new Operator(input));
                }
                if (packets.Count == numberOfPackets)
                {
                    isDone = true;
                }
                input = input.Substring(packets.Last().Length);
            }
            Length = 3 + 3 + 1 + 11 + packets.Sum(a => a.Length);
        }
        private long GetOperatorValue(int typeID)
        {
            switch (typeID)
            {
                case 0:
                    return packets.Sum(a => a.Value);
                case 1:
                    long product = 1;
                    foreach(var packet in packets)
                    {
                        product *= packet.Value;
                    }
                    return product;
                case 2:
                    return packets.Min(a => a.Value);
                case 3:
                    return packets.Max(a => a.Value);
                case 5:
                    if(packets[0].Value > packets[1].Value)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                case 6:
                    if (packets[0].Value < packets[1].Value)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                case 7:
                    if (packets[0].Value == packets[1].Value)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
            }
            return -1;
        }
    }
}
