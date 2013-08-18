namespace Guitar.Lib
{
    public interface ITestSettings
    {
        string WorkingDirectory { get; }
        bool ShuffleTests { get; }
        bool RunDisabledTests { get; }
    }
}
