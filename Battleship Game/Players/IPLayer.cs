using Battleship_Game.Items;

namespace Battleship_Game.Players
{
    public interface IPlayer
    {
        public void PlaceShip(Ship ship, char[] grid);
        public int GetTarget();
        bool SatisfiedWithPlacement(char[] grid);
    }
}
