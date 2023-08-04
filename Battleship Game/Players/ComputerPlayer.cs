using Battleship_Game.Items;
using Battleship_Game.Game;

namespace Battleship_Game.Players
{
    public class ComputerPlayer : IPlayer
    {
        private Random random;

        public ComputerPlayer()
        {
            random = new Random();
        }

        public int GetTarget()
        {
            return random.Next(100);
        }

        public void PlaceShip(Ship ship, char[] grid)
        {
            bool shipPlaced = false;

            while (!shipPlaced)
            {
                ship.coordinates = random.Next(100);
                ship.orientation = random.Next(0, 2) == 0 ? Orientation.Horizontal : Orientation.Vertical;
                shipPlaced = GameLogic.TryToPlace(ship, grid, false);
            }
        }

        public bool SatisfiedWithPlacement(char[] grid)
        {
            return true;
        }
    }
}