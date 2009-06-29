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
            InstructionAttribute attribute = new StringAttribute("name", 1);
            


        }
    }
}
