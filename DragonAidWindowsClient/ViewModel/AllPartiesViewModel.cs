using System.Linq;
using DragonAidLib.Data;
using DragonAidLib.Data.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace DragonAidWindowsClient.ViewModel
{
    /// <summary>
    /// ViewModel for a Character with its set of associated Characters
    /// 
    /// Also understands how to deal with the special "party" of ID PartyViewModel.AllCharactersParty,
    /// which deals with displaying a view of all of a player's characters irrespective of their Parties
    /// 
    /// Users must await a LoadCharacterFromServiceAsync call for this to be useful
    /// </summary>
    public sealed class AllPartiesViewModel
    {
        private readonly ObservableCollection<PartyViewModel> _parties = new ObservableCollection<PartyViewModel>(); 
        public ObservableCollection<PartyViewModel> Parties { get { return _parties; } }

        private const string AllPartiesUniqueId = "AllParties/PartyIds";

        public AllPartiesViewModel()
        {
        }

        public AllPartiesViewModel(ICollection<Party> parties, ICollection<Character> characters)
        {
            
        }

        /// <summary>
        /// Populates view model from saved page state that was previously populated with SaveState
        /// </summary>
        /// <returns>Whether or not any saved state was found and loaded</returns>
        public bool LoadState(IDictionary<string, object> savedState)
        {
            if (savedState == null) return false;

            var savedPartyIds = savedState[AllPartiesUniqueId] as IEnumerable<int>;
            if (savedPartyIds == null) return false;

            Parties.Clear();
            foreach (var savedPartyId in savedPartyIds)
            {
                var partyViewModel = new PartyViewModel();
                if (partyViewModel.LoadState(savedPartyId, savedState))
                {
                    Parties.Add(partyViewModel);
                }
            }
            return Parties.Any();
        }

        public void SaveState(IDictionary<string, object> stateContainer)
        {
            stateContainer[AllPartiesUniqueId] = Parties.Select(pvm => pvm.Party.Id).ToList();
            foreach (var partyViewModel in Parties)
            {
                partyViewModel.SaveState(stateContainer);
            }
        }

        public async Task LoadAllPartiesFromServiceAsync()
        {
            await LoadAllPartiesFromServiceAsync(DragonAidService.Client);
        }
        
        public async Task LoadAllPartiesFromServiceAsync(MobileServiceClient client)
        {
            var characterTable = client.GetTable<Character>();
 	        var partyTable = client.GetTable<Party>();

            var getPartiesTask = partyTable.ToListAsync();
            var getCharactersTask = characterTable.ToListAsync();

            var parties = await getPartiesTask;
            var characters = await getCharactersTask;
            
            // Only after the network IO succeeds do we change anything
            parties.Insert(0, PartyViewModel.AllCharactersParty);
            Parties.Clear();
            foreach (var p in parties)
            {
                Parties.Add(new PartyViewModel(p, characters));
            }
        }
    }
}
