using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2021.Test
{
    public class Tests
    {
        static string filepathTest = Environment.CurrentDirectory + "/Inputs/";

        [Fact]
        public void Day1_PartOne()
        {
            int expected = 7;

            int actual = _1.Day1.PartOne(File.ReadAllLines(filepathTest + "Day1.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day1_PartTwo()
        {
            int expected = 5;

            int actual = _1.Day1.PartTwo(File.ReadAllLines(filepathTest + "Day1.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day7_PartOne()
        {
            int expected = 37;

            int actual = _7.Day7.PartOne(File.ReadAllText(filepathTest + "Day7.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day7_PartTwo()
        {
            int expected = 168;

            int actual = _7.Day7.PartTwo(File.ReadAllText(filepathTest + "Day7.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day8_PartOne()
        {
            int expected = 26;

            int actual = _8.Day8.PartOne(File.ReadAllLines(filepathTest + "Day8.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day8_PartTwo()
        {
            int expected = 61229;

            int actual = _8.Day8.PartTwo(File.ReadAllLines(filepathTest + "Day8.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day9_PartOne()
        {
            int expected = 15;

            int actual = _9.Day9.PartOne(File.ReadAllLines(filepathTest + "Day9.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day9_PartTwo()
        {
            int expected = 1134;

            int actual = _9.Day9.PartTwo(File.ReadAllLines(filepathTest + "Day9.txt"));

            Assert.Equal(expected, actual);
        }
    }
}
