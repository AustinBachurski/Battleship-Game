using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Game.IO
{
    public static class Change
    {
        public static int ToIndex(string coordinates)
        {
            int yIndex = (int.Parse(coordinates.Substring(1)) - 1) * 10;
            int xIndex = (int)coordinates[0] - 65;

            return xIndex + yIndex;
        }

        public static string ToCoordinates(int index)
        {
            char x = (char)(index / 10 + 65);
            string y = (index % 10).ToString();

            return x + y;
        }
    }
}
