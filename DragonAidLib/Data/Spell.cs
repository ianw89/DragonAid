using System.Diagnostics.Contracts;

namespace DragonAid.Lib.Data
{
    public class Spell
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