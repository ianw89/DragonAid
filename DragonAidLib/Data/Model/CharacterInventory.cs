using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterInventory : IEnumerable<Item>
    {
        private readonly List<Item> _items = new List<Item>();

        public decimal TotalWeight
        {
            get { return this.Sum(i => i.Weight); }
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
            _items.Add(item);
        }
    }
}