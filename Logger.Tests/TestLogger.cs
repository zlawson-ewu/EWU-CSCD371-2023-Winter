namespace Logger.Tests;

public class TestLogger : BaseLogger, ILogger, ILogger<TestLogger>, ILogger<TestLogger, TestLoggerFactory>
{
    public TestLogger(string logSource)
    {
        LogSource=logSource;
    }
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override string LogSource { get; }
    

    public TestLogger? Next { get; set; }

    static TestLogger Create(string logSource)
    {
        return new TestLogger(logSource);
    }

    public override void Log(LogLevel logLevel, string message)
    {
        LoggedMessages.Add((logLevel, message));
        Next?.Log(logLevel, message);
    }


}
