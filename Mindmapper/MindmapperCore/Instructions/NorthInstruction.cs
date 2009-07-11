using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore.Instructions
{
    internal class NorthInstruction:DirectionInstruction
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="codeText">Original code for this code part.</param>
        public NorthInstruction(string codeText)
            : base(codeText)
        {
        }

        protected override ConnectionDirections.Direction Direction
        {
            get { return ConnectionDirections.Direction.North; }
        }
    }
}
