using System;
using System.Diagnostics.Contracts;

namespace DragonAidLib.Data.Model
{
    public class CombatAction
    {
        public CombatAction(string name, Func<Character, int> determineChanceOfSuccess)
        {
            Contract.Requires(name != null);
            Contract.Requires(determineChanceOfSuccess != null);
            
            _name = name;
            _determineChanceOfSuccess = determineChanceOfSuccess;
        }

        private readonly string _name;
        public string Name
        {
            get { return _name; }
        }

        
        private readonly Func<Character, int> _determineChanceOfSuccess;
        public Func<Character, int> DetermineChanceOfSuccess
        {
            get { return _determineChanceOfSuccess; }
        }
        
        public static CombatAction AttackWithSap = new CombatAction("Attack with Sap", c => 45 + c.ManualDexterity);
        public static CombatAction CastWalkingUnseen = new CombatAction("Cast 'Walking Unseen'", c => 50 + (c.MagicalAptitude - 15));
    }
}
