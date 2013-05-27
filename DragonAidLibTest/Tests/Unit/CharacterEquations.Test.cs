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
        private readonly Spell fakeSpell = new Spell("FakeSpell", 10);

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
            var c = new Character { MagicalAptitude = 15 };
            c.SpellRanks[this.fakeSpell] = 0;
            CharacterEquations.ComputeCastChance(c, this.fakeSpell).Should().Be(10);
        }

        [TestMethod]
        public void BetterMagicalAptitudeShouldIncreaseSpellCastChance()
        {
            var c = new Character { MagicalAptitude = 20 };
            c.SpellRanks[this.fakeSpell] = 0;
            CharacterEquations.ComputeCastChance(c, this.fakeSpell).Should().Be(15);
        }

        [TestMethod]
        public void WorseMagicalAptitudeShouldIncreaseSpellCastChance()
        {
            var c = new Character { MagicalAptitude = 10 };
            c.SpellRanks[this.fakeSpell] = 0;
            CharacterEquations.ComputeCastChance(c, this.fakeSpell).Should().Be(5);
        }

        [TestMethod]
        public void HigherRankShouldIncreaseSpellCastChance()
        {
            var c = new Character { MagicalAptitude = 15 };
            c.SpellRanks[this.fakeSpell] = 3;
            CharacterEquations.ComputeCastChance(c, this.fakeSpell).Should().Be(19);
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
            Action getCastChance = () => new Character().CastChance(fakeSpell);
            getCastChance.ShouldThrow<InvalidOperationException>();
        }
    }
}