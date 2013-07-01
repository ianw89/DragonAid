using System.Collections.Generic;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public static class Skills
    {
        /* Standard skills */
        public static readonly Skill Assassin = new Skill("Assassin");
        public static readonly Skill Alchemy = new Skill("Alchemy");
        public static readonly Skill Astrology = new Skill("Astrology");
        public static readonly Skill Beastmaster = new Skill("Beastmaster");
        public static readonly Skill Spy = new Skill("Spy");
        public static readonly Skill Courtesan = new Skill("Courtesan");

        /* Adventuring skills */
        public static readonly Skill Swimming = new Skill("Swimming");
        public static readonly Skill Climbing = new Skill("Climbing");
        public static readonly Skill Horsemanship = new Skill("Horsemanship");
        public static readonly Skill Stealth = new Skill("Stealth");

        /* Extension skills */
        // TODO Should be top level abilities, not skill
        public static readonly Skill InstantDispatch = new Skill("Instant Dispatch");
        public static readonly Skill CombatRotation = new Skill("Combat Rotation");

        static Skills()
        {
            Assassin.Abilities = new List<IAbility>()
                {
                    // TODO We need to be using Expression or our own Expression language for these formulas. 
                    // TODO This is just to get us started with some skills that have abilities.
                    new SelfActivatedAbility("Recall Scene", (c) =>
                        {
                            int chance = 5*c.Perception + 2*c.Skills[Assassin];
                            return "Chance: " + chance + "%, modified by GM.";
                        }),
                    new TargetedActivatedAbility("Torture", 
                                                 (assassin, victim) => 
                                                     {
                                                         double hoursNeeded = (double)victim.Willpower / (double)assassin.Skills[Assassin];
                                                         int chanceOfSuccess = 10*assassin.Skills[Assassin] - 4*victim.Willpower;
                                                         chanceOfSuccess = chanceOfSuccess < 1 ? 1 : chanceOfSuccess; // minimum chance is 1%
                                                         int tortureAttemptsBeforeDeath = victim.Endurance/5; // rounded down 

                                                         return "Required Time: " + hoursNeeded + " hours. Chance: " + chanceOfSuccess +
                                                                "%. Victim wlil die after " + tortureAttemptsBeforeDeath + " torture attempts.";
                                                     }),
                    new UnaffectingPassiveAbility("Cheap Poisons", "An assassin is able to buy poisons, distilled venoms, and acids at cost from an alchemist.")
                    // TODO missing some abilities
                };
        }
    }
}