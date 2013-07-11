using System;

namespace DragonAid.Lib.GamemasterUtilities
{
    /// <summary>
    /// Class that generates a characteristic's value by randomly choosing a number in range. 
    /// All numbers have equal chance of being chosen.
    /// </summary>
    public class RandomCharacteristicGenerator
    {
        private readonly Random _rand;

        public RandomCharacteristicGenerator()
        {
            this._rand = new Random();            
        }

        public int Generate(CharacteristicRangeTemplate physicalStrengthRange)
        {
            return this._rand.Next(physicalStrengthRange.Minimum, physicalStrengthRange.Maximum);
        }
    }
}