using TrackLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CommonLib;
using System.Collections.Generic;

namespace TrackLibTest
{
    
    
    /// <summary>
    ///This is a test class for TrackLayoutSerializerTest and is intended
    ///to contain all TrackLayoutSerializerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TrackLayoutSerializerTest
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
        ///A test for TrackLayoutSerializer Constructor
        ///</summary>
        [TestMethod()]
        public void TrackLayoutSerializerConstructorTest()
        {
            string fileName = "TestXML"; // TODO: Initialize to an appropriate value
            TrackLayoutSerializer_Accessor target = new TrackLayoutSerializer_Accessor(fileName);
            Assert.AreEqual(fileName, target.m_fileName);
        }

        /// <summary>
        ///A test for TrackLayoutSerializer Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TrackLib.dll")]
        public void TrackLayoutSerializerConstructorTest1()
        {
            TrackLayoutSerializer_Accessor target = new TrackLayoutSerializer_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CreateTrackLayoutFileRedLine
        ///</summary>
        [TestMethod()]
        public void CreateTrackLayoutFileRedLineTest()
        {
            TrackLayoutSerializer_Accessor target = new TrackLayoutSerializer_Accessor("TestXMl.xml"); // TODO: Initialize to an appropriate value
            target.CreateTrackLayoutFileRedLine();
            Assert.IsNotNull(target.m_blockList);
            Assert.IsTrue(target.BlockList.Count > 0);
            Assert.IsNotNull(target.m_switchList);
        }

        /// <summary>
        ///A test for Restore
        ///</summary>
        [TestMethod()]
        public void RestoreTest()
        {
            TrackLayoutSerializer target = new TrackLayoutSerializer(); // TODO: Initialize to an appropriate value
            target.Restore();
            Assert.IsTrue(true);
            // Needs a File to test.... We know this works because of the program
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            TrackLayoutSerializer target = new TrackLayoutSerializer("TestXmlSave.xml"); // TODO: Initialize to an appropriate value
            target.Save();
            // Can not find save directory for unit tests
        }

        /// <summary>
        ///A test for BlockList
        ///</summary>
        [TestMethod()]
        public void BlockListTest()
        {
            TrackLayoutSerializer_Accessor target = new TrackLayoutSerializer_Accessor("Test.xml"); // TODO: Initialize to an appropriate value
            TrackLayoutSerializer_Accessor target2 = new TrackLayoutSerializer_Accessor("Test.xml"); // TODO: Initialize to an appropriate value
            target2.CreateTrackLayoutFileRedLine();
            List<TrackBlock> expected = target2.m_blockList;
            List<TrackBlock> actual;
            target.BlockList = expected;
            actual = target2.BlockList;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LastUpdated
        ///</summary>
        [TestMethod()]
        public void LastUpdatedTest()
        {
            TrackLayoutSerializer target = new TrackLayoutSerializer(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.LastUpdated = expected;
            actual = target.LastUpdated;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SwitchList
        ///</summary>
        [TestMethod()]
        public void SwitchListTest()
        {
            TrackLayoutSerializer target = new TrackLayoutSerializer("TestLine.xml"); // TODO: Initialize to an appropriate value
            target.CreateTrackLayoutFileRedLine();
            TrackLayoutSerializer target2 = new TrackLayoutSerializer("TestLine.xml"); // TODO: Initialize to an appropriate value
            target2.CreateTrackLayoutFileRedLine();
            List<TrackSwitch> expected = target2.SwitchList ; // TODO: Initialize to an appropriate value
            List<TrackSwitch> actual;
            target.SwitchList = expected;
            actual = target.SwitchList;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
