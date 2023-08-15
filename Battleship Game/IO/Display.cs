using Battleship_Game.Objects;

namespace Battleship_Game.IO
{
    public static class Display
    {
        public static void EnterCoordinates()
        {
            Console.Write("\tEnter target coordinates (ex: A5): ");
        }

        public static void GameOver(string winner, string loser)
        {
            Console.WriteLine($"\n\t{winner} has won the battle by sinking all of {loser}'s ships!");
        }

        public static void Grid(char[] grid)
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine(
                  "\t         A     B     C     D     E     F     G     H     I     J     \n"
                + "\t    ╔════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩════╗\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + $"\t 1 ═╣ │  {grid[0 ]}  │  {grid[1 ]}  │  {grid[2 ]}  │  {grid[3 ]}  │  {grid[4 ]}  │  {grid[5 ]}  │  {grid[6 ]}  │  {grid[7 ]}  │  {grid[8 ]}  │  {grid[9 ]}  │ ║\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + $"\t 2 ═╣ │  {grid[10]}  │  {grid[11]}  │  {grid[12]}  │  {grid[13]}  │  {grid[14]}  │  {grid[15]}  │  {grid[16]}  │  {grid[17]}  │  {grid[18]}  │  {grid[19]}  │ ║\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + $"\t 3 ═╣ │  {grid[20]}  │  {grid[21]}  │  {grid[22]}  │  {grid[23]}  │  {grid[24]}  │  {grid[25]}  │  {grid[26]}  │  {grid[27]}  │  {grid[28]}  │  {grid[29]}  │ ║\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + $"\t 4 ═╣ │  {grid[30]}  │  {grid[31]}  │  {grid[32]}  │  {grid[33]}  │  {grid[34]}  │  {grid[35]}  │  {grid[36]}  │  {grid[37]}  │  {grid[38]}  │  {grid[39]}  │ ║\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + $"\t 5 ═╣ │  {grid[40]}  │  {grid[41]}  │  {grid[42]}  │  {grid[43]}  │  {grid[44]}  │  {grid[45]}  │  {grid[46]}  │  {grid[47]}  │  {grid[48]}  │  {grid[49]}  │ ║\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + $"\t 6 ═╣ │  {grid[50]}  │  {grid[51]}  │  {grid[52]}  │  {grid[53]}  │  {grid[54]}  │  {grid[55]}  │  {grid[56]}  │  {grid[57]}  │  {grid[58]}  │  {grid[59]}  │ ║\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + $"\t 7 ═╣ │  {grid[60]}  │  {grid[61]}  │  {grid[62]}  │  {grid[63]}  │  {grid[64]}  │  {grid[65]}  │  {grid[66]}  │  {grid[67]}  │  {grid[68]}  │  {grid[69]}  │ ║\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + $"\t 8 ═╣ │  {grid[70]}  │  {grid[71]}  │  {grid[72]}  │  {grid[73]}  │  {grid[74]}  │  {grid[75]}  │  {grid[76]}  │  {grid[77]}  │  {grid[78]}  │  {grid[79]}  │ ║\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + $"\t 9 ═╣ │  {grid[80]}  │  {grid[81]}  │  {grid[82]}  │  {grid[83]}  │  {grid[84]}  │  {grid[85]}  │  {grid[86]}  │  {grid[87]}  │  {grid[88]}  │  {grid[89]}  │ ║\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + $"\t10 ═╣ │  {grid[90]}  │  {grid[91]}  │  {grid[92]}  │  {grid[93]}  │  {grid[94]}  │  {grid[95]}  │  {grid[96]}  │  {grid[97]}  │  {grid[98]}  │  {grid[99]}  │ ║\n"
                + "\t    ║─┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─║\n"
                + "\t    ╚═══════════════════════════════════════════════════════════════╝\n");
        }

        public static void InvalidCoordinatesWarning(int index)
        {
            Console.WriteLine($"\n\tYou already fired a shot at '{Change.ToCoordinates(index)}', choose a different target.");
        }

        public static void InvalidCoordinatesWarning(string coordinates)
        {
            Console.WriteLine($"\n\t'{coordinates}' is not a valid option, please try again.");
        }

        public static void InvalidKey(char key)
        {
            Console.WriteLine($"\n\t'{key}' is not a valid option, please try again.");
        }

        public static void OutOfBoundsWarning()
        {
            Console.WriteLine("\n\tShips must be placed within the bounds of the exercise, try again.");
        }

        public static void OverlapWarning()
        {
            Console.WriteLine("\nShips cannot overlap one another, please try again.");
        }

        public static void PlaceInstructions(Ship ship, PlayerData data)
        {
            Console.WriteLine($"\t{data.name}, place your {ship.type} on the grid!  {ship.type}s are {ship.size} squares in length.");
        }
        public static void PlacementInformation()
        {
            char[] example = {
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };

            Grid(example);

            Console.WriteLine("\tShip placement is done by selecting a grid square, and then an orientation.");
            Console.WriteLine("\tShips are placed top to bottom or left to right from the selected grid square.");
            Console.WriteLine("\n\tIn the example above:");
            Console.WriteLine("\t\tThe Aircraft Carrier was placed at \"A1\" with \"Vertical\" orientation,");
            Console.WriteLine("\t\tand the Battleship was placed at \"D6\" with \"Horizontal\" orientation.");
            GetInput.AnyKey();
        }

        public static void PlayerData(PlayerData data)
        {
            Console.WriteLine($"\t{data.name} has "
                + $"{data.shipsRemaining} ships remaining with "
                + $"{data.totalHitpoints} {(data.totalHitpoints > 1 ? "hits" : "hit")} left.");
        }

        public static void ResultsOf(ShotResult result)
        {
            switch (result)
            {
                case ShotResult.Missed:
                    Console.WriteLine("\tSplash!  The shot missed...");
                    break;

                case ShotResult.Hit:
                    Console.WriteLine("\tBoom!  They hit something!");
                    break;

                case ShotResult.Sunk:
                    Console.WriteLine("\tBoom! Gurgle! The ship is sunk!");
                    break;
            }
        }

        public static void SatisfiedWithLayout()
        {
            Console.WriteLine("\tAre you satisfied with your layout? (Y)es or (N)o: ");
        }

        public static void SelectOrientation()
        {
            Console.Write("\tEnter the orientation you want to place the ship - (V)ertical or (H)orizontal: ");
        }

        public static void SelectPlayerType(int playerNumber)
        {
            Console.Write($"Is player {playerNumber} a (H)uman or a (C)omputer? ");
        }

        public static void ShotFired(string name, int target)
        {
            Console.WriteLine($"\t{name} fires a shot at {Change.ToCoordinates(target)}!");
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship!\n");
        }

        public static void YourTurn(string name)
        {
            Console.WriteLine($"\t{name}'s turn.");
        }
    }
}