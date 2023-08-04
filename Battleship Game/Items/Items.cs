namespace Battleship_Game.Items
{
    public struct Ship
    {
        public Ship(ShipType shipType, int shipSize, int shipCoordinates = -1, Orientation shipOrientation = Orientation.Void)
        {
            type = shipType;
            size = shipSize;
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
    }

    public enum Orientation
    {
        Horizontal,
        Vertical,
        Void,
    }

    public enum Player
    {
        One,
        Two,
        Both,
    }

    public enum ShipType
    {
        AircraftCarrier,
        Battleship,
        Cruiser,
        Destroyer,
        Submarine,
    }

    public enum ShotResult
    {
        Missed,
        Hit,
        TryAgain,
        Sunk,
    }
}
