using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    internal class Item
    {
        private Dictionary<Directions, ItemConnection> m_Connections;

        public string Name { public get; private set; }
        public string Color { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">name of the item</param>
        public Item(string name)
        {
            this.Name = name;
        }
    }
}