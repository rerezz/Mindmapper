using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MindmapperCore.InstructionAttributes;

namespace MindmapperCore.Instructions
{
    /// <summary>
    /// Instruction for creating a new Item without an initial connection.
    /// Example: mind Länder
    /// </summary>
    internal class MindInstruction : Instruction
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="codeText">Original code for this code part.</param>
        public MindInstruction(string codeText)
            : base(codeText)
        {
        }

        /// <summary>
        /// Creates the Attribute list for the mind Instruction
        /// </summary>
        protected override void CreateAttributeList()
        {
            this.AddAttribute(new StringAttribute("name", 1, Guid.NewGuid().ToString()));
            this.AddAttribute(new StringAttribute("caption", 2));
            this.AddAttribute(new StringAttribute("color", 3));
            this.AddAttribute(new StringAttribute("activation",4,"true"));
        }

        /// <summary>
        /// Adds an item to the given mindmap.
        /// </summary>
        /// <param name="mindmap">target mindmap</param>
        protected void AddMindMapItem(Mindmap mindmap)
        {
            mindmap.AddItem(this.GetAttributeValue("name"), this.GetAttributeValue("caption"), this.GetAttributeValue("color"));
        }

        /// <summary>
        /// Activates the item on the given mindmap if its required
        /// </summary>
        /// <param name="mindmap">target mindmap</param>
        protected void ActivateItem(Mindmap mindmap)
        { 
            // Don't activate the item when the users sets the activation attribute to false
            if (this.GetAttributeValue("activation") == "true")
            {
                mindmap.SetActiveItem(this.GetAttributeValue("name"));
            }
        }

        /// <summary>
        /// Adds a new element to the given mindmap datastructure.
        /// </summary>
        /// <param name="mindmap">mindmap datastructure</param>
        public override void ExecuteInstruction(Mindmap mindmap)
        {
            AddMindMapItem(mindmap);
            ActivateItem(mindmap);

        }
    }
}
