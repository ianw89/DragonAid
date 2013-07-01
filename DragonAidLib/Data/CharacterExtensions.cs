using System.Diagnostics.Contracts;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public static class CharacterExtensions
    {
        public static int TacticalMovementRate(this Character character)
        {
            Contract.Requires(character != null);
            Contract.Requires(character.Race != null);
            return CharacterEquations.ComputeBasicTacticalMovementRate(character.EffectiveAgility(), character.Race);
        }

        public static int EffectiveAgility(this Character character)
        {
            Contract.Requires(character != null);
            return CharacterEquations.ComputeEffectiveAgility(character);
        }

        public static int EffectiveManualDexterity(this Character character)
        {
            Contract.Requires(character != null);
            return character.ManualDexterity; // TODO can be lowered by shield
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