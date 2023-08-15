using Battleship_Game.Game;
using Battleship_Game.IO;
using Battleship_Game.Objects;

namespace Battleship_Game.Players
{
    public class HumanPlayer : IPlayer
    {
        public bool isHuman { get { return true; } }
        public int GetTarget()
        {
            string? coordinates = null;

            while (true)
            {
                Display.EnterCoordinates();
                coordinates = Console.ReadLine().ToUpper();

                if (!string.IsNullOrEmpty(coordinates) && IsValidCoordinate(coordinates))
                {
                    return Change.ToIndex(coordinates);
                }
                Display.InvalidCoordinatesWarning(coordinates);
            }
        }

        public void PlaceShip(Ship ship, PlayerData data)
        {
            bool shipPlaced = false;

            while (!shipPlaced)
            {
                Console.Clear();
                Display.Grid(data.shipGrid);
                Display.PlaceInstructions(ship, data);

                ship.coordinates = GetTarget();
                ship.orientation = GetInput.ShipOrientation();

                shipPlaced = ShipPlacement.TryToPlace(ship, data.shipGrid, isHuman);

                if (!shipPlaced)
                {
                    GetInput.AnyKey();
                }
            }
        }

        public bool SatisfiedWithPlacement(char[] grid)
        {
            Console.Clear();
            Display.Grid(grid);
            Display.SatisfiedWithLayout();
            char key;

            while (true)
            {
                key = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (key == 'Y')
                {
                    return true;
                }
                else if (key == 'N')
                {
                    return false;
                }
                Display.InvalidKey(key);
            }
        }

        private bool IsValidCoordinate(string target)
        {
            if (target[0] >= 'A' && target[0] <= 'J')
            {
                if (target.Length == 2)
                {
                    return target[1] <= '9' && target[1] >= '1';
                }
                else if (target.Length == 3)
                {
                    return target[1] == '1' && target[2] == '0';

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}