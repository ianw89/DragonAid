using System.Diagnostics.Contracts;

namespace DragonAid.Lib.Data.Model
{
    public class Item
    {
        public Item(string name, decimal weight)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(name));
            Contract.Requires(weight >= 0);

            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public decimal Weight { get; private set; }
    }
}