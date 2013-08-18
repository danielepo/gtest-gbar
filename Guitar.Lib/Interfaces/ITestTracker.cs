namespace Guitar.Lib
{
    public interface ITestTracker
    {
        void TestStarted(ITest test);
        void TestCompleted(ITest test, TestResult result);
    }
}
