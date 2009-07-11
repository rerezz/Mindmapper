using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// Holds all items from a mindmap
    /// </summary>
    internal class ItemList
    {
        /// <summary>
        /// Holds all items
        /// </summary>
        private Dictionary<string, Item> m_Items;

        /// <summary>
        /// Represents
        /// </summary>
        public Item ActiveItem { get; private set; }

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
        public void AddItem(string name, string caption, string color)
        {
            Item addingItem = new Item(name)
            {
                Caption = caption,
                Color = color
            };

            m_Items.Add(name, addingItem);
        }

        /// <summary>
        /// Remove and get the item for the given name.
        /// </summary>
        /// <param name="name">item name</param>
        /// <returns>removed item</returns>
        public Item RemoveItem(string name)
        {
            Item removedItem = m_Items[name];
            m_Items.Remove(name);
            return removedItem;
        }

        /// <summary>
        /// Sets the item with the given name as active item
        /// </summary>
        /// <param name="name">item name</param>
        public void SetActiveItem(string name)
        {
            ActiveItem = m_Items[name];
        }

        /// <summary>
        /// Gets an item by name
        /// </summary>
        /// <param name="name">item name</param>
        /// <returns>item</returns>
        public Item GetItem(string name)
        {
            return m_Items[name];
        }
    }
}