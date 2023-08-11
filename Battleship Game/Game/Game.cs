using Battleship_Game.IO;
using Battleship_Game.Objects;
using Battleship_Game.Players;
using System.Numerics;

namespace Battleship_Game.Game
{
    public class Game
    {
        IPlayer _playerOne;
        IPlayer _playerTwo;

        PlayerData _playerOneData;
        PlayerData _playerTwoData;

        private readonly Ship[] _ships = {
                                        new Ship(ShipType.AircraftCarrier),
                                        new Ship(ShipType.Battleship),
                                        new Ship(ShipType.Cruiser),
                                        new Ship(ShipType.Submarine),
                                        new Ship(ShipType.Destroyer) };

        public Game(IPlayer playerOne, IPlayer playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _playerOneData = new PlayerData(playerOne.isHuman);
            _playerTwoData = new PlayerData(playerTwo.isHuman);
        }

        public void Play()
        {
            SetPlayerNames();
            PlaceShips();

            while (true)
            {
                Display.ResultsOf(PlayerOneTurn());
                if (_playerTwoData.isDead)
                {
                    Display.GameOver(_playerOneData.name, _playerTwoData.name);
                    GetInput.Exit();
                    break;
                }
                GetInput.AnyKey();

                Display.ResultsOf(PlayerTwoTurn());
                if (_playerOneData.isDead)
                {
                    Display.GameOver(_playerTwoData.name, _playerOneData.name);
                    GetInput.Exit();
                    break;
                }
                GetInput.AnyKey();
            }
        }

        private ShotResult PlayerOneTurn()
        {
            int target = -1;

            do
            {
                Console.Clear();
                Display.Grid(_playerOneData.shotHistory);
                Display.PlayerData(_playerTwoData);
                Display.YourTurn(_playerOneData.name);

                target = _playerOne.GetTarget();

            } while (!_playerOneData.IsValidTarget(target));

            Display.ShotFired(_playerOneData.name, target);
            ShotResult result = _playerTwoData.GetShotResult(target);
            _playerOneData.SetHistory(result, target);

            return result;
        }

        private ShotResult PlayerTwoTurn()
        {
            int target = -1;

            do
            {
                Console.Clear();
                Display.Grid(_playerTwoData.shotHistory);
                Display.PlayerData(_playerOneData);
                Display.YourTurn(_playerTwoData.name);

                target = _playerTwo.GetTarget();

            } while (!_playerTwoData.IsValidTarget(target));

            Display.ShotFired(_playerTwoData.name, target);
            ShotResult result = _playerOneData.GetShotResult(target);
            _playerTwoData.SetHistory(result, target);

            return result;
        }

        private void SetPlayerNames()
        {
            _playerOneData.name = GetInput.PlayerName(1);
            _playerTwoData.name = GetInput.PlayerName(2);
        }

        private void PlaceShips()
        {
            do
            {
                _playerOneData.ResetShipPlacement();

                foreach (Ship ship in _ships)
                {
                        Display.Grid(_playerOneData.shipGrid);
                        _playerOne.PlaceShip(ship, _playerOneData);

                }
            } while (!_playerOne.SatisfiedWithPlacement(_playerOneData.shipGrid));

            do
            {
                _playerTwoData.ResetShipPlacement();

                foreach (Ship ship in _ships)
                {
                    Display.Grid(_playerTwoData.shipGrid);
                    _playerTwo.PlaceShip(ship, _playerTwoData);

                }
            } while (!_playerTwo.SatisfiedWithPlacement(_playerTwoData.shipGrid));
        }











    }
}