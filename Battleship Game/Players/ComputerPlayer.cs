﻿using Battleship_Game.Objects;
using Battleship_Game.Game;

namespace Battleship_Game.Players
{
    public class ComputerPlayer : IPlayer
    {
        public bool isHuman { get { return false; } }

        private Random _random;

        public ComputerPlayer()
        {
            _random = new Random();
        }

        public int GetTarget()
        {
            return _random.Next(100);
        }

        public void PlaceShip(Ship ship, PlayerData data)
        {
            bool shipPlaced = false;

            while (!shipPlaced)
            {
                ship.coordinates = _random.Next(100);
                ship.orientation = _random.Next(0, 2) == 0 ? Orientation.Horizontal : Orientation.Vertical;
                shipPlaced = GameLogic.TryToPlace(ship, data.shipGrid, false);
            }
        }

        public bool SatisfiedWithPlacement(char[] grid)
        {
            return true;
        }
    }
}