using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeJC.Entities
{
    public class Location
    {
        public int Column { get;}
        public int Row { get;}

        public Location(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
