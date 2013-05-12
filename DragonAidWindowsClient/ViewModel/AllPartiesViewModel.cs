using System.Linq;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

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
    public sealed class AllPartiesViewModel
    {
        private ICollection<Character> _rawCharacterData;
        private ICollection<Party> _rawPartyData;

        private readonly ObservableCollection<PartyViewModel> _partyViews = new ObservableCollection<PartyViewModel>();
        private readonly ObservableCollection<int> _numbers = new ObservableCollection<int>();

        private const string AllPartiesUniqueId = "AllParties/PartyIds";

        public AllPartiesViewModel()
        {
            this._rawCharacterData = new List<Character>();
            this._rawPartyData = new List<Party>();
            this._numbers = new ObservableCollection<int>(new[] {1,2,3,4,5});
        }

        public AllPartiesViewModel(ICollection<Party> parties, ICollection<Character> characters)
        {
            this._rawCharacterData = characters;
            this._rawPartyData = parties;
            this._numbers = new ObservableCollection<int>(new[] {1,2,3,4,5});
        }

        public ObservableCollection<PartyViewModel> PartyViews
        {
            get { return _partyViews; }
        }

        public ObservableCollection<int> Numbers
        {
            get { return _numbers; }
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

            PartyViews.Clear();
            foreach (var savedPartyId in savedPartyIds)
            {
                var partyViewModel = new PartyViewModel();
                if (partyViewModel.LoadState(savedPartyId, savedState))
                {
                    PartyViews.Add(partyViewModel);
                }
            }
            return PartyViews.Any();
        }

        public void SaveState(IDictionary<string, object> stateContainer)
        {
            stateContainer[AllPartiesUniqueId] = PartyViews.Select(pvm => pvm.Party.Id).ToList();
            foreach (var partyViewModel in PartyViews)
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
            // TODO want these readonly fields
            this._rawCharacterData = characters;
            this._rawPartyData = parties;
            BuildPartyViewModelsFromParties();
        }

        /// <summary>
        /// Builds the public PartyViews property from our internal collections of parties and characters.
        /// </summary>
        private void BuildPartyViewModelsFromParties()
        {
            PartyViews.Clear();
            foreach (var p in _rawPartyData)
            {
                PartyViews.Add(new PartyViewModel(p, _rawCharacterData));
            }
        }

        public static AllPartiesViewModel CreateWithStaticData()
        {
            var sampleData = new SampleDataSource();
            var instance = sampleData.AllParties;
            instance.BuildPartyViewModelsFromParties();

            return instance;
        }
    }
}
