using System;
using DragonAid.Lib.Data.Model;

namespace DragonAid.WindowsClient.ViewModel
{
    /// <summary>
    /// View model for an Item.
    /// </summary>
    public class ItemViewModel
    {
        private readonly Item _spellInfo;

        public ItemViewModel(Item spellInfo)
        {
            this._spellInfo = spellInfo;
        }

        public string ItemName
        {
            get { return this._spellInfo.FullName; }
            set { throw new NotSupportedException(); }
        }

        public string Weight
        {
            get { return this._spellInfo.Weight + " lb"; }
            set { throw new NotSupportedException(); }
        }
    }
}