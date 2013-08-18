using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Guitar.Lib;
using Guitar.Lib.GTest;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System.Linq;
using Plugin.VisualStudio2012.VisualStudio;

namespace Plugin.VisualStudio2012.GTest
{
    [ExtensionUri(GTestExecutor.ExecutorUriString)]
    public class GTestExecutor : ITestExecutor
    {
        public const string ExecutorUriString = "executor://gtestexecutor/v1";
        public static readonly Uri ExecutorUri = new Uri(GTestExecutor.ExecutorUriString);

        private readonly List<KeyValuePair<Process, GTestRunOutputParser>> _testProcesses;

        public GTestExecutor()
        {
            _testProcesses = new List<KeyValuePair<Process, GTestRunOutputParser>>();
        }

        public void RunTests(IEnumerable<TestCase> tests, IRunContext runContext, IFrameworkHandle frameworkHandle)
        {

            ITestLogger logger = new VSLogger(frameworkHandle);

            var settings = LoadSettings(runContext, logger);

            GTestConverter converter = new GTestConverter();
            ITestSuite[] suites = converter.ConvertToGTest(tests.ToArray(), logger);

            foreach (var suite in suites)
            {
                logger.Information(string.Format("Processing suite {0}...", suite.RunTarget));
                VSTracker tracker = new VSTracker(frameworkHandle, suite);
                GTestRunner runner = new GTestRunner(logger, settings, false);

                runner.TestCompleted += tracker.TestCompleted;
                logger.Information(string.Format("Running converted suite {0}...", suite.RunTarget));

                List<ITest> testsToRun = new List<ITest>();
                foreach(var cCase in suite.TestCases)
                {
                    foreach (var test in cCase.Tests)
                    {
                        testsToRun.Add(test);
                    }
                }
                runner.Run(testsToRun);
            }
        }

        public void RunTests(IEnumerable<string> sources, IRunContext runContext, IFrameworkHandle frameworkHandle)
        {
            VSLogger logger = new VSLogger(frameworkHandle);

            var settings = LoadSettings(runContext, logger);

            foreach (var source in sources)
            {
                logger.Information(string.Format("Attempting to run tests in {0}", source));

                GTestExtractor extractor = new GTestExtractor(false);
                ITestSuite suite = extractor.ExtractFrom(source);

                VSTracker tracker = new VSTracker(frameworkHandle, suite);
                GTestRunner runner = new GTestRunner(logger, settings, false);
                runner.TestCompleted += tracker.TestCompleted;

                runner.Run(suite);
            }
        }

        private VSTestSettings LoadSettings(IRunContext context, ITestLogger logger)
        {
            var settingsProvider =
                    context.RunSettings.GetSettings(VSTestSettings.SettingsName) as VSTestSettingsService;

            VSTestSettings settings;
            if (settingsProvider != null)
            {
                logger.Debug("Found settings.");
                settings = settingsProvider.Settings;
            }
            else
            {
                logger.Debug("No settings found. Using defaults.");
                settings = new VSTestSettings();
            }

            logger.Debug(string.Format("Working Directory: {0}", settings.WorkingDirectory));
            logger.Debug(string.Format("Run Disabled Tests: {0}", settings.RunDisabledTests));
            logger.Debug(string.Format("Shuffle Tests: {0}", settings.ShuffleTests));

            return settings;
        }

        public void Cancel()
        {
            foreach (var procPair in _testProcesses)
            {
                //procPair.Key.Kill();
                //procPair.Key.OutputDataReceived -= procPair.Value.DataReceivedEventHandler;
            }
        }
    }
}
