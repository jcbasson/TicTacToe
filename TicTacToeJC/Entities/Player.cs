using System;
using TicTacToeJC.Enums;

namespace TicTacToeJC.Entities
{
    public class Player
    {
        public State State { get; private set; }
        public string Name { get; private set; }

        public Player(State state, string playerName)
        {
            State = state;
            Name = playerName;
        }

        public void MakesPlay(Board board)
        {           
            Location locationSelected = null;
            bool isLocationSelected = true;
            
            while(isLocationSelected)
            {
                int intState = ForceValidLocationSelection();
                locationSelected = TranslateSelectionToLocation(intState);
                isLocationSelected = board.CheckIfLocationIsSelected(locationSelected);
            }
            
            if (locationSelected != null)
            board.SetState(locationSelected, State);
        }

        public int ForceValidLocationSelection()
        {
            string strState = string.Empty;
            int intState;
            while (!Int32.TryParse(strState, out intState) || intState > 9 || intState < 1)
            {
                Console.Write($"{Name} please enter a value between 1 and 9 that is not selected : ");
                strState = Console.ReadLine();
            }
            return intState;
        }

        public Location TranslateSelectionToLocation(int selection)
        {
            Location reciprocalLocation = null;
            switch (selection)
            {
                case 1:
                    reciprocalLocation = new Location(0, 0);
                    break;
                case 2:
                    reciprocalLocation = new Location(0, 1);
                    break;
                case 3:
                    reciprocalLocation = new Location(0, 2);
                    break;
                case 4:
                    reciprocalLocation = new Location(1, 0);
                    break;
                case 5:
                    reciprocalLocation = new Location(1, 1);
                    break;
                case 6:
                    reciprocalLocation = new Location(1, 2);
                    break;
                case 7:
                    reciprocalLocation = new Location(2, 0);
                    break;
                case 8:
                    reciprocalLocation = new Location(2, 1);
                    break;
                case 9:
                    reciprocalLocation = new Location(2, 2);
                    break;
            }
            return reciprocalLocation;
        }
    }
}
