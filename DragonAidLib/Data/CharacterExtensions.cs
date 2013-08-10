using System.Diagnostics.Contracts;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public static class CharacterExtensions
    {
        public static int TacticalMovementRate(this Character character)
        {
            ExceptionUtils.CheckArgumentNotNull(character);
            ExceptionUtils.CheckNotNull(character.Race);
            return CharacterEquations.ComputeBasicTacticalMovementRate(character.EffectiveAgility(), character.Race);
        }

        public static int EffectiveAgility(this Character character)
        {
            ExceptionUtils.CheckArgumentNotNull(character);
            return CharacterEquations.ComputeEffectiveAgility(character);
        }

        public static int EffectiveManualDexterity(this Character character)
        {
            ExceptionUtils.CheckArgumentNotNull(character);
            return character.ManualDexterity; // TODO can be lowered by shield
        }

        public static int CastChance(this Character character, Spell spell)
        {
            ExceptionUtils.CheckArgumentNotNull(character);
            ExceptionUtils.CheckArgumentNotNull(spell);

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