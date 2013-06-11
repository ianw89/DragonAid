namespace DragonAid.Lib.Data.Model
{
    public class Language
    {
        private readonly string _fullName;

        public Language(string fullName)
        {
            _fullName = fullName;
        }

        public string FullName
        {
            get { return _fullName; }
        }
    }
}