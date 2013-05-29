using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterInventory : IEnumerable<Item>
    {
        private readonly List<Item> _items = new List<Item>();
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

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Item item)
        {
            Contract.Requires(item != null);
            _items.Add(item);
        }
    }
}