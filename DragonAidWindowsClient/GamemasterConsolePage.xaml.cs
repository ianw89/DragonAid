using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using DragonAid.WindowsClient.Common;
using DragonAid.WindowsClient.ViewModel;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DragonAid.WindowsClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamemasterConsolePage : LayoutAwarePage
    {
        private readonly PartyViewModel _partyViewModel = new PartyViewModel();
        private double _difficultyFactor;
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

        private void MakeTeamPerceptionRollClicked(object sender, RoutedEventArgs e)
        {
            var checker = new TeamAttributeChecker(this.PartyViewModel.Characters.Select(v => v.Character));
            if (this._difficultyFactor > 0)
            {
                var result = checker.MakeTeamRoll(this._difficultyFactor, (c) => c.Perception);
                this.PerceptionRollResults.Text = result.ToString();
            }
        }

        private void DifficultyFactorTextChanged(object sender, TextChangedEventArgs e)
        {
            // Clear any previous results
            this.PerceptionRollResults.Text = "";

            // If what is in the box does not parse correctly, then outline box in red
            this._difficultyFactor = -1;
            if (Double.TryParse(this.PerceptionRollDifficultyFactorBox.Text, out _difficultyFactor))
            {
                this.PerceptionRollDifficultyFactorBox.BorderBrush = new SolidColorBrush(Colors.White);
            }
            else
            {
                this.PerceptionRollDifficultyFactorBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private void RollDiceButtonClicked(object sender, RoutedEventArgs e)
        {
            this.RollDiceResults.Text = Dice.RollD100().ToString();
        }
    }
}
