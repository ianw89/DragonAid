using System.Diagnostics.Contracts;

namespace DragonAid.Lib.GamemasterUtilities
{
    public class CharacteristicRangeTemplate
    {
        public CharacteristicRangeTemplate(int minimum, int maximum)
        {
            Contract.Requires(minimum >= 0);
            Contract.Requires(maximum >= minimum);
            Minimum = minimum;
            Maximum = maximum;
        }

        public int Minimum { get; set; }
        public int Maximum { get; private set; }
    }
}