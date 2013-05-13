using System;

namespace DragonAid.Commander
{
    internal class MainMenuState : State
    {
        private readonly CommanderConsole _commander;
        private readonly ChoiceList _choiceList;

        public MainMenuState(CommanderConsole commander)
        {
            _commander = commander;

            this._choiceList = new ChoiceList(
                    new UserInputChoice("Option 1"),
                    new UserInputChoice("Option 2"),
                    new UserInputChoice("Exit Program")
                );
        }

        public override void Enter()
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            WritingHelpers.WriteListOfChoices(this._choiceList);
            Console.WriteLine();
        }

        public override bool ProcessInput(string input)
        {
            var choiceMade = this._choiceList.DetermineChoiceMade(input);

            if (choiceMade == null)
            {
                Console.WriteLine("Bad Input!");
                return false;
            }
            else
            {
                choiceMade.DoAction();
                return false;
            }
        }
    }
}