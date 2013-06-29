using System;
using System.Diagnostics.Contracts;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public class SelfActivatedAbility : IAbility
    {
        private readonly Func<Character, string> _successChanceCalculator;

        public SelfActivatedAbility(string name, Func<Character, string> successChanceCalculator)
        {
            _successChanceCalculator = successChanceCalculator;
            this.FullName = name;
        }

        public string FullName { get; private set; }

        public Func<Character, string> SuccessChanceCalculator
        {
            get { return _successChanceCalculator; }
        }
    }
}