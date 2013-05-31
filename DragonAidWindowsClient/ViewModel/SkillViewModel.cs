using System;
using DragonAid.Lib.Data.Model;

namespace DragonAid.WindowsClient.ViewModel
{
    public class SkillViewModel
    {
        private readonly CharacterSkillInfo _characterSkillInfo;

        public SkillViewModel(CharacterSkillInfo characterSkillInfo)
        {
            _characterSkillInfo = characterSkillInfo;
        }

        public string FullName
        {
            get { return this._characterSkillInfo.Skill.FullName; }
            set { throw new NotSupportedException();}
        }

        public int Rank
        {
            get { return this._characterSkillInfo.Rank; }
            set { throw new NotSupportedException();}
        }
    }
}
