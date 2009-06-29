using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// Class to parse a production
    /// </summary>
    internal class Parser
    {
        /// <summary>
        /// Unparsed line of code.
        /// </summary>
        public string Production { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="production">line of code</param>
        public Parser(string production)
        {
            Production = production;
        }

        /// <summary>
        /// Parse the line of code.
        /// </summary>
        /// <returns>Instruction class with attribute values</returns>
        public Instruction Parse()
        {

        }


    }
}
