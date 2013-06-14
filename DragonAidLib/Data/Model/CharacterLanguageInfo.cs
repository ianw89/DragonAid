using System.Diagnostics.Contracts;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterLanguageInfo
    {
        private readonly Character _character;
        private int? _speakRank;
        private int? _readWriteRank;

        public CharacterLanguageInfo(Character character, Language language, int? speakRank, int? readWriteRank)
        {
            Contract.Requires(character != null);
            Contract.Requires(language != null);

            _character = character;
            Language = language;
            _speakRank = speakRank;
            _readWriteRank = readWriteRank;
        }

        public Language Language { get; private set; }

        public int? SpeakRank
        {
            get { return _speakRank; }
            set
            {
                Contract.Requires(_speakRank == null || _speakRank >= 0);
                _speakRank = value;
            }
        }

        public int? ReadWriteRank
        {
            get { return _readWriteRank; }
            set
            {
                Contract.Requires(_readWriteRank == null || _readWriteRank >= 0);
                _readWriteRank = value;
            }
        }

        public Character Character
        {
            get { return _character; }
        }
    }
}