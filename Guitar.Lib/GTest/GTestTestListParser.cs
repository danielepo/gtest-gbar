using System.IO;
using System.Text.RegularExpressions;

namespace Guitar.Lib
{
    public class GTestTestListParser : ITestRunOutputParser
    {
        bool _testListingStarted = false;

        private readonly ITestSuite _suite;
        ITestCase _currentCase = null;
        private const string TestCaseRegex = @".*\.$";
        string _testRegex = @"\w{2}.*$";
        public GTestTestListParser(ITestSuite suite)
        {
            this._suite = suite;
        }

        public void ParseLine(string line)
        {
            if (line == null) return;
            if (!_testListingStarted && Regex.IsMatch(line, TestCaseRegex, RegexOptions.Singleline))
            {
                _testListingStarted = true;
                _currentCase = GTestTestFactory.BuildTestCase(_suite, line.TrimEnd('.').Trim());
                _suite.AddTestCase(_currentCase);
            }
            else
            {
                if (Regex.IsMatch(line, TestCaseRegex, RegexOptions.Singleline))
                {
                    _currentCase = GTestTestFactory.BuildTestCase(_suite, line.TrimEnd('.').Trim());
                    _suite.AddTestCase(_currentCase);
                }
                else if (_currentCase != null && line != string.Empty)
                {
                    string testName = line.Trim();
                    ITest test = GTestTestFactory.BuildTest(_currentCase, testName);
                    _currentCase.AddTest(test);
                }
            }
        }

        public event TestDiscoveredHandler TestDiscovered;
        public event TestStartedHandler TestStarted;
        public event TestCompletedHandler TestFinished;
    }
}
