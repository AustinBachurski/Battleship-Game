using Battleship_Game.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Battleship_Game.Objects
{
    public struct Ship
    {
        public Ship(ShipType shipType, int shipCoordinates = -1, Orientation shipOrientation = Orientation.Void)
        {
            type = shipType;
            size = SetSize();
            coordinates = shipCoordinates;
            orientation = shipOrientation;
        }

        public ShipType type;
        public int size;
        public int coordinates;
        public Orientation orientation;

        public char ToChar
        {
            get
            {
                switch (type)
                {
                    case ShipType.AircraftCarrier:
                        return 'A';

                    case ShipType.Battleship:
                        return 'B';

                    case ShipType.Cruiser:
                        return 'C';

                    case ShipType.Submarine:
                        return 'S';

                    case ShipType.Destroyer:
                        return 'D';

                    default:
                        throw new InvalidDataException("Ship.type was invalid!");
                }
            }
        }

        private int SetSize()
        {
            switch(type)
            {
                case ShipType.AircraftCarrier:
                    return 5;

                case ShipType.Battleship:
                    return 4;

                case ShipType.Cruiser:
                    return 3;

                case ShipType.Submarine:
                    return 3;

                case ShipType.Destroyer:
                    return 2;

                default:
                    throw new InvalidDataException("Ship.type was invalid!");
            }
        }
    }

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
                    Display.InvalidCoordinates(target);
                    GetInput.AnyKey();
                }
                return false;
            }
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

        public void ResetShipPlacement()
        {
            Array.Fill(shipGrid, ' ');
        }
    }
}
