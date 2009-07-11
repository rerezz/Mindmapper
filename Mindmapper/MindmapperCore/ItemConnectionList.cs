using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// Holds all item connections of the mind map
    /// </summary>
    internal class ItemConnectionList
    {
        /// <summary>
        /// Holds all connections of the mind map
        /// </summary>
        private List<ItemConnection> m_ItemConnections;

        /// <summary>
        /// Constructor
        /// </summary>
        public ItemConnectionList()
        {
            m_ItemConnections = new List<ItemConnection>();
        }

        /// <summary>
        /// Adds the given connection to the list
        /// </summary>
        /// <param name="connection"></param>
        public void AddConnection(ItemConnection connection)
        {
            m_ItemConnections.Add(connection);
        }

        /// <summary>
        /// Removes the given connection from the list
        /// </summary>
        /// <param name="connection">connection to remove</param>
        public void RemoveConnection(ItemConnection connection)
        {
            m_ItemConnections.Remove(connection);
        }
    }
}