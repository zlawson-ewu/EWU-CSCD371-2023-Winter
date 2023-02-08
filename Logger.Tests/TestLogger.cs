namespace Logger.Tests;

public class TestLogger : BaseLogger, ILogger<TestLogger>
{
    public TestLogger(string logSource)
    {
        LogSource=logSource;
    }
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override string LogSource { get; }

    public static TLogger CreateLogger<TLogger>(string logSource, string filePath)
    {
        throw new NotImplementedException();
    }

    static TestLogger Create(string logSource)
    {
        return new TestLogger(logSource);
    }

    public override void Log(LogLevel logLevel, string message)
    {
        LoggedMessages.Add((logLevel, message));
    }


}
