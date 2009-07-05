using MindmapperCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MindmapperCore.Resources;
using MindmapperCore.Instructions;

namespace MindmapperCoreTest
{
    
    
    /// <summary>
    ///This is a test class for InstructionFactoryTest and is intended
    ///to contain all InstructionFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InstructionFactoryTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        /// Test with empty instruction.
        /// </summary>
        [TestMethod()]
        public void GetInstructionTest01()
        {
            string codeText = string.Empty;
            Instruction actual;
            try
            {
                actual = InstructionFactory.GetInstruction(codeText);
            }
            catch (Exception exeption)
            {
                Assert.IsTrue(exeption is SyntaxException,"incorrect exeption type");
                Assert.AreEqual<string>(exeption.Message,String.Format(Messages.ERROR_INVALID_INSTRUCTION,codeText),"incorrect exeption message");
            }
        }

        /// <summary>
        /// Test with an invalid instruction.
        /// </summary>
        [TestMethod()]
        public void GetInstructionTest02()
        {
            string codeText = "invalidinstruction";
            Instruction actual;
            try
            {
                actual = InstructionFactory.GetInstruction(codeText);
            }
            catch (Exception exeption)
            {
                Assert.IsTrue(exeption is SyntaxException, "incorrect exeption type");
                Assert.AreEqual<string>(exeption.Message, String.Format(Messages.ERROR_INVALID_INSTRUCTION, codeText), "incorrect exeption message");
            }
        }

        /// <summary>
        /// Test for mind instruction.
        /// </summary>
        [TestMethod()]
        public void GetInstructionTest03()
        {
            string codeText = "mind";
            Instruction actual;

            actual = InstructionFactory.GetInstruction(codeText);

            Assert.IsTrue(actual is MindInstruction, "incorrect instruction type given");
        }

        /// <summary>
        /// Test for forget instruction.
        /// </summary>
        [TestMethod()]
        public void GetInstructionTest04()
        {
            string codeText = "forget";
            Instruction actual;

            actual = InstructionFactory.GetInstruction(codeText);

            Assert.IsTrue(actual is ForgetInstruction, "incorrect instruction type given");
        }
    }
}
