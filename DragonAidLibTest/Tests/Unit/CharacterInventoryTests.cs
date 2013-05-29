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
            var testSubject = new CharacterInventory { new Item("Sandwich", 1), new Weapon("Shotgun", 0, 5) };
            testSubject.TotalWeight.Should().Be(6m);
        }

        [TestMethod]
        public void EmptyInventoryIsWeightless()
        {
            new CharacterInventory().TotalWeight.Should().Be(0m);
        }
    }
}