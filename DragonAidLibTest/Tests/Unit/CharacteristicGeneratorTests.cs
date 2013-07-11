using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonAid.Lib.GamemasterUtilities;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class CharacteristicGeneratorTests
    {
        [TestMethod]
        public void RandomGeneratorShouldUseNumberIfNoRangeProvided()
        {
            var template = new CharacteristicRangeTemplate(10, 10);
            var generator = new RandomCharacteristicGenerator();
            generator.Generate(template).Should().Be(10);
        }

        [TestMethod]
        public void RandomGeneratorShouldPickNumberWithinRange()
        {
            var template = new CharacteristicRangeTemplate(10, 12);
            var generator = new RandomCharacteristicGenerator();
            
            for (int i = 0; i < 100; i++)
            {
                generator.Generate(template).Should().BeInRange(10, 12);
            }
        }
    }
}
