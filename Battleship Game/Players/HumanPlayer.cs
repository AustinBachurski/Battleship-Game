using Battleship_Game.Game;
using Battleship_Game.IO;
using Battleship_Game.Items;

namespace Battleship_Game.Players
{
    public class HumanPlayer : IPlayer
    {
        public int GetTarget()
        {
            string? coordinates = null;

            while (true)
            {
                Console.Write("\tEnter target coordinates (ex: A5): ");
                coordinates = Console.ReadLine().ToUpper();

                if (!string.IsNullOrEmpty(coordinates) && IsValidCoordinate(coordinates))
                {
                    return ConvertCoordinatesToIndex(coordinates);
                }
                Console.WriteLine($"\n\t'{coordinates}' is not a valid option, please try again.");
            }
        }

        private Orientation GetOrientation()
        {
            while (true)
            {
                Console.Write("\tEnter the orientation you want to place the ship - (V)ertical or (H)orizontal: ");
                char key = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (key == 'V')
                {
                    return Orientation.Vertical;
                }
                else if (key == 'H')
                {
                    return Orientation.Horizontal;
                }
                Console.WriteLine($"\n\t'{key}' is not a valid option, please try again.");
            }
        }

        private int ConvertCoordinatesToIndex(string coordinates)
        {
            int yIndex = (int.Parse(coordinates.Substring(1)) - 1) * 10;
            int xIndex = (int)coordinates[0] - 65;

            return xIndex + yIndex;
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

        public void PlaceShip(Ship ship, char[] grid)
        {
            bool shipPlaced = false;

            while (!shipPlaced)
            {
                Console.Clear();
                Display.Grid(grid);
                Console.WriteLine($"\tPlace your {ship.type} on the grid!  {ship.type}s are {ship.size} squares in length.");

                ship.coordinates = GetTarget();
                ship.orientation = GetOrientation();

                shipPlaced = GameLogic.TryToPlace(ship, grid);
                
                if(!shipPlaced)
                {
                    Input.WaitForKeyPress();
                }
            }
        }

        public bool SatisfiedWithPlacement(char[] grid)
        {
            Console.Clear();
            Display.Grid(grid);
            Console.WriteLine("\tAre you satisfied with your layout? (Y)es or (N)o: ");
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
                Console.WriteLine($"\t'{key}' is not valid, I need a Y or an N please.");
            }
        }
    }
}