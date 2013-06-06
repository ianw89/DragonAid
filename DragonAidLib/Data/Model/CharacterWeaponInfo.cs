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

        public Weapon Weapon { get; set; }
        public int Rank { get; set; }

        /// <summary>
        /// Calculated property that gives the strike chance of the character with this weapon.
        /// </summary>
        public int StrikeChance
        {
            get
            {
                // TODO need equation
                return CharacterEquations.ComputeStrikeChance(this._character, this.Weapon);
            }
            set
            {
                throw new NotSupportedException("Cannot set the StrikeChance.");
            }
        }
    }
}