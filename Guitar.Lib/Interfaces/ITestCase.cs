using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Guitar.Lib
{
    public delegate void ResultUpdatedHandler(object sender, TestResult result);

    public interface ITestCase 
    {
        string Name { get; }
        ITestSuite Suite { get; }
        ITest[] Tests { get; }

        TestResult LastResult { get; }
        void AddTest(ITest test);

        event ResultUpdatedHandler ResultUpdated;
    }
}
