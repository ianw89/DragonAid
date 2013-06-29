using System.Collections.Generic;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public static class HardCodedSampleData
    {
        public static readonly List<Character> SampleCharacters = new List<Character>
            {
                new Character
                    {
                        Id = 1,
                        Name = "Hap",
                        Title = "Happenstance McGillity",
                        Description = "Big, mean, and in a dress.",
                        ImageUri = "Assets/Hap.jpg",
                        PlayerName = "Jen",
                        IsMine = false,
                        Race = Race.Human,
                        PartyId = 1,
                        PhysicalStrength = 20,
                        ManualDexterity = 15,
                        Agility = 19,
                        Endurance = 22,
                        MagicalAptitude = 5,
                        Willpower = 9,
                        Perception = 13,
                        PhysicalBeauty = 13,
                        Fatigue = 23,
                        WeaponRanks =
                            {
                                { WeaponLibrary.Mattock, 1 },
                                { WeaponLibrary.Dagger, 2 },
                                { WeaponLibrary.WarHammer, 5 },
                                { WeaponLibrary.Morningstar, 0 },
                                { WeaponLibrary.Crossbow, 1 },
                            },
                        Skills =
                            {
                                { SkillLibrary.Courtesan, 3 },
                                { SkillLibrary.Alchemy, 0 },

                                { SkillLibrary.Climbing, 3 },
                                { SkillLibrary.Horsemanship, 3 },
                                { SkillLibrary.Stealth, 1 },
                                { SkillLibrary.Swimming, 1 },

                                // The following are binary skills (either you have it or you don't), so rank isn't applicable.
                                { SkillLibrary.InstantDispatch, 0 },
                                { SkillLibrary.CombatRotation, 0 }
                            },
                        Languages =
                            {
                                { LanguageLibrary.Common, 8, 4 },
                                { LanguageLibrary.BerensTongue, 8, 0 },
                                { LanguageLibrary.Lutherian, 0, null }
                            },
                        Inventory =
                            {
                                { WeaponLibrary.Mattock, "Combat", "OverlandFoot" },
                                { WeaponLibrary.Crossbow, "Combat", "OverlandFoot" },
                                { WeaponLibrary.Dagger, "Combat", "OverlandFoot" },
                                { new Armor("Partial Plate", -2, 33), "Combat", "OverlandFoot" },
                                { new Item("Buckler", 3), "Combat", "OverlandFoot" },
                                { new Item("Quiver", 3), "Combat", "OverlandFoot" },
                                { new Item("Quarrels", 7), "Combat", "OverlandFoot" },
 
                                { new Item("Adventuring Pack", 23), "OverlandFoot" },
                                { new Item("Overnight Pack", 12), "OverlandFoot" },
                                { new Item("Money", 10), "OverlandFoot" },
                            }
                    },
                new Character
                    {
                        Id = 2,
                        Name = "Muscles",
                        Title = "Muscles Bufflyton",
                        Description = "Nazi Hunter. Unknown and at large.",
                        ImageUri = "Assets/Muscles.jpg",
                        PlayerName = "Dan",
                        Race = Race.Human,
                        IsMine = false,
                        PartyId = 1,
                        PhysicalStrength = 9,
                        ManualDexterity = 12,
                        Agility = 16,
                        Endurance = 20,
                        MagicalAptitude = 20,
                        Willpower = 15,
                        Perception = 9,
                        PhysicalBeauty = 15,
                        Fatigue = 22,
                        SpellRanks = 
                            {
                                /*
                                { Spells.Shadow.SpeakToShadowCreatures, 0 },
                                { Spells.Shadow.NightVision, 0 },
                                { Spells.Shadow.DetectAura, 7 },
                                */

                                { Spells.Shadow.Blending, 0 },
                                { Spells.Shadow.Light, 2 },
                                { Spells.Shadow.Darkness, 1 },
                                { Spells.Shadow.ShadowForm, 1 },
                                { Spells.Shadow.WallOfStarlight, 0 },
                                { Spells.Shadow.WallOfDarkness, 0 },
                                { Spells.Shadow.Witchsight, 2 },
                                { Spells.Shadow.WalkingUnseen, 6 },
                                { Spells.Shadow.GeneralCounterspell, 0 },
                                { Spells.Shadow.SpecialCounterspell, 0 },
                                
                                { Spells.Shadow.Healing, 3 },
                                { Spells.Shadow.Starfire, 3 },
                                { Spells.Shadow.ShadowWings, 2 },
                                { Spells.Shadow.ShadowSlipping, 0 },
                            },
                        WeaponRanks =
                            {
                                { WeaponLibrary.Sap, 3 },
                                { WeaponLibrary.Dagger, 0 },
                            }
                            ,
                        Inventory = 
                            {
                                { new Armor("Cloth armor (improved)", 0, 6), "Combat", "OverlandFoot" },
                                { WeaponLibrary.Sap, "Combat", "OverlandFoot" },
                                { WeaponLibrary.Sap, "Combat", "OverlandFoot" },
                                { WeaponLibrary.Dagger, "Combat", "OverlandFoot" },

                                { new Item("Adventuring pack", 23), "OverlandFoot" },
                                { new Item("Money", 10), "OverlandFoot" },
                                { new Item("2 weeks of supplies", 14), "OverlandFoot" },
                            },
                        Skills =
                            {
                                { SkillLibrary.Assassin, 3},     
                                { SkillLibrary.Horsemanship, 0},        
                                { SkillLibrary.Stealth, 2}        
                            },
                        Languages =
                            {
                                { LanguageLibrary.Common, 8, null },
                                { LanguageLibrary.BerensTongue, 8, null },
                            }
                    },
                new Character
                    {
                        Id = 3,
                        Name = "Orj",
                        Title = "Orjbortz Daborgleschnortz",
                        Description = "He trains falcons, not dire wolves.",
                        ImageUri = "Assets/Orjbortz.jpg",
                        PlayerName = "David",
                        Race = Race.Human,
                        IsMine = false,
                        PartyId = 1,
                        PhysicalStrength = 18,
                        ManualDexterity = 19,
                        Agility = 18,
                        Endurance = 17,
                        MagicalAptitude = 7,
                        Willpower = 19,
                        Perception = 9,
                        PhysicalBeauty = 15,
                        Fatigue = 21,
                        WeaponRanks =
                            {
                                { WeaponLibrary.Whip, 2 },
                                { WeaponLibrary.Net, 2 },
                                { WeaponLibrary.Bola, 2 },
                            },
                        Skills =
                            {
                                { SkillLibrary.Beastmaster, 2 },

                                { SkillLibrary.Climbing, 3 },
                                { SkillLibrary.Horsemanship, 4 },
                                { SkillLibrary.Stealth, 0 },
                                { SkillLibrary.Swimming, 0 }
                            },
                        Languages =
                            {
                                { LanguageLibrary.Common, 8, 4 },
                                { LanguageLibrary.Hundschrei, 5, 1 },
                            },
                        Inventory =
                            {
                                { new Armor("Leather Armor", -1, 18), "Combat", "OverlandFoot" },
                                { WeaponLibrary.Whip, "Combat", "OverlandFoot" },
                                { WeaponLibrary.Net, "Combat", "OverlandFoot" },
                                { WeaponLibrary.Bola, "Combat", "OverlandFoot" },
                                { new Item("Falconry Pads", 3), "Combat", "OverlandFoot" },
                                
                                { new Item("Adventuring pack", 23), "OverlandFoot" },
                                { new Item("Money", 10), "OverlandFoot" },
                                { new Item("Climbing Pack", 24), "OverlandFoot" },
                                { new Item("2 weeks of supplies", 14), "OverlandFoot" },
                            }
                    },
                new Character
                    {
                        Id = 4,
                        Name = "Nick",
                        Title = "Nick Black",
                        Description = "Full of venom, and worse.",
                        ImageUri = "Assets/Nick.png",
                        PlayerName = "Matt",
                        Race = Race.Human,
                        IsMine = false,
                        PartyId = 1,
                        PhysicalStrength = 14,
                        ManualDexterity = 15,
                        Agility = 15,
                        Endurance = 18,
                        MagicalAptitude = 20,
                        Willpower = 18,
                        Perception = 8,
                        PhysicalBeauty = 12,
                        Fatigue = 21,
                        SpellRanks =
                            {
                                { Spells.Mind.ESP, 1 },
                                { Spells.Mind.LimitedPrecognition, 0 },
                                { Spells.Mind.MindCloak, 0 },
                                { Spells.Mind.Empathy, 0 },
                                { Spells.Mind.Hypnotism, 2 },
                                { Spells.Mind.ControlAnimal, 0 },
                                { Spells.Mind.ControlPerson, 0 },

                                { Spells.Mind.MentalAttack, 2 },
                                { Spells.Mind.MentalHealing, 1 },
                            },
                        WeaponRanks =
                            {
                                { WeaponLibrary.Cane, 3 },
                                { WeaponLibrary.Sap, 3 },
                                { WeaponLibrary.Darts, 2 },
                            },
                        Inventory = 
                            {
                                { new Armor("Cloth armor (improved)", 0, 6), "Combat", "OverlandFoot" },
                                { WeaponLibrary.Cane, "Combat", "OverlandFoot" },
                                { WeaponLibrary.Sap, "Combat", "OverlandFoot" },
                                { WeaponLibrary.Darts, "Combat", "OverlandFoot" },
                                
                                { new Item("Adventuring pack", 23), "OverlandFoot" },
                                { new Item("Money", 10), "OverlandFoot" },
                                { new Item("2 weeks of supplies", 14), "OverlandFoot" },
                            },
                        Skills =
                            {
                                { SkillLibrary.Assassin, 3},     
                                { SkillLibrary.Spy, 1},        
                                { SkillLibrary.Stealth, 1}        
                            }
                    },
                new Character
                    {
                        Id = 5,
                        Name = "Renee",
                        Title = "Renee Black",
                        Description = "Able-bodied sailor and baby-sitter.",
                        ImageUri = "Assets/Renee.jpg",
                        PlayerName = "Lindsay",
                        Race = Race.Human,
                        IsMine = false,
                        PartyId = 1,
                        PhysicalStrength = 15,
                        ManualDexterity = 18,
                        Agility = 23,
                        Endurance = 15,
                        MagicalAptitude = 5,
                        Willpower = 10,
                        Perception = 9,
                        PhysicalBeauty = 15,
                        Fatigue = 21
                    },


                new Character
                    {
                        Id = 6,
                        Name = "Pirate A",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 1",
                        IsMine = false,
                        PartyId = 2,
                    },
                new Character
                    {
                        Id = 7,
                        Name = "Pirate B",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 2",
                        IsMine = false,
                        PartyId = 2,
                    },
            };

        public static readonly List<Party> SampleParties = new List<Party>
            {
                new Party
                    {
                        Id = 1,
                        Title = "Tuesday Night DragonQuest",
                        Description = "Casual weekly DragonQuest.",
                        GameMasterName = "Ian Williams",
                        ImageUri = "Assets/MyCharacters.png"
                    },
                new Party
                    {
                        Id = 2,
                        Title = "The Land Of Moordoor",
                        Description = "Where the shadows (of sunken boats) lie",
                        GameMasterName = "Sauron",
                        ImageUri = "Assets/MyCharacters.png"
                    }
            };
    }


    public static class WeaponLibrary
    {
        // Name, Weight, BaseChance, Use, MaxRank
        public static readonly Weapon Dagger = new Weapon("Dagger", 10m / 16m, 40, WeaponKind.Close & WeaponKind.Melee & WeaponKind.Ranged, 9);
        public static readonly Weapon MainGauche = new Weapon("Main-Gauche", 1m, 45, WeaponKind.Close & WeaponKind.Melee, 10);
        public static readonly Weapon ShortSword = new Weapon("Short Sword", 2m, 45, WeaponKind.Melee, 6);
        public static readonly Weapon Falchion = new Weapon("Falchion", 4m, 50, WeaponKind.Melee, 8);
        public static readonly Weapon Scimitar = new Weapon("Scimitar", 4m, 50, WeaponKind.Melee, 8);
        public static readonly Weapon Tulwar = new Weapon("Tulwar", 4m, 50, WeaponKind.Melee, 8);
        public static readonly Weapon Rapier = new Weapon("Rapier", 2m, 45, WeaponKind.Melee, 10);
        public static readonly Weapon Sabre = new Weapon("Sabre", 3m, 60, WeaponKind.Melee, 7);
        public static readonly Weapon Broadsword = new Weapon("Broadsword", 3m, 55, WeaponKind.Melee, 6);
        public static readonly Weapon Estoc = new Weapon("Estoc", 2m, 45, WeaponKind.Melee, 9);
        public static readonly Weapon HandAndAHalf = new Weapon("Hand & a Half", 6m, 60, WeaponKind.Melee, 7);
        public static readonly Weapon Claymore = new Weapon("Claymore", 5m, 50, WeaponKind.Melee, 7);
        public static readonly Weapon TwoHandedSword = new Weapon("Two-Handed Sword", 9m, 55, WeaponKind.Melee, 5);

        public static readonly Weapon HandAxe = new Weapon("Hand Axe", 2m, 40, WeaponKind.Close & WeaponKind.Melee & WeaponKind.Ranged, 4);
        public static readonly Weapon BattleAxe = new Weapon("Battle Axe", 5m, 60, WeaponKind.Close & WeaponKind.Melee, 7);
        public static readonly Weapon GreatAxe =  new Weapon("Great Axe", 6, 65, WeaponKind.Melee, 7);
        public static readonly Weapon GiantAxe = new Weapon("Giant Axe", 25, 65, WeaponKind.Ranged & WeaponKind.Melee, 7);
        public static readonly Weapon CrudeClub = new Weapon("Crude Club", 4, 45, WeaponKind.Ranged & WeaponKind.Melee, 2);
        public static readonly Weapon WarClub = new Weapon("War Club", 3, 50, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon GiantClub = new Weapon("Giant Club", 20, 50, WeaponKind.Ranged & WeaponKind.Melee, 5);
        // TODO: make max rank nullable
        // public static readonly Weapon Torch = new Weapon("Torch", 3, 40, WeaponKind.Melee, null);
        public static readonly Weapon Mace = new Weapon("Mace", 5, 50, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon GiantMace = new Weapon("Giant Mace", 25, 50, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon WarHammer = new Weapon("War Hammer", 4m, 45, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon WarPick = new Weapon("War Pick", 5, 45, WeaponKind.Melee, 5);
        public static readonly Weapon Flail = new Weapon("Flail", 4, 50, WeaponKind.Melee, 5);
        public static readonly Weapon Morningstar = new Weapon("Morningstar", 5m, 60, WeaponKind.Melee, 5);
        public static readonly Weapon Mattock = new Weapon("Mattock", 6m, 55, WeaponKind.Melee, 5);
        public static readonly Weapon Quarterstaff = new Weapon("Quarterstaff", 3, 55, WeaponKind.Melee, 9);
        public static readonly Weapon Sap = new Weapon("Sap", 1m, 40, WeaponKind.Close & WeaponKind.Melee, 3);

        public static readonly Weapon ThrowingDart = new Weapon("Throwing Dart", 3m / 16m, 40, WeaponKind.Ranged, 10);
        public static readonly Weapon Boomerang = new Weapon("Boomerang", 1, 40, WeaponKind.Ranged, 7);
        public static readonly Weapon Grenado = new Weapon("Grenado", 2, 40, WeaponKind.Ranged, 4);

        public static readonly Weapon Javelin = new Weapon("Javelin", 3, 45, WeaponKind.Ranged & WeaponKind.Melee, 10);
        public static readonly Weapon Spear = new Weapon("Spear", 5, 50, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon GiantSpear = new Weapon("Giant Spear", 15, 55, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon Pike = new Weapon("Pike", 8, 45, WeaponKind.Melee, 5);
        public static readonly Weapon Lance = new Weapon("Lance", 7, 45, WeaponKind.Melee, 5);
        public static readonly Weapon Halberd = new Weapon("Halbeard", 6, 55, WeaponKind.Melee, 5);
        public static readonly Weapon Poleaxe = new Weapon("Poleaxe", 6, 55, WeaponKind.Melee, 5);
        public static readonly Weapon Trident = new Weapon("Trident", 5, 45, WeaponKind.Melee, 5);
        public static readonly Weapon Glaive = new Weapon("Glaive", 7, 55, WeaponKind.Melee, 9);
        public static readonly Weapon GiantGlaive = new Weapon("Giant Glaive", 14, 65, WeaponKind.Melee, 9);

        public static readonly Weapon Sling = new Weapon("Sling", 1, 40, WeaponKind.Ranged, 8);
        public static readonly Weapon ShortBow = new Weapon("Short Bow", 4, 45, WeaponKind.Ranged, 8);
        public static readonly Weapon LongBow = new Weapon("Long Bow", 6, 55, WeaponKind.Ranged, 8);
        public static readonly Weapon CompositeBow = new Weapon("Composite Bow", 8, 55, WeaponKind.Ranged, 8);
        public static readonly Weapon GiantBow = new Weapon("Giant Bow", 14, 55, WeaponKind.Ranged, 8);
        public static readonly Weapon Crossbow = new Weapon("Crossbow", 7m, 60, WeaponKind.Ranged, 5);
        public static readonly Weapon HeavyCrossbow = new Weapon("Heavy Crossbow", 10, 60, WeaponKind.Ranged, 5);
        public static readonly Weapon SpearThrower = new Weapon("Spear Thrower", 4, 50, WeaponKind.Ranged, 10);
        public static readonly Weapon Blowgun = new Weapon("Blowgun", 1, 30, WeaponKind.Ranged, 10);

        public static readonly Weapon Net = new Weapon("Net", 2, 30, WeaponKind.Ranged & WeaponKind.Melee & WeaponKind.Close, 4);
        public static readonly Weapon Bola = new Weapon("Bola", 2, 35, WeaponKind.Ranged & WeaponKind.Close, 6);
        public static readonly Weapon Whip = new Weapon("Whip", 3, 40, WeaponKind.Melee & WeaponKind.Close, 10);

        // TODO: Make weight nullable (to signify variable weight)
        // public static readonly Weapon Rock = new Weapon("Rock", null, 30, WeaponKind.Ranged & WeaponKind.Melee & WeaponKind.Close, 6);
        public static readonly Weapon Cestus = new Weapon("Cestus", 3, 35, WeaponKind.Melee & WeaponKind.Close, 9);
        public static readonly Weapon Garrote = new Weapon("Garrote", 1, 30, WeaponKind.Close, 3);
        // public static readonly Weapon Shield = new Weapon("Shield", null, 40, WeaponKind.Melee, 4);

        // Custom weapons (TODO: can we have a more general way of building on top of the standard weapons?)
        public static readonly Weapon Cane = new Weapon("Cane (Sap)", 5, 40, WeaponKind.Close & WeaponKind.Melee, 3);
        // TODO: Is this different than throwing dart? It has a different weight (the way of the weapon accesory, not the weapon)
        public static readonly Weapon Darts = new Weapon("Darts (10)", 2, 40, WeaponKind.Ranged, 10);
    }

    public static class SkillLibrary
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

        static SkillLibrary()
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

    public static class LanguageLibrary
    {
        public static readonly Language Common = new Language("Common");
        public static readonly Language BerensTongue = new Language("Beren's Tongue");
        public static readonly Language Lutherian = new Language("Lutherian");
        public static readonly Language Hundschrei = new Language("Hundschrei");
        public static readonly Language Orcish = new Language("Orcish");
        public static readonly Language Elvish = new Language("Elvish");
    }
}
