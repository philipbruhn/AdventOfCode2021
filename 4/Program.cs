using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            #region Format Input
            int[] numbersToDraw = Array.ConvertAll(input[0].Split(","), s => int.Parse(s));
            string[] boardStrings = new string[5];
            int boardRow = 0;
            List<BingoBoard> boards = CreateListWithBoards(input);
            List<BingoBoard> CreateListWithBoards(string[] input)
            {
                List<BingoBoard> bingoBoards = new();
                for (int i = 2; i < input.Length; i++)
                {
                    if (!input[i].Equals(""))
                    {
                        boardStrings[boardRow] = input[i];
                        boardRow++;
                    }
                    if (boardRow > 4)
                    {
                        bingoBoards.Add(new BingoBoard(boardStrings));
                        boardRow = 0;
                    }
                }
                return bingoBoards;
            }
            #endregion
            #region Part One
            int PlayBingo()
            {
                foreach (var number in numbersToDraw)
                {
                    foreach (var board in boards)
                    {
                        if (board.TryMarkValue(number, out (int, int) position))
                        {
                            if (board.HasBoardBingo(position))
                            {
                                int sum = 0;
                                foreach(var item in board.Board.Where(a => !a.Value.isChecked))
                                {
                                    sum += item.Value.value;
                                }
                                return sum * number;
                            }
                        }
                    }
                }
                return 0;
            }

            Console.WriteLine($"{PlayBingo()}");
            #endregion
            #region PartTwo
            boards = CreateListWithBoards(input);
            Console.WriteLine($"{PlayBingoToLose()}");

            int PlayBingoToLose()
            {
                foreach (var number in numbersToDraw)
                {
                    List<BingoBoard> boardsWithBingo = new();
                    for (int i = 0; i < boards.Count; i++)
                    {
                        if (boards[i].TryMarkValue(number, out (int, int) position))
                        {
                            if (boards[i].HasBoardBingo(position))
                            {
                                if(boards.Count < 2)
                                {
                                    int sum = 0;
                                    foreach (var item in boards[i].Board.Where(a => !a.Value.isChecked))
                                    {
                                        sum += item.Value.value;
                                    }
                                    return sum * number;
                                }
                                else
                                {
                                    boardsWithBingo.Add(boards[i]);
                                }
                            }
                        }
                    }
                    foreach(var board in boardsWithBingo)
                    {
                        boards.Remove(board);
                    }
                }
                return 0;
            }
            #endregion
        }
    }
}
