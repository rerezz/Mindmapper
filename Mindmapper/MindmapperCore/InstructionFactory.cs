using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MindmapperCore.Resources;
using MindmapperCore.Instructions;

namespace MindmapperCore
{
    /// <summary>
    /// Factory who gives the instruction for a given codeText
    /// </summary>
    internal class InstructionFactory
    {
        /// <summary>
        /// Tries to get the correct instruction for the given code text.
        /// </summary>
        /// <param name="codeText">Instruction code text</param>
        /// <returns>Instruction class</returns>
        public Instruction GetInstruction(string codeText)
        {
            Instruction resultInstruction = null;

            switch (codeText.ToLower())
            {
                case "mind":
                    resultInstruction = new MindInstruction(codeText);
                    break;

                case "forget":
                    resultInstruction = new ForgetInstruction(codeText);
                    break;

                default:
                    throw new SyntaxException(String.Format(Messages.ERROR_INVALID_INSTRUCTION,codeText));
            }

            return resultInstruction;
        }
    }
}
