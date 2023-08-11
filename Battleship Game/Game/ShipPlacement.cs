using Battleship_Game.IO;
using Battleship_Game.Objects;

namespace Battleship_Game.Game
{
    public static class ShipPlacement
    {
        public static bool TryToPlace(Ship ship, char[] grid, bool humanPlayer)
        {
            int[] gridSquares = PlacementPoints(ship);

            if (gridSquares.Any(x => x < 0 || x > 99))
            {
                if (humanPlayer)
                {
                    Console.WriteLine("\nShips must be placed within the pounds of the exercise, try again.\n");
                }
                return false;
            }

            if (gridSquares.All(x => grid[x] == ' '))
            {
                foreach (int i in gridSquares)
                {
                    grid[i] = ship.ToChar;
                }
                return true;
            }
            else
            {
                if (humanPlayer)
                {
                    Console.WriteLine("\nShips cannot overlap one another, please try again.\n");
                }
                return false;
            }
        }

        private static int[] PlacementPoints(Ship ship)
        {
            int[] gridSquares = new int[ship.size];
            Array.Fill(gridSquares, -1);
            int insert = 0;

            if (ship.orientation == Orientation.Horizontal)
            {
                if ((ship.coordinates % 10) + ship.size <= 10)
                {
                    for (int i = ship.coordinates; i < ship.coordinates + ship.size; ++i)
                    {
                        gridSquares[insert] = i;
                        ++insert;
                    }
                    return gridSquares;
                }
                else
                {
                    return gridSquares;
                }
            }
            else if (ship.orientation == Orientation.Vertical)
            {
                if ((ship.coordinates / 10) + ship.size <= 10)
                {
                    for (int i = ship.coordinates; i < ship.coordinates + (ship.size * 10); i += 10)
                    {
                        gridSquares[insert] = i;
                        ++insert;
                    }
                    return gridSquares;
                }
                else
                {
                    return gridSquares;
                }
            }
            else
            {
                // TODO: Implement Diagonal
                return gridSquares;
            }
        }
    }
}