using System;
using System.Collections.Generic;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public class SelfActivatedSkill : ISkill
    {
        private readonly Func<Character, string> _calculateDisplayInfo;

        public SelfActivatedSkill(string name, Func<Character, string> calculateDisplayInfo)
        {
            this._calculateDisplayInfo = calculateDisplayInfo;
            this.FullName = name;
        }

        public string FullName { get; private set; }

        public IList<ISkill> Subskills { get { return new List<ISkill>(); } }

        public string Description { get { return "TODO: Use Func CalculateDisplayInfo for Description"; } }

        public Func<Character, string> CalculateDisplayInfo
        {
            get { return this._calculateDisplayInfo; }
        }
    }
}