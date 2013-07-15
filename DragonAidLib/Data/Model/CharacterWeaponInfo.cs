using System;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterWeaponInfo
    {
        private readonly Character _character;

        public CharacterWeaponInfo(Weapon weapon, int rank, Character character)
        {
            _character = character;
            Weapon = weapon;
            Rank = rank;
        }

        // TODO Should be a WeaponSkill (that implements ISkill) instead of a Weapon, which is a physical object.
        public Weapon Weapon { get; private set; }
        public int Rank { get; set; }

        /// <summary>
        /// Calculated property that gives the strike chance of the character with this weapon.
        /// </summary>
        public int StrikeChance
        {
            get
            {
                return CharacterEquations.ComputeStrikeChance(this._character, this.Weapon);
            }
            set
            {
                throw new NotSupportedException("Cannot set the StrikeChance.");
            }
        }
    }
}