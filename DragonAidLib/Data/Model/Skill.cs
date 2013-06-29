using System.Collections.Generic;

namespace DragonAid.Lib.Data.Model
{
    /// <summary>
    /// Skills contain abilities. 
    /// 
    /// TODO We should probably merge the concepts of ability and skill. Abilities can contain arbitrary sub abilities... makes sense right?
    /// TODO The template for displaying an ability in the UI would always make a sublist if there are sub abilities... right?
    /// </summary>
    public class Skill
    {
        private readonly string _fullName;

        public Skill(string fullName)
        {
            _fullName = fullName;
        }

        public string FullName
        {
            get { return _fullName; }
        }

        public IList<IAbility> Abilities { get; set; }
    }
}