using System.ComponentModel;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        private readonly ObservableCollection<CharacterViewModel> _topCharacters = new ObservableCollection<CharacterViewModel>();

        public PartyViewModel()
        {
            Characters.CollectionChanged += CharacterCollectionChanged;
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

        public ObservableCollection<CharacterViewModel> TopCharacters
        {
            get { return _topCharacters; }
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

        //public async Task LoadPartyFromServiceAsync(int partyId)
        //{
        //    await LoadPartyFromServiceAsync(DragonAidService.Client, partyId);
        //}

        //public async Task LoadAllCharactersFromServiceAsync()
        //{
        //    await LoadAllCharactersFromServiceAsync(DragonAidService.Client);
        //}

        //public async Task LoadPartyFromServiceAsync(MobileServiceClient client, int partyId)
        //{
        //    if (partyId == AllCharactersParty.Id)
        //    {
        //        await LoadAllCharactersFromServiceAsync(client);
        //        return;
        //    }

        //    var partyTable = client.GetTable<Party>();
        //    var characterTable = client.GetTable<Character>();

        //    // These can run concurrently, so start both before awaiting either
        //    var getPartyTask = partyTable.LookupAsync(partyId);
        //    var getCharactersTask = characterTable.Where(c => c.PartyId == partyId).ToListAsync();

        //    Party party = await getPartyTask;
        //    List<Character> characters = await getCharactersTask;

        //    // Only after both succeed do we change either
        //    SetModels(party, characters);
        //}

        //public async Task LoadAllCharactersFromServiceAsync(MobileServiceClient client)
        //{
        //    var characterTable = client.GetTable<Character>();
        //    var characters = await characterTable.Where(c => c.IsMine).ToListAsync();

        //    // Only after the network IO succeeds do we change anything
        //    SetModels(AllCharactersParty, characters);
        //}

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
            foreach (var c in characters)
            {
                Characters.Add(new CharacterViewModel(c));
            }
        }

        private void CharacterCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Provides a subset of the full items collection to bind to from a GroupedItemsPage
            // for two reasons: GridView will not virtualize large items collections, and it
            // improves the user experience when browsing through groups with large numbers of
            // items.
            //
            // A maximum of 12 items are displayed because it results in filled grid columns
            // whether there are 1, 2, 3, 4, or 6 rows displayed

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewStartingIndex < 12)
                    {
                        TopCharacters.Insert(e.NewStartingIndex,Characters[e.NewStartingIndex]);
                        if (TopCharacters.Count > 12)
                        {
                            TopCharacters.RemoveAt(12);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    if (e.OldStartingIndex < 12 && e.NewStartingIndex < 12)
                    {
                        TopCharacters.Move(e.OldStartingIndex, e.NewStartingIndex);
                    }
                    else if (e.OldStartingIndex < 12)
                    {
                        TopCharacters.RemoveAt(e.OldStartingIndex);
                        TopCharacters.Add(Characters[11]);
                    }
                    else if (e.NewStartingIndex < 12)
                    {
                        TopCharacters.Insert(e.NewStartingIndex, Characters[e.NewStartingIndex]);
                        TopCharacters.RemoveAt(12);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldStartingIndex < 12)
                    {
                        TopCharacters.RemoveAt(e.OldStartingIndex);
                        if (Characters.Count >= 12)
                        {
                            TopCharacters.Add(Characters[11]);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.OldStartingIndex < 12)
                    {
                        TopCharacters[e.OldStartingIndex] = Characters[e.OldStartingIndex];
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    TopCharacters.Clear();
                    while (TopCharacters.Count < Characters.Count && TopCharacters.Count < 12)
                    {
                        TopCharacters.Add(Characters[TopCharacters.Count]);
                    }
                    break;
            }
        }

    }
}
