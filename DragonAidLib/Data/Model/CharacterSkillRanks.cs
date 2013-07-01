using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterSkillRanks : IEnumerable<CharacterSkillInfo>
    {
        private readonly List<CharacterSkillInfo> _list = new List<CharacterSkillInfo>();
        private readonly Character character;

        public CharacterSkillRanks(Character character)
        {
            Contract.Requires(character != null);
            this.character = character;
        }

        public IEnumerator<CharacterSkillInfo> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TopLevelSkill skill, int rank)
        {
            this[skill] = rank;
        }

        public int this[TopLevelSkill skill]
        {
            get
            {
                Contract.Requires(skill != null);

                var characterSkillInfo = this._list.SingleOrDefault(s => s.Skill == skill);
                if (characterSkillInfo == null)
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                                                                      "Character has no ranks in {0}!", skill.FullName));
                }

                return characterSkillInfo.Rank;
            }

            set
            {
                Contract.Requires(skill != null);
                Contract.Requires(value > -0);

                var characterSkillInfo = this._list.SingleOrDefault(w => w.Skill == skill);
                if (characterSkillInfo == null)
                {
                    this._list.Add(new CharacterSkillInfo(skill, value, this.character));
                }
                else
                {
                    characterSkillInfo.Rank = value;
                }
            }
        }
    }
}