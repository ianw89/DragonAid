using System.Linq;
using DragonAid.Lib.Data;
using DragonAid.WindowsClient.Common;
using DragonAid.WindowsClient.ViewModel;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace DragonAid.WindowsClient
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class CharacterDetailPage : LayoutAwarePage
    {
        private bool useWebServiceFordata = false;
        private readonly CharacterViewModel _characterViewModel = new CharacterViewModel();

        public CharacterDetailPage()
        {
            this.InitializeComponent();
            this.OnLoadingStateChanged += OnOnLoadingStateChanged;
        }

        /// <summary>
        /// The single view model that all the data on the page binds to. It represents one character.
        /// </summary>
        public CharacterViewModel CharacterViewModel
        {
            get { return _characterViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected async override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // Normally this page will be open when clicked on, so there is a navigation parameter that
            // contains the Id of the character we are displaying details for.
            // During development it's conventient to load a hard coded character instead.
            int characterId;
            if (navigationParameter != null)
            {
                characterId = (int) navigationParameter;
            }
            else
            {
                characterId = 2; // Muscles
            }

            // This is fast and can be done synchronously
            // Try and load from saved data. Not implemented really...
            bool loaded = CharacterViewModel.LoadState(characterId, pageState);

            // This involves network IO. We'll put up a loading indicator (either full-screen or
            // non-obtrusive, depending on if anything could be loaded synchronously)
            LoadingState = loaded ? LoadingStates.LoadingUpdate : LoadingStates.LoadingFresh;

            if (this.useWebServiceFordata)
            {
                await CharacterViewModel.LoadCharacterFromServiceAsync(characterId);
            }
            else
            {
                CharacterViewModel.LoadCharacterFromStaticData(characterId);
            }

            LoadingState = LoadingStates.NotLoading;
        }

        private void OnOnLoadingStateChanged(object sender, EventArgs eventArgs)
        {
            // TODO maybe do something
        }

        private void InventoryTabClicked(object sender, RoutedEventArgs e)
        {
            this.SelectTab(this.InventoryTab);
        }

        private void SpellTabClicked(object sender, RoutedEventArgs e)
        {
            this.SelectTab(this.SpellTab);
        }

        private void SkillTabClicked(object sender, RoutedEventArgs e)
        {
            this.SelectTab(this.SkillTab);
        }

        private void CombatTabClicked(object sender, RoutedEventArgs e)
        {
            this.SelectTab(this.WeaponTab);
        }

        private void SelectTab(ListView selectedTab)
        {
            this.SpellTab.Visibility = Visibility.Collapsed;
            this.SkillTab.Visibility = Visibility.Collapsed;
            this.WeaponTab.Visibility = Visibility.Collapsed;
            this.InventoryTab.Visibility = Visibility.Collapsed;
            selectedTab.Visibility = Visibility.Visible;
        }

    }
}
