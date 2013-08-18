namespace Guitar.Lib
{
    public static class GTestTestFactory
    {
        public static ITest BuildTest(ITestCase testCase, string testName)
        {
            return new GTest.GTest(testName, testCase);
        }

        public static ITestCase BuildTestCase(ITestSuite suite, string testCaseName)
        {
            return new TestCase(testCaseName, suite);
        }

        public static ITestSuite BuildTestSuite(string suiteName, string suiteFile)
        {
            return new GTestTestSuite(suiteName, suiteFile);
        }
    }
}
