using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    public static class Day8
    {
        public static int PartOne(string[] input)
        {
            int uniqueOutputs = 0;
            foreach(var line in input)
            {
                string[] outputLine = line.Split("|")[1].Trim().Split(" ");
                uniqueOutputs +=  outputLine.Count(a => a.Length == 2 || a.Length == 3 || a.Length == 4 || a.Length == 7);
            }
            return uniqueOutputs;
        }
        public static int PartTwo(string[] input)
        {
            int number = 0;
            foreach (var line in input)
            {
                string numString = "";
                string[] inputLine = line.Split("|")[0].Trim().Split(" ");
                var decypher = DecypherNumbers(inputLine);
                foreach(var output in line.Split("|")[1].Trim().Split(" "))
                {
                    char[] o = output.ToCharArray();
                    Array.Sort(o);
                    numString += decypher[new string(o)];
                }
                number += int.Parse(numString);
            }
            return number;
        }
        public static Dictionary<string, string> DecypherNumbers(string[] inputLine)
        {
            List<char[]> inputs = Array.ConvertAll(inputLine, s => s.ToCharArray()).ToList();
            foreach (var input in inputs)
            {
                Array.Sort(input);
            }
            Dictionary<string, char[]> segment = new();
            segment["1"] = inputs.First(a => a.Length == 2);
            segment["7"] = inputs.First(a => a.Length == 3);
            segment["4"] = inputs.First(a => a.Length == 4);
            segment["8"] = inputs.First(a => a.Length == 7);
            segment["9"] = inputs.First(a => a.Length == 6 && segment["4"].All(b => a.Contains(b)));
            segment["0"] = inputs.First(a => a.Length == 6 && segment["1"].All(b => a.Contains(b)) && a != segment["9"]);
            segment["6"] = inputs.First(a => a.Length == 6 && a != segment["0"] && a != segment["9"]);
            segment["3"] = inputs.First(a => a.Length == 5 && a.All(a => segment["9"].Contains(a)) && segment["1"].All(b => a.Contains(b)));
            segment["5"] = inputs.First(a => a.Length == 5 && a.All(a => segment["9"].Contains(a)) && a.All(a => segment["6"].Contains(a)));
            segment["2"] = inputs.First(a => a.Length == 5 && a != segment["3"] && a != segment["5"]);

            Dictionary<string, string> dictDecypher = segment.ToDictionary(a => new string(a.Value), a => a.Key);
            return dictDecypher;
        }
    }
}
