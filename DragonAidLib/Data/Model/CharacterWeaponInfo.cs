using System.Diagnostics.Contracts;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterWeaponInfo
    {
        private readonly Character _character;

        public CharacterWeaponInfo(WeaponSkill weapon, int rank, Character character)
        {
            ExceptionUtils.CheckArgumentNotNull(weapon);
            ExceptionUtils.CheckArgumentNotNull(character);
            _character = character;
            Weapon = weapon;
            Rank = rank;
        }

        public WeaponSkill Weapon { get; private set; }
        public int Rank { get; set; }
    }
}