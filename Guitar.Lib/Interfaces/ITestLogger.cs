namespace Guitar.Lib
{
    public interface ITestLogger
    {
        void Error(string errorMessage);
        void Warning(string message);
        void Information(string message);
        void Debug(string message);
    }
}
