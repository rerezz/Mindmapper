using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    internal class Item
    {
        private Dictionary<ConnectionDirections.Direction, ItemConnection> m_Connections;

        public string Name { get; private set; }
        public string Color { get; set; }
        public string Caption { get; set; }
        public Dictionary<ConnectionDirections.Direction, ItemConnection> Connections
        {
            get
            {
                return m_Connections;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">name of the item</param>
        public Item(string name)
        {
            this.Name = name;
            m_Connections = new Dictionary<ConnectionDirections.Direction, ItemConnection>();
        }

        /// <summary>
        /// Register the connection at the item
        /// </summary>
        /// <param name="direction">direction of the connection</param>
        /// <param name="connection">connection</param>
        public void AddConnection(ConnectionDirections.Direction direction, ItemConnection connection)
        {
            m_Connections.Add(direction, connection);
        }

        /// <summary>
        /// Releases all connections of the item
        /// </summary>
        public void ReleaseConnections()
        {
            m_Connections = null;
        }

        /// <summary>
        /// Releases the given connection from the item
        /// </summary>
        /// <param name="connection"></param>
        public void ReleaseConnectionFromItem(ConnectionDirections.Direction direction)
        {
            m_Connections.Remove(direction);
        }

        /// <summary>
        /// tostring gets the name of the item.
        /// </summary>
        /// <returns>item name</returns>
        public override string ToString()
        {
            return String.Format("{0}({1})", this.Name, this.Caption);
        }

    }
}