using Battleship_Game.IO;
using Battleship_Game.Objects;
using Battleship_Game.Game;
using Battleship_Tests.Test_Data;
using NUnit.Framework;

namespace Battleship_Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCaseSource(typeof(AircraftCarrierData), nameof(AircraftCarrierData.Test))]
        [TestCaseSource(typeof(BattleshipData), nameof(BattleshipData.Test))]
        [TestCaseSource(typeof(CruiserData), nameof(CruiserData.Test))]
        [TestCaseSource(typeof(SubmarineData), nameof(SubmarineData.Test))]
        [TestCaseSource(typeof(DestroyerData), nameof(DestroyerData.Test))]
        public void Placement(Ship ship, bool expectedResult, char[] expectedGrid)
        {
            char[] testGrid = TestItem.Grid();

            bool result = ShipPlacement.TryToPlace(ship, testGrid, false);

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedGrid, testGrid);
        }

        [TestCaseSource(typeof(HitData), nameof(HitData.Test))]
        [TestCaseSource(typeof(MissData), nameof(MissData.Test))]
        public void HitAndMiss(PlayerData data, string target, ShotResult expectedResult, char[] expectedGrid)
        {
            data.shipGrid = TestItem.Grid();
            ShotResult result = data.GetShotResult(Change.ToIndex(target));
            data.SetHistory(result, Change.ToIndex(target));

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedGrid, data.shotHistory);
        }

        [TestCaseSource(typeof(SunkData), nameof(SunkData.Test))]
        public void Sunk(NearlySunk sinkTest, string target, ShotResult expectedResult, char[] expectedGrid)
        {
            ShotResult result = sinkTest.data.GetShotResult(Change.ToIndex(target));
            sinkTest.data.SetHistory(result, Change.ToIndex(target));

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedGrid, sinkTest.data.shotHistory);
        }

        [TestCase("A1", 0)]
        [TestCase("B2", 11)]
        [TestCase("C3", 22)]
        [TestCase("D4", 33)]
        [TestCase("E5", 44)]
        [TestCase("F6", 55)]
        [TestCase("G7", 66)]
        [TestCase("H8", 77)]
        [TestCase("I9", 88)]
        [TestCase("J10", 99)]
        public void CoordinateToIndexConversion(string coordinate, int expected)
        {
            int result = Change.ToIndex(coordinate);

            Assert.AreEqual(expected, result);
        }

        [TestCase(0, "A1")]
        [TestCase(11, "B2")]
        [TestCase(22, "C3")]
        [TestCase(33, "D4")]
        [TestCase(44, "E5")]
        [TestCase(55, "F6")]
        [TestCase(66, "G7")]
        [TestCase(77, "H8")]
        [TestCase(88, "I9")]
        [TestCase(99, "J10")]
        public void IndexToCoordinateConversion(int index, string expected)
        {
            string result = Change.ToCoordinates(index);

            Assert.AreEqual(expected, result);
        }
    }
}