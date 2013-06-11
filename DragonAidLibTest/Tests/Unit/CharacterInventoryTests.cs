using System.Collections.Generic;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class CharacterInventoryTests
    {
        private readonly Armor _testArmor = new Armor("Fake armor", -1, 2);

        [TestMethod]
        public void InventoryShouldBeEmptyByDefault()
        {
            new CharacterInventory().Should().BeEmpty();
        }

        [TestMethod]
        public void ItemCanBeAddedToInventory()
        {
            var testSubject = new CharacterInventory();
            var item = new Item("Fake item", 0);
            testSubject.Add(item);
            testSubject.Should().Contain(item);
        }

        [TestMethod]
        public void CharacterCanBeInitializedWithItemInInventory()
        {  
            var item = new Item("Fake item", 0);
            var character = new Character { Inventory = { item } };
            character.Inventory.Should().Contain(item);
        }

        [TestMethod]
        public void InventoryCanReportTotalWeight()
        {
            var testSubject = new CharacterInventory { new Item("Sandwich", 1), new Weapon("Shotgun", 5, 0, WeaponKind.Ranged, 10) };
            testSubject.TotalWeight.Should().Be(6m);
        }

        [TestMethod]
        public void EmptyInventoryIsWeightless()
        {
            new CharacterInventory().TotalWeight.Should().Be(0m);
        }

        [TestMethod]
        public void NoArmorIsEquippedByDefault()
        {
            new CharacterInventory().EquippedArmor.Should().BeNull();
        }

        [TestMethod]
        public void ArmorAddedToInventoryIsNotAutomaticallyEquipped()
        {
            new CharacterInventory { _testArmor}.EquippedArmor.Should().BeNull();
        }

        [TestMethod]
        public void EquippedArmorIsAutomaticallyPartOfInventory()
        {
            new CharacterInventory { EquippedArmor = _testArmor }.Should().Contain(_testArmor);
        }

        [TestMethod]
        public void ArmorThatIsUnequippedStaysInInventory()
        {
            var inventory = new CharacterInventory { EquippedArmor = _testArmor };
            inventory.EquippedArmor = null;
            inventory.Should().Contain(_testArmor);
        }

        [TestMethod]
        public void ArmorThatWasInInventoryIsNotDoubleCountedWhenEquipped()
        {
            var inventory = new CharacterInventory { _testArmor };
            inventory.EquippedArmor = _testArmor;
            inventory.Should().HaveCount(1);
        }

        [TestMethod]
        public void ArmorThatWasInInventoryIsNotDoubleCountedWhenEquippedTwice()
        {
            var inventory = new CharacterInventory { _testArmor };
            inventory.EquippedArmor = _testArmor;
            inventory.EquippedArmor = _testArmor;
            inventory.Should().HaveCount(1);
        }
    }
}