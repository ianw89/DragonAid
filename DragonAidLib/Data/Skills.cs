using System.Collections.Generic;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public static class Skills
    {
        /* Standard skills */
        public static readonly TopLevelSkill Assassin = new TopLevelSkill("Assassin");
        public static readonly TopLevelSkill Alchemy = new TopLevelSkill("Alchemy");
        public static readonly TopLevelSkill Astrology = new TopLevelSkill("Astrology");
        public static readonly TopLevelSkill Beastmaster = new TopLevelSkill("Beastmaster");
        public static readonly TopLevelSkill Spy = new TopLevelSkill("Spy");
        public static readonly TopLevelSkill Courtesan = new TopLevelSkill("Courtesan");

        /* Adventuring skills */
        public static readonly TopLevelSkill Swimming = new TopLevelSkill("Swimming");
        public static readonly TopLevelSkill Climbing = new TopLevelSkill("Climbing");
        public static readonly TopLevelSkill Horsemanship = new TopLevelSkill("Horsemanship");
        public static readonly TopLevelSkill Stealth = new TopLevelSkill("Stealth");

        /* Extension skills */
        // TODO Should be top level abilities, not skill
        public static readonly TopLevelSkill InstantDispatch = new TopLevelSkill("Instant Dispatch");
        public static readonly TopLevelSkill CombatRotation = new TopLevelSkill("Combat Rotation");

        static Skills()
        {
            Assassin.Subskills = new List<ISkill>()
                {
                    // TODO We need to be using Expression or our own Expression language for these formulas. 
                    // TODO This is just to get us started with some skills that have abilities.
                    new SelfActivatedSkill("Recall Scene", (c) =>
                        {
                            int chance = 5*c.Perception + 2*c.Skills[Assassin];
                            return "Chance: " + chance + "%, modified by GM.";
                        }),
                    new TargetedActivatedSkill("Torture", 
                                                 (assassin, victim) => 
                                                     {
                                                         double hoursNeeded = (double)victim.Willpower / (double)assassin.Skills[Assassin];
                                                         int chanceOfSuccess = 10*assassin.Skills[Assassin] - 4*victim.Willpower;
                                                         chanceOfSuccess = chanceOfSuccess < 1 ? 1 : chanceOfSuccess; // minimum chance is 1%
                                                         int tortureAttemptsBeforeDeath = victim.Endurance/5; // rounded down 

                                                         return "Required Time: " + hoursNeeded + " hours. Chance: " + chanceOfSuccess +
                                                                "%. Victim wlil die after " + tortureAttemptsBeforeDeath + " torture attempts.";
                                                     }),
                    new UnaffectingPassiveSkill("Cheap Poisons", "An assassin is able to buy poisons, distilled venoms, and acids at cost from an alchemist.")
                    // TODO missing some abilities
                };
        }
    }
}