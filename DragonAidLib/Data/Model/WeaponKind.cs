using System;

namespace DragonAid.Lib.Data.Model
{
    /// <summary>
    /// The possible ways to use a weapon. A weapon may be used in one or more of these modes.
    /// </summary>
    [Flags]
    public enum WeaponKind
    {
        Unspecified = 0,
        Ranged = 1,
        Melee = 2,
        Close = 4,
    }
}