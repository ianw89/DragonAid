using System;
using System.Collections.Generic;
using System.Linq;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    /// <summary>
    /// Object that knows how to check if a group of <see cref="Character"/>s have suceeded
    /// at a particular check.
    /// </summary>
    public class TeamAttributeChecker
    {
        private readonly IEnumerable<Character> _people;

        public TeamAttributeChecker(IEnumerable<Character> people)
        {
            _people = people;
        }

        public TeamRollResult MakePerceptionRoll(double difficultyFactor)
        {
            RollResult lastResult = null;

            foreach (var person in _people.OrderByDescending(p => p.Perception))
            {
                lastResult = MakeDifficultyFactorRoll(person.Perception, difficultyFactor);
                lastResult.Character = person;

                if (lastResult.Success)
                {
                    return new TeamRollResult(lastResult);
                }

                // Harder for next person
                difficultyFactor = difficultyFactor / 2;

                if (difficultyFactor < 0.5)
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