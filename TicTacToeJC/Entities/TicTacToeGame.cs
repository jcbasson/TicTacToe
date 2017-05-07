using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeJC.Entities
{
    public class TicTacToeGame
    {
         public  GameMaster Master { get; private set; }
         public Board Board { get; private set; }

        public TicTacToeGame(GameMaster gameMaster , Board board)
        {
            Master = gameMaster;
            Board = board;
        }
    }
}
