namespace Battleship_Game.Objects
{
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
        Playing,
        Missed,
        Hit,
        TryAgain,
        Sunk,
        Win,
    }
}