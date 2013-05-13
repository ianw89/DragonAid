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

            this._choiceList = new ChoiceList()
                {
                    new UserInputChoice(1, "Option 1"),
                    new UserInputChoice(2, "Option 2"),
                };
        }

        public override void Enter()
        {
            Console.WriteLine("Main Menu");
            WritingHelpers.WriteListOfChoices(this._choiceList);
        }

        public override void ProcessInput(string input)
        {
            var choiceMade = this._choiceList.DetermineChoiceMade(input);

            if (choiceMade == null)
            {
                Console.WriteLine("Bad Input!");
            }
            else
            {
                choiceMade.DoAction();
            }
        }
    }
}