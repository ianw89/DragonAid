using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.GamemasterUtilities
{
    /// <summary>
    /// This IWeaponChooser looks randomly chooses a reasonable number of weapons that a character can
    /// use, and gives the character some ranks in those weapons. It takes no preferences into account.
    /// </summary>
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

            // Step 2: Choose an archtype and delegate
            var result = this._rand.Next(3);
            switch (result)
            {
                case 0:
                case 1:
                    this.AddRanksForMeleeFighter(possibilities, character);
                    break;
                case 2:
                    this.AddRanksForArcher(possibilities, character);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [TestOnly]
        internal void AddRanksForArcher(IEnumerable<Weapon> possibilities, Character character)
        {
            var rangedOnlyWeapons = possibilities.Where(w => w.Use == WeaponKind.Ranged).ToArray();
            var primaryWeapon = rangedOnlyWeapons[this._rand.Next(rangedOnlyWeapons.Length)];
            var ranksOfPrimary = this._rand.Next(primaryWeapon.MaxRank + 1);

            // TODO Consider eliminating really high / low ranks
            character.WeaponRanks.Add(primaryWeapon, ranksOfPrimary);

            // TODO Consider adding ranks to 1-2 secondary weapons
        }

        [TestOnly]
        internal void AddRanksForMeleeFighter(IEnumerable<Weapon> possibilities, Character character)
        {
            var meleeWeapons = possibilities.Where(w => w.Use.HasFlag(WeaponKind.Melee)).ToArray();
            var primaryWeapon = meleeWeapons[this._rand.Next(meleeWeapons.Length)];
            var ranksOfPrimary = this._rand.Next(primaryWeapon.MaxRank + 1);

            // TODO Consider eliminating really high / low ranks
            character.WeaponRanks.Add(primaryWeapon, ranksOfPrimary);

            // TODO Consider adding ranks to 1-2 secondary weapons
        }

        [TestOnly]
        internal IEnumerable<Weapon> CreatePossibilities(int maximumStength, int maximumDexterity)
        {
            return this._allWeapons.Where(w => w.PhysicalStengthRequired <= maximumStength && w.ManualDexterityRequired <= maximumDexterity);
        }
    }
}