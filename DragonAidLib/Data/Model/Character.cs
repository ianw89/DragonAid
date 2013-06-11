using System.Diagnostics.Contracts;

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
        private CharacterSkillRanks _skillRanks;
        private CharacterLanguageRanks _languageRanks;
        private CharacterInventory _inventory;

        public Character()
        {
            this._spellRanks = new CharacterSpellRanks(this);
            this._weaponRanks = new CharacterWeaponRanks(this);
            this._skillRanks = new CharacterSkillRanks(this);
            this._inventory = new CharacterInventory();
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

        // TODO: converter?
        public CharacterSpellRanks SpellRanks
        {
            get { return _spellRanks; }
            set
            {
                Contract.Requires(value != null);
                _spellRanks = value;
            }
        }

        public CharacterWeaponRanks WeaponRanks
        {
            get { return _weaponRanks; }
            set
            {
                Contract.Requires(value != null);
                _weaponRanks = value;
            }
        }

        public CharacterSkillRanks Skills
        {
            get { return _skillRanks; }
            set
            {
                Contract.Requires(value != null);
                _skillRanks = value;
            }
        }

        public CharacterLanguageRanks Languages
        {
            get { return _languageRanks; }
            set
            {
                Contract.Requires(value != null);
                _languageRanks = value;
            }
        }

        public CharacterInventory Inventory
        {
            get { return _inventory; }
            set
            {
                Contract.Requires(value != null);
                _inventory = value;
            }
        }

        public Armor EquippedArmor
        {
            get { return this.Inventory.EquippedArmor;  }
            set { this.Inventory.EquippedArmor = value; }
        }

    }
}