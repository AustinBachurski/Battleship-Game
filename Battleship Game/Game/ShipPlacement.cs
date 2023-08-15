using Battleship_Game.IO;
using Battleship_Game.Objects;

namespace Battleship_Game.Game
{
    public static class ShipPlacement
    {
        public static bool TryToPlace(Ship ship, char[] grid, bool humanPlayer)
        {
            int[] gridSquares = PlacementPoints(ship);

            if (InvalidPlacementPoint(gridSquares))
            {
                if (humanPlayer)
                {
                    Display.OutOfBoundsWarning();
                }
                return false;
            }

            if (SpacesAreEmpty(gridSquares, grid))
            {
                foreach (int i in gridSquares)
                {
                    grid[i] = ship.ToChar; // Place ship on grid.
                }
                return true;
            }
            else
            {
                if (humanPlayer)
                {
                    Display.OverlapWarning();
                }
                return false;
            }
        }

        private static bool FallsWithinHorizontalBounds(Ship ship)
        {
            return (ship.coordinates % 10) + ship.size <= 10;
        }

        private static bool FallsWithinVerticalBounds(Ship ship)
        {
            return (ship.coordinates / 10) + ship.size <= 10;
        }

        private static bool InvalidPlacementPoint(int[] gridSquares)
        {
            return gridSquares.Any(x => x == -1);
        }

        private static int[] PlacementPoints(Ship ship)
        {
            int[] gridSquares = new int[ship.size];

            Array.Fill(gridSquares, -1); // Fill with invalid value, if value is unchanged
                                         // when returned, placement request is invalid.

            int insertionIndex = 0;

            if (ship.orientation == Orientation.Horizontal)
            {
                if (FallsWithinHorizontalBounds(ship))
                {
                    for (int i = ship.coordinates; i < ship.coordinates + ship.size; ++i)
                    {
                        gridSquares[insertionIndex] = i;
                        ++insertionIndex;
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
                if (FallsWithinVerticalBounds(ship))
                {
                    for (int i = ship.coordinates; i < ship.coordinates + (ship.size * 10); i += 10)
                    {
                        gridSquares[insertionIndex] = i;
                        ++insertionIndex;
                    }
                    return gridSquares;
                }
                else
                {
                    return gridSquares;
                }
            }
        }

        private static bool SpacesAreEmpty(int[] gridSquares, char[] grid)
        {
            return gridSquares.All(x => grid[x] == ' ');
        }
    }
}