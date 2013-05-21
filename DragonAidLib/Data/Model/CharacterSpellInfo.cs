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

        // TODO: This is not the way properties that are data bound should work.
        // They need setters to trigger the UI to update. They need to be dumb values controlled by something else.
        public int BaseCastChace
        {
            get
            {
                return CharacterEquations.ComputeCastChance(this._character.MagicalAptitude, this.Rank, this.Spell.BaseChance);
            }
            set
            {
                throw new NotSupportedException("Cannot set the BaseCastChance.");
            }
        }
    }
}