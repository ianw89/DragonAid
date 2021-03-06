using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DragonAid.Lib.Data.Model
{
    [DataContract]
    public class Talent : IMagicalSkill
    {
        public Talent(string name)
        {
            this.FullName = name;
        }

        [DataMember]
        public string FullName { get; private set; }

        public IList<ISkill> Subskills { get { return new List<ISkill>(); } }

        public string Description { get { return "TODO: Descriptions for Talents"; } }
    }
}