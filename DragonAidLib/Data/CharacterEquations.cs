using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public static class CharacterEquations
    {
        public static int ComputeBasicTacticalMovementRate(int agility, Race race)
        {
            Contract.Requires(race != null);

            int tmr;

            if (agility > 25)
                tmr = 8;
            else if (agility > 21)
                tmr = 7;
            else if (agility > 17)
                tmr = 6;
            else if (agility > 12)
                tmr = 5;
            else if (agility > 8)
                tmr = 4;
            else if (agility > 4)
                tmr = 3;
            else tmr = 2;

            return tmr + race.TacticalMovementRateModifier;
        }

        public static int TacticalMovementRate(this Character character)
        {
            return ComputeBasicTacticalMovementRate(character.Agility, character.Race);
        }

#if !DRAGON_COMMANDER
        public static int ComputeCastChance(this Character character, Spell spell)
        {
            Contract.Requires(character != null);
            Contract.Requires(spell != null);

            return ComputeCastChance(character.MagicalAptitude, character.GetSpellRank(spell), spell.BaseChance);
        }

        public static int ComputeCastChance(int magicalAptitude, int rank, int spellBaseChance)
        {
            return spellBaseChance + (magicalAptitude - 15) + (3 * rank);
        }

        private static int GetSpellRank(this Character character, Spell spell)
        {
            Contract.Requires(character != null);
            Contract.Requires(spell != null);

            if (character.Spells == null)
            {
                throw new InvalidOperationException("Character has no spell!");
            }

            int rank;
            if (!character.Spells.TryGetValue(spell.FullName, out rank))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Character has no ranks in {0}!", spell.FullName));
            }

            return rank;
        }
#endif
    }
}