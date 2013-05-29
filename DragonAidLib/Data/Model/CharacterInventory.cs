using System.Collections;
using System.Collections.Generic;

namespace DragonAid.Lib.Data.Model
{
    public class CharacterInventory : IEnumerable<Item>
    {
        private readonly List<Item> _items = new List<Item>();

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}