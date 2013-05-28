using System.Linq;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        private const string AllPartiesUniqueId = "AllParties/PartyIds";

        public AllPartiesViewModel()
        {
            this._rawCharacterData = new List<Character>();
            this._rawPartyData = new List<Party>();
        }

        public AllPartiesViewModel(ICollection<Party> parties, ICollection<Character> characters)
        {
            this._rawCharacterData = characters;
            this._rawPartyData = parties;
        }

        public ObservableCollection<PartyViewModel> PartyViews
        {
            get { return _partyViews; }
        }

        /// <summary>
        /// Populates view model from saved page state that was previously populated with SaveState
        /// </summary>
        /// <returns>Whether or not any saved state was found and loaded</returns>
        public bool LoadState(IDictionary<string, object> savedState)
        {
            if (savedState == null || savedState.Count == 0)
            {
                return false;
            }

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
            var instance = new AllPartiesViewModel(HardCodedSampleData.SampleParties, HardCodedSampleData.SampleCharacters);
            instance.BuildPartyViewModelsFromParties();
            return instance;
        }
    }
}
