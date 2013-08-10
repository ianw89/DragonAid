namespace DragonAid.Lib.Data.Model
{
    public class Item
    {
        public Item(string fullName, decimal weight)
        {
            ExceptionUtils.MustBeTrue(!string.IsNullOrWhiteSpace(fullName));
            ExceptionUtils.MustBeTrue(weight >= 0);

            FullName = fullName;
            Weight = weight;
        }

        public string FullName { get; private set; }

        public decimal Weight { get; private set; }
    }
}