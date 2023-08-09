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
                Console.Write($"Is player {playerNumber} a (H)uman or a (C)omputer? ");
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

                Console.WriteLine($"\"{choice}\" is not a valid option, please try again.\n");
            }
        }
    }
}