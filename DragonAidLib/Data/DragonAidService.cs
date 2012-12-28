using Microsoft.WindowsAzure.MobileServices;

namespace DragonAidLib.Data
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
    }
}
