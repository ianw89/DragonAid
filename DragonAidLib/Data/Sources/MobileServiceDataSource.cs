using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace DragonAidLib.Data.Sources
{
    class MobileServiceDataSource : IDataSource
    {
        private static readonly MobileServiceClient MobileService = new MobileServiceClient(
            "https://dragonaid-msvc.azure-mobile.net/",
            "zqluHzWMYRCtytKXNZjkJhGxTXiQKX67"
        );

        public IMobileServiceTable<T> GetTable<T>()
        {
            return MobileService.GetTable<T>();
        }
    }
}
