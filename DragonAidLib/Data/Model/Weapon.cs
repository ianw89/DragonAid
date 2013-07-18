using System;
using System.Diagnostics.Contracts;
using DragonAid.Lib.GamemasterUtilities;

namespace DragonAid.Lib.Data.Model
{    
    /// <summary>
    /// Represents a physical weapon.
    /// </summary>
    /// <remarks>
    /// Note that this is different that the weapon skill. We are kind of collapsing the two right now,
    /// since CharacterWeaponInfo references this.
    /// </remarks>
    public class Weapon : Item
    {
        public Weapon(WeaponSkill skill, decimal weight) : base(skill.FullName, weight)
        {
            Contract.Requires(skill != null);
            Contract.Requires(weight != null);
            this.Skill = skill;
            this.BaseChance = skill.BaseChance;
            this.Use = skill.Use;
            this.MaxRank = skill.MaxRank;
            this.PhysicalStengthRequired = Skill.PhysicalStengthRequired;
            this.ManualDexterityRequired = skill.ManualDexterityRequired;
        }

        public int BaseChance { get; private set; }
        public WeaponKind Use { get; private set; }
        public int MaxRank { get; private set; }
        public int PhysicalStengthRequired { get; private set; }
        public int ManualDexterityRequired { get; private set; }
        public WeaponSkill Skill { get; private set; }
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