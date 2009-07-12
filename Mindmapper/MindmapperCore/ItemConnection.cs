using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    internal class ItemConnection
    {
        private Item m_ItemOne;
        private Item m_ItemTwo;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="itemOne">item one</param>
        /// <param name="itemTwo">item two</param>
        public ItemConnection(Item itemOne, Item itemTwo)
        {
            m_ItemOne = itemOne;
            m_ItemTwo = itemTwo;
        }

        /// <summary>
        /// Releases the connection and the other item
        /// </summary>
        /// <param name="itemFrom">item from with the deletion is executed.</param>
        public void ReleaseConnection(Item itemFrom,ConnectionDirections.Direction directionFrom)
        {
            GetOtherItem(itemFrom.Name).ReleaseConnectionFromItem(ConnectionDirections.GetOppositeDirection(directionFrom));

            m_ItemOne = null;
            m_ItemTwo = null;
        }

        /// <summary>
        /// Returns the other item from the connection
        /// </summary>
        /// <param name="name">name of one item</param>
        /// <returns>other item</returns>
        public Item GetOtherItem(string name)
        {
            if (m_ItemOne.Name == name)
            {
                return m_ItemTwo;
            }
            else
            {
                return m_ItemOne;
            }
        }

        public override string ToString()
        {
            return String.Format("Connection between {0} and {1}", m_ItemOne.ToString(), m_ItemTwo.ToString());
        }
    }
}