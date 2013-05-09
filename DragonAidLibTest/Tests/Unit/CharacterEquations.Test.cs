using DragonAidLib.Data;
using DragonAidLib.Data.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAidLibTest.Tests.Unit
{
    [TestClass]
    public class CharacterEquationsTests
    {
        [TestMethod]
        public void ComputeBasicTacticalMovementRateForVaryingAgilities()
        {
            Assert.AreEqual(2, CharacterEquations.ComputeBasicTacticalMovementRate(3, Race.Human));
            Assert.AreEqual(5, CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Human));
            Assert.AreEqual(8, CharacterEquations.ComputeBasicTacticalMovementRate(26, Race.Human));
        }

        [TestMethod]
        public void ComputeBasicTacticalMovementRateForVaryingRaces()
        {
            Assert.AreEqual(5, CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Human));
            Assert.AreEqual(4, CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Dwarf));
            Assert.AreEqual(6, CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Elf));
        }
    }
}