using DragonAidLib.Data;
using DragonAidLib.Data.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAidLibTest.Data
{
    [TestClass]
    public class CharacterEquationsTest
    {
        [TestMethod]
        public void ComputeBasicTacticalMovementRate_VaryingAgilities()
        {
            Assert.AreEqual(2, CharacterEquations.ComputeBasicTacticalMovementRate(3, Race.Human));
            Assert.AreEqual(5, CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Human));
            Assert.AreEqual(8, CharacterEquations.ComputeBasicTacticalMovementRate(26, Race.Human));
        }

        [TestMethod]
        public void ComputeBasicTacticalMovementRate_VaryingRaces()
        {
            Assert.AreEqual(5, CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Human));
            Assert.AreEqual(4, CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Dwarf));
            Assert.AreEqual(6, CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Elf));
        }
    }
}