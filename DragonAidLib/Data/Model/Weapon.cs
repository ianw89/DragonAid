using System;
using System.Diagnostics.Contracts;

namespace DragonAid.Lib.Data.Model
{
    // TODO Is there value in having Weapon and Spell share a base class?
    // Note that when we do skills we will have _abilities_ of the skills that look like these...
    public class Weapon : Item
    {
        public Weapon(string fullName, decimal weight, int baseChance, WeaponKind use, int maxRank)
            : base(fullName, weight)
        {
            Contract.Requires(baseChance >= 0 && baseChance <= 100);
            Contract.Requires(maxRank >=0 && maxRank <= 10);
            this.BaseChance = baseChance;
            this.Use = use;
            this.MaxRank = maxRank;
        }

        public int BaseChance { get; private set; }
        public WeaponKind Use { get; private set; }
        public int MaxRank { get; private set; }
    }

    /// <summary>
    /// The possible ways to use a weapon. A weapon may be used in one or more of these modes.
    /// </summary>
    [Flags]
    public enum WeaponKind
    {
        Unspecified = 0,
        Ranged = 1,
        Melee = 2,
        Close = 4,
    }
}