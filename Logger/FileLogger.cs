namespace Logger;

public class FileLogger : BaseLogger, ILogger, ILogger<FileLogger>, ILogger<FileLogger, FileLoggerFactory>
{
    public FileLogger(string logSource, string filePath)
    {
        LogSource = logSource;
        FilePath=filePath;
        File = new FileInfo(FilePath);
    }

    public override string LogSource { get; }
    public string FilePath { get; }
    public FileLogger? Next { get; set; }
    FileInfo File { get; }

    public static FileLogger CreateLogger(string logSource, string filePath) =>
        new FileLogger(logSource, filePath);


    public override void Log(LogLevel logLevel, string message)
    {
        using StreamWriter writer = File.AppendText();
        writer.WriteLine($"{ DateTime.Now },{LogSource},{logLevel},{message}");
    }
}
