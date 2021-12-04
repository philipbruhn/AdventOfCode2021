using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class BingoBoard
    {
        public BingoBoard(string[] boardStrings)
        {
            ConvertToDictItems(boardStrings);
        }

        public Dictionary<(int x, int y), (int value, bool isChecked)> Board { get; set; } = new();
        
        private void ConvertToDictItems(string[] boardStrings)
        {
            for(int i = 0; i < boardStrings.Length; i++)
            {
                List<string> rowString = boardStrings[i]
                    .Split(" ")
                    .Where(x => !x.Equals(""))
                    .ToList();

                for(int j = 0; j < rowString.Count; j++)
                {
                    Board.Add((i, j),(int.Parse(rowString[j]), false));
                }
            }
        }

        public bool HasBoardBingo((int x, int y) position)
        {
            if(HasRowBingo(position.x) || HasColumnBingo(position.y))
            {
                return true;
            }
            return false;
        }

        public bool TryMarkValue(int value, out (int, int) markedItemKey)
        {
            markedItemKey = (-1,-1);
            if (Board.ContainsValue((value,false)))
            {
                var markedItem = Board.FirstOrDefault(a => a.Value == (value, false));
                markedItemKey = markedItem.Key;
                Board[markedItemKey] = (value, true) ;
                return true;
            }
            return false;
        }

        private bool HasRowBingo(int x)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!Board.GetValueOrDefault((x, i)).isChecked)
                {
                    return false;
                }
            }
            return true;
        }

        private bool HasColumnBingo(int y)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!Board.GetValueOrDefault((i, y)).isChecked)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
