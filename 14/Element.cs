using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14
{
    class Element
    {
        public Element(double amount, List<string> becomes)
        {
            Amount = amount;
            Becomes = becomes;
        }
        public Element(double amount, List<string> becomes, char single)
        {
            Amount = amount;
            Single = single;
            Becomes = becomes;
        }
        public char Single { get; set; }
        public double Amount { get; set; }
        public List<string> Becomes { get; set; }
    }
}
