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
            if (m_ItemOne.Name == itemFrom.Name)
            {
                m_ItemTwo.ReleaseConnectionFromItem(ConnectionDirections.GetOppositeDirection(directionFrom));
            }
            else
            {
                m_ItemOne.ReleaseConnectionFromItem(ConnectionDirections.GetOppositeDirection(directionFrom));
            }
            m_ItemOne = null;
            m_ItemTwo = null;
        }
    }
}