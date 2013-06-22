using System.ComponentModel;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DragonAid.WindowsClient.ViewModel
{
    /// <summary>
    /// ViewModel for a Character with its set of associated Characters
    /// 
    /// Also understands how to deal with the special "party" of ID PartyViewModel.AllCharactersParty,
    /// which deals with displaying a view of all of a player's characters irrespective of their PartyViews
    /// 
    /// Users must await a LoadCharacterFromServiceAsync call for this to be useful
    /// </summary>
    public sealed class PartyViewModel : GroupableViewModelBase
    {
        private Party _party;
        private readonly ObservableCollection<CharacterViewModel> _characters = new ObservableCollection<CharacterViewModel>();

        public PartyViewModel()
        {
            PropertyChanged += PartyChangedHandler;
        }

        /// <summary>
        /// Populates the PartyViewModel from the given Party data and populates its children with data
        /// from the given list of knownCharacters.
        /// </summary>
        /// <param name="party"></param>
        /// <param name="knownCharacters">The set of characters to draw CharacterViewModel data from.
        /// It's okay for knownCharacters to contain more characters than the party (they'll be ignored),
        /// and it's also okay for it to be missing characters (they won't be displayed).</param>
        public PartyViewModel(Party party, IEnumerable<Character> knownCharacters) : this()
        {
            this.Party = party;
            SetModels(knownCharacters.Where(c => c.PartyId == party.Id));
        }

        public Party Party { get { return _party; } private set { SetProperty(ref _party, value); } }

        public ObservableCollection<CharacterViewModel> Characters
        {
            get { return _characters; }
        }

        void PartyChangedHandler(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Character")
            {
                UniqueId = Party.Id.ToString();
                Title = Party.Title;
                Subtitle = Party.GameMasterName ?? string.Format("GM: {0}", Party.GameMasterName);
                Description = Party.Description;
                SetImage(Party.ImageUri);
            }

            if (args.PropertyName == "Party")
            {
                this.SetModels(HardCodedSampleData.SampleCharacters);
            }
        }
        
        /// <summary>
        /// Populates view model from saved page state that was previously populated with LoadState
        /// </summary>
        /// <returns>Whether or not any saved state was found and loaded</returns>
        public bool LoadState(int partyId, IDictionary<string, object> savedState)
        {
            if (savedState == null || savedState.Count == 0)
            {
                return false;
            }

            var uniqueId = PartyIdToUniqueId(partyId);
            var savedParty = savedState[uniqueId] as Party;
            if (savedParty == null)
            {
                return false;
            }

            Party = savedParty;

            // Now check for known character IDs
            var uniquePartyCharactersId = PartyIdToUniquePartyCharactersId(partyId);
            var savedCharacterIds = savedState[uniquePartyCharactersId] as IEnumerable<int>;
            if (savedCharacterIds == null) return true; // We loaded something...

            foreach (var savedCharacterId in savedCharacterIds)
            {
                var characterViewModel = new CharacterViewModel();
                if (characterViewModel.LoadState(savedCharacterId, savedState))
                {
                    Characters.Add(characterViewModel);
                }
            }
            return true;
        }

        public void SaveState(IDictionary<string, object> stateContainer)
        {
            stateContainer[UniqueId] = Party;
            foreach (var characterViewModel in Characters)
            {
                characterViewModel.SaveState(stateContainer);
            }
        }

        public void LoadPartyFromStaticData(int partyId)
        {
            Party = HardCodedSampleData.SampleParties.Single(p => p.Id == partyId);
        }

        private static string PartyIdToUniqueId(int partyId)
        {
            return string.Format("Party/{0}", partyId);
        }

        private static string PartyIdToUniquePartyCharactersId(int partyId)
        {
            return string.Format("Party/{0}/CharacterIds", partyId);
        }

        /// <summary>
        /// Using the current Party that is set, create CharacterViewModels from the character list in the party.
        /// </summary>
        /// <param name="characters"></param>
        private void SetModels(IEnumerable<Character> characters)
        {
            Characters.Clear();
            foreach (var c in characters.Where(c => c.PartyId == this.Party.Id))
            {
                Characters.Add(new CharacterViewModel(c));
            }
        }
    }
}
