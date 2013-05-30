using System;
using DragonAid.Lib.Data.Model;

namespace DragonAid.WindowsClient.ViewModel
{
    /// <summary>
    /// View model for a Spell.
    /// </summary>
    public class SpellViewModel
    {
        private readonly CharacterSpellInfo _spellInfo;

        public SpellViewModel(CharacterSpellInfo spellInfo)
        {
            this._spellInfo = spellInfo;
        }

        public string SpellName
        {
            get { return this._spellInfo.Spell.FullName; }
            set { throw new NotSupportedException();}
        }

        public int Rank
        {
            get { return this._spellInfo.Rank; }
            set { throw new NotSupportedException();}
        }

        public int BaseCastChance
        {
            get { return this._spellInfo.BaseCastChace; }
            set { throw new NotSupportedException();}
        }
    }
}
