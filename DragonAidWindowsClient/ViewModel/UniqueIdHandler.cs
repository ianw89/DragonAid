using System;

namespace DragonAid.WindowsClient.ViewModel
{
    public static class UniqueIdHandler
    {
        public static string CharacterIdToUniqueId(int characterId)
        {
            return String.Format("Character/{0}", characterId);
        }
    }
}