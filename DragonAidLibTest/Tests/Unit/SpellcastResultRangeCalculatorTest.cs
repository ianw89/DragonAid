using System.Collections.Generic;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class SpellcastResultRangeCalculatorTest
    {
        [TestMethod]
        public void BackfireRangeStartsSomewhere()
        {
            SpellcastResultRangeCalculator.Calculate(10).Backfire.Should().Be(40);
        }

        [TestMethod]
        public void DoubleEffectRangeStartsSomewhere()
        {
            SpellcastResultRangeCalculator.Calculate(60).DoubleEffect.Should().Be(9);
        }

        [TestMethod]
        public void TripleEffectRangeStartsSomewhere()
        {
            SpellcastResultRangeCalculator.Calculate(60).TripleEffect.Should().Be(3);
        }
    }
}