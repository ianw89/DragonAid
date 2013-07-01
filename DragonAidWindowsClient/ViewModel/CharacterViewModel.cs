using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using System.Collections.Generic;

namespace DragonAid.WindowsClient.ViewModel
{
    /// <summary>
    /// ViewModel for a Character, for use as either a tile in one of the Character pages or the content in
    /// a CharacterDetailPage
    /// 
    /// Users must await a LoadCharacterFromServiceAsync call for this to be useful
    /// </summary>
    public sealed class CharacterViewModel : GroupableViewModelBase
    {
        /// <summary>
        /// Underlying character that this ViewModel represents.
        /// </summary>
        private Character _character;

        private IEnumerable<ItemViewModel> _displayedItemSet;
        private string _displayedItemSetName;
        private string _agilityString;
        private int _tmr;
        private string _manualDexterityString;

        /// <summary>
        /// Construct a ViewModel without assigning a character.
        /// </summary>
        public CharacterViewModel()
        {
            PropertyChanged += this.PropertyChangedHandler;
        }

        /// <summary>
        /// Construct a ViewModel for the specified character.
        /// </summary>
        public CharacterViewModel(Character c) : this()
        {
            Character = c;
        }

        /// <summary>
        /// Note the public setter - it is okay to, for example, load several characters in one query and set each
        /// corresponding ViewModel directly
        /// </summary>
        public Character Character
        {
            get { return _character; }
            set { SetProperty(ref _character, value); }
        }

        #region Data binding properties

        public int PhysicalStrength
        {
            get { return Character.PhysicalStrength; } 
            set { throw new NotSupportedException(); }
        }

        public string ManualDexterity
        {
            get { return this._manualDexterityString; }
            set { throw new NotSupportedException(); }
        }

        public string Agility
        {
            get { return this._agilityString; }
            set { throw new NotSupportedException(); }
        }

        public int PhysicalBeauty
        {
            get { return Character.PhysicalBeauty; }
            set { throw new NotSupportedException(); }
        }

        public int Willpower
        {
            get { return Character.Willpower; }
            set { throw new NotSupportedException(); }
        }

        public int MagicalAptitude
        {
            get { return Character.MagicalAptitude; }
            set { throw new NotSupportedException(); }
        }

        public int Endurance
        {
            get { return Character.Endurance; }
            set { throw new NotSupportedException(); }
        }

        public int Fatigue
        {
            get { return Character.Fatigue; }
            set { throw new NotSupportedException(); }
        }

        public int Perception
        {
            get { return Character.Perception; }
            set { throw new NotSupportedException(); }
        }

        public int TacticalMovementRate
        {
            get { return this._tmr; }
            set { throw new NotSupportedException(); }
        }

        public IEnumerable<SpellViewModel> Spells
        {
            get { return this.GetSpellViewModelsFromCharacter(); }
            set { throw new NotSupportedException("Cannot set spell dictioary."); }
        }

        public IEnumerable<ItemViewModel> DisplayedItemSet
        {
            get { return _displayedItemSet; }
            set { this.SetProperty(ref _displayedItemSet, value); }
        }

        public IEnumerable<WeaponViewModel> Weapons
        {
            get { return this.GetWeaponViewModelsFromCharacter(); }
            set { throw new NotSupportedException("Cannot set weapons."); }
        }

        public IEnumerable<RankedSkillViewModel> Skills
        {
            get { return this.GetSkillViewModelsFromCharacter(); }
            set { throw new NotSupportedException("Cannot set skills."); }
        }

        #endregion

        /// <summary>
        /// Populates view model from saved page state that was previously populated with LoadState
        /// </summary>
        /// <returns>Whether or not any saved state was found and loaded</returns>
        public bool LoadState(int characterId, IDictionary<string, object> savedState)
        {
            if (savedState == null || savedState.Count == 0)
            {
                return false;
            }

            string uniqueId = UniqueIdHandler.CharacterIdToUniqueId(characterId);
            var savedCharacter = savedState[uniqueId] as Character;
            
            if (savedCharacter == null)
            {
                return false;
            }

            Character = savedCharacter;
            return true;
        }

