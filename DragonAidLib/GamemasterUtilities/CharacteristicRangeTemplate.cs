using System.Diagnostics.Contracts;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.GamemasterUtilities
{
    public class CharacteristicRangeTemplate
    {
        public CharacteristicRangeTemplate(int minimum, int maximum)
        {
            ExceptionUtils.MustBeTrue(minimum >= 0);
            ExceptionUtils.MustBeTrue(maximum >= minimum);
            Minimum = minimum;
            Maximum = maximum;
        }

        public int Minimum { get; set; }
        public int Maximum { get; private set; }
    }
}