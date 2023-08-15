using Battleship_Game.Objects;

namespace Battleship_Game.Players
{
    public interface IPlayer
    {
        public bool isHuman { get; }
        public int GetTarget();
        public void PlaceShip(Ship ship, PlayerData data);
        bool SatisfiedWithPlacement(char[] grid);
    }
}