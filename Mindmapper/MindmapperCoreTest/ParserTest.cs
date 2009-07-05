using MindmapperCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MindmapperCoreTest
{
    /// <summary>
    ///This is a test class for ParserTest and is intended
    ///to contain all ParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParserTest
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
        ///A test for RemoveIrrelevantSpaces
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MindmapperCore.dll")]
        public void RemoveIrrelevantSpacesTest01()
        {
            string production = "mind name =    Länder";
            string expected = "mind name=Länder";
            string actual;
            actual = Parser_Accessor.RemoveIrrelevantSpaces(production);
            Assert.AreEqual(expected, actual, "invalid space replacement");
        }

        /// <summary>
        ///A test for SplittProduction
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MindmapperCore.dll")]
        public void SplittProductionTest01()
        {
            string production = "mind name=Länder color=Red size=5";
            string expected01 = "mind";
            string expected02 = "name=Länder";
            string expected03 = "color=Red";
            string expected04 = "size=5";

            List<string> actual;
            actual = Parser_Accessor.SplittProduction(production);

            string faildmsg = "invalid splitt";
            Assert.AreEqual(expected01, actual[0], faildmsg);
            Assert.AreEqual(expected02, actual[1], faildmsg);
            Assert.AreEqual(expected03, actual[2], faildmsg);
            Assert.AreEqual(expected04, actual[3], faildmsg);
        }

        /// <summary>
        ///A test for Parse (attribute by name)
        ///</summary>
        [TestMethod()]
        public void ParseTest01()
        {
            string production = "mind name=Länder color=Red"; // TODO: Initialize to an appropriate value
            Parser target = new Parser(production);

            Instruction actual;
            actual = target.Parse();
        }

        /// <summary>
        ///A test for Parse (attribute by position)
        ///</summary>
        [TestMethod()]
        public void ParseTest02()
        {
            string production = "mind Länder  Red"; // TODO: Initialize to an appropriate value
            Parser target = new Parser(production);

            Instruction actual;
            actual = target.Parse();
        }
    }
}
