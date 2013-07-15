using System.Collections.Generic;
using System.Linq;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using DragonAid.Lib.GamemasterUtilities;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class RandomWeaponChooserTests
    {
        private readonly Character _dummyCharacter = new Character();

        [TestMethod]
        public void CreatePossibilitiesUsesStrengthAndDex()
        {
            var chooser = new RandomWeaponChooser(new List<Weapon>()
                {
                    new Weapon("A", 1, 1),
                    new Weapon("B", 2, 3),
                    new Weapon("C", 3, 2),
                    new Weapon("D", 3, 3),
                    new Weapon("E", 2, 2)
                });

            var results = chooser.CreatePossibilities(2, 2);

            var resultsList = results as IList<Weapon> ?? results.ToList();
            resultsList.Should().HaveCount(2);
            resultsList.Should().OnlyContain(w => w.FullName == "A" || w.FullName == "E");
        }

        [TestMethod]
        public void CreatePossibilitiesCanCreateEmptyListIfAppropriate()
        {
            var chooser = new RandomWeaponChooser(new List<Weapon>()
                {
                    new Weapon("A", 0, 2),
                    new Weapon("B", 2, 0),
                    new Weapon("C", 10, 10),
                });

            var results = chooser.CreatePossibilities(1, 1);

            var resultsList = results as IList<Weapon> ?? results.ToList();
            resultsList.Should().BeEmpty();
        }

        [TestMethod]
        public void AddRanksForMeleeFighterShouldChooseAMeleeWeapon()
        {
            var weapons = new List<Weapon>()
                {
                    new Weapon("A", 1, 1, WeaponKind.Melee, 10),
                    new Weapon("B", 1, 1, WeaponKind.Ranged, 10),
                    new Weapon("C", 1, 1, WeaponKind.Ranged, 10),
                    new Weapon("D", 1, 1, WeaponKind.Ranged, 10),
                };
            var chooser = new RandomWeaponChooser(weapons);

            chooser.AddRanksForMeleeFighter(weapons, _dummyCharacter);

            // There is only 1 melee weapon, so it MUST be chosen
            _dummyCharacter.WeaponRanks.Should().Contain(i => i.Weapon == weapons.First());
        }

        [TestMethod]
        public void AddRanksForArcherShouldChooseARealRangedWeapon()
        {
            // Weapons that have more than just the ranged flag aren't primarilly ranged, so
            // we don't want them counted as a primary ranged weapon
            var weapons = new List<Weapon>()
                {
                    new Weapon("A", 1, 1, WeaponKind.Ranged, 10),
                    new Weapon("B", 1, 1, WeaponKind.Melee | WeaponKind.Ranged, 10),
                    new Weapon("C", 1, 1, WeaponKind.Melee | WeaponKind.Ranged, 10),
                    new Weapon("D", 1, 1, WeaponKind.Melee | WeaponKind.Ranged, 10),
                };
            var chooser = new RandomWeaponChooser(weapons);

            var result = chooser.AddRanksForArcher(weapons, _dummyCharacter);

            // There is only 1 ranged-only weapon, so it MUST be chosen
            result.Should().BeTrue();
            _dummyCharacter.WeaponRanks.Should().Contain(i => i.Weapon == weapons.First());
        }

        [TestMethod]
        public void ChooseWeaponsShouldDoNothingIfNoArchtypeIsPossible()
        {
            var weapons = new List<Weapon>()
                {
                    new Weapon("A", 1, 1, WeaponKind.Unspecified, 10),
                };
            var chooser = new RandomWeaponChooser(weapons);

            chooser.ChooseWeapons(_dummyCharacter);

            // Nothing should have happened. Just ensuring that we don't error.
            _dummyCharacter.WeaponRanks.Should().BeEmpty();
        }
    }
}
