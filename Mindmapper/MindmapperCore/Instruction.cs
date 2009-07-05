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
        /// Set an attribute value by attribute name
        /// </summary>
        /// <param name="attributeName">name of the attribute</param>
        /// <param name="attributeValue">string value of the attribute</param>
        public void SetAttributeValueByName(string attributeName, string attributeValue)
        {
            m_AttributesByName[attributeName].SetAttributeValue(attributeName);
        }

        /// <summary>
        /// Set an attribute value by position
        /// </summary>
        /// <param name="position">attribute position</param>
        /// <param name="attributeValue">string value of the attribute</param>
        public void SetAttributeValueByPosition(int position, string attributeValue)
        {
            m_AttributesByPosition[position].SetAttributeValue(attributeValue);
        }

        /// <summary>
        /// Gets the attribute value string from the attribute with the given name
        /// </summary>
        /// <param name="name">attribute name</param>
        /// <returns>attribute value string</returns>
        public string GetAttributeValue(string name)
        {
            return m_AttributesByName[name].AttributeValueString;
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

        /// <summary>
        /// Executes the instruction on the given mindmap structure.
        /// </summary>
        /// <param name="mindmap">mindmap datastructure</param>
        public abstract void ExecuteInstruction(Mindmap mindmap);
    }
}
