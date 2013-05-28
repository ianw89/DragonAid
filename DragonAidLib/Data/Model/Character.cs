#if INCLUDE_AZURE_BINDINGS
using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.MobileServices;
#endif
using System.Collections.Generic;

namespace DragonAid.Lib.Data.Model
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
        private CharacterSpellRanks _spellRanks;
        private CharacterWeaponRanks _weaponRanks;

        public Character()
        {
            this._spellRanks = new CharacterSpellRanks(this);
            this._weaponRanks = new CharacterWeaponRanks(this);
        }


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
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }
        public int PartyId { get; set; }

        // *** DragonQuest specific properties (may be refactored later)
#if INCLUDE_AZURE_BINDINGS
        [DataMemberJsonConverter(ConverterType = typeof(RaceJsonConverter))]
#endif
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

        // TODO: converter?
        public CharacterSpellRanks SpellRanks
        {
            get { return _spellRanks; }
            set
            {
#if !DRAGON_COMMANDER
                Contract.Requires(value != null);
#endif
                _spellRanks = value;
            }
        }

        public CharacterWeaponRanks WeaponRanks
        {
            get { return _weaponRanks; }
            set
            {
#if !DRAGON_COMMANDER
                Contract.Requires(value != null);
#endif
                _weaponRanks = value;
            }
        }
    }
}