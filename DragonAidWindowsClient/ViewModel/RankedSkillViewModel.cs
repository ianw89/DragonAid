using System;
using DragonAid.Lib.Data.Model;

namespace DragonAid.WindowsClient.ViewModel
{
    public class RankedSkillViewModel : SkillViewModel
    {
        private readonly CharacterSkillInfo _characterSkillInfo;

        public RankedSkillViewModel(CharacterSkillInfo characterSkillInfo) : base(characterSkillInfo.Skill)
        {
            _characterSkillInfo = characterSkillInfo;
        }

        public int Rank
        {
            get { return this._characterSkillInfo.Rank; }
            set { throw new NotSupportedException();}
        }
    }
}
