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
            SpellcastResultRangeCalculator.Calculate(10).Backfire.Should().Be(30);
        }

        [TestMethod]
        public void DoubleEffectRangeStartsSomewhere()
        {
            SpellcastResultRangeCalculator.Calculate(30).DoubleEffect.Should().Be(10);
        }

        [TestMethod]
        public void TripleEffectRangeStartsSomewhere()
        {
            SpellcastResultRangeCalculator.Calculate(50).TripleEffect.Should().Be(10);
        }
    }
}