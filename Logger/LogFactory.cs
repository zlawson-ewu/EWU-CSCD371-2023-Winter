namespace Logger;

public class LogFactory
{
    private string? _Path;

    public BaseLogger? CreateLogger(string className)
    {
        if (_Path is null)
        {
            return null;
        }
        return new FileLogger(_Path) { ClassName = className };
    }
    public void ConfigureFileLogger(string path)
    {
        _Path = path;
    }

    public BaseLogger CreateConsoleLogger(string className)
    {
        return new ConsoleLogger() { ClassName = className };
    }
}
