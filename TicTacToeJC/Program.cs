using System;
using TicTacToeJC.Entities;
using TicTacToeJC.Enums;

namespace TicTacToeJC
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerO = new Player(State.O, "PlayerO");
            Player playerX = new Player(State.X, "PlayerX");
            Board board = new Board();
            GameMaster gameMaster = new GameMaster(playerO, playerX);
            Player winningPlayer = null;

            while (board.hasMovesLeft())
            {
                Player currentPlayersTurn = gameMaster.CurrentPlayersTurn;
                currentPlayersTurn.MakesPlay(board);
                board.Render();

                winningPlayer = gameMaster.GetWinningPlayer(board);
                if(winningPlayer != null) break;
              
                gameMaster.SetNextPlayersTurn();
            }   
            if(winningPlayer == null)
            {
                Console.WriteLine("Game is a DRAW!");
            }
            else
            {
                Console.WriteLine($"CONGRATULATIONS {winningPlayer.Name}!");
            }
            Console.ReadLine();
        }
    }
}