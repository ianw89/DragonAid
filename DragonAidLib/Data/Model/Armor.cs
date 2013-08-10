namespace DragonAid.Lib.Data.Model
{
    public class Armor : Item
    {
        public Armor(string fullName, int agilityModifier, decimal weight)
            : base(fullName, weight)
        {
            ExceptionUtils.MustBeTrue(agilityModifier <= 0);
            this.AgilityModifier = agilityModifier;
        }

        public int AgilityModifier { get; private set; }
    }
}