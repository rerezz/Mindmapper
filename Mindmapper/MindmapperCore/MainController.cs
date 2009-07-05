using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// Central controlling class.
    /// </summary>
    internal class MainController
    {
        private Mindmap m_Mindmap;
        private Parser m_Parser;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainController()
        {
            m_Mindmap = new Mindmap();
            m_Parser = new Parser();
        }

        /// <summary>
        /// Executes the given instruction
        /// </summary>
        /// <param name="instruction">instruction</param>
        public void ExecuteInstruction(string instruction)
        {
            Instruction actualInstruction = m_Parser.Parse(instruction);
            actualInstruction.ExecuteInstruction(m_Mindmap);
        }

    }
}
