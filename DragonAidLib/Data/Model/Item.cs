using System.Diagnostics.Contracts;

namespace DragonAid.Lib.Data.Model
{
    public class Item
    {
        public Item(string fullName, decimal weight)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(fullName));
            Contract.Requires(weight >= 0);

            FullName = fullName;
            Weight = weight;
        }

        public string FullName { get; private set; }

        public decimal Weight { get; private set; }
    }
}