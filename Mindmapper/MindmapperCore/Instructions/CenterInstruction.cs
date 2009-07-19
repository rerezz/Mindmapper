using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MindmapperCore.InstructionAttributes;

namespace MindmapperCore.Instructions
{
    internal class CenterInstruction: Instruction
    {
        /// <summary>
        /// Minimal attribute count
        /// </summary>
        public override int AttributeCountMin
        {
            get { return 1; }
        }

        /// <summary>
        /// Maximal attribute count
        /// </summary>
        public override int AttributeCountMax
        {
            get { return 1; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="codeText">Original code for this code part.</param>
        public CenterInstruction(string codeText)
            : base(codeText)
        {
        }

        /// <summary>
        /// Creates the attribute list for the center instruction
        /// </summary>
        protected override void CreateAttributeList()
        {
            this.AddAttribute(new StringAttribute("name", 1));
        }

        public override void ExecuteInstruction(Mindmap mindmap)
        {
            mindmap.SetActiveItem(this.GetAttributeValue("name"));
        }
    }
}
