using System.Diagnostics.Contracts;

namespace DragonAid.Lib.Data.Model
{
    /// <summary>
    /// Class that represents a Spell.
    /// TODO: Figure out how to handle talents and rituals. In general, some things do not follow the standard formulas.
    /// </summary>
    public class Spell : IMagicalAbility
    {
        public Spell(string fullName, int baseChance)
        {
            Contract.Requires(!string.IsNullOrEmpty(fullName));
            Contract.Requires(baseChance >= 0 && baseChance <= 100);

            this.FullName = fullName;
            this.BaseChance = baseChance;
        }

        public int BaseChance { get; private set; }

        public string FullName { get; private set; }
    }
}