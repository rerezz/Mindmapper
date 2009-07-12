using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace MindmapperCore
{
    /// <summary>
    /// Central controlling class.
    /// </summary>
    public class MainController
    {
        private Mindmap m_Mindmap;
        private Parser m_Parser;

        internal Mindmap Mindmap
        {
            get
            {
                return m_Mindmap;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainController(Canvas canvas)
        {
            m_Mindmap = new Mindmap();
            m_Mindmap.Attach(new MindmapObserver(m_Mindmap,new DisplayController(canvas)));
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
            m_Mindmap.Notify();
        }

    }
}
