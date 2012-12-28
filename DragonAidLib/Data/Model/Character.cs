using Microsoft.WindowsAzure.MobileServices;

namespace DragonAidLib.Data.Model
{
    /// <summary>
    /// This base class just consists of those properties which are persisted to the backing service
    /// Secondary properties are provided by extension methods in DragonAid.Data.CharacterEquations
    /// 
    /// Most properties of a character (skills, inventory, etc) are just baked into the character table;
    /// it simplifies the MobileServices usage at the cost of losing the ability to query based on them
    /// (which we expect never to need)
    /// </summary>
    public sealed class Character
    {
        // *** RPG system agnostic properties
        public int Id { get; set; }
        /// <summary>
        /// Whether this is your character or someone else's
        /// </summary>
        /// <remarks>
        /// The Mobile Service deals with setting this appropriately based on its internal-only userId
        /// field - there is no database column for "IsMine".
        /// </remarks>
        public bool IsMine { get; set; }

        public string Name { get; set; }
        // This is purposefully unrelated to the userId used internally for server-side authorization
        public string PlayerName { get; set; }
        public string ImageUri { get; set; }
        public int PartyId { get; set; }

        // *** DragonQuest specific properties (may be refactored later)
        [DataMemberJsonConverter(ConverterType = typeof(RaceJsonConverter))]
        public Race Race { get; set; }

        public int PhysicalStrength { get; set; }
        public int ManualDexterity { get; set; }
        public int Agility { get; set; }
        public int Endurance { get; set; }
        public int MagicalAptitude { get; set; }
        public int Willpower { get; set; }
        public int Perception { get; set; }
        public int PhysicalBeauty { get; set; }
        public int Fatigue { get; set; }

        /* TODO
        [DataMemberJsonConverter(ConverterType = typeof(InventoryJsonConverter))]
        public Inventory Inventory { get; set; }

        [DataMemberJsonConverter(ConverterType = typeof(SkillsJsonConverter))]
        public IDictionary<string, int> Skills { get; set; }
        */
    }
}