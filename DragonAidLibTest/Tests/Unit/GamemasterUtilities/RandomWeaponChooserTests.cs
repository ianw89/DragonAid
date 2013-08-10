using DragonAid.Lib.Data.Model;
using DragonAid.Lib.GamemasterUtilities;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Collections.Generic;
using System.Linq;

namespace DragonAid.Test.Tests.Unit.GamemasterUtilities
{
    [TestClass]
    public class RandomWeaponChooserTests
    {
        private readonly Character _dummyCharacter = new Character();

        [TestMethod]
        public void CreatePossibilitiesUsesStrengthAndDex()
        {
            var chooser = new RandomWeaponChooser(new List<WeaponSkill>()
                {
                    new WeaponSkill("A", 1, 1),
                    new WeaponSkill("B", 2, 3),
                    new WeaponSkill("C", 3, 2),
                    new WeaponSkill("D", 3, 3),
                    new WeaponSkill("E", 2, 2)
                });

            var results = chooser.CreatePossibilities(2, 2);

            var resultsList = results as IList<WeaponSkill> ?? results.ToList();
            resultsList.Should().HaveCount(2);
            resultsList.Should().OnlyContain(w => w.FullName == "A" || w.FullName == "E");
        }

        [TestMethod]
        public void CreatePossibilitiesCanCreateEmptyListIfAppropriate()
        {
            var chooser = new RandomWeaponChooser(new List<WeaponSkill>()
                {
                    new WeaponSkill("A", 0, 2),
                    new WeaponSkill("B", 2, 0),
                    new WeaponSkill("C", 10, 10),
                });

            var results = chooser.CreatePossibilities(1, 1);

            var resultsList = results as IList<WeaponSkill> ?? results.ToList();
            resultsList.Should().BeEmpty();
        }

        [TestMethod]
        public void AddRanksForMeleeFighterShouldChooseAMeleeWeapon()
        {
            var weapons = new List<WeaponSkill>()
                {
                    new WeaponSkill("A", 1, WeaponKind.Melee, 10, 1, 1),
                    new WeaponSkill("B", 1, WeaponKind.Ranged, 10, 1, 1),
                    new WeaponSkill("C", 1, WeaponKind.Ranged, 10, 1, 1),
                    new WeaponSkill("D", 1, WeaponKind.Ranged, 10, 1, 1),
                };
            var chooser = new RandomWeaponChooser(weapons);

            chooser.AddRanksForMeleeFighter(weapons, this._dummyCharacter);

            // There is only 1 melee weapon, so it MUST be chosen
            this._dummyCharacter.WeaponRanks.Should().Contain(i => i.Weapon == weapons.First());
        }

        [TestMethod]
        public void AddRanksForArcherShouldChooseARealRangedWeapon()
        {
            // Weapons that have more than just the ranged flag aren't primarilly ranged, so
            // we don't want them counted as a primary ranged weapon
            var weapons = new List<WeaponSkill>()
                {
                    new WeaponSkill("A", 1, WeaponKind.Ranged, 10, 1, 1),
                    new WeaponSkill("B", 1, WeaponKind.Melee | WeaponKind.Ranged, 10, 1, 1),
                    new WeaponSkill("C", 1, WeaponKind.Melee | WeaponKind.Ranged, 10, 1, 1),
                    new WeaponSkill("D", 1, WeaponKind.Melee | WeaponKind.Ranged, 10, 1, 1),
                };
            var chooser = new RandomWeaponChooser(weapons);

            var result = chooser.AddRanksForArcher(weapons, this._dummyCharacter);

            // There is only 1 ranged-only weapon, so it MUST be chosen
            result.Should().BeTrue();
            this._dummyCharacter.WeaponRanks.Should().Contain(i => i.Weapon == weapons.First());
        }

        [TestMethod]
        public void ChooseWeaponsShouldDoNothingIfNoArchtypeIsPossible()
        {
            var weapons = new List<WeaponSkill>()
                {
                    new WeaponSkill("A", 1, WeaponKind.Unspecified, 10, 1, 1),
                };
            var chooser = new RandomWeaponChooser(weapons);

            chooser.ChooseWeapons(this._dummyCharacter);

            // Nothing should have happened. Just ensuring that we don't error.
            this._dummyCharacter.WeaponRanks.Should().BeEmpty();
        }
    }
}
