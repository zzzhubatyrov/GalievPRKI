using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI
{
    public class SudokuBoard
    {
        private int[,] _board;

        public SudokuBoard(int[,] initialBoard)
        {
            _board = initialBoard;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(_board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public Memento Save()
        {
            return new Memento((int[,])_board.Clone());
        }

        public void Restore(Memento memento)
        {
            _board = memento.GetState();
        }

        public void MakeMove(int row, int col, int value)
        {
            _board[row, col] = value;
        }
    }

    public class Memento
    {
        private int[,] _state;

        public Memento(int[,] state)
        {
            _state = state;
        }

        public int[,] GetState()
        {
            return _state;
        }
    }

    public class GameHistory
    {
        private Stack<Memento> _history = new Stack<Memento>();

        public void SaveState(Memento memento)
        {
            _history.Push(memento);
        }

        public Memento Undo()
        {
            if (_history.Count == 0)
            {
                return null;
            }
            return _history.Pop();
        }
    }
}
