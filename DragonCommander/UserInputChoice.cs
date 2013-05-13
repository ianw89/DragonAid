using System;

namespace DragonAid.Commander
{
    internal class UserInputChoice
    {
        public UserInputChoice(string description)
        {
            this.Description = description;
        }

        public string Description { get; private set; }

        public void DoAction()
        {
            Console.WriteLine("Performing Action for: " + this.Description);
        }
    }
}