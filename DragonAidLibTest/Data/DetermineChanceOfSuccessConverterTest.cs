using DragonAidLib.Data;
using DragonAidLib.Data.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAidLibTest.Data
{
    [TestClass]
    public class DetermineChanceOfSuccessConverterTest
    {
        [TestMethod]
        public void DetermineChanceOfSuccessConverter_ConvertJoesSapChance()
        {
            var converter = new DetermineChanceOfSuccessConverter();

            var action = new CombatAction("Do a MA based thing", c => 30 + c.MagicalAptitude);

            var joe = new Character("Joe Average", "", "", "", "", null)
            {
                Agility = 15,
                Endurance = 15,
                Fatigue = 15,
                MagicalAptitude = 15,
                ManualDexterity = 15,
                Perception = 15,
                PhysicalBeauty = 15,
                PhysicalStrength = 15,
                Willpower = 15,
                Race = Race.Human
            };

            Assert.AreEqual("45", converter.Convert(action.DetermineChanceOfSuccess, "".GetType(), joe, "en-us"));
        }
    }
}