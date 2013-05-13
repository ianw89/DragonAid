//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace DragonAid.Commander
//{
//    internal class TeamAttributeChecker
//    {
//        private readonly IEnumerable<Character> _people;
//        private readonly Random _rand;

//        public TeamAttributeChecker(IEnumerable<Character> people)
//        {
//            _people = people;
//            _rand = new Random();
//        }

//        public TeamRollResult MakePerceptionRoll(double difficultyFactor)
//        {
//            RollResult lastResult = null;

//            foreach (var person in _people.OrderByDescending(p => p.Perception))
//            {
//                lastResult = MakeDifficultyFactorRoll(person.Perception, difficultyFactor);
//                lastResult.Person = person;
//                Console.WriteLine(lastResult);

//                if (lastResult.Success)
//                {
//                    return new TeamRollResult(lastResult);
//                }

//                // Harder for next person
//                difficultyFactor = difficultyFactor / 2;

//                if (difficultyFactor < 0.5)
//                {
//                    break;
//                }
//            }

//            return new TeamRollResult(lastResult);
//        }

//        private RollResult MakeDifficultyFactorRoll(int perception, double difficultyFactor)
//        {
//            return new RollResult
//            {
//                Roll = _rand.Next(100) + 1,
//                RequiredRoll = (int)(difficultyFactor * perception)
//            };
//        }
//    }


//    internal class RollResult
//    {
//        public bool Success
//        {
//            get { return Roll < RequiredRoll; }
//        }

//        public int Roll { get; set; }

//        public int RequiredRoll { get; set; }

//        public Character Person { get; set; }

//        public override string ToString()
//        {
//            return Person + " rolled a " + Roll + " and need a " + RequiredRoll + " to succeed.";
//        }
//    }

//    internal class TeamRollResult
//    {
//        private readonly RollResult _result;

//        public TeamRollResult(RollResult result)
//        {
//            _result = result;
//        }

//        public override string ToString()
//        {
//            if (this._result != null && this._result.Success)
//            {
//                return "The team succeeded, thanks to " + 
//                    this._result.Person + 
//                    ", who rolled a " + 
//                    this._result.Roll +
//                    "!";
//            }

//            return "The team failed the roll.";
//        }
    
//}