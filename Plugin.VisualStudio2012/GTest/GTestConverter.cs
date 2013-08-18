using System.Collections.Generic;
using Guitar.Lib;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Plugin.VisualStudio2012.GTest
{
    class GTestConverter
    {
        public ITestSuite[] ConvertToGTest(TestCase[] cases, ITestLogger logger)
        {
            logger.Information("Converting Visual Studio TestCases to TestSuite");
            Dictionary<string, ITestSuite> testSuites = new Dictionary<string, ITestSuite>();

            foreach (var testCase in cases)
            {
                logger.Information(string.Format("Processing TestCase {0}", testCase.FullyQualifiedName));
                if (!testSuites.ContainsKey(testCase.Source))
                {
                    logger.Information(string.Format("No existing source for {0}.  Creating one...", testCase.Source));
                    testSuites[testCase.Source] = GTestTestFactory.BuildTestSuite(testCase.Source, testCase.Source);
                }

                ITestSuite suite = testSuites[testCase.Source];

                string[] splits = testCase.FullyQualifiedName.Split('.');
                string caseName = splits[0];
                string testName = splits[1];

                logger.Information(string.Format("Searching for test case {0}...", caseName));

                ITestCase foundCase = null;
                foreach (var @case in suite.TestCases)
                {
                    if (@case.Name == caseName)
                    {
                        logger.Information(string.Format("Found test case {0}.", caseName));
                        foundCase = @case;
                    }
                }
                if (foundCase == null)
                {
                    logger.Information(string.Format("Did not find test case {0}.  Creating it now...", caseName));
                    foundCase = GTestTestFactory.BuildTestCase(suite, caseName);
                    suite.AddTestCase(foundCase);
                }

                logger.Information(string.Format("Adding test {0}...", testName));
                foundCase.AddTest(GTestTestFactory.BuildTest(foundCase, testName));
            }

            logger.Information("Preparing conversion result...");
            ITestSuite[] suites = new ITestSuite[testSuites.Count];
            int i = 0;

            foreach (var testSuite in testSuites)
            {
                suites[i++] = testSuite.Value;
            }

            logger.Information(string.Format("Conversion complete.  Converted {0} suites.", suites.Length));
            return suites;
        }
    }
}
