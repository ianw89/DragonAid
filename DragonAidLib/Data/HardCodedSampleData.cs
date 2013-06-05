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
                                new Armor("Cloth armor (improved)", 0, 6),
                                WeaponLibrary.Sap,
                                WeaponLibrary.Sap,
                                WeaponLibrary.Dagger,

                                new Item("Adventuring pack", 23),
                                new Item("Money", 5),
                                new Item("2 weeks of supplies", 14),
                            },
                        Skills =
                            {
                                { SkillLibrary.Assassin, 3},     
                                { SkillLibrary.Horsemanship, 0},        
                                { SkillLibrary.Stealth, 2}        
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
                        Fatigue = 21
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
                                new Armor("Cloth armor (improved)", 0, 6),
                                WeaponLibrary.Cane,
                                WeaponLibrary.Sap,
                                WeaponLibrary.Darts,
                                
                                new Item("Adventuring pack", 23),
                                new Item("Money", 5),
                                new Item("2 weeks of supplies", 14),
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
                new Character
                    {
                        Id = 8,
                        Name = "Pirate C",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 3",
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
    
    
    public static class Spells
    {
        public static readonly ShadowSpells Shadow = new ShadowSpells();
        public static readonly MindSpells Mind = new MindSpells();

        public class ShadowSpells
        {
            // TODO Talents
            public readonly Talent SpeakToShadowCreatures = new Talent("Speak to Shadow Creatures");
            public readonly Talent NightVision = new Talent("Night Vision");
            public readonly Talent DetectAura = new Talent("Detect Aura");

            // General Knowledge Spells
            public readonly Spell Blending = new Spell("Blending", 60);
            public readonly Spell Light = new Spell("Light", 50);
            public readonly Spell Darkness = new Spell("Darkness", 50);
            public readonly Spell ShadowForm = new Spell("Shadow Form", 10);
            public readonly Spell WallOfStarlight = new Spell("Wall of Starlight", 15);
            public readonly Spell WallOfDarkness = new Spell("Wall of Darkness", 20);
            public readonly Spell Witchsight = new Spell("Witchsight", 15);
            public readonly Spell WalkingUnseen = new Spell("Walking Unseen", 15);
            public readonly Spell GeneralCounterspell = new Spell("General Counterspell", 40);
            public readonly Spell SpecialCounterspell = new Spell("Special Counterspell", 40);

            // Special Knowledge Spells
            public readonly Spell Healing = new Spell("Healing", 40);
            public readonly Spell Starfire = new Spell("Starfire", 35);
            public readonly Spell ShadowWings = new Spell("Shadow Wings", 25);
            public readonly Spell ShadowSlipping = new Spell("Shadow Slipping", 25);

            // TODO Rituals
        }

        public class MindSpells
        {
            // TODO Talents

            // General Knowledge Spells
            public readonly Spell ESP = new Spell("Extrasensory Perception", 40);
            public readonly Spell LimitedPrecognition = new Spell("Limited Precognition", 20);
            public readonly Spell MindCloak = new Spell("Mind Cloak", 30);
            public readonly Spell Empathy = new Spell("Empathy", 20);
            public readonly Spell Hypnotism = new Spell("Hypnotism", 40);
            public readonly Spell ControlAnimal = new Spell("Control Animal", 40);
            public readonly Spell ControlPerson = new Spell("Control Person", 30);

            // Special Knowledge Spells
            public readonly Spell MentalAttack = new Spell("Mental Attack", 25);
            public readonly Spell Telepathy = new Spell("Telepathy", 0);
            public readonly Spell Phantasm = new Spell("Phantasm", 0);
            public readonly Spell MolecularDisruption = new Spell("Molecular Disruption", 0);
            public readonly Spell MolecularRearrangement = new Spell("Molecular Rearrangement", 0);
            public readonly Spell ForceShield = new Spell("Force Shield", 40);
            public readonly Spell MentalHealing = new Spell("Healing", 40);
            public readonly Spell Invisibility = new Spell("Invisibility", 15);
            public readonly Spell Telekinesis = new Spell("Telekinesis", 25);
            public readonly Spell TelekineticRage = new Spell("Telekinetic Rage", 1);

            // TODO Rituals
        }
    }


    public static class WeaponLibrary
    {
        // Name, BaseChance, Weight, Use, MaxRank
        public static readonly Weapon Dagger = new Weapon("Dagger", 40, 10m / 16m, WeaponKind.Close & WeaponKind.Melee & WeaponKind.Ranged, 9);

        public static readonly Weapon Sap = new Weapon("Sap", 40, 1m, WeaponKind.Close & WeaponKind.Melee, 3);
        public static readonly Weapon Mattock = new Weapon("Mattock", 55, 6m, WeaponKind.Melee, 5);

        public static readonly Weapon Cane = new Weapon("Cane (Sap)", 40, 5, WeaponKind.Close & WeaponKind.Melee, 3);
        public static readonly Weapon Darts = new Weapon("Darts (10)", 40, 2, WeaponKind.Ranged, 10);
    }

    public static class SkillLibrary
    {
        public static readonly Skill Assassin = new Skill("Assassin");
        public static readonly Skill Alchemy = new Skill("Alchemy");
        public static readonly Skill Astrology = new Skill("Astrology");
        public static readonly Skill Beastmaster = new Skill("Beastmaster");

        public static readonly Skill Horsemanship = new Skill("Horsemanship");
        public static readonly Skill Stealth = new Skill("Stealth");

        public static readonly Skill Spy = new Skill("Spy");
    }
}
