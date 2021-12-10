using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    public static class Day10
    {
        public static Dictionary<char, (char sign, int value)> syntax = new Dictionary<char, (char, int)> { { ')', ('(', 3) }, { ']', ('[', 57) }, {'}', ('{', 1197)}, {'>', ('<', 25137)} };

        public static int PartOne(string[] input)
        {
            int score = 0;
            List<char> corruptLines = new();
            foreach(var line in input)
            {
                if (!TryRemovePairs(line,out char[] corruptLine))
                {
                    corruptLines.AddRange(corruptLine.ToList());
                }
            }
            foreach (var sign in corruptLines)
            {
                score += syntax[sign].value;
            }
            return score;
        }

        public static long PartTwo(string[] input)
        {
            List<long> scores = new();
            List<char[]> v = new();
            foreach (var line in input)
            {
                if (TryRemovePairs(line, out char[] bla))
                {
                    v.Add(bla);
                }
            }
            foreach (var line in v)
            {
                scores.Add(CalcScores(line.Reverse().ToList()));
            }
            scores.Sort();
            return scores[scores.Count() / 2];
        }

        private static bool TryRemovePairs(string line, out char[] checkedLine)
        {
            bool found = true;
            string newLine = "";
            while (found)
            {
                newLine = "";
                found = false;
                for (int i = 0; i < line.Length; i++)
                {
                    if (syntax.Keys.Contains(line[i]) && line[i - 1] == syntax[line[i]].sign)
                    {
                        newLine = newLine.Remove(newLine.Length - 1);
                        found = true;
                    }
                    else if (syntax.Keys.Contains(line[i]) && !syntax.Keys.Contains(line[i - 1]))
                    {
                        checkedLine = new char[] { line[i] };
                        return false ;
                    }
                    else
                    {
                        newLine += line[i];
                    }
                }
                line = newLine;
            }
            checkedLine = newLine.ToCharArray();
            return true;
        }

        private static long CalcScores(List<char> line)
        {
            Dictionary<char, int> scoreSheet = new Dictionary<char, int> { { '(', 1 }, { '[', 2 }, { '{', 3 }, { '<', 4 } };
            long score = 0;
            foreach(var sign in line)
            {
                score = score * 5 + scoreSheet[sign];
            }
            return score;
        }
        
    }
}
