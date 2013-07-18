using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
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
            Contract.Requires(character != null);
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
            Contract.Requires(weapon != null);
            this[weapon] = rank;
        }

        public int this[WeaponSkill weaponSkill]
        {
            get
            {
                Contract.Requires(weaponSkill != null);

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
                Contract.Requires(weaponSkill != null, "Can't have rank with null.");
                Contract.Requires(value >- 0);

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