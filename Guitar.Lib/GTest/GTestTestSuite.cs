using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Guitar.Lib
{
    class GTestTestSuite : ITestSuite
    {
        public GTestTestSuite(string name, string assembly)
        {
            Name = name;
            RunName = "*";
            RunTarget = assembly;
            _testCases = new List<ITestCase>();
        }

        public string Name { get; private set; }
        public string RunName { get; private set; }
        public IEnumerable<ITest> Children { get; private set; }

        public TestResult LastRunResult { get; private set; }
        public void AddTestCase(ITestCase testCase)
        {
            _testCases.Add(testCase);
            testCase.ResultUpdated += TestCaseOnResultUpdated;
        }

        public event ResultUpdatedHandler ResultUpdated;

        protected virtual void OnResultUpdated(TestResult result)
        {
            ResultUpdatedHandler handler = ResultUpdated;
            if (handler != null) handler(this, result);
        }

        private void TestCaseOnResultUpdated(object sender, TestResult result)
        {
            TestStatus status = TestStatus.Passed;
            foreach (var case1 in TestCases)
            {
                if (status == TestStatus.Passed)
                {
                    if (case1.LastResult.Outcome == TestStatus.Failed || case1.LastResult.Outcome == TestStatus.NotRun || case1.LastResult.Outcome == TestStatus.Ignored)
                    {
                        status = case1.LastResult.Outcome;
                    }
                }
            }

            LastRunResult = new TestResult() { Outcome = status };
            OnResultUpdated(LastRunResult);
        }

        private List<ITestCase> _testCases;
        public string RunTarget { get; private set; }
        public ITestCase[] TestCases { get { return _testCases.ToArray(); } }
    }
}
