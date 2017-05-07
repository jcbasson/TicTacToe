using TicTacToeJC.Enums;

namespace TicTacToeJC.Entities
{
    public class GameMaster
    {
        public Player CurrentPlayersTurn { get; private set; }
        public static Player[] Players = new Player[2];

        public GameMaster(Player startingPlayer, Player otherPlayer)
        {
            CurrentPlayersTurn = startingPlayer;
            Players[0] = startingPlayer;
            Players[1] = otherPlayer;
        }

        public void SetNextPlayersTurn()
        {
           if(Players[0].State == CurrentPlayersTurn.State)
            {
                CurrentPlayersTurn = Players[1];
            }
           else
            {
                CurrentPlayersTurn = Players[0];
            }
        }

        public Player GetWinningPlayer(Board board)
        {
            foreach(Player player in Players)
            {
                if (CheckBoardFor3StraightHorizontal(board, player.State)
                    || CheckBoardFor3StraightVertical(board, player.State)
                    || CheckBoardFor3StraightDiagonalTopToBottom(board, player.State)
                    || CheckBoardFor3StraightDiagonalTopToBottom(board, player.State)) return player;
            }

            return null;
        }

        private bool CheckBoardFor3StraightHorizontal(Board board, State playersState)
        {
            for(int row = 0; row < Board.Rows; row++ )
            {
                bool found3Straight = true;
                for(int column = 0; column < Board.Columns; column++)
                {
                    State stateAt = board.GetState(new Location(row, column));

                    if(stateAt != playersState)
                    {
                        found3Straight = false;
                        break;
                    }
                }
                if (found3Straight) return true;
            }
            return false;
        }

        private bool CheckBoardFor3StraightVertical(Board board, State playersState)
        {
            for (int column = 0; column < Board.Columns; column++)
            {
                bool found3Straight = true;
                for (int row = 0; row < Board.Rows; row++)
                {
                    State stateAt = board.GetState(new Location(row, column));

                    if (stateAt != playersState)
                    {
                        found3Straight = false;
                        break;
                    }
                }
                if (found3Straight) return true;
            }
            return false;
        }

        private bool CheckBoardFor3StraightDiagonalTopToBottom(Board board, State playersState)
        {
            Location[] diagonalLocations = new Location[] { new Location(0, 0), new Location(1, 1), new Location(2, 2) };
            foreach (Location location in diagonalLocations)
            {
                State stateAt = board.GetState(location);

                if(stateAt != playersState)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckBoardFor3StraightDiagonalBottomToTop(Board board, State playersState)
        {
            Location[] diagonalLocations = new Location[] { new Location(0, 2), new Location(1, 1), new Location(2, 0) };
            foreach (Location location in diagonalLocations)
            {
                State stateAt = board.GetState(location);

                if (stateAt != playersState)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
