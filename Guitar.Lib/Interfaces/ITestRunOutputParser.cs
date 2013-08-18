namespace Guitar.Lib
{
    public delegate void TestStartedHandler(ITest test);
    public delegate void TestCompletedHandler(ITest test, TestResult result);
    public delegate void TestDiscoveredHandler(ITest test);

    public interface ITestRunOutputParser
    {
        void ParseLine(string line);

        event TestDiscoveredHandler TestDiscovered;
        event TestStartedHandler TestStarted;
        event TestCompletedHandler TestFinished;
    }
}
