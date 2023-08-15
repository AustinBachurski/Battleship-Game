namespace Battleship_Game.Objects
{
    public struct Ship
    {
        public Ship(ShipType shipType, int shipCoordinates = -1, Orientation shipOrientation = Orientation.Void)
        {
            type = shipType;
            size = SetSize(shipType);
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

        private int SetSize(ShipType shipType)
        {
            switch (shipType)
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
                    throw new InvalidDataException("shipType was invalid!");
            }
        }
    }
}