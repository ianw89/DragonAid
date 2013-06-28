using System.Runtime.Serialization;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    [DataContract]
    public class Talent : IMagicalAbility
    {
        public Talent(string name)
        {
            this.FullName = name;
        }

        [DataMember]
        public string FullName { get; private set; }
    }
}