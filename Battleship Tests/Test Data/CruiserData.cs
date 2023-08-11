using Battleship_Game.IO;
using Battleship_Game.Objects;
using NUnit.Framework;

namespace Battleship_Tests.Test_Data
{
    internal static class CruiserData
    {
        private static SuccessfulCase h = new SuccessfulCase("F4", new char[] {
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', 'C', 'C', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', });

        private static SuccessfulCase v = new SuccessfulCase("A8", new char[] {
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'C', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'C', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'C', 'S', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', });

        internal static IEnumerable<TestCaseData> Test
        {
            get
            {
                yield return new TestCaseData(new Ship(ShipType.Cruiser, Change.ToIndex("A1"), Orientation.Horizontal), false, TestItem.Grid()); // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.Cruiser, Change.ToIndex("I4"), Orientation.Horizontal), false, TestItem.Grid()); // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.Cruiser, Change.ToIndex(h.coordinate), Orientation.Horizontal), true, h.grid);  // SUCCESS.
                yield return new TestCaseData(new Ship(ShipType.Cruiser, Change.ToIndex("B6"), Orientation.Vertical), false, TestItem.Grid()); // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.Cruiser, Change.ToIndex("A9"), Orientation.Vertical), false, TestItem.Grid()); // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.Cruiser, Change.ToIndex(v.coordinate), Orientation.Vertical), true, v.grid);  // SUCCESS.
            }
        }
    }
}
