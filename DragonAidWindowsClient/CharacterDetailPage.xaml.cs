using DragonAid.WindowsClient.Common;
using DragonAid.WindowsClient.ViewModel;
using System;
using System.Collections.Generic;
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
        public CharacterDetailPage()
        {
            this.InitializeComponent();
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
            var characterId = (int)navigationParameter;
            var viewModel = new CharacterViewModel();

            this.DefaultViewModel["Character"] = viewModel;

            // This is fast and can be done synchronously
            bool loaded = viewModel.LoadState(characterId, pageState);

            // This involves network IO. We'll put up a loading indicator (either full-screen or
            // non-obtrusive, depending on if anything could be loaded synchronously)
            LoadingState = loaded ? LoadingStates.LoadingUpdate : LoadingStates.LoadingFresh;
            await viewModel.LoadCharacterFromServiceAsync(characterId);
            LoadingState = LoadingStates.NotLoading;
        }
        
        private void flipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
