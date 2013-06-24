using System;

namespace DragonAid.Lib.Data
{
    public static class Dice
    {
        private static readonly Random Rand = new Random();

        public static int RollD100()
        {
            return Rand.Next(100) + 1;
        }
    }
}