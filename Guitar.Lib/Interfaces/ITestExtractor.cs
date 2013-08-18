namespace Guitar.Lib
{
    internal interface ITestExtractor
    {
        ITestSuite ExtractFrom(string file);
        event TestDiscoveredHandler TestDiscovered;
    }
}