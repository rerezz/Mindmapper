using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore.InstructionAttributes
{
    internal class StringAttribute:InstructionAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="attributeName">name of the attribute</param>
        /// <param name="attributePosition">position in the instruction attributelist</param>
        public StringAttribute(string attributeName, int attributePosition)
            : base(attributeName,attributePosition)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="attributeName">name of the attribute</param>
        /// <param name="attributePosition">position in the instruction attributelist</param>
        /// <param name="attributePosition">initial value for attribute</param>
        public StringAttribute(string attributeName, int attributePosition, string defaultValue)
            : base(attributeName, attributePosition, defaultValue)
        {
        }

        /// <summary>
        /// The string attribute don't have to convert the value.
        /// </summary>
        /// <param name="attributeValueString">value as string</param>
        protected override void ConvertAndSaveValue(string attributeValueString)
        {
            this.AttributeValueString = attributeValueString;
        }

        /// <summary>
        /// Sets the default value of the name attribute
        /// </summary>
        protected override void SetDefaultValue()
        {
            AttributeValueString = "null";
        }
    }
}
