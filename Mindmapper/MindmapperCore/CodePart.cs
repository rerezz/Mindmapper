using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// Abstract class for all language elements.
    /// </summary>
    internal abstract class CodePart
    {
        /// <summary>
        /// Original part of the typed code.
        /// </summary>
        private string m_CodeText;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="codeText">Original code for this code part.</param>
        public CodePart(string codeText)
        {
            m_CodeText = codeText;
        }
    }
}
