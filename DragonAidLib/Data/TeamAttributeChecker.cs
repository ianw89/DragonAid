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
    internal class TeamAttributeChecker
    {
        private readonly IEnumerable<Character> _people;
        private readonly Random _rand;

        public TeamAttributeChecker(IEnumerable<Character> people)
        {
            _people = people;
            _rand = new Random();
        }

        public TeamRollResult MakePerceptionRoll(double difficultyFactor)
        {
            RollResult lastResult = null;

            foreach (var person in _people.OrderByDescending(p => p.Perception))
            {
                lastResult = MakeDifficultyFactorRoll(person.Perception, difficultyFactor);
                lastResult.Person = person;

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

        private RollResult MakeDifficultyFactorRoll(int perception, double difficultyFactor)
        {
            return new RollResult
            {
                Roll = _rand.Next(100) + 1,
                RequiredRoll = (int)(difficultyFactor * perception)
            };
        }
    }
}