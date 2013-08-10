using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterWeaponRanks : IEnumerable<CharacterWeaponInfo>
    {
        private readonly List<CharacterWeaponInfo> _list = new List<CharacterWeaponInfo>();
        private readonly Character _character;

        public CharacterWeaponRanks(Character character)
        {
            ExceptionUtils.CheckArgumentNotNull(character);
            this._character = character;
        }

        public IEnumerator<CharacterWeaponInfo> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(WeaponSkill weapon, int rank)
        {
            ExceptionUtils.CheckArgumentNotNull(weapon);
            this[weapon] = rank;
        }

        public int this[WeaponSkill weaponSkill]
        {
            get
            {
                ExceptionUtils.CheckArgumentNotNull(weaponSkill);

                var characterWeaponInfo = this._list.SingleOrDefault(w => w.Weapon == weaponSkill);
                if (characterWeaponInfo == null)
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                                                                      "Character has no ranks in {0}!", weaponSkill.FullName));
                }

                return characterWeaponInfo.Rank;
            }

            set
            {
                ExceptionUtils.CheckArgumentNotNull(weaponSkill);
                ExceptionUtils.MustBeTrue(value > -1);

                var characterWeaponInfo = this._list.SingleOrDefault(w => w.Weapon == weaponSkill);
                if (characterWeaponInfo == null)
                {
                    this._list.Add(new CharacterWeaponInfo(weaponSkill, value, this._character));
                }
                else
                {
                    characterWeaponInfo.Rank = value;
                }
            }
        }
    }
}