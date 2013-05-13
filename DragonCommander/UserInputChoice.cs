using System;

namespace DragonAid.Commander
{
    internal class UserInputChoice
    {
        public UserInputChoice(int number, string description)
        {
            this.InputNumber = number;
            this.Description = description;
        }

        public int InputNumber { get; private set; }

        public string Description { get; private set; }

        public void DoAction()
        {
            Console.WriteLine("Performing Action for: " + this.Description);
        }
    }
}