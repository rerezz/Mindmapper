using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// Holds all items from a mindmap
    /// </summary>
    public class ItemList
    {
        private Dictionary<string, Item> m_Items;
        private Item m_ActiveItem;

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemList()
        {
            m_Items = new Dictionary<string, Item>();
        }

        /// <summary>
        /// Add item and set item as active item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        public void AddItem(string name, string color)
        {
            Item addingItem = new Item(name)
            {
                Color = color
            };

            m_Items.Add(name, addingItem);
            m_ActiveItem = addingItem;
        }
    }
}