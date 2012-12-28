﻿using System;
using System.Collections.Generic;
using DragonAidLib.Data;
using DragonAidLib.Data.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Grouped Characters Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace DragonAidWindowsClient
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class PartiesPage : DragonAidWindowsClient.Common.LayoutAwarePage
    {
        public PartiesPage()
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
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // Ignoring navigationParameter - just displaying all parties
            DefaultViewModel["Parties"] = new AllPartiesViewModel(pageState);
        }

        protected override void SaveState(Dictionary<string, object> pageState)
        {
            (DefaultViewModel["Parties"] as AllPartiesViewModel).SaveState(pageState);
        }

        /// <summary>
        /// Invoked when a group header is clicked.
        /// </summary>
        /// <param name="sender">The Button used as a group header for the selected group.</param>
        /// <param name="e">Event data that describes how the click was initiated.</param>
        void Header_Click(object sender, RoutedEventArgs e)
        {
            // Determine what group the Button instance represents
            var group = (sender as FrameworkElement).DataContext;

            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            Frame.Navigate(typeof(PartyDetailPage), ((Party)group).Id);
        }

        /// <summary>
        /// Invoked when an item within a group is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var characterId = ((Character)e.ClickedItem).Id;
            this.Frame.Navigate(typeof(CharacterDetailPage), characterId);
        }
    }
}
