using System;
using System.Collections.Generic;
using System.Linq;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.GamemasterUtilities
{
    /// <summary>
    /// Object that knows how to check if a group of <see cref="Character"/>s have suceeded
    /// at a particular check.
    /// </summary>
    /// <remarks>
    /// Uses this forumla: the person with the
    /// </remarks>
    public class TeamAttributeChecker
    {
        private readonly IEnumerable<Character> _people;

        public TeamAttributeChecker(IEnumerable<Character> people)
        {
            _people = people;
        }

        public TeamRollResult MakeTeamRoll(double difficultyFactor, Func<Character, int> characteristicExtractor)
        {
            RollResult lastResult = null;

            foreach (var person in _people.OrderByDescending(characteristicExtractor))
            {
                lastResult = MakeDifficultyFactorRoll(characteristicExtractor(person), difficultyFactor);
                lastResult.Character = person;

                if (lastResult.Success)
                {
                    return new TeamRollResult(lastResult);
                }

                // Harder for next person
                difficultyFactor = difficultyFactor / 2;

                if (difficultyFactor < 0.25)
                {
                    break;
                }
            }

            return new TeamRollResult(lastResult);
        }

        private RollResult MakeDifficultyFactorRoll(int stat, double difficultyFactor)
        {
            return new RollResult
            {
                Roll = Dice.RollD100(),
                RequiredRoll = (int)(difficultyFactor * stat)
            };
        }
    }
}