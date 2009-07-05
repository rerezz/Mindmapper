using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// The mindmap class holds the mindmap datastructure.
    /// </summary>
    internal class Mindmap
    {
        private ItemList m_Items;
        private ItemConnectionList m_ItemConnections;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Mindmap()
        {
            m_Items = new ItemList();
            m_ItemConnections = new ItemConnectionList();
        }

        /// <summary>
        /// Add a mindmap item.
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="color">color of the item</param>
        public void AddItem(string name, string color)
        {
            m_Items.AddItem(name, color);
        }

        /// <summary>
        /// Removes the mindmap item with the given name.
        /// </summary>
        /// <param name="name"></param>
        public void RemoveItem(string name)
        {

        }
    }
}
