using Guitar.Lib;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Plugin.VisualStudio2012.VisualStudio
{
    static class TestExtensions
    {
        public static TestCase ToVSTest(this ITest test)
        {
            return new TestCase(test.FullyQualifiedName, GTest.GTestExecutor.ExecutorUri, test.Case.Suite.RunTarget);
        }
    }
}
