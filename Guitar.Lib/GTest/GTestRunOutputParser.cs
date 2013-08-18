using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Guitar.Lib.GTest
{
    /// <summary>
    /// Parses the output of a single source (executable) and registers test beginnings/endings with a given ITestTracker
    /// </summary>
    public class GTestRunOutputParser : ITestRunOutputParser
    {
        private readonly Dictionary<string, ITest> _expectedTests;
        private ITest _currentTest;
        private System.Text.StringBuilder _currentTestRun;
        private ITestLogger _logger;
        private const string RUN_REGEX = @"\[\s*RUN\s*\](.*)$";
        private const string FAIL_REGEX = @"\[\s*FAILED\s*\](.*?)(, where.*)?\(\d+\s*ms\)";
        private const string OK_REGEX = @"\[\s*OK\s*\](.*)\(\d+\s*ms\)";

        public GTestRunOutputParser(ITestSuite testSuite, ITestLogger logger)
        {
            _expectedTests = new Dictionary<string, ITest>();
            foreach (var testCase in testSuite.TestCases)
            {
                foreach (var test in testCase.Tests)
                {
                    _expectedTests.Add(GTestNameFormatter.GetRunName(test), test);
                }
            }

            _currentTestRun = new StringBuilder();
            _logger = logger;
        }

        public void ParseLine(string line)
        {
            if (line != null && !string.IsNullOrEmpty(line.Trim()))
            {
                _logger.Information(line);

                if (Regex.IsMatch(line, RUN_REGEX))
                {
                    string caseName = Regex.Match(line, RUN_REGEX).Groups[1].Value.Trim();
                    _currentTest = _expectedTests[line.Remove(0, 12).Trim()];
                    _currentTestRun = new StringBuilder();
                    OnTestStarted(_currentTest);
                } 
                else if (Regex.IsMatch(line, FAIL_REGEX))
                {
                    if (Regex.IsMatch(line, FAIL_REGEX))
                    {
                        string caseName = Regex.Match(line, FAIL_REGEX).Groups[1].Value.Trim();
                        ITest test = _expectedTests[caseName];

                        if (test != null)
                        {
                            OnTestFinished(test,
                                           new TestResult()
                                               {
                                                   Message = _currentTestRun.ToString(),
                                                   Outcome = TestStatus.Failed
                                               });
                        }
                    }
                }
                else if (Regex.IsMatch(line, OK_REGEX))
                {
                    string caseName = Regex.Match(line, OK_REGEX).Groups[1].Value.Trim();
                    ITest test = _expectedTests[caseName];

                    if (test != null)
                    {
                        OnTestFinished(test, new TestResult()
                                               {
                                                   Message = _currentTestRun.ToString(),
                                                   Outcome = TestStatus.Passed
                                               });
                    }
                } else if (_currentTest != null)
                {
                    _currentTestRun.Append(line);
                }
            }
        }

        public event TestDiscoveredHandler TestDiscovered;

        protected virtual void OnTestDiscovered(ITest test)
        {
            TestDiscoveredHandler handler = TestDiscovered;
            if (handler != null) handler(test);
        }

        public event TestStartedHandler TestStarted;

        protected virtual void OnTestStarted(ITest test)
        {
            TestStartedHandler handler = TestStarted;
            if (handler != null) handler(test);
        }

        public event TestCompletedHandler TestFinished;

        protected virtual void OnTestFinished(ITest test, TestResult result)
        {
            test.Completed(result);
            TestCompletedHandler handler = TestFinished;
            if (handler != null) handler(test, result);
        }
    }
}
