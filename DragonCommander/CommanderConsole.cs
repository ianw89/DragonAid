using System;
using System.Threading;

namespace DragonAid.Commander
{
    public class CommanderConsole
    {
        private State _currentState;

        public static void Main(string[] args)
        {
            var console = new CommanderConsole();

            console.Startup();
            while (console.HandleUserInput());
            console.Shutdown();
        }

        private bool HandleUserInput()
        {
            var input = Console.ReadLine();
            this._currentState.ProcessInput(input);
            return false;
        }

        private void Startup()
        {
            WritingHelpers.WriteLineWithSeperators(
                "D R A G O N   A I D   C O M M A N D E R   C O N S O L E",
                "",
                "Welcome! This app provides a variety of command line utilities.");
            Console.WriteLine();

            this._currentState = new MainMenuState(this);
            this._currentState.Enter();
        }

        private void Shutdown()
        {
            WritingHelpers.WriteLineWithSeperators("E X I T I N G   D R A G O N   A I D");
            Thread.Sleep(1500);
        }
    }
}
