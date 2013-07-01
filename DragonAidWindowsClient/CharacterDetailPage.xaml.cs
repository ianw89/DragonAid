using System.Linq;
using DragonAid.WindowsClient.Common;
using DragonAid.WindowsClient.ViewModel;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace DragonAid.WindowsClient
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class CharacterDetailPage : LayoutAwarePage
    {
        private readonly CharacterViewModel _characterViewModel = new CharacterViewModel();
        private static readonly string CombatSetIdentifier = "Combat";
        private static readonly string OverlandFootSetIdentifier = "OverlandFoot";

        public CharacterDetailPage()
        {
            this.InitializeComponent();
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
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
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
                throw new InvalidOperationException("Cannot open a CharacterDetailPage without a navigation paramter that provides the character to open.");
            }

            // Try and load from saved data. Not implemented really...
            this.CharacterViewModel.LoadState(characterId, pageState);
            CharacterViewModel.LoadCharacterFromStaticData(characterId);
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

        private void SelectTab(FrameworkElement selectedTab)
        {
            this.SpellTab.Visibility = Visibility.Collapsed;
            this.SkillTab.Visibility = Visibility.Collapsed;
            this.WeaponTab.Visibility = Visibility.Collapsed;
            this.InventoryTab.Visibility = Visibility.Collapsed;
            selectedTab.Visibility = Visibility.Visible;
        }

        private void AllItemsClicked(object sender, RoutedEventArgs e)
        {
            this.CharacterViewModel.SetItemSetToAll();
        }

        private void CombatItemsClicked(object sender, RoutedEventArgs e)
        {
            this.CharacterViewModel.SetVisibleItemSet(CombatSetIdentifier);
        }

        private void OverlandFootItemsClicked(object sender, RoutedEventArgs e)
        {
            this.CharacterViewModel.SetVisibleItemSet(OverlandFootSetIdentifier);
        }

        private void EquipActiveItemSetClicked(object sender, RoutedEventArgs e)
        {
            this.CharacterViewModel.SetVisibleItemSetToEquipted();
        }

        private void SpellTab_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var spell in e.AddedItems.Cast<SpellViewModel>())
            {
                spell.ExtendedInfoVisibility = Visibility.Visible;
            }

            foreach (var spell in e.RemovedItems.Cast<SpellViewModel>())
            {
                spell.ExtendedInfoVisibility = Visibility.Collapsed;
            }
        }
    }
}
