using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterSpellRanks : IEnumerable<CharacterSpellInfo>
    {
        private readonly List<CharacterSpellInfo> _list = new List<CharacterSpellInfo>();
        private readonly Character character;

        public CharacterSpellRanks(Character character)
        {
            ExceptionUtils.CheckArgumentNotNull(character);
            this.character = character;
        }

        public IEnumerator<CharacterSpellInfo> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Spell spell, int rank)
        {
            this[spell] = rank;
        }

        public int this[Spell spell]
        {
            get
            {
                ExceptionUtils.CheckArgumentNotNull(spell);

                var characterSpellInfo = this._list.SingleOrDefault(s => s.Spell == spell);
                if (characterSpellInfo == null)
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                                                                      "Character has no ranks in {0}!", spell.FullName));
                }

                return characterSpellInfo.Rank;
            }

            set
            {
                ExceptionUtils.CheckArgumentNotNull(spell);
                ExceptionUtils.MustBeTrue(value > -1);

                var spellInfo = this._list.SingleOrDefault(s => s.Spell == spell);
                if (spellInfo == null)
                {
                    this._list.Add(new CharacterSpellInfo(spell, value, this.character));
                }
                else
                {
                    spellInfo.Rank = value;
                }
            }
        }
    }
}