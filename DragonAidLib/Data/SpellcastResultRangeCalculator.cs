using System;

namespace DragonAid.Lib.Data
{
    public static class SpellcastResultRangeCalculator
    {
        public static SpellcastResultRange Calculate(int castChance)
        {
            return new SpellcastResultRange
                {
                    Backfire = castChance * 3,
                    DoubleEffect = (int)Math.Floor(((decimal)castChance) / 3),
                    TripleEffect = (int)Math.Floor(((decimal)castChance) / 5),
                };
        }
    }
}