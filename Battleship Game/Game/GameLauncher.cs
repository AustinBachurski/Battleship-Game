using Battleship_Game.IO;
using Battleship_Game.Players;

namespace Battleship_Game.Game
{
    public static class GameLauncher
    {
        public static void Run()
        {
            Display.WelcomeMessage();

            Game game = new Game(
                PlayerFactory.GetPlayerType(1),   // Player 1.
                PlayerFactory.GetPlayerType(2));  // Player 2.

            game.Play();
        }
    }
}