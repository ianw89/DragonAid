using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using DragonAid.Lib.Util;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class EquationPrettyTextWriterTests
    {
        private readonly EquationPrettyTextWriter _testSubject = new EquationPrettyTextWriter();

        [TestMethod]
        public void EquationThatIsJustOneAttribute()
        {
            Write(c => c.MagicalAptitude).Should().Be("MA");
        }

        [TestMethod]
        public void EquationThatIsJustRank()
        {
            Write((c,s) => c.SpellRanks[s]).Should().Be("Rank");
        }

        [TestMethod]
        public void EquationThatIsJustOneConstant()
        {
            Write(c => 5).Should().Be("5");
        }

        [TestMethod]
        public void EquationThatIsMultiplication()
        {
            Write(c => 5 * c.MagicalAptitude).Should().Be("5 * MA");
        }

        [TestMethod]
        public void EquationThatIsSubtraction()
        {
            Write(c => c.MagicalAptitude - 15).Should().Be("MA - 15");
        }

        [TestMethod]
        public void EquationThatIsAddition()
        {
            Write(c => c.MagicalAptitude + 15).Should().Be("MA + 15");
        }

        [TestMethod]
        public void EquationThatIsIsDeepShouldHaveParentheses()
        {
            Write(c => 3 * (c.MagicalAptitude - 15)).Should().Be("3 * (MA - 15)");
        }

        [TestMethod]
        public void SpellCastChanceEquationBaseline()
        {
            Write(CharacterEquations.CastChance).Should().Be("BaseChance + (MA - 15) + (3 * Rank)");
        }

        private string Write(Expression<Func<Character, int>> expr)
        {
            return _testSubject.Write(expr);
        }

        private string Write(Expression<Func<Character, Spell, int>> expr)
        {
            return _testSubject.Write(expr);
        }
    }
}