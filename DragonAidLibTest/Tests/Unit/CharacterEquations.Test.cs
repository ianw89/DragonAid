using System;
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
        private readonly Item _heavyItem = new Item("Lead weight", 50);

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

        [TestMethod]
        public void EffectiveAgilityShouldBeAffectedByInventoryWeight()
        {
            var c = new Character { Agility = 10, PhysicalStrength = 10, Inventory = { WeaponLibrary.Mattock } };
            CharacterEquations.ComputeEffectiveAgility(c).Should().BeLessThan(c.Agility);
        }

        [TestMethod]
        public void EffectiveAgilityShouldNotBeAffectedIfInventoryIsEmptyAndStrengthIsReasonably()
        {
            var c = new Character { Agility = 10, PhysicalStrength = 15 };
            CharacterEquations.ComputeEffectiveAgility(c).Should().Be(c.Agility);
        }

        [TestMethod]
        public void EffectOfWeightOnAgilityIsLessForStrongerCharacter()
        {
            var c = new Character { Agility = 10, PhysicalStrength = 10, Inventory = { _heavyItem } };
            var withMediumStrength = CharacterEquations.ComputeEffectiveAgility(c);
            c.PhysicalStrength += 5;
            CharacterEquations.ComputeEffectiveAgility(c).Should().BeGreaterThan(withMediumStrength);
        }

        [TestMethod]
        public void EffectOfWeightOnAgilityIsMoreForWeakerCharacter()
        {
            var c = new Character { Agility = 10, PhysicalStrength = 10, Inventory = { _heavyItem } };
            var withMediumStrength = CharacterEquations.ComputeEffectiveAgility(c);
            c.PhysicalStrength -= 5;
            CharacterEquations.ComputeEffectiveAgility(c).Should().BeLessThan(withMediumStrength);
        }

        [TestMethod]
        public void HeavierItemsAffectAgilityMoreThanLightOnes()
        {
            var withHeavyItem = new Character { Agility = 10, PhysicalStrength = 10, Inventory = { _heavyItem } };
            var withDagger = new Character { Agility = 10, PhysicalStrength = 10, Inventory = { WeaponLibrary.Dagger } };
            CharacterEquations.ComputeEffectiveAgility(withHeavyItem).Should().BeLessThan(CharacterEquations.ComputeEffectiveAgility(withDagger));
        }

        [TestMethod]
        public void CarryingStuffSlowsCharacterDown()
        {
            var c = new Character { Agility = 10, PhysicalStrength = 10, Race = Race.Human };
            var tmr = c.TacticalMovementRate();
            c.Inventory.Add(_heavyItem);
            c.TacticalMovementRate().Should().BeLessThan(tmr);
        }

        [TestMethod]
        public void ArmorAffectsAgility()
        {
            var c = new Character { Agility = 10, PhysicalStrength = 15, EquippedArmor = new Armor("A straightjacket", -10, 0) };
            c.EffectiveAgility().Should().Be(0);
        }

        // ///////////////////////////////////////////////
        // Strike Chance
        // ///////////////////////////////////////////////

        [TestMethod]
        public void ForUnrankedStrikeChanceIsJustBaseChance()
        {
            var w = new Weapon("Bat", 1m, 30, WeaponKind.Melee, 10);
            var c = new Character { ManualDexterity = 20 };
            // No ranks added to character
            CharacterEquations.ComputeStrikeChance(c, w).Should().Be(30);
        }
        
        [TestMethod]
        public void StrikeChanceStartsWithBaseChanceIfRanked()
        {
            var w = new Weapon("Bat", 1m, 30, WeaponKind.Melee, 10);
            var c = new Character { ManualDexterity = 0 };
            c.WeaponRanks[w] = 0;
            CharacterEquations.ComputeStrikeChance(c, w).Should().Be(30);
        }

        [TestMethod]
        public void DexterityAffectsStrikeChanceIfRanked()
        {
            var w = new Weapon("Bat", 1m, 30, WeaponKind.Melee, 10);
            var c = new Character { ManualDexterity = 20 };
            c.WeaponRanks[w] = 0;
            CharacterEquations.ComputeStrikeChance(c, w).Should().Be(50);
        }

        [TestMethod]
        public void RankAffectsStrikeChance()
        {
            var w = new Weapon("Bat", 1m, 30, WeaponKind.Melee, 10);
            var c = new Character { ManualDexterity = 0 };
            c.WeaponRanks[w] = 3;
            CharacterEquations.ComputeStrikeChance(c, w).Should().Be(42);
        }
    }
}