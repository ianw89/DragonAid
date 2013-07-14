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
        [TestMethod]
        public void WeaponChooserShouldCreateListOfPossibleWeaponsFromStrengthAndDex()
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
    }
}
