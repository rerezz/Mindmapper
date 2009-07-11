using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore.Instructions
{
    internal class SouthInstruction:DirectionInstruction
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="codeText">Original code for this code part.</param>
        public SouthInstruction(string codeText)
            : base(codeText)
        {
        }

        protected override ConnectionDirections.Direction Direction
        {
            get { return ConnectionDirections.Direction.South; }
        }
    }
}
