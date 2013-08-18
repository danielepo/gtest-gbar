using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Guitar.Lib
{
    public interface ITestSuite
    {
        string Name { get; }
        string RunTarget { get; }
        ITestCase[] TestCases { get; }

        void AddTestCase(ITestCase testCase);
        event ResultUpdatedHandler ResultUpdated;
    }
}
