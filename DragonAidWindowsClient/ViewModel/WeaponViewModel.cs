using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string Text
        {
            get { return string.Format(CultureInfo.InvariantCulture, "'{0}' RK: {1} SC: {2}", this._info.Weapon.FullName, this._info.Rank, this._info.StrikeChance); }
            set { throw new NotSupportedException(); }
        }
    }
}
