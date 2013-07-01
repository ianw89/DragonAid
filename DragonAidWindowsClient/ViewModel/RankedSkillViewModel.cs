using System;
using DragonAid.Lib.Data.Model;

namespace DragonAid.WindowsClient.ViewModel
{
    /// <summary>
    /// View model for a ranked skill. 
    /// Extends the basic SkillViewModel with Rank information.
    /// </summary>
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
