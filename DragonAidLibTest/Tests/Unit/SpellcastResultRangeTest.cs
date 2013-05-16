using System.Collections.Generic;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class SpellcastResultRangeTest
    {
        private readonly SpellcastResultRange testSubject = new SpellcastResultRange()
            {
                TripleEffect = 5,
                DoubleEffect = 10,
                Backfire = 15,
            };

        [TestMethod]
        public void MatchingBackfireChanceIsBackfire()
        {
            testSubject.GetResult(testSubject.Backfire).Should().Be(SpellcastResult.Backfire);
        }

        [TestMethod]
        public void ExceedingBackfireChanceIsBackfire()
        {
            testSubject.GetResult(testSubject.Backfire + 1).Should().Be(SpellcastResult.Backfire);
        }

        [TestMethod]
        public void MatchingDoubleEffectChanceIsDoubleEffect()
        {
            testSubject.GetResult(testSubject.DoubleEffect).Should().Be(SpellcastResult.DoubleEffect);
        }

        [TestMethod]
        public void LessThanDoubleEffectChanceButMoreThanTripleEffectIsDoubleEffect()
        {
            testSubject.GetResult(testSubject.DoubleEffect - 1).Should().Be(SpellcastResult.DoubleEffect);
        }

        [TestMethod]
        public void MatchingTriplleEffectChanceIsTripleEffect()
        {
            testSubject.GetResult(testSubject.TripleEffect).Should().Be(SpellcastResult.TripleEffect);
        }

        [TestMethod]
        public void LessThanTripleEffectChanceIsTripleEffect()
        {
            testSubject.GetResult(testSubject.TripleEffect - 1).Should().Be(SpellcastResult.TripleEffect);
        }

        [TestMethod]
        public void BetweenDoubleAndBackfireIsNormal()
        {
            testSubject.GetResult(testSubject.Backfire - 1).Should().Be(SpellcastResult.Normal);
        }
    }
}