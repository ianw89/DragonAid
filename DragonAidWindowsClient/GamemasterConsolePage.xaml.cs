﻿using System;
using System.Collections.Generic;
using System.Linq;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using DragonAid.WindowsClient.Common;
using DragonAid.WindowsClient.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DragonAid.WindowsClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamemasterConsolePage : LayoutAwarePage
    {
        private readonly PartyViewModel _partyViewModel = new PartyViewModel();
        //private Character _clickedCharacter;

        public GamemasterConsolePage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            if (navigationParameter != null)
            {
                var partyId = (int) navigationParameter;
                this.PartyViewModel.LoadState(partyId, null);
                this.PartyViewModel.LoadPartyFromStaticData(partyId);
            }
            else throw new InvalidOperationException();        
        }

        public PartyViewModel PartyViewModel
        {
            get { return _partyViewModel; }
        }

        private void CharacterClicked(object sender, ItemClickEventArgs e)
        {
            // Remember what is clicked for later...? TODO
            //this._clickedCharacter = ((CharacterViewModel) e.ClickedItem).Character;
        }
    }
}
