using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class CharacterEquationsTests
    {
        [TestMethod]
        public void ComputeBasicTacticalMovementRateForVaryingAgilities()
        {

            CharacterEquations.ComputeBasicTacticalMovementRate(3, Race.Human).Should().Be(2);
            CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Human).Should().Be(5);
            CharacterEquations.ComputeBasicTacticalMovementRate(26, Race.Human).Should().Be(8);
        }

        [TestMethod]
        public void ComputeBasicTacticalMovementRateForVaryingRaces()
        {
            CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Human).Should().Be(5);
            CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Dwarf).Should().Be(4);
            CharacterEquations.ComputeBasicTacticalMovementRate(15, Race.Elf).Should().Be(6);
        }

        [Ignore]
        [TestMethod]
        public void Test()
        {
            ////CharacterEquations.ComputeModifiedManualDexterity(20, null /* objects for shield*/);
        }


    }
}