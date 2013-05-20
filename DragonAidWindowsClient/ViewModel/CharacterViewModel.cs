using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Event for standard property change handling.
        /// </summary>
        public event PropertyChangedEventHandler CharacterPropertyChanged;

        /// <summary>
        /// Construct a ViewModel without assigning a character.
        /// </summary>
        public CharacterViewModel()
        {
            PropertyChanged += CharacterChangedHandler;
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
            set { SetCharacterProperty(c => c.PhysicalStrength = value); }
        }
        public int ManualDexterity
        {
            get { return Character.ManualDexterity; }
            set { SetCharacterProperty(c => c.ManualDexterity = value); }
        }
        public int Agility
        {
            get { return Character.Agility; }
            set { SetCharacterProperty(c => c.Agility = value); }
        }
        public int PhysicalBeauty
        {
            get { return Character.PhysicalBeauty; }
            set { SetCharacterProperty(c => c.PhysicalBeauty = value); }
        }
        public int Willpower
        {
            get { return Character.Willpower; }
            set { SetCharacterProperty(c => c.Willpower = value); }
        }
        public int MagicalAptitude
        {
            get { return Character.MagicalAptitude; }
            set { SetCharacterProperty(c => c.MagicalAptitude = value); }
        }
        public int Endurance
        {
            get { return Character.Endurance; }
            set { SetCharacterProperty(c => c.Endurance = value); }
        }
        public int Fatigue
        {
            get { return Character.Fatigue; }
            set { SetCharacterProperty(c => c.Fatigue = value); }
        }
        public int Perception
        {
            get { return Character.Perception; }
            set { SetCharacterProperty(c => c.Perception = value); }
        }
        public int TacticalMovementRate
        {
            get { return Character.TacticalMovementRate(); }
            set { throw new NotSupportedException("Cannot set TMR."); }
        }
        public ICollection<string> Spells
        {
            get { return Character.Spells.Select(s => s.Spell.FullName).ToList(); }
            set { throw new NotSupportedException("Cannot set spell dictioary."); }
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

            // Not sure what this formula of saving and loading things is... TODO
            string uniqueId = CharacterIdToUniqueId(characterId);
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

        public async Task LoadCharacterFromServiceAsync(int characterId)
        {
            await LoadCharacterFromServiceAsync(DragonAidService.Client, characterId);
        }

        public void LoadCharacterFromStaticData(int characterId)
        {
            Character = HardCodedSampleData.SampleCharacters.Single(c => c.Id == characterId);
        }

        #region Character change handling

        // TODO: Hook up a DragonAidService....UpdateAsync()

        private void OnCharacterPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = CharacterPropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private delegate void CharacterPropertySetter(Character c);
        private void SetCharacterProperty(CharacterPropertySetter setter, [CallerMemberName] string propertyName = null)
        {
            setter(_character);
            OnPropertyChanged(propertyName);
            OnCharacterPropertyChanged(propertyName);
        }

        #endregion

        private static string CharacterIdToUniqueId(int characterId)
        {
            return string.Format("Character/{0}", characterId);
        }

        private async Task LoadCharacterFromServiceAsync(MobileServiceClient client, int characterId)
        {
            var characterTable = client.GetTable<Character>();
            Character = await characterTable.LookupAsync(characterId);
        }

        private void CharacterChangedHandler(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Character")
            {
                UniqueId = CharacterIdToUniqueId(Character.Id);
                Title = Character.Name;
                Subtitle = Character.IsMine ? Character.Title : Character.PlayerName;
                Description = Character.Description;
                SetImage(Character.ImageUri);
            }
        }
    }
}
