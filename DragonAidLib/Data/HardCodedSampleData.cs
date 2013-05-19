using System;
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
                        Title = "Happinstance McGillity",
                        Description = "Big, mean, and ugly.",
                        ImageUri = null,
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
                        Fatigue = 23
                    },
                new Character
                    {
                        Id = 2,
                        Name = "Muscles",
                        Title = "Muscles Bufflyton",
                        Description = "Nazi Hunter. Unknown and at large.",
                        ImageUri = null,
                        PlayerName = "Dan",
                        Race = Race.Human,
                        IsMine = true,
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
                        Spells = GetMusclesSpells()
                    },
                new Character
                    {
                        Id = 3,
                        Name = "Orj",
                        Title = "Orjbortz Daborgleschnortz",
                        Description = "Falcon Lover of the ages.",
                        ImageUri = null,
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
                        ImageUri = null,
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
                        Fatigue = 21
                    },
                new Character
                    {
                        Id = 5,
                        Name = "Renee",
                        Title = "Renee Black",
                        Description = "A bag of secrets.",
                        ImageUri = null,
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
                new Character
                    {
                        Id = 9,
                        Name = "Pirate D",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 4",
                        IsMine = false,
                        PartyId = 2,
                    },
                new Character
                    {
                        Id = 10,
                        Name = "Pirate E",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 5",
                        IsMine = false,
                        PartyId = 2,
                    },
                new Character
                    {
                        Id = 11,
                        Name = "Pirate F",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 6",
                        IsMine = false,
                        PartyId = 2,
                    },
            };

        private static IDictionary<string, int> GetMusclesSpells()
        {
            var spells = new SortedDictionary<string, int>(StringComparer.OrdinalIgnoreCase)
                {
                    {"Walking Unseen", 6},
                    {"Shadow Wings", 1},
                    {"Healing", 3}
                };
            return spells;
        }

        public static readonly List<Party> SampleParties = new List<Party>
            {
                new Party
                    {
                        Id = 1,
                        Title = "Tuesday Night DragonQuest",
                        Description = "Casual weekly DragonQuest.",
                        GameMasterName = "Ian Williams",
                        ImageUri = "Assets\\MyCharacters.png"
                    },
                new Party
                    {
                        Id = 2,
                        Title = "The Land Of Moordoor",
                        Description = "Where the shadows (of sunken boats) lie",
                        GameMasterName = "Me",
                        ImageUri = "Assets\\MyCharacters.png"
                    }
            };
    }
}
