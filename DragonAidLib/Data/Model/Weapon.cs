using System.Diagnostics.Contracts;

namespace DragonAid.Lib.Data.Model
{
    // TODO Is there value in having Weapon and Spell share a base class?
    // Note that when we do skills we will have _abilities_ of the skills that look like these...
    public class Weapon
    {
        public Weapon(string fullName, int baseChance)
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