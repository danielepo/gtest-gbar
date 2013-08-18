using System;
using System.Collections.Generic;

namespace Guitar.Lib
{
    interface ITestRunner
    {
        void Run(ITestSuite testSuite);
        void Run(ITestCase testCase);
        void Run(IEnumerable<ITestCase> testCase);
        void Run(ITest test);
        void Run(IEnumerable<ITest> test);

        event TestCompletedHandler TestCompleted;
        event EventHandler RunCompleted;
    }
}
