using Battleship_Game.IO;

namespace Battleship_Game.Players
{
    public static class PlayerFactory
    {
        public static IPlayer GetPlayerType(int playerNumber)
        {
            char choice;

            while (true)
            {
                Display.SelectPlayerType(playerNumber);
                choice = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (choice == 'H')
                {
                    return new HumanPlayer();
                }
                else if (choice == 'C')
                {
                    return new ComputerPlayer();
                }
                else
                {
                    Display.InvalidKey(choice);
                }
            }
        }
    }
}