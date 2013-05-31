namespace DragonAid.Lib.Data.Model
{
    public class Skill
    {
        private readonly string _fullName;

        public Skill(string fullName)
        {
            _fullName = fullName;
        }

        public string FullName
        {
            get { return _fullName; }
        }
    }
}