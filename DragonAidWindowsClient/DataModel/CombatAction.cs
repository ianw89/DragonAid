using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonAidWindowsClient.Common;
using DragonAidWindowsClient.Data;

namespace DragonAidWindowsClient.DataModel
{
    public class CombatAction
    {
        private CombatAction(string name, Func<Character, int> determineChanceOfSuccess)
        {
            ExceptionUtils.CheckArgumentNotNull(name);
            ExceptionUtils.CheckArgumentNotNull(determineChanceOfSuccess);

            this._name = name;
            this._determineChanceOfSuccess = determineChanceOfSuccess;

        }

        private string _name;
        public string Name
        {
            get { return this._name; }
        }

        
        private Func<Character, int> _determineChanceOfSuccess;
        public int DetermineChanceOfSuccess(Character character)
        {
            ExceptionUtils.CheckArgumentNotNull(character);
            return this._determineChanceOfSuccess(character);
        }
        
        public static CombatAction AttackWithSap = new CombatAction("Attack with Sap", (c) => { return 45 + c.ManualDexterity; });
        public static CombatAction CastWalkingUnseen = new CombatAction("Cast 'Walking Unseen'", (c) => { return 50 + (c.MagicalAptitude - 15); });
    }
}
