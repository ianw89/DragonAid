using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonAidWindowsClient.Common
{
    internal static class ExceptionUtils
    {
        public static void CheckArgumentNotNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
