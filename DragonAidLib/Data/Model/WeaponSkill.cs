using System.Collections.Generic;
using System.Diagnostics.Contracts;
using DragonAid.Lib.GamemasterUtilities;

namespace DragonAid.Lib.Data.Model
{
    /// <summary>
    /// Represents skill with a particular kind of weapon.
    /// </summary>
    /// <remarks>
    /// This is different than a physical weapon, which is an Item, not a skill. 
    /// </remarks>
    public class WeaponSkill: ISkill
    {
        public WeaponSkill(string fullName, decimal weight, int baseChance, WeaponKind use, int maxRank, int minStength, int minDex)
        {
            ExceptionUtils.CheckArgumentNotNull(fullName);
            ExceptionUtils.MustBeTrue(baseChance >= 0 && baseChance <= 100);
            ExceptionUtils.MustBeTrue(maxRank >= 0 && maxRank <= 10);
            this.FullName = fullName;
            this.BaseChance = baseChance;
            this.Use = use;
            this.MaxRank = maxRank;
            this.PhysicalStengthRequired = minStength;
            this.ManualDexterityRequired = minDex;
        }
        
        [TestOnly]
        public WeaponSkill(string fullName, int minStength, int minDex)
            : this(fullName, 1, 0, WeaponKind.Unspecified, 0, minStength, minDex)
        {
        }

        public string FullName { get; private set; }
        public IList<ISkill> Subskills { get { return new List<ISkill>(); } }
        public string Description { get; private set; }
        public int BaseChance { get; private set; }
        public WeaponKind Use { get; private set; }
        public int MaxRank { get; private set; }
        public int PhysicalStengthRequired { get; private set; }
        public int ManualDexterityRequired { get; private set; }
    }
}