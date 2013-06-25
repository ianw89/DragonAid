using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
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
            decimal totalWeight = character.Inventory.GetWeightForSet(character.Inventory.EquiptedSetName);
            var agility = character.Agility;

            if (character.EquippedArmor != null)
            {
                agility += character.EquippedArmor.AgilityModifier;
            }

            agility += FatigueAndEncumberanceChart.Lookup(character.PhysicalStrength, totalWeight).AgilityModifier;

            return agility;
        }

        public static readonly Expression<Func<Character, Weapon, int>> RankedStrikeChance =
            (Character c, Weapon s) => s.BaseChance + (c.ManualDexterity) + (4 * c.WeaponRanks[s]) ;

        public static readonly Expression<Func<Character, Weapon, int>> UnrankedStrikeChance =
            (Character c, Weapon s) => s.BaseChance;

        private static readonly Lazy<Func<Character, Weapon, int>> CompiledRankedStrikeChance = new Lazy<Func<Character, Weapon, int>>(() => RankedStrikeChance.Compile()); 

        private static readonly Lazy<Func<Character, Weapon, int>> CompiledUnrankedStrikeChance = new Lazy<Func<Character, Weapon, int>>(() => UnrankedStrikeChance.Compile()); 

        public static int ComputeStrikeChance(Character character, Weapon weapon)
        {
            Contract.Requires(character != null);
            Contract.Requires(weapon != null);
            var info = character.WeaponRanks.SingleOrDefault(i => i.Weapon == weapon);
            if (info != null)
            {
                return CompiledRankedStrikeChance.Value(character, weapon);
            }

            return CompiledUnrankedStrikeChance.Value(character, weapon);
        }
    }
}