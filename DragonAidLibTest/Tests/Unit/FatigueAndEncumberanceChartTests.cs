using System;
using System.Collections.Generic;
using System.Text;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class FatigueAndEncumberanceChartTests
    {
        [TestMethod]
        public void MinimumStrengthShouldBeEncumberedByEvenASmallWeight()
        {
            FatigueAndEncumberanceChart.Lookup(2, 1m).AgilityModifier.Should().Be(-3);
        }

        [TestMethod]
        public void MaximumStrengthShouldNotBeEncumberedByASmallWeight()
        {
            FatigueAndEncumberanceChart.Lookup(26, 28m).AgilityModifier.Should().Be(0);
        }

        [TestMethod]
        public void MaximumStrengthShouldBeEncumberedALotByAHugeWeight()
        {
            FatigueAndEncumberanceChart.Lookup(26, 219).AgilityModifier.Should().Be(-12);
        }

        [TestMethod]
        public void EncumberanceShouldOnlyIncreaseAsWeightIncreases()
        {
            for (int strength = 2; strength <= 26; strength++)
            {
                int penalty = int.MaxValue;
                for (int weight = 0; weight < 220; weight++)
                {
                    int computed = FatigueAndEncumberanceChart.Lookup(strength, weight).AgilityModifier;
                    computed.Should().BeLessOrEqualTo(penalty);
                    penalty = computed;
                }
            }
        }
    }
}