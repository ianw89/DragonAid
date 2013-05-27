using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public static class CharacterExtensions
    {
        public static int TacticalMovementRate(this Character character)
        {
            Contract.Requires(character != null);
            return CharacterEquations.ComputeBasicTacticalMovementRate(character.Agility, character.Race);
        }

        public static int CastChance(this Character character, Spell spell)
        {
            Contract.Requires(character != null);
            Contract.Requires(spell != null);

            return CharacterEquations.ComputeCastChance(character, spell);
        }

        public static SpellcastResult SpellcastResult(this Character character, Spell spell, int roll)
        {
            return character.SpellcastResultRange(spell).GetResult(roll);
        }

        private static SpellcastResultRange SpellcastResultRange(this Character character, Spell spell)
        {
            return SpellcastResultRangeCalculator.Calculate(character.CastChance(spell));
        }
    }
}