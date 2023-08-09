using Battleship_Game.Objects;

namespace Battleship_Game.Players
{
    public interface IPlayer
    {
        public bool isHuman { get; }
        public void PlaceShip(Ship ship, PlayerData data);
        public int GetTarget();
        bool SatisfiedWithPlacement(char[] grid);
    }
}