        public void SaveState(IDictionary<string, object> stateContainer)
        {
            stateContainer[UniqueId] = Character;
        }

        public void LoadCharacterFromStaticData(int characterId)
        {
            Character = HardCodedSampleData.SampleCharacters.Single(c => c.Id == characterId);
        }

        #region Change handling

        /// <summary>
        /// Method that handles any property changes to this class. All of the dependencies are authored into this method.
        /// </summary>
        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs args)
        {
            // TODO We want this stuff to happen once at the creation time of this view model. Character should never get set after that...
            if (args.PropertyName == "Character")
            {
                UniqueId = UniqueIdHandler.CharacterIdToUniqueId(Character.Id);
                Title = Character.Title;
                Subtitle = Character.PlayerName;
                Description = Character.Description;
                SetImage(Character.ImageUri);
                this.SetItemSetToAll();
                this.RefreshCharacteristicStrings();

            }

            if (args.PropertyName == "Agility")
            {
                SetProperty(ref this._tmr, this.Character.TacticalMovementRate(), "TacticalMovementRate");
            }
        }

        #endregion

        private IEnumerable<WeaponViewModel> GetWeaponViewModelsFromCharacter()
        {
            if (this._character != null)
            {
                return this._character.WeaponRanks.Select(weaponInfo => new WeaponViewModel(weaponInfo)).ToList();
            }

            return null;
        }

        private IEnumerable<SpellViewModel> GetSpellViewModelsFromCharacter()
        {
            if (this._character != null)
            {
                return this._character.SpellRanks.Select(spellInfo => new SpellViewModel(spellInfo)).OrderByDescending(s => s.CastChance).ToList();
            }

            return null;
        }

        // TODO Right now we are dumb and call this alot. We shouldn't have to keep rebuilding the view models. Cache.
        private IEnumerable<ItemViewModel> GetItemViewModels(IEnumerable<Item> sourceItems)
        {
            return sourceItems.Select(item => new ItemViewModel(item)).ToList();
        }

        private IEnumerable<RankedSkillViewModel> GetSkillViewModelsFromCharacter()
        {
            if (this._character != null)
            {
                return this._character.Skills.Select(Skills => new RankedSkillViewModel(Skills)).ToList();
            }

            return null;
        }

        public void SetItemSetToAll()
        {
            this._displayedItemSetName = "All";
            this.DisplayedItemSet = this.GetItemViewModels(this.Character.Inventory);
        }

        public void SetVisibleItemSet(string setIdentifier)
        {
            if (this.Character.Inventory.ItemSets.ContainsKey(setIdentifier))
            {
                this._displayedItemSetName = setIdentifier;
                this.DisplayedItemSet = this.GetItemViewModels(this.Character.Inventory.ItemSets[setIdentifier]);
            }
            else
            {
                // If the set isn't defined, we'll just make it an empty list
                this.DisplayedItemSet = new List<ItemViewModel>();
            }
        }

        public void SetVisibleItemSetToEquipted()
        {
            this.Character.Inventory.EquiptedSetName = this._displayedItemSetName;
            this.RefreshCharacteristicStrings();
        }

        // TODO Hmm... haven't really figured out the right pattern for 'updating' computed values. 
        // It seems like the BindableBass class provided for us is really just optimized for simple that are get and set
        private void RefreshCharacteristicStrings()
        {
            this.SetProperty(ref this._agilityString, this.CreateCharacteristicDisplayString(this.Character.Agility, this.Character.EffectiveAgility()), "Agility");
            this.SetProperty(ref this._manualDexterityString, this.CreateCharacteristicDisplayString(this.Character.ManualDexterity, this.Character.EffectiveManualDexterity()), "ManualDexterity");
        }

        private string CreateCharacteristicDisplayString(int rawCharacteristic, int effectiveCharacteristic)
        {
            var sb = new StringBuilder();
            sb.Append(rawCharacteristic);

            if (rawCharacteristic != effectiveCharacteristic)
            {
                sb.Append("(");
                sb.Append(effectiveCharacteristic);
                sb.Append(")");
            }
            
            return sb.ToString();
        }
    }
}
