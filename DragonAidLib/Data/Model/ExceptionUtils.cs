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

        public static void CheckNotNull(object value)
        {
            Debug.Assert(value != null, "The value should never be null.");

            if (value == null)
            {
                throw new InvalidOperationException();
            }
        }

        public static void MustBeTrue(bool condition)
        {
            Debug.Assert(condition, "The condition must be true.");
            
            if (!condition)
            {
                throw new InvalidOperationException();
            }
        }
    }
}