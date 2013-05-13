using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DragonAid.Commander
{
    /// <summary>
    /// Object to represent a list of possible choices the user could make.
    /// Knows how to handle user input to pick one of the choices.
    /// </summary>
    internal class ChoiceList : IEnumerable<KeyValuePair<int, UserInputChoice>>
    {
        private readonly Dictionary<int, UserInputChoice> _dictionary; 

        public ChoiceList(params UserInputChoice[] choices)
        {
            this._dictionary = new Dictionary<int, UserInputChoice>();
            var keyCounter = 1;

            foreach (var choice in choices)
            {
                this._dictionary.Add(keyCounter++, choice);
            }
        }

        public UserInputChoice DetermineChoiceMade(string input)
        {
            int parsedInput;
            var success = Int32.TryParse(input, out parsedInput);
            
            if (!success)
            {
                return null;
            }

            UserInputChoice choiceMade;
            this._dictionary.TryGetValue(parsedInput, out choiceMade);

            return choiceMade;
        }

        public IEnumerator<KeyValuePair<int, UserInputChoice>> GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}