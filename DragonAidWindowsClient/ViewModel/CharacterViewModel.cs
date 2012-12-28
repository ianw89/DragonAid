using System.ComponentModel;
using DragonAidLib.Data;
using DragonAidLib.Data.Model;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonAidWindowsClient.ViewModel
{
    /// <summary>
    /// ViewModel for a Character, for use as either a tile in one of the Character pages or the content in
    /// a CharacterDetailPage
    /// 
    /// Users must await a LoadCharacterFromServiceAsync call for this to be useful
    /// </summary>
    class CharacterViewModel : GroupableViewModelBase
    {
        private static string CharacterIdToUniqueId(int characterId)
        {
            return string.Format("Character/{0}", characterId);
        }

        public CharacterViewModel()
        {
            PropertyChanged += CharacterChangedHandler;
        }

        public CharacterViewModel(Character c) : this()
        {
            Character = c;
        }

        void CharacterChangedHandler(object sender, PropertyChangedEventArgs args)
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
        
        /// <summary>
        /// Populates view model from saved page state that was previously populated with LoadState
        /// </summary>
        /// <returns>Whether or not any saved state was found and loaded</returns>
        public bool LoadState(int characterId, IDictionary<string, object> savedState)
        {
            if (savedState == null) return false;

            string uniqueId = CharacterIdToUniqueId(characterId);
            var savedCharacter = savedState[uniqueId] as Character;
            if (savedCharacter == null) return false;

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

        public async Task LoadCharacterFromServiceAsync(MobileServiceClient client, int characterId)
        {
            var characterTable = client.GetTable<Character>();
            Character = await characterTable.LookupAsync(characterId);
        }

        private Character _character;
        /// <summary>
        /// Note the public setter - it is okay to, for example, load several characters in one query and set each
        /// corresponding ViewModel directly
        /// </summary>
        public Character Character { get { return _character; } set { SetProperty(ref _character, value); } }
    }
}
