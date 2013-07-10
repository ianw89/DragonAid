using System;
using System.Collections.Generic;

namespace DragonAid.Lib.Data.Model
{
    public class TargetedActivatedSkill : ISkill
    {
        private readonly Func<Character, Character, string> _calculateDisplayInfo;

        public TargetedActivatedSkill(string name, Func<Character, Character, string> calculateDisplayInfo)
        {
            _calculateDisplayInfo = calculateDisplayInfo;
            this.FullName = name;
        }

        public string FullName { get; private set; }

        public IList<ISkill> Subskills { get { return new List<ISkill>(); } }

        public string Description { get { return "TODO: Use Func CalculateDisplayInfo for Description"; } }

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