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
        public void Day01_PartOne()
        {
            int expected = 7;

            int actual = _1.Day1.PartOne(File.ReadAllLines(filepathTest + "Day1.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day01_PartTwo()
        {
            int expected = 5;

            int actual = _1.Day1.PartTwo(File.ReadAllLines(filepathTest + "Day1.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day07_PartOne()
        {
            int expected = 37;

            int actual = _7.Day7.PartOne(File.ReadAllText(filepathTest + "Day7.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day07_PartTwo()
        {
            int expected = 168;

            int actual = _7.Day7.PartTwo(File.ReadAllText(filepathTest + "Day7.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day08_PartOne()
        {
            int expected = 26;

            int actual = _8.Day8.PartOne(File.ReadAllLines(filepathTest + "Day8.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day08_PartTwo()
        {
            int expected = 61229;

            int actual = _8.Day8.PartTwo(File.ReadAllLines(filepathTest + "Day8.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day09_PartOne()
        {
            int expected = 15;

            int actual = _9.Day9.PartOne(File.ReadAllLines(filepathTest + "Day9.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day09_PartTwo()
        {
            int expected = 1134;

            int actual = _9.Day9.PartTwo(File.ReadAllLines(filepathTest + "Day9.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day10_PartOne()
        {
            int expected = 26397;

            int actual = _10.Day10.PartOne(File.ReadAllLines(filepathTest + "Day10.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day10_PartTwo()
        {
            long expected = 288957;

            long actual = _10.Day10.PartTwo(File.ReadAllLines(filepathTest + "Day10.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day11_PartOne()
        {
            long expected = 1656;

            long actual = _11.Day11.PartOne(File.ReadAllLines(filepathTest + "Day11.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day11_PartTwo()
        {
            long expected = 195;

            long actual = _11.Day11.PartTwo(File.ReadAllLines(filepathTest + "Day11.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day12_PartOne()
        {
            int expected = 226;

            int actual = _12.Day12.PartOne(File.ReadAllLines(filepathTest + "Day12.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day12_PartTwo()
        {
            long expected = 3509;

            long actual = _12.Day12.PartTwo(File.ReadAllLines(filepathTest + "Day12.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day13_PartOne()
        {
            int expected = 17;

            int actual = _13.Day13.PartOne(File.ReadAllLines(filepathTest + "Day13.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day14_PartOne()
        {
            double expected = 1588;

            double actual = _14.Day14.PartOne(File.ReadAllLines(filepathTest + "Day14.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day14_PartTwo()
        {
            double expected = 2188189693529;

            double actual = _14.Day14.PartTwo(File.ReadAllLines(filepathTest + "Day14.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day15_PartOne()
        {
            int expected = 40;

            int actual = _15.Day15.PartOne(File.ReadAllLines(filepathTest + "Day15.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day15_PartTwo()
        {
            int expected = 315;

            int actual = _15.Day15.PartTwo(File.ReadAllLines(filepathTest + "Day15.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day16_PartOne()
        {
            int expected = 31;

            int actual = _16.Day16.PartOne(File.ReadAllText(filepathTest + "Day16.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day17_PartOne()
        {
            int expected = 45;

            int actual = _17.Day17.PartOne(File.ReadAllText(filepathTest + "Day17.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day17_PartTwo()
        {
            int expected = 112;

            int actual = _17.Day17.PartTwo(File.ReadAllText(filepathTest + "Day17.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day18_PartOne()
        {
            int expected = 45;

            int actual = _18.Day18.PartOne(File.ReadAllText(filepathTest + "Day18.txt"));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Day18_PartTwo()
        {
            int expected = 112;

            int actual = _18.Day18.PartTwo(File.ReadAllText(filepathTest + "Day18.txt"));

            Assert.Equal(expected, actual);
        }
    }
}
