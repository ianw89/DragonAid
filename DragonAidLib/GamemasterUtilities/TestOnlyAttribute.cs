using System;

namespace DragonAid.Lib.GamemasterUtilities
{
    /// <summary>
    /// Indicates that a given method, though internal, is actually meant to be private and is internal only for unit tests.
    /// </summary>
    public class TestOnlyAttribute : Attribute
    {
        // TODO Can we enforce that a method marked with this is only called from the Test DLL or the class it belongs to?
        // My only thought is to write a custom FxCop rule, but that sounds horrible.
    }
}