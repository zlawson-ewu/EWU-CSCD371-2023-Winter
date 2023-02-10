namespace Logger.Tests;

public class TestLoggerFactory : ILogFactory<TestLogger>
{

    public TestLogger CreateLogger(string logSource)
    {
        return new TestLogger(logSource);
    }
}