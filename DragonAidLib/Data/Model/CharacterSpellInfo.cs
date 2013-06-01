using System;

namespace DragonAid.Lib.Data.Model
{
    /// <summary>
    /// Class encapsolating all the info about a character's progress with a Spell.
    /// </summary>
    public class CharacterSpellInfo
    {
        private readonly Character _character;

        public CharacterSpellInfo(Spell spell, int rank, Character character)
        {
            _character = character;
            Spell = spell;
            Rank = rank;
        }

        public Spell Spell { get; set; }
        public int Rank { get; set; }

        public int CastChace
        {
            get
            {
                return CharacterEquations.ComputeCastChance(this._character, this.Spell);
            }
            set
            {
                throw new NotSupportedException("Cannot set the BaseCastChance.");
            }
        }
    }
}