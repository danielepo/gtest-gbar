using System.Collections.Generic;
using Guitar.Lib;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using TestResult = Microsoft.VisualStudio.TestPlatform.ObjectModel.TestResult;

namespace Plugin.VisualStudio2012.VisualStudio
{
    class VSTracker : ITestTracker
    {
        private readonly IFrameworkHandle _frameworkHandle;
        private Dictionary<string, TestCase> _expectedTests;

        public VSTracker(IFrameworkHandle frameworkHandle, ITestSuite suite)
        {
            _frameworkHandle = frameworkHandle;

            _expectedTests = new Dictionary<string, TestCase>();
            foreach (var testCase in suite.TestCases)
            {
                foreach (var test in testCase.Tests)
                {
                    _expectedTests.Add(createDictionaryKey(test), test.ToVSTest());
                }
            }
        }

        public void TestStarted(ITest test)
        {
            TestCase testToStart = _expectedTests[createDictionaryKey(test)];
            _frameworkHandle.RecordStart(testToStart);
        }

        public void TestCompleted(ITest test, Guitar.Lib.TestResult result)
        {
            TestOutcome outcome = TestOutcome.None;
            switch (result.Outcome)
            {
                case TestStatus.Passed:
                    outcome = TestOutcome.Passed;
                    break;
                case TestStatus.Failed:
                    outcome = TestOutcome.Failed;
                    break;
                case TestStatus.Ignored:
                    outcome = TestOutcome.Skipped;
                    break;
            }
            TestCase testToStart = _expectedTests[createDictionaryKey(test)];
            _frameworkHandle.RecordEnd(testToStart, outcome);

            TestResult testresult = new TestResult(testToStart) {ErrorMessage = result.Message, Outcome = outcome};
            _frameworkHandle.RecordResult(testresult);
        }

        private string createDictionaryKey(ITest test)
        {
            return test.Case.Suite.RunTarget + ":" + test.FullyQualifiedName;
        }
    }
}
