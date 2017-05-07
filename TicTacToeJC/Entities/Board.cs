using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeJC.Enums;

namespace TicTacToeJC.Entities
{
    public class Board
    {
        private State[,] States;
        public const int Rows = 3;
        public const int Columns = 3;

        public Board()
        {
            States = new State[3, 3];
        }

        public State GetState(Location location)
        {
            return States[location.Row, location.Column];
        }

        public void SetState(Location location, State state)
        {
            States[location.Row, location.Column] = state;
        }

        public bool CheckIfLocationIsSelected( Location location)
        {
            return States[location.Row, location.Column] != State.Undecided;
        }

        public bool hasMovesLeft()
        {
            for (int row = 0; row < Board.Rows; row++)
            {
                for (int column = 0; column < Board.Columns; column++)
                {
                    if (GetState(new Location(row, column)) == State.Undecided) return true;
                }
            }
            return false;
        }

        public void Render()
        {
            char[,] symbols = new char[3, 3];
            for (int row = 0; row < 3; row++)
                for (int column = 0; column < 3; column++)
                    symbols[row, column] = SymbolFor(GetState(new Location(row, column)));

            Console.WriteLine($" {symbols[0, 0]} | {symbols[0, 1]} | {symbols[0, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {symbols[1, 0]} | {symbols[1, 1]} | {symbols[1, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {symbols[2, 0]} | {symbols[2, 1]} | {symbols[2, 2]} ");
        }

        private char SymbolFor(State state)
        {
            switch (state)
            {
                case State.O: return 'O';
                case State.X: return 'X';
                default: return ' ';
            }
        }
    }
}
