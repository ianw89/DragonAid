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
            ExceptionUtils.CheckArgumentNotNull(skill);
            ExceptionUtils.CheckArgumentNotNull(weight);
            this.Skill = skill;
            this.BaseChance = skill.BaseChance;
            // TODO BaseChance and DamageModifier can be modified from base
            // TODO introduce factory to construct these
        }

        public int BaseChance { get; private set; }
        public WeaponSkill Skill { get; private set; }
    }
}