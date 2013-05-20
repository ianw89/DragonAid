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

            return CharacterEquations.ComputeCastChance(character.MagicalAptitude, character.GetSpellRank(spell), spell.BaseChance);
        }

        public static SpellcastResult SpellcastResult(this Character character, Spell spell, int roll)
        {
            return character.SpellcastResultRange(spell).GetResult(roll);
        }

        private static SpellcastResultRange SpellcastResultRange(this Character character, Spell spell)
        {
            return SpellcastResultRangeCalculator.Calculate(character.CastChance(spell));
        }

        private static int GetSpellRank(this Character character, Spell spell)
        {
            Contract.Requires(character != null);
            Contract.Requires(spell != null);

            if (character.Spells == null)
            {
                throw new InvalidOperationException("Character has no spell!");
            }

            if (character.Spells.All(s => s.Spell != spell))
            {
                throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, "Character has no ranks in {0}!", spell.FullName));
            }

            return character.Spells.Single(s => s.Spell == spell).Rank;
        }
    }
}