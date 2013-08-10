using System.Runtime.Serialization;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.GamemasterUtilities
{
    [DataContract]
    public class CharacteristicRangeTemplate
    {
        public CharacteristicRangeTemplate(int minimum, int maximum)
        {
            ExceptionUtils.MustBeTrue(minimum >= 0);
            ExceptionUtils.MustBeTrue(maximum >= minimum);
            Minimum = minimum;
            Maximum = maximum;
        }

        [DataMember]
        public int Minimum { get; set; }
        [DataMember]
        public int Maximum { get; set; }
    }
}