using Microsoft.WindowsAzure.MobileServices;

// TODO: this shouldn't be dependent on MobileServices
// Probably IDataSource should require templatized versions of IMobileServiceTable's <blah>Async methods
namespace DragonAidLib.Data.Sources
{
    interface IDataSource
    {
        IMobileServiceTable<T> GetTable<T>();
    }
}