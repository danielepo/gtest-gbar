namespace Guitar.Lib
{
    public enum TestStatus
    {
        NotRun,
        Passed,
        Failed,
        Ignored
    }

    public struct TestResult
    {
        public string Message;
        public TestStatus Outcome;
    }
}