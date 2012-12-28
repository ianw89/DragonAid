using DragonAidLib.Data;
using DragonAidLib.Data.Model;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace DragonAidWindowsClient.ViewModel
{
    /// <summary>
    /// ViewModel for a Party with its set of associated Characters
    /// 
    /// Also understands how to deal with the special "party" of ID PartyViewModel.AllCharactersParty,
    /// which deals with displaying a view of all of a player's characters irrespective of their Parties
    /// 
    /// Users must await a LoadPartyFromServiceAsync call for this to be useful
    /// </summary>
    class PartyViewModel : GroupableViewModelBase
    {
        public PartyViewModel(IDictionary<string, object> savedState)
        {
            Characters.CollectionChanged += CharacterCollectionChanged;
            LoadState(savedState);
        }

        /// <summary>
        /// Populates view model from saved page state that was previously populated with LoadState
        /// </summary>
        /// <returns>Whether or not any saved state was found and loaded</returns>
        public bool LoadState(IDictionary<string, object> savedState)
        {
            if (savedState == null) return false;

            var savedParty = savedState["Party"] as Party;
            var savedCharacters = savedState["Characters"] as IEnumerable<Character>;
            if (savedParty == null || savedCharacters == null) return false;

            Party = savedParty;
            foreach (var c in savedCharacters)
            {
                Characters.Add(c);
            }
            return true;
        }

        public void SaveState(IDictionary<string, object> stateContainer)
        {
            stateContainer["Party"] = Party;
            stateContainer["Characters"] = Characters.Select(c => c).ToList(); // shallow copy
        }

        public async Task LoadPartyFromServiceAsync(int partyId)
        {
            await LoadPartyFromServiceAsync(DragonAidService.Client, partyId);
        }

        public async Task LoadPartyFromServiceAsync(MobileServiceClient client, int partyId)
        {
            var partyTable = client.GetTable<Party>();
            var characterTable = client.GetTable<Character>();

            // These can run concurrently, so start both before awaiting either
            var getPartyTask = partyTable.LookupAsync(partyId);
            var getCharactersTask = characterTable.Where(c => c.PartyId == partyId).ToListAsync();

            Party party = await getPartyTask;
            List<Character> characters = await getCharactersTask;

            // Only after both succeed do we change either
            Party = party;
            foreach (var c in characters)
            {
                Characters.Add(c);
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

        public Party Party { get; private set; }

        private readonly ObservableCollection<Character> _characters = new ObservableCollection<Character>();
        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
        }

        private readonly ObservableCollection<Character> _topCharacters = new ObservableCollection<Character>();
        public ObservableCollection<Character> TopCharacters
        {
            get {return _topCharacters; }
        }
    }
}
