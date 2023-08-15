using Battleship_Game.IO;
using Battleship_Game.Objects;
using NUnit.Framework;

namespace Battleship_Tests.Test_Data
{
    internal static class DestroyerData
    {
        private static SuccessfulCase horizontalCase = new SuccessfulCase("I1", new char[] {
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', 'D', 'D',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', });

        private static SuccessfulCase verticalCase = new SuccessfulCase("A9", new char[] {
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'D', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'D', 'S', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', });

        internal static IEnumerable<TestCaseData> Test
        {
            get
            {
                // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.Destroyer,
                    Change.ToIndex("A5"), Orientation.Horizontal), false, TestItem.Grid());

                // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.Destroyer,
                    Change.ToIndex("J1"), Orientation.Horizontal), false, TestItem.Grid());

                // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.Destroyer,
                    Change.ToIndex("G5"), Orientation.Vertical), false, TestItem.Grid());

                // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.Destroyer,
                    Change.ToIndex("A10"), Orientation.Vertical), false, TestItem.Grid());

                // SUCCESS.
                yield return new TestCaseData(new Ship(ShipType.Destroyer,
                    Change.ToIndex(horizontalCase.coordinate), Orientation.Horizontal),
                    true, horizontalCase.grid);

                // SUCCESS.
                yield return new TestCaseData(new Ship(ShipType.Destroyer,
                    Change.ToIndex(verticalCase.coordinate), Orientation.Vertical),
                    true, verticalCase.grid);
            }
        }
    }
}