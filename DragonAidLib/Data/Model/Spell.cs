using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace DragonAid.Lib.Data.Model
{
    /// <summary>
    /// Class that represents a Spell.
    /// TODO: Figure out how to handle talents and rituals. In general, some things do not follow the standard formulas.
    /// </summary>
    [DataContract]
    public class Spell : IMagicalAbility
    {
        public Spell(string fullName, int baseChance)
        {
            Contract.Requires(!string.IsNullOrEmpty(fullName));
            Contract.Requires(baseChance >= 0 && baseChance <= 100);

            this.FullName = fullName;
            this.BaseChance = baseChance;
        }

        [DataMember]
        public int BaseChance { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}