using System;
using Guitar.Lib;
using Guitar.Lib.GTest;
using Moq;
using NUnit.Framework;
using TestStatus = Guitar.Lib.TestStatus;

namespace Guitar.Tests.GTest
{
    [TestFixture]
    class GTestOutputParserTests
    {
        private void CreateMockSuite(out ITestSuite suite)
        {
            Mock<ITest> mockTest = new Mock<ITest>();
            Mock<ITestCase> mockCase = new Mock<ITestCase>();
            Mock<ITestSuite> mockSuite = new Mock<ITestSuite>();

            mockTest.Setup(t => t.Case).Returns(mockCase.Object);
            mockTest.Setup(t => t.Completed(It.IsAny<TestResult>())).Raises(t => t.TestCompleted += null);
            mockTest.Setup(t => t.Name).Returns("Test");

            mockCase.Setup(cs => cs.Name).Returns("Test");
            mockCase.Setup(cs => cs.Suite).Returns(mockSuite.Object);
            mockCase.Setup(cs => cs.Tests).Returns(new[] {mockTest.Object});

            mockSuite.Setup(s => s.RunTarget).Returns("Test.exe");
            mockSuite.Setup(s => s.Name).Returns("TestSuite");
            mockSuite.Setup(s => s.TestCases).Returns(new[] {mockCase.Object});

            suite = mockSuite.Object;
        }

        private class ParserValidator
        {
            private GTestRunOutputParser _parser;

            public bool TestDiscovered { get; private set; }
            public bool TestStarted { get; private set; }
            public bool TestFinished { get; private set; }
            public TestResult FinishResult { get; private set; }

            public ParserValidator(GTestRunOutputParser parser)
            {
                _parser = parser;

                _parser.TestStarted += ParserOnTestStarted;
                _parser.TestDiscovered += ParserOnTestDiscovered;
                _parser.TestFinished += ParserOnTestFinished;

                TestDiscovered = false;
                TestStarted = false;
                TestFinished = false;
            }

            private void ParserOnTestDiscovered(ITest test)
            {
                TestDiscovered = true;
            }

            private void ParserOnTestStarted(ITest test)
            {
                TestStarted = true;
            }

            private void ParserOnTestFinished(ITest test, TestResult result)
            {
                TestFinished = true;
                FinishResult = result;
            }
        }

        [Test]
        public void ParseLine_RUN_RaisesTestStartedEvent()
        {
            ITestSuite suite;
            CreateMockSuite(out suite);
            var parserUnderTest = new GTestRunOutputParser(suite, new Mock<ITestLogger>().Object);
            ParserValidator validator = new ParserValidator(parserUnderTest);

            parserUnderTest.ParseLine("[ RUN      ] Test.Test");

            Assert.True(validator.TestStarted);
        }

        [Test]
        public void ParseLine_OK_RaisesFinishedEventWithPassedResult()
        {
            ITestSuite suite;
            CreateMockSuite(out suite);
            var parserUnderTest = new GTestRunOutputParser(suite, new Mock<ITestLogger>().Object);
            ParserValidator validator = new ParserValidator(parserUnderTest);

            parserUnderTest.ParseLine("[       OK ] Test.Test (10ms)");

            Assert.True(validator.TestFinished);
            Assert.NotNull(validator.FinishResult);
            Assert.AreEqual(TestStatus.Passed, validator.FinishResult.Outcome);
        }

        [Test]
        public void ParseLine_FAILED_RaisesFinishedEventWithFailedResult()
        {
            ITestSuite suite;
            CreateMockSuite(out suite);
            var parserUnderTest = new GTestRunOutputParser(suite, new Mock<ITestLogger>().Object);
            ParserValidator validator = new ParserValidator(parserUnderTest);

            parserUnderTest.ParseLine("[  FAILED  ] Test.Test (10ms)");

            Assert.True(validator.TestFinished);
            Assert.NotNull(validator.FinishResult);
            Assert.AreEqual(TestStatus.Failed, validator.FinishResult.Outcome);
        }

        [Test]
        public void ParseLine_FAILED_TestWithParams_RaisesFinishedEventWithFailedResult()
        {
            ITestSuite suite;
            CreateMockSuite(out suite);
            var parserUnderTest = new GTestRunOutputParser(suite, new Mock<ITestLogger>().Object);
            ParserValidator validator = new ParserValidator(parserUnderTest);

            parserUnderTest.ParseLine("[  FAILED  ] Test.Test, where GetParam() = \"Test\" (10 ms)");

            Assert.True(validator.TestFinished);
            Assert.NotNull(validator.FinishResult);
            Assert.AreEqual(TestStatus.Failed, validator.FinishResult.Outcome);
        }

        [Test]
        public void ParseLine_FAILED_EndResult_RaisesNoEvents()
        {
            ITestSuite suite;
            CreateMockSuite(out suite);
            var parserUnderTest = new GTestRunOutputParser(suite, new Mock<ITestLogger>().Object);
            ParserValidator validator = new ParserValidator(parserUnderTest);

            parserUnderTest.ParseLine("[  FAILED  ] 1 test, listed below:");
            parserUnderTest.ParseLine("[  FAILED  ] Test.Test");

            Assert.False(validator.TestDiscovered);
            Assert.False(validator.TestStarted);
            Assert.False(validator.TestFinished);
        }
    }
}
