using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.GamemasterUtilities
{
    public class RandomWeaponChooser : IWeaponChooser
    {
        private Random _rand;
        private readonly List<Weapon> _allWeapons;

        public RandomWeaponChooser(List<Weapon> allWeapons)
        {
            this._rand = new Random();
            this._allWeapons = allWeapons;
        }

        public void ChooseWeapons(Character character)
        {
            Contract.Requires(character != null);

            // Step 1: Make list of all possible weapons we could have ranks in based on the character's stats
            var possibilities = this.CreatePossibilities(character.PhysicalStrength, character.ManualDexterity);

            // TODO Something more interesting
            character.WeaponRanks.Add(possibilities.First(), 0);
        }

        [TestOnly]
        internal IEnumerable<Weapon> CreatePossibilities(int maximumStength, int maximumDexterity)
        {
            return this._allWeapons.Where(w => w.PhysicalStengthRequired <= maximumStength && w.ManualDexterityRequired <= maximumDexterity);
        }
    }
}