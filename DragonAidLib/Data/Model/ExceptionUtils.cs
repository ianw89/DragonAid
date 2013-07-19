using System;
using System.Diagnostics;

namespace DragonAid.Lib.Data.Model
{
    public static class ExceptionUtils
    {
        public static void CheckArgumentNotNull(object value)
        {
            Debug.Assert(value != null, "The argument should never be null.");
            
            if (value == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}