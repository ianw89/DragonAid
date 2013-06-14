using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace DragonAid.Lib.Data.Model
{
    /// <summary>
    /// Class that manages all the items a Character has.
    /// Enumerating it returns all of the items the character has.
    /// </summary>
    public class CharacterInventory : IEnumerable<Item>
    {
        private readonly List<Item> _items = new List<Item>();
        private readonly IDictionary<string, List<Item>> _itemSets = new Dictionary<string, List<Item>>();
        private Armor _armor;

        public decimal TotalWeight
        {
            get
            {
                return this.Sum(i => i.Weight);
            }
        }

        public Armor EquippedArmor
        {
            get
            {
                return this._armor;
            }

            set
            {
                if (value != null && !this._items.Contains(value))
                {
                    this._items.Add(value);
                }

                this._armor = value;
            }
        }

        public IDictionary<string, List<Item>> ItemSets
        {
            get { return this._itemSets; }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Item item, params string[] setNames)
        {
            Contract.Requires(item != null);
            _items.Add(item);

            foreach (var setName in setNames)
            {
                if (!this.ItemSets.ContainsKey(setName))
                {
                    this.ItemSets.Add(setName, new List<Item>());
                }

                this.ItemSets[setName].Add(item);
            }
        }
    }
}