namespace Logger;

public class LogFactory<TLogger> where TLogger : class, new()
{
    public string? FileName { get; set; }

    public TLogger CreateLogger(string className) =>
        FileName is null ? null : new TLogger();

    public void ConfigureFileLogger(string fileName) => FileName=fileName;
}
