using Battleship_Game.IO;
using Battleship_Game.Items;
using Battleship_Game.Players;

namespace Battleship_Game.Game
{
    public class Game
    {
        IPlayer _playerOne;
        IPlayer _playerTwo;

        private char[] _playerOneShipGrid = new char[100];
        private char[] _playerOneDisplay = new char[100];

        private char[] _playerTwoShipGrid = new char[100];
        private char[] _playerTwoDisplay = new char[100];

        private readonly Ship[] ships = {
                                        new Ship(ShipType.AircraftCarrier, 5),
                                        new Ship(ShipType.Battleship, 4),
                                        new Ship(ShipType.Cruiser, 3),
                                        new Ship(ShipType.Submarine, 3),
                                        new Ship(ShipType.Destroyer, 2) };

        public Game(IPlayer playerOne, IPlayer playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;

            ClearGrids();
        }

        public void Play()
        {
            PlaceShips();

            while (true)
            {

            }
        }
        
        private void PlaceShips()
        {
            do // Player One.
            {
                Array.Fill(_playerOneShipGrid, ' ');

                foreach (Ship ship in ships)
                {
                    Display.Grid(_playerOneShipGrid);
                    _playerOne.PlaceShip(ship, _playerOneShipGrid);
                }

            } while (!_playerOne.SatisfiedWithPlacement(_playerOneShipGrid));

            do // Player Two.
            {
                Array.Fill(_playerTwoShipGrid, ' ');

                foreach (Ship ship in ships)
                {
                    _playerTwo.PlaceShip(ship, _playerTwoShipGrid);
                }

            } while (!_playerTwo.SatisfiedWithPlacement(_playerTwoShipGrid));
        }

        private void ClearGrids(Player player = Player.Both)
        {
                Array.Fill(_playerOneDisplay, ' ');
                Array.Fill(_playerTwoDisplay, ' ');
        }
    }
}
