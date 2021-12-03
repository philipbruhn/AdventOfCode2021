using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            #region Part One
            int[] oneOrZero = new int[12];
            string binGamma = "";
            string binEpsilon = "";

            foreach (var bin in input)
            {
                for (int i = 0; i < bin.Length; i++)
                {
                    if (bin[i].Equals('1'))
                    {
                        oneOrZero[i]++;
                    }
                    else
                    {
                        oneOrZero[i]--;
                    }
                }
            }
            for (int i = 0; i < oneOrZero.Length; i++)
            {
                if (oneOrZero[i] < 0)
                {
                    binGamma += "0";
                    binEpsilon += "1";
                }
                else
                {
                    binGamma += "1";
                    binEpsilon += "0";
                }
            }
            Console.WriteLine($"{Convert.ToInt32(binGamma, 2) * Convert.ToInt32(binEpsilon, 2)}");
            #endregion
            #region Part Two
            Console.WriteLine($"{Convert.ToInt32(LifeSupportRating(input.ToList(), 0, true)[0], 2) * Convert.ToInt32(LifeSupportRating(input.ToList(), 0, false)[0], 2)}");
            
            List<string> LifeSupportRating(List<string> bins, int index, bool isO2)
            {
                int mostFrekvent = 0;
                List<string> potensialBins = new();
                char mostFrekventChar;

                foreach (var bin in bins)
                {
                    if (bin[index].Equals('1'))
                    {
                        mostFrekvent++;
                    }
                    else
                    {
                        mostFrekvent--;
                    }
                }

                if (mostFrekvent >= 0)
                {
                    mostFrekventChar = '1';
                }
                else
                {
                    mostFrekventChar = '0';
                }

                if (!isO2)
                {
                    int x = 1 - int.Parse(mostFrekventChar.ToString());
                    mostFrekventChar = $"{x}"[0];
                }

                potensialBins = bins.FindAll(x => x[index].Equals(mostFrekventChar));

                if (potensialBins.Count > 1)
                {
                    index++;
                    potensialBins = LifeSupportRating(potensialBins, index, isO2);
                }

                return potensialBins;
            }
            #endregion
        }
    }
}
