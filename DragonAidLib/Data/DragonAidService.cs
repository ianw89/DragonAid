using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

namespace DragonAid.Lib.Data
{
    /// <summary>
    /// Acts as a singleton around an app-wide MobileServiceClient pointing to the production
    /// DragonAid Azure Mobile Service.
    /// </summary>
    /// <remarks>
    /// Tests will typically NOT want to use this class - ideally, very few of them will need
    /// to deal with a MobileServiceClient at all. Those that do should create a test
    /// MobileServiceClient pointed to a garbage address and use
    /// <see cref="MobileServiceClient.WithFilter"/> to mock results. See the actual Azure
    /// Mobile Services SDK's ZumoService.Tests.cs unit tests for a good example of this method.
    /// </remarks>
    public static class DragonAidService
    {
        private static readonly MobileServiceClient MobileService = new MobileServiceClient(
            "https://dragonaid-msvc.azure-mobile.net/",
            "zqluHzWMYRCtytKXNZjkJhGxTXiQKX67"
        );
        
        public static MobileServiceClient Client { get { return MobileService; } }

        public static bool IsLoggedIn(this MobileServiceClient client)
        {
            return null != client.CurrentUser;
        }

        public static async Task RequireLoginAsync()
        {
            while (!Client.IsLoggedIn())
            {
                string failureMessage = null;
                try
                {
                    await Client.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount);
                    if (!Client.IsLoggedIn())
                    {
                        failureMessage =
                            "DragonAid needs to be connected to its servers to work - please log in and try again.";
                    }
                }
                catch (MobileServiceInvalidOperationException e)
                {
                    failureMessage = "Client failed to authenticate: "+e.ToString(); // TODO: Make nicer
                }
                catch (InvalidOperationException e)
                {
                    failureMessage = "Service failed to authenticate: "+e.ToString(); // TODO: Make nicer
                }

                if (failureMessage != null)
                {
                    var dialog = new MessageDialog(failureMessage, "Could not connect to DragonAid servers");
                    await dialog.ShowAsync();
                }
            }
        }
    }
}
