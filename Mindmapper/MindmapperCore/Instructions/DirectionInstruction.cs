using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore.Instructions
{
    /// <summary>
    /// Instruction for creating a new Item with an initial connection northerly of the active item
    /// </summary>
    internal abstract class DirectionInstruction:MindInstruction
    {
        protected abstract ConnectionDirections.Direction Direction{get;}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="codeText">Original code for this code part.</param>
        public DirectionInstruction(string codeText)
            : base(codeText)
        {
        }

        /// <summary>
        /// Create a new item in the north of the active item
        /// </summary>
        /// <param name="mindmap">target mindmap</param>
        public override void ExecuteInstruction(Mindmap mindmap)
        {
            AddMindMapItem(mindmap);
            CreateConnection(mindmap);
            ActivateItem(mindmap);
        }

        /// <summary>
        /// Creates a connection 
        /// </summary>
        /// <param name="mindmap"></param>
        private void CreateConnection(Mindmap mindmap)
        {
            mindmap.CreateConnection(this.GetAttributeValue("name"), Direction);
        }
    }
}
