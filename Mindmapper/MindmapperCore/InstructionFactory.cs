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
    internal static class InstructionFactory
    {
        /// <summary>
        /// Tries to get the correct instruction for the given code text.
        /// </summary>
        /// <param name="codeText">Instruction code text</param>
        /// <returns>Instruction class</returns>
        public static Instruction GetInstruction(string codeText)
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

                case "north":
                    resultInstruction = new NorthInstruction(codeText);
                    break;

                case "south":
                    resultInstruction = new SouthInstruction(codeText);
                    break;

                case "east":
                    resultInstruction = new EastInstruction(codeText);
                    break;

                case "west":
                    resultInstruction = new WestInstruction(codeText);
                    break;

                case "northeast":
                    resultInstruction = new NorthEastInstruction(codeText);
                    break;

                case "northwest":
                    resultInstruction = new NorthWestInstruction(codeText);
                    break;

                case "southeast":
                    resultInstruction = new SouthEastInstruction(codeText);
                    break;

                case "southwest":
                    resultInstruction = new SouthWestInstruction(codeText);
                    break;

                case "center":
                    resultInstruction = new CenterInstruction(codeText);
                    break;

                default:
                    throw new SyntaxException(String.Format(Messages.ERROR_INVALID_INSTRUCTION,codeText));
            }

            return resultInstruction;
        }
    }
}
