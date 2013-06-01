using System;
using DragonAid.Lib.Data;
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

        public int CastChance
        {
            get { return this._spellInfo.CastChace; }
            set { throw new NotSupportedException();}
        }

        public int BackfireChance
        {
            get { return SpellcastResultRangeCalculator.Calculate(this.CastChance).Backfire; }
            set { throw new NotSupportedException(); }
        }

        public int TripleEffectChance
        {
            get { return SpellcastResultRangeCalculator.Calculate(this.CastChance).TripleEffect; }
            set { throw new NotSupportedException(); }
        }

        public int DoubleEffectChance
        {
            get { return SpellcastResultRangeCalculator.Calculate(this.CastChance).DoubleEffect; }
            set { throw new NotSupportedException(); }
        }
    }
}
