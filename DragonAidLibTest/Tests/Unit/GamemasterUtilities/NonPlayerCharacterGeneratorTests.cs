﻿using System.Linq;
using DragonAid.Lib.Data.Model;
using DragonAid.Lib.GamemasterUtilities;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit.GamemasterUtilities
{
    [TestClass]
    public class NonPlayerCharacterGeneratorTests
    {
        [TestMethod]
        public void GeneratorShouldFillInAllCharacteristics()
        {
            var template = new NonPlayerCharacterTemplate
                {
                    PhysicalStrengthRange = new CharacteristicRangeTemplate(10, 10),
                    ManualDexterityRange = new CharacteristicRangeTemplate(10, 10),
                    AgilityRange = new CharacteristicRangeTemplate(10, 10),
                    EnduranceRange = new CharacteristicRangeTemplate(10, 10),
                    FatigueRange = new CharacteristicRangeTemplate(10, 10),
                    MagicalAptitudeRange = new CharacteristicRangeTemplate(10, 10),
                    PerceptionRange = new CharacteristicRangeTemplate(10, 10),
                    PhysicalBeautyRange = new CharacteristicRangeTemplate(10, 10),
                    WillpowerRange = new CharacteristicRangeTemplate(10, 10),
                };
            
            var result = this.RunGeneratorTest(template);

            result.PhysicalStrength.Should().Be(10);
            result.ManualDexterity.Should().Be(10);
            result.Agility.Should().Be(10);
            result.Endurance.Should().Be(10);
            result.Fatigue.Should().Be(10);
            result.MagicalAptitude.Should().Be(10);
            result.Perception.Should().Be(10);
            result.PhysicalBeauty.Should().Be(10);
            result.Willpower.Should().Be(10);
        }

        [TestMethod]
        public void GeneratorShouldGiveAtLeastOneWeaponRank()
        {
            var template = new NonPlayerCharacterTemplate
                {
                    PhysicalStrengthRange = new CharacteristicRangeTemplate(15, 15),
                    ManualDexterityRange = new CharacteristicRangeTemplate(15, 15),
                    AgilityRange = new CharacteristicRangeTemplate(10, 10),
                    EnduranceRange = new CharacteristicRangeTemplate(10, 10),
                    FatigueRange = new CharacteristicRangeTemplate(10, 10),
                    MagicalAptitudeRange = new CharacteristicRangeTemplate(10, 10),
                    PerceptionRange = new CharacteristicRangeTemplate(10, 10),
                    PhysicalBeautyRange = new CharacteristicRangeTemplate(10, 10),
                    WillpowerRange = new CharacteristicRangeTemplate(10, 10),
                };
            
            var result = this.RunGeneratorTest(template);

            result.WeaponRanks.Count().Should().BeGreaterOrEqualTo(1);
        }

        private Character RunGeneratorTest(NonPlayerCharacterTemplate template)
        {
            var generator = new NonPlayerCharacterGenerator();
            return generator.GenerateFromTemplate(template);
        }
    }
}