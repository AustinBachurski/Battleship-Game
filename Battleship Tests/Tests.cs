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
    }
}