using Battleship_Game.Objects;
using NUnit.Framework;

namespace Battleship_Tests.Test_Data
{
    public class NearlySunk
    {
        public PlayerData data = new PlayerData(false);
        private int[] targets = { 0, 10, 20, 30, 7, 17, 53, 54, 55, 71, 81, 98 };


        public NearlySunk()
        {
            /*
             * Initialize ship grid, then leave each ship at 1 hp
             * and record the shot history for grid validation.
             */
            data.shipGrid = TestItem.Grid();

            foreach (int target in targets)
            {
                ShotResult result = data.GetShotResult(target);
                data.SetHistory(result, target);
            }
        }
    }

    internal static class SunkData
    {
        private static SuccessfulCase carrier = new SuccessfulCase("A5", new char[] {
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', '☼', '☼', '☼', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', });

        private static SuccessfulCase battleship = new SuccessfulCase("G6", new char[] {
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', '☼', '☼', '☼', '☼', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', });

        private static SuccessfulCase cruiser = new SuccessfulCase("H3", new char[] {
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', '☼', '☼', '☼', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', });

        private static SuccessfulCase submarine = new SuccessfulCase("B10", new char[] {
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', '☼', '☼', '☼', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', });

        private static SuccessfulCase destroyer = new SuccessfulCase("J10", new char[] {
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', '☼', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', '☼', '☼', '☼', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', '☼', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '☼', '☼', });

        internal static IEnumerable<TestCaseData> Test
        {
            get
            {
                // Carrier Sunk.
                yield return new TestCaseData(
                    new NearlySunk(), carrier.coordinate, ShotResult.Sunk, carrier.grid);

                // Battleship Sunk.
                yield return new TestCaseData(
                    new NearlySunk(), battleship.coordinate, ShotResult.Sunk, battleship.grid);

                // Cruiser Sunk.
                yield return new TestCaseData(
                    new NearlySunk(), cruiser.coordinate, ShotResult.Sunk, cruiser.grid);

                // Submarine Sunk.
                yield return new TestCaseData(
                    new NearlySunk(), submarine.coordinate, ShotResult.Sunk, submarine.grid);

                // Destroyer Sunk.
                yield return new TestCaseData(
                    new NearlySunk(), destroyer.coordinate, ShotResult.Sunk, destroyer.grid);
            }
        }
    }
}