using DragonAidLib.Data;
using DragonAidLib.Data.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAidLibTest.Tests.Unit
{
    [TestClass]
    public class DetermineChanceOfSuccessConverterTest
    {
        [TestMethod]
        public void DetermineChanceOfSuccessConverter_ConvertJoesSapChance()
        {
            var converter = new DetermineChanceOfSuccessConverter();

            var action = new CombatAction("Do a MA based thing", c => 30 + c.MagicalAptitude);

            var joe = new Character
            {
                MagicalAptitude = 15,
            };

            Assert.AreEqual("45", converter.Convert(action.DetermineChanceOfSuccess, typeof(string), joe, "en-us"));
        }
    }
}