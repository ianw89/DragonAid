using System;

namespace DragonAid.Lib.Data
{
    public static class SpellcastResultRangeCalculator
    {
        public static SpellcastResultRange Calculate(int castChance)
        {
            return new SpellcastResultRange
                {
                    Backfire = castChance + 30,
                    DoubleEffect = (int)Math.Floor(((decimal)castChance * 15) / 100),
                    TripleEffect = (int)Math.Floor(((decimal)castChance * 5) / 100),
                };
        }
    }
}