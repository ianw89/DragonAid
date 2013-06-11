using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterLanguageRanks : IEnumerable<CharacterLanguageInfo>
    {
        private readonly List<CharacterLanguageInfo> _languages = new List<CharacterLanguageInfo>();
        private readonly Character _character;

        public CharacterLanguageRanks(Character character)
        {
            _character = character;
        }

        public IEnumerator<CharacterLanguageInfo> GetEnumerator()
        {
            return _languages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Language language, int? speakRank, int? readWriteRank)
        {
            this[language] = new CharacterLanguageInfo(_character, language, speakRank, readWriteRank);
        }

        protected CharacterLanguageInfo this[Language language]
        {
            get
            {
                var characterLanguageInfo = _languages.SingleOrDefault(w => w.Language == language);
                if (characterLanguageInfo == null)
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                                                                      "Character has no ranks in {0}!", language.FullName));
                }
                return characterLanguageInfo;
            }
            set
            {
                Contract.Requires(value != null);

                var characterLanguageInfo = _languages.SingleOrDefault(w => w.Language == language);
                if (characterLanguageInfo == null)
                {
                    _languages.Add(value);
                }
                else
                {
                    characterLanguageInfo.SpeakRank = value.SpeakRank;
                    characterLanguageInfo.ReadWriteRank = value.ReadWriteRank;
                }
            }
        }
    }
}