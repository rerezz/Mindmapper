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
        public void AddItem(string name, string caption, string color)
        {
            m_Items.AddItem(name, caption, color);
        }

        /// <summary>
        /// Sets the item with the given name as active.
        /// </summary>
        /// <param name="itemName">name of the item</param>
        public void SetActiveItem(string itemName)
        {
            m_Items.SetActiveItem(itemName);
        }

        /// <summary>
        /// Creates a new connection from the active item to the given item
        /// </summary>
        /// <param name="itemName">name of the given item</param>
        /// <param name="direction">direction where the given item should be placed</param>
        public void CreateConnection(string itemName, ConnectionDirections.Direction direction)
        {
            Item itemOne = m_Items.ActiveItem;
            Item itemTwo = m_Items.GetItem(itemName);
            ConnectionDirections.Direction oppositDirection = ConnectionDirections.GetOppositeDirection(direction);
            ItemConnection newConnection = new ItemConnection(itemOne, itemTwo);
            m_ItemConnections.AddConnection(newConnection);
            itemOne.AddConnection(direction, newConnection);
            itemTwo.AddConnection(oppositDirection, newConnection);
        }

        /// <summary>
        /// Removes the mindmap item with the given name.
        /// </summary>
        /// <param name="name"></param>
        public void RemoveItem(string name)
        {
            Item removedItem = m_Items.RemoveItem(name);
            foreach (KeyValuePair<ConnectionDirections.Direction, ItemConnection> connection in removedItem.Connections)
            {
                connection.Value.ReleaseConnection(removedItem, connection.Key);
                m_ItemConnections.RemoveConnection(connection.Value);
            }
            removedItem.ReleaseConnections();
            
        }




    }
}
