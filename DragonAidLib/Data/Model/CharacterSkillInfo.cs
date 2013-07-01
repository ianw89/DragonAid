namespace DragonAid.Lib.Data.Model
{
    public class CharacterSkillInfo
    {
        private readonly TopLevelSkill _skill;
        private int _rank;
        private readonly Character _character;

        public CharacterSkillInfo()
        {
            
        }

        public CharacterSkillInfo(TopLevelSkill skill, int rank, Character character)
        {
            _skill = skill;
            _rank = rank;
            _character = character;
        }

        public TopLevelSkill Skill
        {
            get { return _skill; }
        }

        public int Rank
        {
            get { return _rank; }
            set { this._rank = value; }
        }

        public Character Character
        {
            get { return _character; }
        }
    }
}