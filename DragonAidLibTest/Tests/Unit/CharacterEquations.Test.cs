using System;
using System.Collections.Generic;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class CharacterEquationsTests
    {
        private readonly Spell fakeSpell = new Spell("FakeSpell", 0);

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

        [TestMethod]
        public void SpellCastChanceShouldBeBaseChanceIfNotRankedOrGreatAtMagic()
        {
            CharacterEquations.ComputeCastChance(15, 0, 10).Should().Be(10);
        }

        [TestMethod]
        public void BetterMagicalAptitudeShouldIncreaseSpellCastChance()
        {
            CharacterEquations.ComputeCastChance(20, 0, 10).Should().Be(15);
        }

        [TestMethod]
        public void WorseMagicalAptitudeShouldIncreaseSpellCastChance()
        {
            CharacterEquations.ComputeCastChance(10, 0, 10).Should().Be(5);
        }

        [TestMethod]
        public void HigherRankShouldIncreaseSpellCastChance()
        {
            CharacterEquations.ComputeCastChance(15, 3, 10).Should().Be(19);
        }

        [TestMethod]
        public void ComputeCastChanceShouldThrowIfCharacterHasNoSpells()
        {
            Action getCastChance = () => new Character().CastChance(fakeSpell);
            getCastChance.ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void ComputeCastChanceShouldThrowIfCharacterHasNoRankInSpell()
        {
            Action getCastChance = () => new Character {Spells = new List<CharacterSpellInfo>()}.CastChance(fakeSpell);
            getCastChance.ShouldThrow<InvalidOperationException>();
        }
    }
}