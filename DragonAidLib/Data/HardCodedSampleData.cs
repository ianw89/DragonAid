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
                                { Weapons.Mattock, 1 },
                                { Weapons.Dagger, 2 },
                                { Weapons.WarHammer, 5 },
                                { Weapons.Morningstar, 0 },
                                { Weapons.Crossbow, 1 },
                            },
                        Skills =
                            {
                                { Skills.Courtesan, 3 },
                                { Skills.Alchemy, 0 },

                                { Skills.Climbing, 3 },
                                { Skills.Horsemanship, 3 },
                                { Skills.Stealth, 1 },
                                { Skills.Swimming, 1 },

                                // The following are binary skills (either you have it or you don't), so rank isn't applicable.
                                { Skills.CoupDeGras, 0 },
                                { Skills.CombatRotation, 0 }
                            },
                        Languages =
                            {
                                { Languages.Common, 8, 4 },
                                { Languages.BerensTongue, 8, 0 },
                                { Languages.Lutherian, 0, null }
                            },
                        Inventory =
                            {
                                { Items.Mattock, "Combat", "OverlandFoot" },
                                { Items.Crossbow, "Combat", "OverlandFoot" },
                                { Items.Dagger, "Combat", "OverlandFoot" },
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
                                { Weapons.Sap, 3 },
                                { Weapons.Dagger, 0 },
                            }
                            ,
                        Inventory = 
                            {
                                { new Armor("Cloth armor (improved)", 0, 6), "Combat", "OverlandFoot" },
                                { Items.Sap, "Combat", "OverlandFoot" },
                                { Items.Sap, "Combat", "OverlandFoot" },
                                { Items.Dagger, "Combat", "OverlandFoot" },

                                { new Item("Adventuring pack", 23), "OverlandFoot" },
                                { new Item("Money", 10), "OverlandFoot" },
                                { new Item("2 weeks of supplies", 14), "OverlandFoot" },
                            },
                        Skills =
                            {
                                { Skills.Assassin, 3},     
                                { Skills.Horsemanship, 0},        
                                { Skills.Stealth, 2}        
                            },
                        Languages =
                            {
                                { Languages.Common, 8, null },
                                { Languages.BerensTongue, 8, null },
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
                                { Weapons.Whip, 2 },
                                { Weapons.Net, 2 },
                                { Weapons.Bola, 2 },
                            },
                        Skills =
                            {
                                { Skills.Beastmaster, 2 },

                                { Skills.Climbing, 3 },
                                { Skills.Horsemanship, 4 },
                                { Skills.Stealth, 0 },
                                { Skills.Swimming, 0 }
                            },
                        Languages =
                            {
                                { Languages.Common, 8, 4 },
                                { Languages.Hundschrei, 5, 1 },
                            },
                        Inventory =
                            {
                                { new Armor("Leather Armor", -1, 18), "Combat", "OverlandFoot" },
                                { Items.Whip, "Combat", "OverlandFoot" },
                                { Items.Net, "Combat", "OverlandFoot" },
                                { Items.Bola, "Combat", "OverlandFoot" },
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
                                { Weapons.Cane, 3 },
                                { Weapons.Sap, 3 },
                                { Weapons.ThrowingDart, 2 },
                            },
                        Inventory = 
                            {
                                { new Armor("Cloth armor (improved)", 0, 6), "Combat", "OverlandFoot" },
                                { Items.Cane, "Combat", "OverlandFoot" },
                                { Items.Sap, "Combat", "OverlandFoot" },
                                { Items.Darts, "Combat", "OverlandFoot" },
                                
                                { new Item("Adventuring pack", 23), "OverlandFoot" },
                                { new Item("Money", 10), "OverlandFoot" },
                                { new Item("2 weeks of supplies", 14), "OverlandFoot" },
                            },
                        Skills =
                            {
                                { Skills.Assassin, 3},     
                                { Skills.Spy, 1},        
                                { Skills.Stealth, 1}        
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
}
