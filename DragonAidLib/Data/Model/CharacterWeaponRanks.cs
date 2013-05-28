using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterWeaponRanks : IEnumerable<CharacterWeaponInfo>
    {
        private readonly List<CharacterWeaponInfo> _list = new List<CharacterWeaponInfo>();
        private readonly Character character;

        public CharacterWeaponRanks(Character character)
        {
            Contract.Requires(character != null);
            this.character = character;
        }

        public IEnumerator<CharacterWeaponInfo> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Weapon weapon, int rank)
        {
            this[weapon] = rank;
        }

        public int this[Weapon weapon]
        {
            get
            {
                Contract.Requires(weapon != null);

                var characterWeaponInfo = this._list.SingleOrDefault(w => w.Weapon == weapon);
                if (characterWeaponInfo == null)
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                                                                      "Character has no ranks in {0}!", weapon.FullName));
                }

                return characterWeaponInfo.Rank;
            }

            set
            {
                Contract.Requires(weapon != null);
                Contract.Requires(value >- 0);

                var characterWeaponInfo = this._list.SingleOrDefault(w => w.Weapon == weapon);
                if (characterWeaponInfo == null)
                {
                    this._list.Add(new CharacterWeaponInfo(weapon, value, this.character));
                }
                else
                {
                    characterWeaponInfo.Rank = value;
                }
            }
        }
    }
}