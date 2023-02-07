namespace Logger;
public interface ILogger
{
    public abstract static ILogger CreateLogger(
        string logSource, string filePath);
}
