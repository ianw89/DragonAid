using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
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

            converter.Convert(action.DetermineChanceOfSuccess, typeof (string), joe, "en-us").Should().Be("45");
        }
    }
}