﻿using System;
using System.Collections.Generic;
using DragonAid.WindowsClient.Common;
using DragonAid.WindowsClient.ViewModel;
using Windows.UI.Xaml.Controls;

// The Group Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234229

namespace DragonAid.WindowsClient
{
    /// <summary>
    /// A page that displays an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    public sealed partial class PartyDetailPage : LayoutAwarePage
    {
        private PartyViewModel _partyViewModel = new PartyViewModel();

        public PartyDetailPage()
        {
            InitializeComponent();
            OnLoadingStateChanged += OnOnLoadingStateChanged;
        }

        /// <summary>
        /// The single view model that all the data on the page binds to. It represents one party of characters.
        /// </summary>
        public PartyViewModel PartyViewModel
        {
            get { return _partyViewModel; }
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
            // contains the Id of the party we are displaying details for.
            // During development it's conventient to load a hard coded party instead.
            int partyId;
            if (navigationParameter != null)
            {
                partyId = (int)navigationParameter;
            }
            else
            {
                partyId = 1; // Tuesday night DQ!
            }

            // This is fast and can be done synchronously
            bool loaded = PartyViewModel.LoadState(partyId, pageState);

            // This involves network IO. We'll put up a loading indicator (either full-screen or
            // non-obtrusive, depending on if anything could be loaded synchronously)
            LoadingState = loaded ? LoadingStates.LoadingUpdate : LoadingStates.LoadingFresh;
            //await viewModel.LoadPartyFromServiceAsync(partyId);
            PartyViewModel.LoadPartyFromStaticData(partyId);
            LoadingState = LoadingStates.NotLoading;
        }

        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void CharacterView_CharacterClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var characterId = ((CharacterViewModel)e.ClickedItem).Character.Id;
            this.Frame.Navigate(typeof(CharacterDetailPage), characterId);
        }

        private void OnOnLoadingStateChanged(object sender, EventArgs eventArgs)
        {
            // TODO maybe do something
        }
    }
}
