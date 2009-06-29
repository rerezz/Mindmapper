using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// Abstract class for all attributes.
    /// </summary>
    internal abstract class InstructionAttribute : CodePart
    {
        /// <summary>
        /// Name of the attribute.
        /// </summary>
        public string AttributeName { get; protected set; }

        /// <summary>
        /// Position of the attribute in the instruction attributelist.
        /// </summary>
        public int AttributePosition { get; protected set; } 


        /// <summary>
        /// String value of the attribute.
        /// </summary>
        protected string AttributeValueString { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="attributeName">name of the attribute</param>
        /// <param name="attributePosition">position in the instruction attributelist</param>
        public InstructionAttribute(string attributeName,int attributePosition)
            : base(attributeName)
        {
            AttributeName = attributeName;
            AttributePosition = attributePosition;
            SetDefaultValue();
        }

        /// <summary>
        /// Public method to set the value of an attribute.
        /// </summary>
        /// <param name="attributeValueString">value as string</param>
        public void SetAttributeValue(string attributeValueString)
        {
            ConvertAndSaveValue(attributeValueString);
        }

        /// <summary>
        /// Each attribute type must convert the value string in its type.
        /// </summary>
        /// <param name="attributeValueString">value as string</param>
        protected abstract void ConvertAndSaveValue(string attributeValueString);

        /// <summary>
        /// Each attribute type must have a default value.
        /// </summary>
        protected abstract void SetDefaultValue();
    }
}
