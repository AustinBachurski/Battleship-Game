using Battleship_Game.IO;

namespace Battleship_Game.Objects
{
    public class PlayerData
    {
        public string name;
        public bool isHuman;
        public char[] shipGrid;
        public char[] shotHistory;
        private int[] hitpoints;

        public int shipsRemaining
        {
            get
            {
                return hitpoints.Count(shipHitpoints => shipHitpoints > 0);
            }
        }

        public int totalHitpoints
        {
            get
            {
                return hitpoints.Sum();
            }
        }

        public bool isDead
        {
            get
            {
                return hitpoints.All(shipHitpoints => shipHitpoints == 0);
            }
        }

        public PlayerData(bool humanPlayer)
        {
            name = "";
            isHuman = humanPlayer;
            shipGrid = new char[100];
            shotHistory = new char[100];
            hitpoints = new int[5];

            Array.Fill(shotHistory, ' ');

            hitpoints[(int)ShipType.AircraftCarrier] = 5;
            hitpoints[(int)ShipType.Battleship] = 4;
            hitpoints[(int)ShipType.Cruiser] = 3;
            hitpoints[(int)ShipType.Submarine] = 3;
            hitpoints[(int)ShipType.Destroyer] = 2;
        }

        public ShotResult GetShotResult(int target)
        {
            switch (shipGrid[target])
            {
                case ' ':
                    return ShotResult.Missed;

                case 'A':
                    return --hitpoints[(int)ShipType.AircraftCarrier] == 0 ? ShotResult.Sunk : ShotResult.Hit;

                case 'B':
                    return --hitpoints[(int)ShipType.Battleship] == 0 ? ShotResult.Sunk : ShotResult.Hit;

                case 'C':
                    return --hitpoints[(int)ShipType.Cruiser] == 0 ? ShotResult.Sunk : ShotResult.Hit;

                case 'S':
                    return --hitpoints[(int)ShipType.Submarine] == 0 ? ShotResult.Sunk : ShotResult.Hit;

                case 'D':
                    return --hitpoints[(int)ShipType.Destroyer] == 0 ? ShotResult.Sunk : ShotResult.Hit;

                default:
                    throw new InvalidDataException("Value passed to switch in GetShotResult() was invalid!");
            }
        }

        public bool IsValidTarget(int target)
        {
            if (shotHistory[target] == ' ')
            {
                return true;
            }
            else
            {
                if (isHuman)
                {
                    Display.InvalidCoordinatesWarning(target);
                    GetInput.AnyKey();
                }
                return false;
            }
        }

        public void ResetShipPlacement()
        {
            Array.Fill(shipGrid, ' ');
        }

        public void SetHistory(ShotResult result, int target)
        {
            if (result == ShotResult.Missed)
            {
                shotHistory[target] = '░';
            }
            else
            {
                shotHistory[target] = '☼';
            }
        }
    }
}