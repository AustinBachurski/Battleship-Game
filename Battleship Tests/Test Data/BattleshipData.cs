using Battleship_Game.IO;
using Battleship_Game.Objects;
using NUnit.Framework;

namespace Battleship_Tests.Test_Data
{
    internal static class BattleshipData
    {
        private static SuccessfulCase horizontalCase = new SuccessfulCase("E9", new char[] {
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', });

        private static SuccessfulCase verticalCase = new SuccessfulCase("I1", new char[] {
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', 'B', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', 'B', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', 'B', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'B', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', });

        internal static IEnumerable<TestCaseData> Test
        {
            get
            {
                // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.Battleship,
                    Change.ToIndex("B8"), Orientation.Horizontal), false, TestItem.Grid());

                // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.Battleship,
                    Change.ToIndex("H9"), Orientation.Horizontal), false, TestItem.Grid());

                // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.Battleship,
                    Change.ToIndex("J7"), Orientation.Vertical), false, TestItem.Grid());

                // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.Battleship,
                    Change.ToIndex("A8"), Orientation.Vertical), false, TestItem.Grid());

                // SUCCESS.
                yield return new TestCaseData(new Ship(ShipType.Battleship,
                Change.ToIndex(horizontalCase.coordinate), Orientation.Horizontal),
                    true, horizontalCase.grid);

                // SUCCESS.
                yield return new TestCaseData(new Ship(ShipType.Battleship,
                    Change.ToIndex(verticalCase.coordinate), Orientation.Vertical),
                    true, verticalCase.grid);                                               
            }
        }
    }
}
