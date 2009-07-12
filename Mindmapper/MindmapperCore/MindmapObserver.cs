using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// Class to observe the mindmap structure
    /// </summary>
    internal class MindmapObserver : Observer
    {
        private Mindmap m_Mindmap;
        private DisplayController m_DispayController;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mindmap">mindmap to observe</param>
        /// <param name="displayController">display controller</param>
        public MindmapObserver(Mindmap mindmap, DisplayController displayController)
        {
            m_Mindmap = mindmap;
            m_DispayController = displayController;
        }

        /// <summary>
        /// Observer update methode
        /// </summary>
        public override void Update()
        {
            m_DispayController.DisplayMindmap(m_Mindmap);
        }
    }
}
