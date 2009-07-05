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
            this.AddAttribute(new StringAttribute("name", 1));
            this.AddAttribute(new StringAttribute("color", 2));
        }

        /// <summary>
        /// Adds a new element to the given mindmap datastructure.
        /// </summary>
        /// <param name="mindmap">mindmap datastructure</param>
        public override void ExecuteInstruction(Mindmap mindmap)
        {
            mindmap.AddItem(this.GetAttributeValue("name"), this.GetAttributeValue("color"));
        }
    }
}
