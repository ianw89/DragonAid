using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public class Talent : IMagicalAbility
    {
        public Talent(string name)
        {
            this.FullName = name;
        }

        public string FullName { get; private set; }
    }
}