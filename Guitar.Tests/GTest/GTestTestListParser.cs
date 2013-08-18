//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Guitar.GTest;
//using Guitar.Interfaces;
//using NUnit.Framework;

//namespace Guitar.Tests.GTest
//{
//    [TestFixture]
//    class GTestTestListParserTests
//    {
//        private string SimpleTestList = 
//            @"TestCase1.
//              TestName1
//              TestName2
//            TestCase2.
//              TestName";

//        private string GMockMainTestList =
//            @"Running main() from gmock_main.cc
//            TestCase1.
//              TestName1
//              TestName2
//            TestCase2.
//              TestName";

//        private GTestTestListParser CreateParserUnderTest()
//        {
//            return new GTestTestListParser();
//        }

//        [Test]
//        public void Parse_GivenSimpleTestList_Returns2TestCases()
//        {
//            GTestTestListParser parserUnderTest = CreateParserUnderTest();

//            var actual = parserUnderTest.Parse("", SimpleTestList);

//            Assert.AreEqual(2, actual.TestCases.Count());
//        }

//        [Test]
//        public void Parse_GivenSimpleTestList_TestCasesHaveExpectedNames()
//        {
//            string expectedTest1 = "TestCase1";
//            string expectedTest2 = "TestCase2";

//            GTestTestListParser parserUnderTest = CreateParserUnderTest();

//            var actual = parserUnderTest.Parse("", SimpleTestList);

//            Assert.AreEqual(expectedTest1, actual.TestCases.ElementAt(0).RunName);
//            Assert.AreEqual(expectedTest2, actual.TestCases.ElementAt(1).RunName);
//        }

//        [Test]
//        public void Parse_GivenSimpleTestList_TestCasesHaveCorrectNumberOfChildTests()
//        {
//            GTestTestListParser parserUnderTest = CreateParserUnderTest();

//            var actual = parserUnderTest.Parse("", SimpleTestList);

//            Assert.AreEqual(2, actual.TestCases.ElementAt(0).Tests.Count());
//            Assert.AreEqual(1, actual.TestCases.ElementAt(1).Tests.Count());
//        }

//        [Test]
//        public void Parse_GivenSimpleTestList_TestCasesHaveCorrectChildTestNames()
//        {
//            List<string> expectedTests1 = new List<string>(new[] { "TestCase1.TestName1", "TestCase1.TestName2" });
//            List<string> expectedTests2 = new List<string>(new[] { "TestCase2.TestName" });

//            GTestTestListParser parserUnderTest = CreateParserUnderTest();

//            var actual = parserUnderTest.Parse("", SimpleTestList);

//            int testIdx = 0;
//            foreach (string test in expectedTests1)
//            {
//                Assert.AreEqual(test, actual.TestCases.ElementAt(0).Tests.ElementAt(testIdx++).RunName);
//            }
//            testIdx = 0;
//            foreach (string test in expectedTests2)
//            {
//                Assert.AreEqual(test, actual.TestCases.ElementAt(1).Tests.ElementAt(testIdx++).RunName);
//            }
//        }

//        [Test]
//        public void Parse_GivenGMockMainTestList_Returns2TestCases()
//        {
//            GTestTestListParser parserUnderTest = CreateParserUnderTest();

//            var actual = parserUnderTest.Parse("", GMockMainTestList);

//            Assert.AreEqual(2, actual.TestCases.Count());
//        }
//    }
//}
