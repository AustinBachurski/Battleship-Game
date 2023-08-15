using Battleship_Game.IO;
using Battleship_Game.Objects;
using NUnit.Framework;

namespace Battleship_Tests.Test_Data
{
    internal static class AircraftCarrierData
    {
        private static SuccessfulCase horizontalCase = new SuccessfulCase("B1", new char[] {
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

        private static SuccessfulCase verticalCase = new SuccessfulCase("H4", new char[] {
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
                // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier,
                    Change.ToIndex("D1"), Orientation.Horizontal), false, TestItem.Grid());

                // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier,
                    Change.ToIndex("G4"), Orientation.Horizontal), false, TestItem.Grid());

                // FAIL: Overlap.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier,
                    Change.ToIndex("D5"), Orientation.Vertical), false, TestItem.Grid());

                // FAIL: Out of bounds.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier,
                    Change.ToIndex("H8"), Orientation.Vertical), false, TestItem.Grid());

                // SUCCESS.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier,
                    Change.ToIndex(horizontalCase.coordinate), Orientation.Horizontal),
                    true, horizontalCase.grid);

                // SUCCESS.
                yield return new TestCaseData(new Ship(ShipType.AircraftCarrier,
                    Change.ToIndex(verticalCase.coordinate), Orientation.Vertical),
                    true, verticalCase.grid);
            }
        }
    }
}
