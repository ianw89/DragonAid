using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public static class CharacterEquations
    {
        public static int ComputeBasicTacticalMovementRate(int agility, Race race)
        {
            Contract.Requires(race != null);

            int tmr;

            if (agility > 25)
                tmr = 8;
            else if (agility > 21)
                tmr = 7;
            else if (agility > 17)
                tmr = 6;
            else if (agility > 12)
                tmr = 5;
            else if (agility > 8)
                tmr = 4;
            else if (agility > 4)
                tmr = 3;
            else tmr = 2;

            return tmr + race.TacticalMovementRateModifier;
        }

#if !DRAGON_COMMANDER

        public static int ComputeCastChance(int magicalAptitude, int rank, int spellBaseChance)
        {
            return spellBaseChance + (magicalAptitude - 15) + (3 * rank);
        }

#endif
    }
}