using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using DragonAid.WindowsClient.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DragonAid.WindowsClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamemasterConsolePage : Page
    {
        private CharacterViewModel _characterToDisplay;

        public GamemasterConsolePage()
        {
            this.InitializeComponent();
            this._characterToDisplay = new CharacterViewModel(HardCodedSampleData.SampleCharacters.First());
            this.DataContext = CharacterToDisplay;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public CharacterViewModel CharacterToDisplay
        {
            get { return this._characterToDisplay; }
            set { this._characterToDisplay = value; }
        }
    }
}
