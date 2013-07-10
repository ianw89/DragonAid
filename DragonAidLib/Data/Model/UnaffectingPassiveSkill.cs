using System.Collections.Generic;

namespace DragonAid.Lib.Data.Model
{
    public class UnaffectingPassiveSkill : ISkill
    {
        private readonly string _description;

        public UnaffectingPassiveSkill(string name, string description)
        {
            _description = description;
            this.FullName = name;
        }

        public string FullName { get; private set; }

        public IList<ISkill> Subskills
        {
            get { return new List<ISkill>(); }
        }

        public string Description
        {
            get { return _description; }
        }
    }
}