using System;
using System.Linq;

namespace DragonAid.Commander
{
    static internal class WritingHelpers
    {
        /// <summary>
        /// Writes a bunch of lines of text to the console surrounded by seperator lines.
        /// The length of the seperator lines are equal to the longest length of the lines provided.
        /// </summary>
        internal static void WriteLineWithSeperators(params string[] messages)
        {
            // EXAMPLE:
            // ==================================================
            // COOL BLOCK OF TEXT!
            // Longer message that sets the length of the thingys
            // Something else
            // ==================================================
            if (!messages.Any())
            {
                WriteSeperatorLine(50);
            }
            else
            {
                var longestLineLength = messages.Select(s => s.Length).Max();
                WriteSeperatorLine(longestLineLength);
                foreach (var message in messages)
                {
                    Console.WriteLine(message);
                }
                WriteSeperatorLine(longestLineLength);
            }
        }

        private static void WriteSeperatorLine(int number)
        {
            // EXAMPLE:
            // ========================================
            for (int x = 0; x < number; x++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        internal static void WriteListOfChoices(ChoiceList choiceList)
        {
            // EXAMPLE:
            // 1:  Some User Choice
            foreach (var choice in choiceList)
            {
                Console.Write(choice.InputNumber);
                Console.Write(":  ");
                Console.WriteLine(choice.Description);
            }
        }
    }
}