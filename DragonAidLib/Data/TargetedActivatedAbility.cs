using System;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public class TargetedActivatedAbility : IAbility
    {
        private readonly Func<Character, Character, string> _calculateDisplayInfo;

        public TargetedActivatedAbility(string name, Func<Character, Character, string> calculateDisplayInfo)
        {
            _calculateDisplayInfo = calculateDisplayInfo;
            this.FullName = name;
        }

        public string FullName { get; private set; }

        /// <summary>
        /// The first character is the caster, the second is the target. The output is a string description containing
        /// all required information.
        /// </summary>
        public Func<Character, Character, string> CalculateDisplayInfo
        {
            get { return _calculateDisplayInfo; }
        }
    }
}