using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DragonAid.Lib.Annotations;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using Windows.UI.Xaml;

namespace DragonAid.WindowsClient.ViewModel
{
    /// <summary>
    /// View model for a Spell.
    /// </summary>
    public class SpellViewModel : INotifyPropertyChanged
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
            get { return "This is a fake spell description."; }
            set { throw new NotImplementedException(); }
        }

        public Visibility ExtendedInfoVisibility
        {
            get { return _extendedInfoVisibility; }
            set
            {
                _extendedInfoVisibility = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
