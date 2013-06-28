using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DragonAid.Test.Tests.Unit
{
    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void AddLanguageToCharacter()
        {
            var c = new Character();
            c.Languages = new CharacterLanguageRanks(c);
            var language = new Language("foo");
            c.Languages.Add(language, 1, 2);
            c.Languages.Single().Language.Should().BeSameAs(language);
        }

        [TestMethod]
        public void AddLanguageToCharacterAtInitialization()
        {
            var language = new Language("foo");
            var c = new Character()
                {
                    Languages =
                        {
                            { language, 1, 2 }
                        }
                };
            c.Languages.Single().Language.Should().BeSameAs(language);
        }
    }
}
