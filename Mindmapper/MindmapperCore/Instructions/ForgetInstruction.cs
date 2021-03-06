﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MindmapperCore.InstructionAttributes;

namespace MindmapperCore.Instructions
{
    /// <summary>
    /// Instruction for delete an existing item.
    /// Example: forget Länder
    /// </summary>
    internal class ForgetInstruction : Instruction
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
        public ForgetInstruction(string codeText)
            : base(codeText)
        {
        }

        /// <summary>
        /// Creates the Attribute list for the forget Instruction
        /// </summary>
        protected override void CreateAttributeList()
        {
            this.AddAttribute(new StringAttribute("name", 1));

        }

        /// <summary>
        /// Removes an element from the given mindmap datastructure.
        /// </summary>
        /// <param name="mindmap">mindmap datastructure</param>
        public override void ExecuteInstruction(Mindmap mindmap)
        {
            mindmap.RemoveItem(this.GetAttributeValue("name"));
        }
    }
}
