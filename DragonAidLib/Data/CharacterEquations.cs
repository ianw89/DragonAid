using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq.Expressions;
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

        public static readonly Expression<Func<Character, Spell, int>> CastChance =
            (Character c, Spell s) => s.BaseChance + (c.MagicalAptitude - 15) + (3 * c.SpellRanks[s]);

        private static readonly Lazy<Func<Character, Spell, int>> CompiledCastChance = new Lazy<Func<Character, Spell, int>>(() => CastChance.Compile()); 

        public static int ComputeCastChance(Character character, Spell spell)
        {
            Contract.Requires(character != null);
            Contract.Requires(spell != null);
            return CompiledCastChance.Value(character, spell);
        }

        public static int ComputeEffectiveAgility(Character character)
        {
            Contract.Requires(character != null);
            decimal totalWeight = character.Inventory.TotalWeight;
            if (totalWeight > 0)
            {
                // TODO: use real formula!!!
                if (character.PhysicalStrength > 10)
                {
                    return character.Agility - 1;
                }
                
                if (character.PhysicalStrength > 5)
                {
                    return character.Agility - 2;
                }

                return character.Agility - 3;
            }

            return character.Agility;
        }
    }
}