using Battleship_Game.IO;
using Battleship_Game.Objects;
using NUnit.Framework;

namespace Battleship_Tests.Test_Data
{
    internal static class SubmarineData
    {
        private static SuccessfulCase h = new SuccessfulCase("H4", new char[] {
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'S', 'S', 'S',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', });

        private static SuccessfulCase v = new SuccessfulCase("D7", new char[] {
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ', ' ',
                ' ', ' ', ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', });

        internal static IEnumerable<TestCaseData> Test
        {
            get
            {
                yield return new TestCaseData(new Ship(ShipType.Submarine, Change.ToIndex("H10"), Orientation.Horizontal), false, TestItem.Grid()); // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.Submarine, Change.ToIndex("I2"), Orientation.Horizontal), false, TestItem.Grid()); // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.Submarine, Change.ToIndex(h.coordinate), Orientation.Horizontal), true, h.grid);  // SUCCESS.
                yield return new TestCaseData(new Ship(ShipType.Submarine, Change.ToIndex("G5"), Orientation.Vertical), false, TestItem.Grid()); // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.Submarine, Change.ToIndex("E9"), Orientation.Vertical), false, TestItem.Grid()); // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.Submarine, Change.ToIndex(v.coordinate), Orientation.Vertical), true, v.grid);  // SUCCESS.
            }
        }
    }
}
