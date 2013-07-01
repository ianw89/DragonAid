using System.Collections.Generic;

namespace DragonAid.Lib.Data.Model
{
    /// <summary>
    /// Skills contain abilities. 
    /// TODO The template for displaying an ability in the UI would always make a sublist if there are sub abilities... right?
    /// </summary>
    public class TopLevelSkill : INonMagicalSkill
    {
        private readonly string _fullName;

        public TopLevelSkill(string fullName, string description)
        {
            _fullName = fullName;
            Description = description;
        }

        public string FullName
        {
            get { return _fullName; }
        }

        public IList<ISkill> Subskills { get; set; }

        public string Description { get; set; }
    }
}