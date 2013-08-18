using System.Collections.Generic;

namespace Guitar.Lib
{
    class TestCase : ITestCase
    {
        private List<ITest> tests; 
        public TestCase(string name, ITestSuite suite)
        {
            Suite = suite;
            Name = name;
            LastRunResult = new TestResult() {Message = "Not Run", Outcome = TestStatus.NotRun};
            tests = new List<ITest>();
        }

        public void AddTest(string test)
        {
            tests.Add(GTestTestFactory.BuildTest(this, test));
        }

        public TestResult LastRunResult { get; private set; }
        public string Name { get; private set; }
        public ITestSuite Suite { get; private set; }
        public ITest[] Tests { get { return tests.ToArray(); } }
        public TestResult LastResult { get; private set; }
        public void AddTest(ITest test)
        {
            tests.Add(test);
            test.TestCompleted += TestOnTestCompleted;
        }

        public event ResultUpdatedHandler ResultUpdated;

        protected virtual void OnResultUpdated(TestResult result)
        {
            ResultUpdatedHandler handler = ResultUpdated;
            if (handler != null) handler(this, result);
        }

        private void TestOnTestCompleted(ITest test, TestResult result)
        {
            TestStatus status = TestStatus.Passed;
            foreach (var test1 in Tests)
            {
                if (status == TestStatus.Passed)
                {
                    if (test1.LastResult.Outcome == TestStatus.Failed || test1.LastResult.Outcome == TestStatus.NotRun || test1.LastResult.Outcome == TestStatus.Ignored)
                    {
                        status = test1.LastResult.Outcome;
                    }
                }
            }

            LastRunResult = new TestResult() {Outcome = status};
            OnResultUpdated(LastRunResult);
        }
    }
}
