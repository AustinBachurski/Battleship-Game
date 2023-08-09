using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Game.IO
{
    public static class GetInput
    {
        public static void AnyKey()
        {
            Console.WriteLine("\t\nPress any key to continue...");
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

        public static void Exit()
        {
            Console.WriteLine("\t\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}