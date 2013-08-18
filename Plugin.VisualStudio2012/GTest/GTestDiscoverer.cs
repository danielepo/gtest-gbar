using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Guitar.Lib;
using Guitar.Lib.GTest;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Plugin.VisualStudio2012.VisualStudio;

namespace Plugin.VisualStudio2012.GTest
{
    [FileExtension(".exe")]
    [DefaultExecutorUri(Plugin.VisualStudio2012.GTest.GTestExecutor.ExecutorUriString)]
    class GTestDiscoverer : ITestDiscoverer
    {
        public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger messageLogger,
                                  ITestCaseDiscoverySink discoverySink)
        {
            var settingsProvider =
                discoveryContext.RunSettings.GetSettings(VSTestSettings.SettingsName) as VSTestSettingsService;
            var settings = settingsProvider != null && settingsProvider.Settings != null
                               ? settingsProvider.Settings
                               : new VSTestSettings() {WorkingDirectory = @"C:\Source"};

            VSLogger logger = new VSLogger(messageLogger);

            foreach (var source in sources)
            {
                logger.Information(string.Format("Beginning test discovery on {0}", source));
                GTestExtractor extractor = new GTestExtractor(false);
                ITestSuite suite = extractor.ExtractFrom(source);

                foreach (var testCase in suite.TestCases)
                {
                    foreach (var test in testCase.Tests)
                    {
                        logger.Information(string.Format("Found test {0}", test.FullyQualifiedName));
                        discoverySink.SendTestCase(test.ToVSTest());

                        System.Threading.Thread.Sleep(0);
                    }
                }

                //ProcessStartInfo listTestsInfo = new ProcessStartInfo();
                //listTestsInfo.FileName = source;
                //listTestsInfo.Arguments = "--gtest_list_tests";
                //listTestsInfo.UseShellExecute = false;
                //listTestsInfo.CreateNoWindow = true;
                //listTestsInfo.RedirectStandardOutput = true;

                //Process listTestsProc = new Process();
                //listTestsProc.StartInfo = listTestsInfo;

                //logger.SendMessage(TestMessageLevel.Informational, string.Format("Beginning test discovery on {0}", source));
                //listTestsProc.Start();

                //listTestsProc.WaitForExit(5000);

                //ParseTests(listTestsProc.StandardOutput, discoverySink, logger, source);
            }
            
        }

        private void ParseTests(StreamReader standardOutput, ITestCaseDiscoverySink discoverySink, IMessageLogger logger, string source)
        {
            string testcase = "";
            bool testsStarted = false;
            Regex testCaseMatch = new Regex(@".*\.$");
            while (standardOutput.Peek() != -1)
            {
                string line = standardOutput.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    if (testCaseMatch.IsMatch(line))
                    {
                        testsStarted = true;
                        testcase = line.Trim();
                        logger.SendMessage(TestMessageLevel.Informational, string.Format("Found test case {0}", testcase.Trim('.')));
                    }
                    else if(testsStarted)
                    {
                        TestCase test = new TestCase(testcase + line.Trim(), Plugin.VisualStudio2012.GTest.GTestExecutor.ExecutorUri, source);
                        discoverySink.SendTestCase(test);
                        logger.SendMessage(TestMessageLevel.Informational, string.Format("Found test {0}", testcase + line.Trim()));
                    }
                }
            }
        }
    }
}
