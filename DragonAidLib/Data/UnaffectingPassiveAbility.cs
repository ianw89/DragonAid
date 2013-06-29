using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public class UnaffectingPassiveAbility : IAbility
    {
        private readonly string _description;

        public UnaffectingPassiveAbility(string name, string description)
        {
            _description = description;
            this.FullName = name;
        }

        public string FullName { get; private set; }

        public string Description
        {
            get { return _description; }
        }
    }
}