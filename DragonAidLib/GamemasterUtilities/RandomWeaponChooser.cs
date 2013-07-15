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
        private readonly Random _rand;
        private readonly List<Weapon> _allWeapons;
        private readonly List<Func<IEnumerable<Weapon>, Character, bool>> _baseArchtypes; 

        public RandomWeaponChooser(List<Weapon> allWeapons)
        {
            Contract.Requires(allWeapons != null);
            this._rand = new Random();
            this._allWeapons = allWeapons;
            this._baseArchtypes = new List<Func<IEnumerable<Weapon>, Character, bool>>();
            _baseArchtypes.Add(AddRanksForMeleeFighter);
            _baseArchtypes.Add(AddRanksForMeleeFighter);
            _baseArchtypes.Add(AddRanksForArcher);
        }

        public void ChooseWeapons(Character character)
        {
            Contract.Requires(character != null);

            // Step 1: Make list of all possible weapons we could have ranks in based on the character's stats
            var possibilities = this.CreatePossibilities(character.PhysicalStrength, character.ManualDexterity);

            // Step 2: Choose an archtype and delegate
            //         Sometimes an archtype isn't possible due to eliminated weapons, so we try again if that happens
            var availibleArchtypes = _baseArchtypes.ToList();
            var success = false;

            while (!success)
            {
                if (availibleArchtypes.Count == 0)
                {
                    return;
                }

                var index = this._rand.Next(availibleArchtypes.Count);
                success = availibleArchtypes[index](possibilities, character);
                availibleArchtypes.RemoveAt(index);
            }
        }

        [TestOnly]
        internal bool AddRanksForArcher(IEnumerable<Weapon> possibilities, Character character)
        {
            var rangedOnlyWeapons = possibilities.Where(w => w.Use == WeaponKind.Ranged).ToArray();
            if (rangedOnlyWeapons.Length == 0)
            {
                return false;
            }

            var primaryWeapon = rangedOnlyWeapons[this._rand.Next(rangedOnlyWeapons.Length)];
            var ranksOfPrimary = this._rand.Next(primaryWeapon.MaxRank + 1);

            // TODO Consider eliminating really high / low ranks
            character.WeaponRanks.Add(primaryWeapon, ranksOfPrimary);

            // TODO Consider adding ranks to 1-2 secondary weapons
            return true;
        }

        [TestOnly]
        internal bool AddRanksForMeleeFighter(IEnumerable<Weapon> possibilities, Character character)
        {
            var meleeWeapons = possibilities.Where(w => w.Use.HasFlag(WeaponKind.Melee)).ToArray();
            if (meleeWeapons.Length == 0)
            {
                return false;
            }

            var primaryWeapon = meleeWeapons[this._rand.Next(meleeWeapons.Length)];
            var ranksOfPrimary = this._rand.Next(primaryWeapon.MaxRank + 1);

            // TODO Consider eliminating really high / low ranks
            character.WeaponRanks.Add(primaryWeapon, ranksOfPrimary);

            // TODO Consider adding ranks to 1-2 secondary weapons
            return true;
        }

        [TestOnly]
        internal IEnumerable<Weapon> CreatePossibilities(int maximumStength, int maximumDexterity)
        {
            return this._allWeapons.Where(w => w.PhysicalStengthRequired <= maximumStength && w.ManualDexterityRequired <= maximumDexterity);
        }
    }
}