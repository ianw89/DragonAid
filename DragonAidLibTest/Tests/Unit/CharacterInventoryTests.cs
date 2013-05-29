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
            var item = new Item();
            testSubject.Add(item);
            testSubject.Should().Contain(item);
        }
    }
}