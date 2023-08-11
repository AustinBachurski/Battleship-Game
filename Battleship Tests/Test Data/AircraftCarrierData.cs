using Battleship_Game.IO;
using Battleship_Game.Objects;
using NUnit.Framework;

namespace Battleship_Tests.Test_Data
{
    internal static class AircraftCarrierData
    {
        private static SuccessfulCase h = new SuccessfulCase("B1", new char[] {
                'A', 'A', 'A', 'A', 'A', 'A', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', ' ', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', });

        private static SuccessfulCase v = new SuccessfulCase("H4", new char[] {
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'C', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'A', ' ', ' ',
                'A', ' ', ' ', ' ', ' ', ' ', ' ', 'A', ' ', ' ',
                ' ', ' ', ' ', 'B', 'B', 'B', 'B', 'A', ' ', ' ',
                ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'A', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', 'A', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
                ' ', 'S', ' ', ' ', ' ', ' ', ' ', ' ', 'D', 'D', });

        internal static IEnumerable<TestCaseData> Test
        {
            get
            {
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier, Change.ToIndex("D1"), Orientation.Horizontal), false, TestItem.Grid()); // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier, Change.ToIndex("G4"), Orientation.Horizontal), false, TestItem.Grid()); // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier, Change.ToIndex(h.coordinate), Orientation.Horizontal), true, h.grid);  // SUCCESS.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier, Change.ToIndex("D5"), Orientation.Vertical), false, TestItem.Grid()); // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier, Change.ToIndex("H8"), Orientation.Vertical), false, TestItem.Grid()); // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier, Change.ToIndex(v.coordinate), Orientation.Vertical), true, v.grid);  // SUCCESS.
            }
        }
    }
}
