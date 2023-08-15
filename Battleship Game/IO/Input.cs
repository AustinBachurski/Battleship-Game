using Battleship_Game.Objects;

namespace Battleship_Game.IO
{
    public static class GetInput
    {
        public static void AnyKey()
        {
            Console.WriteLine("\n\tPress any key to continue...");
            Console.ReadKey();
        }

        public static void Exit()
        {
            Console.WriteLine("\n\tPress any key to exit...");
            Console.ReadKey();
        }

        public static string PlayerName(int playerNumber)
        {
            string? name;

            while (true)
            {
                Console.Write($"Enter the name of player {playerNumber}: ");
                name = Console.ReadLine();

                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }
                Console.WriteLine("\nI can't address you as 'Commander Nothing' now can I?");
            }
        }

        public static Orientation ShipOrientation()
        {
            while (true)
            {
                Display.SelectOrientation();
                char key = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (key == 'V')
                {
                    return Orientation.Vertical;
                }
                else if (key == 'H')
                {
                    return Orientation.Horizontal;
                }
                Display.InvalidKey(key);
            }
        }
    }
}