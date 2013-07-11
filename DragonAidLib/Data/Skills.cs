using System.Collections.Generic;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public static class Skills
    {
        /* Standard Hierarchical DragonQuest 'Skills' */
        public static readonly TopLevelSkill Assassin = new TopLevelSkill("Assassin", 
            "The assassin skill is a set of stealth-oriented abilities that allow the character to accel at clandestine operations.");
        public static readonly TopLevelSkill Alchemy = new TopLevelSkill("Alchemy", 
            "Almost all natural chemicals can be combined into a variety of useful mixtures by expert hands. There are five main areas of study of alchemy: chemical analysis, standard chimicals, medicines and antidotes, poisons, and potions.");
        public static readonly TopLevelSkill Astrology = new TopLevelSkill("Astrology", 
            "The celestrial bodies have a definite, if not entirely understood, effect upon the inhabitants of the world. An astrologer's main talent is a limited ability to predict and shape the future.");
        public static readonly TopLevelSkill Beastmaster = new TopLevelSkill("Beastmaster", 
            "A loyal animal or monster is likely to serve its master far better than adventuring comrades ever will. A beast master is one who trains these creatures to obedience.");
        public static readonly TopLevelSkill Spy = new TopLevelSkill("Spy", 
            "The Spy practices his trade covertly. He represents himself as one worthy of the victim's trust to gain access to valuable information.");
        public static readonly TopLevelSkill Courtesan = new TopLevelSkill("Courtesan", 
            "Courtesanship is a social skill designed expressly to satisfy the needs of lonely or status conscious people. A master courtesan will be an accomplished musician, able to play at least one woodwind or string instrument. The master will also be able to sing, recite and compose stories and legends, perform mime, act out skits and dance. The consummate courtesan is also the master of proper dress, and attractive appearance and is able to simulate a great range of emotions.");

        /* Adventuring skills. Everyone has them. */
        public static readonly TopLevelSkill Swimming = new TopLevelSkill("Swimming",
@"An adventurer will use swimming to perform any actions in the water. 

The base chance for swimming is PS + AG + EN + [8 x Rank].

Little or no clothing: +10. 
Encumbered: -1 per lb. 
Water temperature: +5 to -25. 
Water conditions: +10 to -25. 
May not swim freely: -10 to -50. 

A failure does not mean drowning, but does mean the character is in serious trouble. Two failed rolls means the character is underwater, holding his breath. 

The base time a character can hold their breath is current [EN / 3] + [Rank / 2] pulses, rounded up. If a pass action is taken to prepare, this time is doubled. Once that time is expired then the character must make a 5 × WP check in order to continue holding their breath. At the end of subsequent pulses, the WP factor is reduced by 1 until the roll fails.  At that point the character starts drowning, taking physical damage at a rate of D10 EN per pulse until death or rescue. 

A drowning  character needs to make a 2 × (WP + swimming rank) check before being able to perform useful activity as above. Swimming TMR = (Land TMR + Rank) / 3.");
        public static readonly TopLevelSkill Climbing = new TopLevelSkill("Climbing",
            "An adventurer will use climbing to traverse verticle surfaces. The base chance for climbing is ([3 x MD] + [2 x AG] + [10 x Rank]) - (Distance Modifier). Distance Modifier = (total distance / 5) + ([distance – 50] / 5). The second part of the distance modifier is added only if the distance is greater than 50 feet. A check is made for an entire vertical surface. If a failure occurs, roll percentile dice to determine at which height the character fell.  Once a ledge, or similar area, where a character can stand freely and rest is reached, the climb has ended. If he proceeds upward from that point, another success check should be rolled. However, the GM should ensure that the presence of a ledge always helps the character, regardless of how the numbers work out. The BC is modifed by armor and the surface being climbing. Consult climbing rules.");
        public static readonly TopLevelSkill Horsemanship = new TopLevelSkill("Horsemanship",
            "An adventurer will use horsemanship to direct animals which he rides. The base chance for horsemanship is [modified AG + WP] / 2 + [Rank x 8]. If the modified chance <= roll < [modified chance + WP], then the command is ignored. If the roll > [modified chance + WP], then the mount will disobey, and maybe even attempt to throw the rider.");
        public static readonly TopLevelSkill Stealth = new TopLevelSkill("Stealth", 
            "An adventurer can use stealth to move as soundlessly and unobtrusively as possible. The base chance for stealth is [AG x 3] + [Rank x 5]. The greatest PC of the beings who may be able to discover the character sneaking is substracted, or 3 times that if they are aware of the sneaking entity.");

        /* Mini skills. Mini top-level skills that dont' have subskills. */
        public static readonly TopLevelSkill CoupDeGras = new TopLevelSkill("Coup de Gras", 
            "Requires: PC >= 13.  Cost: 1000 Exp.  Benefit: You may kill a prone & stunned opponent with one hit of your weapon. Targets must general be human sized, and if heavily armored, may require a pass action on the following pulse. GM discretion applies.");
        public static readonly TopLevelSkill CombatRotation = new TopLevelSkill("Combat Rotation", 
            "Cost: 250 Exp.  You are able to swap positions with an ally who is within 5 feet of yourself for the cost of 1 point of TMR.");

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