using System;
using DragonAid.Lib.Data.Model;

namespace DragonAid.WindowsClient.ViewModel
{
    public class WeaponViewModel
    {
        private readonly CharacterWeaponInfo _info;

        public WeaponViewModel(CharacterWeaponInfo info)
        {
            this._info = info;
        }

        public string Name
        {
            get { return _info.Weapon.FullName; }
            set { throw new NotSupportedException(); }
        }

        public int Rank
        {
            get { return _info.Rank; }
            set { throw new NotSupportedException(); }
        }
    }
}
