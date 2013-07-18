using System.Diagnostics.Contracts;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterWeaponInfo
    {
        private readonly Character _character;

        public CharacterWeaponInfo(WeaponSkill weapon, int rank, Character character)
        {
            Contract.Requires(weapon != null);
            Contract.Requires(character != null);
            _character = character;
            Weapon = weapon;
            Rank = rank;
        }

        public WeaponSkill Weapon { get; private set; }
        public int Rank { get; set; }
    }
}