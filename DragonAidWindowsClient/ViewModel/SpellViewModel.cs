using System;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using DragonAid.WindowsClient.Common;
using Windows.UI.Xaml;

namespace DragonAid.WindowsClient.ViewModel
{
    /// <summary>
    /// View model for a Spell.
    /// </summary>
    public class SpellViewModel : BindableBase
    {
        private readonly CharacterSpellInfo _spellInfo;
        private Visibility _extendedInfoVisibility;

        public SpellViewModel(CharacterSpellInfo spellInfo)
        {
            this._spellInfo = spellInfo;
            this._extendedInfoVisibility = Visibility.Collapsed;
        }

        public string SpellName
        {
            get { return this._spellInfo.Spell.FullName; }
            set { throw new NotSupportedException(); }
        }

        public int Rank
        {
            get { return this._spellInfo.Rank; }
            set { throw new NotSupportedException(); }
        }

        public int CastChance
        {
            get { return this._spellInfo.CastChace; }
            set { throw new NotSupportedException(); }
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

        public string Description
        {
            get { return this._spellInfo.Spell.Description ?? "<No spell description set>"; }
            set { throw new NotSupportedException(); }
        }

        public Visibility ExtendedInfoVisibility
        {
            get { return _extendedInfoVisibility; }
            set { this.SetProperty(ref this._extendedInfoVisibility, value); }
        }
    }
}
