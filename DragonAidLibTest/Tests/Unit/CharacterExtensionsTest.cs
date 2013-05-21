using System.Collections.Generic;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class CharacterExtensionsTest
    {
        private readonly Character character = new Character { MagicalAptitude = 17 };
        private readonly Spell spell = new Spell("Fireball", 20);

        public CharacterExtensionsTest()
        {
            // give him some ranks!
            character.Spells.Add(new CharacterSpellInfo(spell, 5, character));
        }

        [TestMethod]
        public void ComputeCastChanceExtensionTest()
        {
            character.CastChance(spell).Should().Be(20 + (17 - 15) + (3*5));
        }

        [TestMethod]
        public void SpellcastResultIsBackire()
        {
            character.SpellcastResult(spell, 10000).Should().Be(SpellcastResult.Backfire);
        }

        [TestMethod]
        public void SpellcastResultIsTripleEffect()
        {
            character.SpellcastResult(spell, 1).Should().Be(SpellcastResult.TripleEffect);
        }
    }
}