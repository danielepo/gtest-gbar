using System;
using System.Collections.Generic;
using System.Text;
using Guitar.Lib.GTest;
using System.ComponentModel;

namespace Guitar.Lib.ViewModels
{
    public class RunRequestEventArgs : EventArgs
    {
        public object RunTarget { get; private set; }

        public RunRequestEventArgs(object runItem)
        {
            RunTarget = runItem;
        }
    }

    public class TestRunViewModel : INotifyPropertyChanged
    {
        private int _testsCompleted;
        private int _testCount;
        private int _failedTests;
        private int _passedTests;
        private int _ignoredTests;

        public const string TestsCompletedProperty = "TestsCompleted";
        public const string TestsFailedProperty = "TestsFailed";
        public const string TestsPassedProperty = "TestsPassed";
        public const string TestsIgnoredProperty = "TestsIgnored";
        public const string TestCountProperty = "TestCount";

        public IList<ITest> FailedTests { get; private set; }  

        public int TestsCompleted
        {
            get { return _testsCompleted; }
            private set { _testsCompleted = value; OnPropertyChanged(TestsCompletedProperty); }
        }

        public int TestCount
        {
            get { return _testCount; }
            private set { _testCount = value; OnPropertyChanged(TestCountProperty); }
        }

        public int TestsPassed
        {
            get { return _passedTests; }
            set { _passedTests = value; OnPropertyChanged(TestsPassedProperty); }
        }

        public int TestsFailed
        {
            get { return _failedTests; }
            private set { _failedTests = value; OnPropertyChanged(TestsFailedProperty); }
        }

        public int TestsIgnored
        {
            get { return _ignoredTests; }
            private set { _ignoredTests = value; OnPropertyChanged(TestsIgnoredProperty); }
        }

        public TestRunViewModel()
        {
            FailedTests = new List<ITest>();
        }

        public void RequestRun(ITest test, ITestLogger logger, ITestSettings settings)
        {
            TestCount = 1;
            TestsCompleted = 0;
            TestsFailed = 0;
            TestsIgnored = 0;
            TestsPassed = 0;
            GTestRunner runner = new GTestRunner(logger, settings);
            runner.TestCompleted += RunnerOnTestCompleted;
            runner.RunCompleted += RunnerOnRunCompleted;
            runner.Run(test);
        }

        public void RequestRun(ITestCase cCase, ITestLogger logger, ITestSettings settings)
        {
            TestCount = cCase.Tests.Length;
            TestsCompleted = 0;
            TestsFailed = 0;
            TestsIgnored = 0;
            TestsPassed = 0;
            GTestRunner runner = new GTestRunner(logger, settings);
            runner.TestCompleted += RunnerOnTestCompleted;
            runner.RunCompleted += RunnerOnRunCompleted;
            runner.Run(cCase);
        }

        public void RequestRun(ITestSuite suite, ITestLogger logger, ITestSettings settings)
        {
            int testCount = 0;
            foreach (var testCase in suite.TestCases)
            {
                testCount += testCase.Tests.Length;
            }
            TestCount = testCount;
            TestsCompleted = 0;
            TestsFailed = 0;
            TestsIgnored = 0;
            TestsPassed = 0;

            GTestRunner runner = new GTestRunner(logger, settings);
            runner.TestCompleted += RunnerOnTestCompleted;
            runner.RunCompleted += RunnerOnRunCompleted;
            runner.Run(suite);
        }

        private void RunnerOnRunCompleted(object sender, EventArgs eventArgs)
        {
            TestsCompleted = TestCount;
            if (sender is GTestRunner)
            {
                (sender as GTestRunner).TestCompleted -= RunnerOnTestCompleted;
                (sender as GTestRunner).RunCompleted -= RunnerOnRunCompleted;
            }
        }

        private void RunnerOnTestCompleted(ITest test, TestResult result)
        {
            TestsCompleted++;
            if (result.Outcome == TestStatus.Failed)
            {
                TestsFailed++;
                FailedTests.Add(test);
            }
            else if (result.Outcome == TestStatus.Ignored)
            {
                TestsIgnored++;
            }
            else if (result.Outcome == TestStatus.Passed)
            {
                TestsPassed++;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
