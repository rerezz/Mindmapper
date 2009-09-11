using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MindmapperCore.Resources;

namespace MindmapperCore
{
    /// <summary>
    /// Class to parse a production
    /// </summary>
    internal class Parser
    {
        /// <summary>
        /// Unparsed line of code.
        /// </summary>
        public string Production { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Parser()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="production">line of code</param>
        public Parser(string production)
        {
            Production = production;
        }

        public Instruction Parse(string production)
        {
            this.Production = production;
            return this.Parse();
        }

        /// <summary>
        /// Parse the line of code.
        /// </summary>
        /// <returns>Instruction class with attribute values</returns>
        public Instruction Parse()
        {
            CheckIllegalCharacters(Production);
            Production = RemoveIrrelevantSpaces(Production);
            List<string> splittedProduction = SplittProduction(Production);
            string[] attribute;

            Instruction currentInstruction = InstructionFactory.GetInstruction(splittedProduction[0]);

            // instruction at position 0
            if (currentInstruction.AttributeCountMin > splittedProduction.Count - 1
                || currentInstruction.AttributeCountMax < splittedProduction.Count - 1)
            {
                throw new SyntaxException(String.Format(Messages.ERROR_INVALID_ATTRIBUTE_COUNT,currentInstruction.GetAttributeListString()));
            }

            // set attributes (do not loop over the instruction at position 0)
            for (int i = 1; i < splittedProduction.Count; i++)
            {
                if (splittedProduction[i].Contains("="))
                {
                    attribute = splittedProduction[i].Split('=');
                    currentInstruction.SetAttributeValueByName(attribute[0], attribute[1]);
                }
                else
                {
                    currentInstruction.SetAttributeValueByPosition(i, splittedProduction[i]);
                }
            }
            
            return currentInstruction;
        }

        /// <summary>
        /// Removes irrelevant spaces from the production. (Ex. = Test -> =Test)
        /// </summary>
        /// <param name="production">Line of code</param>
        /// <returns>Modified line of code</returns>
        private static string RemoveIrrelevantSpaces(string production)
        {
            int length = 0;

            while (length != production.Length)
            {
                length = production.Length;

                production = production.Replace(" =", "=");
                production = production.Replace("= ", "=");
                production = production.Replace("  ", " ");
            }

            return production;
        }

        /// <summary>
        /// Splitts a string by the splitter char space.
        /// </summary>
        /// <param name="production">String to splitt</param>
        /// <returns>Splitted string as list</returns>
        private static List<string> SplittProduction(string production)
        {
            List<string> splittedProduction = new List<string>();

            splittedProduction.AddRange(production.Split(' ')); 

            return splittedProduction;
        }


        /// <summary>
        /// Checks if the production contains any illegal chars
        /// </summary>
        /// <param name="production">line of code</param>
        private void CheckIllegalCharacters(string production)
        {
            foreach (char chr in production)
            {
                if (!(char.IsLetterOrDigit(chr) || char.IsWhiteSpace(chr) || chr.Equals('=')))
                {
                    throw new SyntaxException(String.Format(Messages.ERROR_ILLEGAL_CHAR,chr));
                }
            }
        }

    }
}
