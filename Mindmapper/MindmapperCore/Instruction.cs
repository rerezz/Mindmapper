using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// Abstract class for all instructions.
    /// </summary>
    internal abstract class Instruction : CodePart
    {
        /// <summary>
        /// Holds the instruction attributes by name.
        /// </summary>
        private Dictionary<string, InstructionAttribute> m_AttributesByName = new Dictionary<string,InstructionAttribute>();

        /// <summary>
        /// Holds the instruction attributes by position.
        /// </summary>
        private Dictionary<int, InstructionAttribute> m_AttributesByPosition = new Dictionary<int,InstructionAttribute>();

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="codeText">Original code for this code part.</param>
        public Instruction(string codeText)
            : base(codeText)
        {
            CreateAttributeList();
        }

        /// <summary>
        /// Add the given instruction to the attribute lists (by name and position)
        /// </summary>
        /// <param name="attribute">attribute </param>
        protected void AddAttribute(InstructionAttribute attribute)
        {
            m_AttributesByName.Add(attribute.AttributeName, attribute);
            m_AttributesByPosition.Add(attribute.AttributePosition, attribute);
        }

        /// <summary>
        /// Each instruction must create their attribute list.
        /// </summary>
        protected abstract void CreateAttributeList();


    }
}
