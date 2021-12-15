using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14
{
    public static class Day14
    {
        private static Dictionary<string, Element> elementsCurrent;

        public static double PartOne(string[] input)
        {
            elementsCurrent = CreateElementPairs(input);
            string start = input[0];
            for (int i = 0; i < input[0].Length-1; i++)
            {
                elementsCurrent[$"{start[i]}{start[i + 1]}"].Amount++;
            }
            for (int i = 0; i < 10; i++)
            {
                elementsCurrent = UpdateElements(CreateElementPairs(input));

            }
            var letters = CreateLettersDict(input);
            foreach (var item in elementsCurrent)
            {
                letters[item.Key[1]] += item.Value.Amount;
            }
            letters[start.First()]++;
            return letters.Values.Max() - letters.Values.Min();
        }

        public static double PartTwo(string[] input)
        {
            elementsCurrent = CreateElementPairs(input);
            string start = input[0];
            for (int i = 0; i < input[0].Length - 1; i++)
            {
                elementsCurrent[$"{start[i]}{start[i + 1]}"].Amount++;
            }
            for (int i = 0; i < 40; i++)
            {
                elementsCurrent = UpdateElements(CreateElementPairs(input));
            }
            var letters = CreateLettersDict(input);
            foreach (var item in elementsCurrent)
            {
                    letters[item.Key[0]] += item.Value.Amount;
            }
            letters[start.Last()]++;
            return letters.Values.Max() - letters.Values.Min();
        }

        private static Dictionary<string,Element> CreateElementPairs(string[] input)
        {
            Dictionary<string, Element> elementPairs = new();
            for (int i = 2; i < input.Length; i++)
            {
                string[]pair =  input[i].Split(" -> ");
                elementPairs.Add(pair[0], new Element(0, new List<string>(){
                    pair[0][0] + pair[1],
                    pair[1] + pair[0][1]
                }, pair[1].Last()));
            }
            return elementPairs;
        }
        private static Dictionary<string, Element> UpdateElements(Dictionary<string, Element> newDict)
        {
            foreach (var element in elementsCurrent.Values)
            {
                foreach(var become in element.Becomes)
                {
                    newDict[become].Amount += element.Amount;
                }
            }
            return newDict;
        }
        private static Dictionary<char, double> CreateLettersDict(string[] input)
        {
            Dictionary<char, double> letters = new();
            for (int i = 2; i < input.Length; i++)
            {
                char e = input[i].Last();
                if (!letters.ContainsKey(e))
                {
                    letters.Add(e, 0);
                }
            }
            return letters;
        }
    }
}
