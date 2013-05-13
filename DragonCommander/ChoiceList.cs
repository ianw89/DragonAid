using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonAid.Commander
{
    /// <summary>
    /// Object to represent a list of possible choices the user could make.
    /// Knows how to handle user input to pick one of the choices.
    /// </summary>
    internal class ChoiceList : List<UserInputChoice>
    {
        public UserInputChoice DetermineChoiceMade(string input)
        {
            int parsedInput;
            var success = Int32.TryParse(input, out parsedInput);
            return success ? this.SingleOrDefault(c => c.InputNumber == parsedInput) : null;
        }
    }
}