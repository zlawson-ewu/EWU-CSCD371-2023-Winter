namespace Logger;

public interface ILogger
{
    string LogSource { get;  }
    void Log(LogLevel logLevel, string message);
}

public interface ILogger<TLogger> : ILogger where TLogger: ILogger
{
    TLogger? Next { get; set; }

    
    //abstract static TLogger CreateLogger(
    //    string logSource);
}

public interface ILogger<TLogger, TLoggerFactory> : ILogger where TLogger : ILogger
{



    //abstract static TLogger CreateLogger(
    //    string logSource);
}

public interface ILoggerFactory<TLogger, TLoggerFactory> where TLogger : ILogger
{
    TLogger CreateLogger(string logSource);
}